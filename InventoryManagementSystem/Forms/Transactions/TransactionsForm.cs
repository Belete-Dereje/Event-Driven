using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Transactions
{
    public partial class TransactionsForm : Form
    {
        private readonly TransactionService transactionService;
        private int sortColumn = 0;
        private bool sortAscending = false;

        public TransactionsForm()
            : this(new TransactionService(new InMemoryDataStore()))
        {
        }

        public TransactionsForm(TransactionService transactionService)
        {
            this.transactionService = transactionService;
            InitializeComponent();
        }

        private void TransactionsForm_Load(object sender, EventArgs e)
        {
            InitializeFilters();
            LoadTransactions();
            statusLabel.Text = "Ready. Filter transactions by type, date range, or product.";
        }

        private void InitializeFilters()
        {
            typeFilterComboBox.Items.Clear();
            typeFilterComboBox.Items.AddRange(new object[] { "All Types", "Opening", "Stock In", "Stock Out", "Adjustment" });
            typeFilterComboBox.SelectedIndex = 0;

            productFilterComboBox.DisplayMember = "Name";
            productFilterComboBox.ValueMember = "Id";
            productFilterComboBox.Items.Clear();
            productFilterComboBox.Items.Add(new Product { Id = 0, Name = "All Products" });

            foreach (Product product in transactionService.GetProductFilterList())
            {
                productFilterComboBox.Items.Add(product);
            }

            if (productFilterComboBox.Items.Count > 0)
            {
                productFilterComboBox.SelectedIndex = 0;
            }

            fromDatePicker.Value = DateTime.Today.AddMonths(-1);
            toDatePicker.Value = DateTime.Today;
        }

        private void LoadTransactions()
        {
            transactionsListView.BeginUpdate();
            transactionsListView.Items.Clear();

            TransactionType? typeFilter = null;
            if (typeFilterComboBox.SelectedIndex == 1) typeFilter = TransactionType.OpeningBalance;
            if (typeFilterComboBox.SelectedIndex == 2) typeFilter = TransactionType.StockIn;
            if (typeFilterComboBox.SelectedIndex == 3) typeFilter = TransactionType.StockOut;
            if (typeFilterComboBox.SelectedIndex == 4) typeFilter = TransactionType.Adjustment;

            int? productFilter = null;
            if (productFilterComboBox.SelectedItem is Product selectedProduct && selectedProduct.Id > 0)
            {
                productFilter = selectedProduct.Id;
            }

            List<TransactionListItem> transactions = transactionService.GetAll(
                fromDatePicker.Value,
                toDatePicker.Value,
                typeFilter,
                productFilter);

            foreach (TransactionListItem item in transactions)
            {
                ListViewItem row = new ListViewItem(item.Id.ToString());
                row.SubItems.Add(item.Date.ToString("dd MMM yyyy"));
                row.SubItems.Add(item.ProductName);
                row.SubItems.Add(item.TypeName);
                row.SubItems.Add(item.Quantity.ToString("0.###"));

                string amountText = "-";
                if (item.UnitCost > 0)
                {
                    amountText = item.UnitCost.ToString("N2");
                }
                else if (item.UnitPrice > 0)
                {
                    amountText = item.UnitPrice.ToString("N2");
                }
                row.SubItems.Add(amountText);

                row.SubItems.Add(item.Reason);
                row.SubItems.Add(item.Notes);
                row.Tag = item.Id;

                transactionsListView.Items.Add(row);
            }

            transactionsListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            transactionsListView.Sort();
            transactionsListView.EndUpdate();

            UpdateSortIndicator();
            countLabel.Text = "Total transactions: " + transactions.Count;
        }

        private void UpdateSortIndicator()
        {
            foreach (ColumnHeader column in transactionsListView.Columns)
            {
                column.Text = column.Text.Replace(" \u25B2", string.Empty).Replace(" \u25BC", string.Empty);
            }

            if (sortColumn >= 0 && sortColumn < transactionsListView.Columns.Count)
            {
                transactionsListView.Columns[sortColumn].Text += sortAscending ? " \u25B2" : " \u25BC";
            }
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            LoadTransactions();
            statusLabel.Text = "Filtered transactions loaded.";
        }

        private void clearFiltersButton_Click(object sender, EventArgs e)
        {
            typeFilterComboBox.SelectedIndex = 0;
            if (productFilterComboBox.Items.Count > 0)
            {
                productFilterComboBox.SelectedIndex = 0;
            }
            fromDatePicker.Value = DateTime.Today.AddMonths(-1);
            toDatePicker.Value = DateTime.Today;
            LoadTransactions();
            statusLabel.Text = "Filters reset.";
        }

        private void transactionsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortColumn = e.Column;
                sortAscending = true;
            }
            transactionsListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            transactionsListView.Sort();
            UpdateSortIndicator();
            statusLabel.Text = "Sorted by " + transactionsListView.Columns[sortColumn].Text.TrimEnd(' ', '\u25B2', '\u25BC') + ".";
        }

        private void transactionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (transactionsListView.SelectedItems.Count == 0)
            {
                return;
            }

            ListViewItem selected = transactionsListView.SelectedItems[0];
            statusLabel.Text = "Selected Transaction #" + selected.SubItems[0].Text + ": " + selected.SubItems[2].Text + " (" + selected.SubItems[3].Text + ", Qty: " + selected.SubItems[4].Text + ")";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadTransactions();
            statusLabel.Text = "Transaction list refreshed.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TransactionsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
