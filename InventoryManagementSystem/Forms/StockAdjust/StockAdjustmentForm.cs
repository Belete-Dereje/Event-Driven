using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.StockAdjust
{
    public partial class StockAdjustmentForm : Form
    {
        private readonly StockService stockService;

        public StockAdjustmentForm()
            : this(new StockService(new InMemoryDataStore()))
        {
        }

        public StockAdjustmentForm(StockService stockService)
        {
            this.stockService = stockService;
            InitializeComponent();
        }

        private void StockAdjustmentForm_Load(object sender, EventArgs e)
        {
            InitializeLookups();
            InitializeReasons();
            dateTimePicker.Value = DateTime.Today;
            increaseRadioButton.Checked = true;
            ResetForm();
            statusLabel.Text = "Select a product, choose increase or decrease, and enter a mandatory reason.";
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

        private void InitializeReasons()
        {
            reasonComboBox.Items.Clear();
            reasonComboBox.Items.Add(new ReasonItem(AdjustmentReason.Damaged, "Damaged"));
            reasonComboBox.Items.Add(new ReasonItem(AdjustmentReason.Expired, "Expired"));
            reasonComboBox.Items.Add(new ReasonItem(AdjustmentReason.Lost, "Lost"));
            reasonComboBox.Items.Add(new ReasonItem(AdjustmentReason.CountingCorrection, "Counting Correction"));
            reasonComboBox.Items.Add(new ReasonItem(AdjustmentReason.Returned, "Returned (Stock-out Return)"));
            reasonComboBox.SelectedIndex = -1;
        }

        private void ResetForm()
        {
            quantityTextBox.Clear();
            notesTextBox.Clear();
            reasonComboBox.SelectedIndex = -1;
            increaseRadioButton.Checked = true;
            validationLabel.Text = string.Empty;
            quantityTextBox.Focus();
        }

        private bool TryReadQuantity(out decimal quantity)
        {
            quantity = 0;
            string text = quantityTextBox.Text.Trim();

            if (text.Length == 0)
            {
                ShowValidationError("Quantity is required.");
                return false;
            }

            if (!decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out quantity))
            {
                ShowValidationError("Quantity must be a valid number.");
                return false;
            }

            if (quantity <= 0)
            {
                ShowValidationError("Quantity must be greater than zero.");
                return false;
            }

            return true;
        }

        private void ShowValidationError(string message)
        {
            validationLabel.Text = message;
            MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            quantityTextBox.Focus();
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

            if (reasonComboBox.SelectedItem == null)
            {
                validationLabel.Text = "A reason is required for every adjustment.";
                MessageBox.Show("A reason is required for every adjustment.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                reasonComboBox.Focus();
                return;
            }

            if (!TryReadQuantity(out decimal quantity))
            {
                return;
            }

            ProductItem productItem = (ProductItem)productComboBox.SelectedItem;
            ReasonItem reasonItem = (ReasonItem)reasonComboBox.SelectedItem;
            bool isIncrease = increaseRadioButton.Checked;

            string? errorMessage = stockService.Adjust(
                productItem.Id,
                quantity,
                isIncrease,
                reasonItem.Reason,
                dateTimePicker.Value,
                notesTextBox.Text);

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string direction = isIncrease ? "Increased by" : "Decreased by";
            MessageBox.Show(
                "Adjustment recorded. Quantity " + direction + " " + quantity.ToString("0.###") + " (" + reasonItem.Display + ").",
                "Adjustment Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            statusLabel.Text = "Adjustment recorded at " + DateTime.Now.ToShortTimeString() + ".";
            InitializeLookups();
            ResetForm();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            statusLabel.Text = "Form cleared.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StockAdjustmentForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private class ProductItem
        {
            public int Id { get; }
            public string Display { get; }

            public ProductItem(int id, string display)
            {
                Id = id;
                Display = display;
            }
        }

        private class ReasonItem
        {
            public AdjustmentReason Reason { get; }
            public string Display { get; }

            public ReasonItem(AdjustmentReason reason, string display)
            {
                Reason = reason;
                Display = display;
            }
        }
    }
}
