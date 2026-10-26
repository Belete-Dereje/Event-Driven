using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Reports
{
    public partial class ReportsForm : Form
    {
        private readonly ReportService reportService;

        public ReportsForm()
            : this(new ReportService(new InMemoryDataStore()))
        {
        }

        public ReportsForm(ReportService reportService)
        {
            this.reportService = reportService;
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            LoadInventoryReport();
            LoadLowStockReport();
            statusLabel.Text = "Reports generated from current in-memory data.";
        }

        private void LoadInventoryReport()
        {
            inventoryListView.BeginUpdate();
            inventoryListView.Items.Clear();
            decimal totalValue = 0;

            foreach (InventoryReportItem item in reportService.GetInventoryReport())
            {
                ListViewItem row = new ListViewItem(item.ProductCode);
                row.SubItems.Add(item.ProductName);
                row.SubItems.Add(item.CategoryName);
                row.SubItems.Add(item.Quantity.ToString("0.###"));
                row.SubItems.Add(item.Unit);
                row.SubItems.Add(item.PurchaseCost.ToString("N2"));
                row.SubItems.Add(item.SellingPrice.ToString("N2"));
                row.SubItems.Add(item.StockValue.ToString("N2"));
                row.SubItems.Add(item.MinimumStock.ToString("0.###"));
                row.SubItems.Add(item.Status);
                inventoryListView.Items.Add(row);
                totalValue += item.StockValue;
            }

            inventoryListView.EndUpdate();
            inventoryCountLabel.Text = "Items: " + inventoryListView.Items.Count + " | Total Stock Value (at cost): " + totalValue.ToString("N2");
        }

        private void LoadLowStockReport()
        {
            lowStockListView.BeginUpdate();
            lowStockListView.Items.Clear();

            foreach (InventoryManagementSystem.Models.LowStockItem item in reportService.GetLowStockReport())
            {
                ListViewItem row = new ListViewItem(item.Code);
                row.SubItems.Add(item.Name);
                row.SubItems.Add(item.Category);
                row.SubItems.Add(item.Quantity.ToString("0.###"));
                row.SubItems.Add(item.MinimumStock.ToString("0.###"));
                row.SubItems.Add(item.SuggestedReorder.ToString("0.###"));
                row.ForeColor = Color.FromArgb(192, 57, 43);
                lowStockListView.Items.Add(row);
            }

            lowStockListView.EndUpdate();
            lowStockCountLabel.Text = "Low stock items: " + lowStockListView.Items.Count;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadInventoryReport();
            LoadLowStockReport();
            statusLabel.Text = "Reports refreshed.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ReportsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
