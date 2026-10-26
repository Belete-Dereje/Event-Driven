using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.StockOut
{
    public partial class StockOutForm : Form
    {
        private readonly StockService stockService;

        public StockOutForm()
            : this(new StockService(new InMemoryDataStore()))
        {
        }

        public StockOutForm(StockService stockService)
        {
            this.stockService = stockService;
            InitializeComponent();
        }

        private void StockOutForm_Load(object sender, EventArgs e)
        {
            InitializeLookups();
            dateTimePicker.Value = DateTime.Today;
            ResetForm();
            statusLabel.Text = "Select a product and enter stock issued details.";
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
        }

        private void ResetForm()
        {
            quantityTextBox.Clear();
            notesTextBox.Clear();
            validationLabel.Text = string.Empty;
            quantityTextBox.Focus();
        }

        private bool TryReadDecimal(TextBox textBox, string fieldName, out decimal value)
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
                if (value <= 0)
                {
                    validationLabel.Text = fieldName + " must be greater than zero.";
                    MessageBox.Show(fieldName + " must be greater than zero.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            if (!TryReadDecimal(quantityTextBox, "Quantity", out decimal quantity)) return;

            string? errorMessage = stockService.StockOut(productItem.Id, quantity, dateTimePicker.Value, notesTextBox.Text);
            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Stock issued successfully.", "Stock Out", MessageBoxButtons.OK, MessageBoxIcon.Information);
            statusLabel.Text = "Stock out recorded at " + DateTime.Now.ToShortTimeString() + ".";
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

        private void StockOutForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
