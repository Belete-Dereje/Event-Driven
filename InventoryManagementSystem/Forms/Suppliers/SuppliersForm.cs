using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Suppliers
{
    public partial class SuppliersForm : Form
    {
        private readonly SupplierService supplierService;
        private int selectedSupplierId;
        private bool isRefreshingList;
        private int sortColumn = 1;
        private bool sortAscending = true;

        public SuppliersForm()
            : this(new SupplierService(new InMemoryDataStore()))
        {
        }

        public SuppliersForm(SupplierService supplierService)
        {
            this.supplierService = supplierService;
            InitializeComponent();
        }

        private void SuppliersForm_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadSuppliers();
            statusLabel.Text = "Ready. Add a new supplier or select one to edit.";
        }

        private void SuppliersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void LoadSuppliers()
        {
            isRefreshingList = true;
            suppliersListView.BeginUpdate();
            suppliersListView.Items.Clear();

            List<Supplier> suppliers = supplierService.Search(searchTextBox.Text);

            foreach (Supplier supplier in suppliers)
            {
                ListViewItem row = new ListViewItem(supplier.Id.ToString());
                row.SubItems.Add(supplier.Name);
                row.SubItems.Add(supplier.ContactPerson);
                row.SubItems.Add(supplier.Phone);
                row.SubItems.Add(supplier.Email);
                row.SubItems.Add(supplierService.GetTransactionCount(supplier.Id).ToString());
                row.Tag = supplier.Id;
                suppliersListView.Items.Add(row);
            }

            suppliersListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            suppliersListView.Sort();
            suppliersListView.EndUpdate();
            isRefreshingList = false;

            UpdateSortIndicator();

            int totalSuppliers = supplierService.GetAll().Count;
            countLabel.Text = "Showing " + suppliers.Count + " of " + totalSuppliers + " suppliers";
            UpdateButtonStates();
        }

        private void UpdateSortIndicator()
        {
            foreach (ColumnHeader column in suppliersListView.Columns)
            {
                column.Text = column.Text.Replace(" \u25B2", string.Empty).Replace(" \u25BC", string.Empty);
            }

            if (sortColumn >= 0 && sortColumn < suppliersListView.Columns.Count)
            {
                suppliersListView.Columns[sortColumn].Text += sortAscending ? " \u25B2" : " \u25BC";
            }
        }

        private void ResetForm()
        {
            selectedSupplierId = 0;

            isRefreshingList = true;
            suppliersListView.SelectedItems.Clear();
            isRefreshingList = false;

            nameTextBox.Clear();
            contactTextBox.Clear();
            phoneTextBox.Clear();
            emailTextBox.Clear();
            addressTextBox.Clear();
            validationLabel.Text = string.Empty;
            UpdateButtonStates();
            nameTextBox.Focus();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedSupplierId > 0;
            deleteButton.Enabled = hasSelection;
            saveButton.Text = hasSelection ? "Update Supplier" : "Add Supplier";
        }

        private void SelectSupplierInList(int supplierId)
        {
            foreach (ListViewItem row in suppliersListView.Items)
            {
                if (row.Tag != null && (int)row.Tag == supplierId)
                {
                    row.Selected = true;
                    row.EnsureVisible();
                    return;
                }
            }
        }

        private void suppliersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRefreshingList)
            {
                return;
            }

            if (suppliersListView.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem row = suppliersListView.SelectedItems[0];

            if (row.Tag == null)
            {
                return;
            }

            int supplierId = (int)row.Tag;
            Supplier? supplier = supplierService.GetById(supplierId);

            if (supplier == null)
            {
                return;
            }

            selectedSupplierId = supplier.Id;
            nameTextBox.Text = supplier.Name;
            contactTextBox.Text = supplier.ContactPerson;
            phoneTextBox.Text = supplier.Phone;
            emailTextBox.Text = supplier.Email;
            addressTextBox.Text = supplier.Address;
            validationLabel.Text = string.Empty;
            UpdateButtonStates();
            statusLabel.Text = "Selected supplier: " + supplier.Name;
        }

        private void suppliersListView_ColumnClick(object sender, ColumnClickEventArgs e)
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

            suppliersListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            suppliersListView.Sort();
            UpdateSortIndicator();
            statusLabel.Text = "Sorted by " + suppliersListView.Columns[sortColumn].Text.TrimEnd(' ', '\u25B2', '\u25BC') + ".";
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSuppliers();

            if (selectedSupplierId > 0)
            {
                SelectSupplierInList(selectedSupplierId);
            }
        }

        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            searchTextBox.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            statusLabel.Text = "Enter the details for the new supplier.";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string supplierName = nameTextBox.Text;
            string contactPerson = contactTextBox.Text;
            string phone = phoneTextBox.Text;
            string email = emailTextBox.Text;
            string address = addressTextBox.Text;
            bool isNewSupplier = selectedSupplierId == 0;

            string? errorMessage;

            if (isNewSupplier)
            {
                errorMessage = supplierService.Add(supplierName, contactPerson, phone, email, address);
            }
            else
            {
                errorMessage = supplierService.Update(selectedSupplierId, supplierName, contactPerson, phone, email, address);
            }

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int supplierIdToSelect = selectedSupplierId;

            if (isNewSupplier)
            {
                Supplier? createdSupplier = supplierService.FindByName(supplierName);

                if (createdSupplier != null)
                {
                    supplierIdToSelect = createdSupplier.Id;
                }
            }

            if (searchTextBox.Text.Length > 0)
            {
                searchTextBox.Clear();
            }
            else
            {
                LoadSuppliers();
            }

            if (supplierIdToSelect > 0)
            {
                SelectSupplierInList(supplierIdToSelect);
            }
            else
            {
                ResetForm();
            }

            statusLabel.Text = isNewSupplier
                ? "Supplier added successfully."
                : "Supplier updated successfully.";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedSupplierId == 0)
            {
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Are you sure you want to delete the supplier \"" + nameTextBox.Text + "\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            string? errorMessage = supplierService.Delete(selectedSupplierId);

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Cannot Delete Supplier", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetForm();
            LoadSuppliers();
            statusLabel.Text = "Supplier deleted successfully.";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            int supplierIdToKeep = selectedSupplierId;
            LoadSuppliers();

            if (supplierIdToKeep > 0)
            {
                SelectSupplierInList(supplierIdToKeep);
            }

            statusLabel.Text = "Supplier list refreshed.";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            statusLabel.Text = "Changes cancelled.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
