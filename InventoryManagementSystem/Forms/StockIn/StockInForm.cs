using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.StockIn
{
    public partial class StockInForm : Form
    {
        private readonly StockService stockService;

        public StockInForm()
            : this(new StockService(new InMemoryDataStore()))
        {
        }

        public StockInForm(StockService stockService)
        {
            this.stockService = stockService;
            InitializeComponent();
        }

        private void StockInForm_Load(object sender, EventArgs e)
        {
            InitializeLookups();
            dateTimePicker.Value = DateTime.Today;
            ResetForm();
            statusLabel.Text = "Select a product and enter stock received details.";
        }

        private void InitializeLookups()
        {
            productComboBox.DisplayMember = "Display";
            productComboBox.ValueMember = "Id";
            productComboBox.Items.Clear();

            foreach (Product product in stockService.GetActiveProducts())
            {
                productComboBox.Items.Add(new ProductItem(product.Id, product.Code + " - " + product.Name + " (Qty: " + product.Quantity.ToString("0.###") + " " + product.Unit + ")"));
            }

            if (productComboBox.Items.Count > 0)
            {
                productComboBox.SelectedIndex = 0;
            }

            supplierComboBox.DisplayMember = "Name";
            supplierComboBox.Items.Clear();
            supplierComboBox.Items.Add(new Supplier { Id = 0, Name = "None" });
            foreach (Supplier supplier in stockService.GetSuppliers())
            {
                supplierComboBox.Items.Add(supplier);
            }
            supplierComboBox.SelectedIndex = 0;
        }

        private void ResetForm()
        {
            quantityTextBox.Clear();
            unitCostTextBox.Clear();
            notesTextBox.Clear();
            validationLabel.Text = string.Empty;
            quantityTextBox.Focus();
        }

        private bool TryReadDecimal(TextBox textBox, string fieldName, out decimal value, bool allowZero)
        {
            string text = textBox.Text.Trim();
            if (text.Length == 0)
            {
                value = 0;
                validationLabel.Text = fieldName + " is required.";
                MessageBox.Show(fieldName + " is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox.Focus();
                return false;
            }

            if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                if (!allowZero && value <= 0)
                {
                    validationLabel.Text = fieldName + " must be greater than zero.";
                    MessageBox.Show(fieldName + " must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                    return false;
                }
                if (value < 0)
                {
                    validationLabel.Text = fieldName + " cannot be negative.";
                    MessageBox.Show(fieldName + " cannot be negative.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                    return false;
                }
                return true;
            }

            validationLabel.Text = fieldName + " must be a valid number.";
            MessageBox.Show(fieldName + " must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox.Focus();
            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (productComboBox.SelectedItem == null)
            {
                validationLabel.Text = "Please select a product.";
                MessageBox.Show("Please select a product.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                productComboBox.Focus();
                return;
            }

            ProductItem productItem = (ProductItem)productComboBox.SelectedItem;
            if (!TryReadDecimal(quantityTextBox, "Quantity", out decimal quantity, false)) return;
            if (!TryReadDecimal(unitCostTextBox, "Unit cost", out decimal unitCost, true)) return;

            int? supplierId = null;
            if (supplierComboBox.SelectedItem is Supplier supplier && supplier.Id > 0)
            {
                supplierId = supplier.Id;
            }

            string? errorMessage = stockService.StockIn(productItem.Id, quantity, supplierId, unitCost, dateTimePicker.Value, notesTextBox.Text);
            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Stock received successfully.", "Stock In", MessageBoxButtons.OK, MessageBoxIcon.Information);
            statusLabel.Text = "Stock in recorded at " + DateTime.Now.ToShortTimeString() + ".";
            InitializeLookups();
            ResetForm();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            if (productComboBox.Items.Count > 0 && productComboBox.SelectedIndex < 0)
            {
                productComboBox.SelectedIndex = 0;
            }
            statusLabel.Text = "Form cleared.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private class ProductItem
        {
            public int Id { get; set; }
            public string Display { get; set; }
            public ProductItem(int id, string display)
            {
                Id = id;
                Display = display;
            }
        }

        private void StockInForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
