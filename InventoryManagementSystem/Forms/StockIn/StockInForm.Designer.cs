using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.StockIn
{
    partial class StockInForm
    {
        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            labelTitle = new Label();
            contentPanel = new Panel();
            notesGroupBox = new GroupBox();
            notesTextBox = new TextBox();
            detailsGroupBox = new GroupBox();
            supplierComboBox = new ComboBox();
            labelSupplier = new Label();
            unitCostTextBox = new TextBox();
            labelUnitCost = new Label();
            dateTimePicker = new DateTimePicker();
            labelDate = new Label();
            quantityTextBox = new TextBox();
            labelQuantity = new Label();
            productComboBox = new ComboBox();
            labelProduct = new Label();
            validationLabel = new Label();
            buttonsPanel = new Panel();
            closeButton = new Button();
            clearButton = new Button();
            saveButton = new Button();
            statusStripMain = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            notesGroupBox.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            buttonsPanel.SuspendLayout();
            statusStripMain.SuspendLayout();
            SuspendLayout();
            // header
            headerPanel.BackColor = Color.FromArgb(39, 174, 96);
            headerPanel.Controls.Add(labelTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Size = new Size(600, 56);
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Text = "Stock In - Receive Goods";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.Padding = new Padding(16, 0, 0, 0);
            // content
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Controls.Add(validationLabel);
            contentPanel.Controls.Add(notesGroupBox);
            contentPanel.Controls.Add(detailsGroupBox);
            contentPanel.Controls.Add(buttonsPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 56);
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(600, 404);
            // details
            detailsGroupBox.BackColor = Color.White;
            detailsGroupBox.Controls.Add(supplierComboBox);
            detailsGroupBox.Controls.Add(labelSupplier);
            detailsGroupBox.Controls.Add(unitCostTextBox);
            detailsGroupBox.Controls.Add(labelUnitCost);
            detailsGroupBox.Controls.Add(dateTimePicker);
            detailsGroupBox.Controls.Add(labelDate);
            detailsGroupBox.Controls.Add(quantityTextBox);
            detailsGroupBox.Controls.Add(labelQuantity);
            detailsGroupBox.Controls.Add(productComboBox);
            detailsGroupBox.Controls.Add(labelProduct);
            detailsGroupBox.Dock = DockStyle.Top;
            detailsGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            detailsGroupBox.Location = new Point(20, 20);
            detailsGroupBox.Size = new Size(540, 220);
            detailsGroupBox.Text = "Stock In Details";
            // labels/controls
            labelProduct.AutoSize = true;
            labelProduct.Font = new Font("Segoe UI", 9F);
            labelProduct.Location = new Point(16, 30);
            labelProduct.Text = "Product *";
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.Font = new Font("Segoe UI", 9F);
            productComboBox.Location = new Point(16, 50);
            productComboBox.Size = new Size(508, 23);
            labelDate.AutoSize = true;
            labelDate.Font = new Font("Segoe UI", 9F);
            labelDate.Location = new Point(16, 84);
            labelDate.Text = "Date";
            dateTimePicker.Font = new Font("Segoe UI", 9F);
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(16, 104);
            dateTimePicker.Size = new Size(160, 23);
            labelQuantity.AutoSize = true;
            labelQuantity.Font = new Font("Segoe UI", 9F);
            labelQuantity.Location = new Point(192, 84);
            labelQuantity.Text = "Quantity *";
            quantityTextBox.Font = new Font("Segoe UI", 9F);
            quantityTextBox.Location = new Point(192, 104);
            quantityTextBox.Size = new Size(160, 23);
            labelUnitCost.AutoSize = true;
            labelUnitCost.Font = new Font("Segoe UI", 9F);
            labelUnitCost.Location = new Point(368, 84);
            labelUnitCost.Text = "Unit Cost";
            unitCostTextBox.Font = new Font("Segoe UI", 9F);
            unitCostTextBox.Location = new Point(368, 104);
            unitCostTextBox.Size = new Size(156, 23);
            labelSupplier.AutoSize = true;
            labelSupplier.Font = new Font("Segoe UI", 9F);
            labelSupplier.Location = new Point(16, 140);
            labelSupplier.Text = "Supplier (optional)";
            supplierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierComboBox.Font = new Font("Segoe UI", 9F);
            supplierComboBox.Location = new Point(16, 160);
            supplierComboBox.Size = new Size(508, 23);
            // notes
            notesGroupBox.BackColor = Color.White;
            notesGroupBox.Controls.Add(notesTextBox);
            notesGroupBox.Dock = DockStyle.Top;
            notesGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            notesGroupBox.Location = new Point(20, 240);
            notesGroupBox.Size = new Size(540, 90);
            notesGroupBox.Text = "Notes";
            notesTextBox.Dock = DockStyle.Fill;
            notesTextBox.Font = new Font("Segoe UI", 9F);
            notesTextBox.Location = new Point(3, 19);
            notesTextBox.Multiline = true;
            notesTextBox.Size = new Size(534, 68);
            notesTextBox.ScrollBars = ScrollBars.Vertical;
            // validation
            validationLabel.Dock = DockStyle.Top;
            validationLabel.Font = new Font("Segoe UI", 9F);
            validationLabel.ForeColor = Color.FromArgb(192, 57, 43);
            validationLabel.Location = new Point(20, 330);
            validationLabel.Padding = new Padding(0, 6, 0, 0);
            validationLabel.Size = new Size(540, 24);
            // buttons
            buttonsPanel.Controls.Add(closeButton);
            buttonsPanel.Controls.Add(clearButton);
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.Location = new Point(20, 354);
            buttonsPanel.Size = new Size(540, 44);
            saveButton.BackColor = Color.FromArgb(39, 174, 96);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(0, 6);
            saveButton.Size = new Size(110, 32);
            saveButton.Text = "Save Stock In";
            saveButton.Click += saveButton_Click;
            clearButton.BackColor = Color.FromArgb(236, 239, 242);
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 9F);
            clearButton.Location = new Point(118, 6);
            clearButton.Size = new Size(80, 32);
            clearButton.Text = "Clear";
            clearButton.Click += clearButton_Click;
            closeButton.BackColor = Color.FromArgb(236, 239, 242);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 9F);
            closeButton.Location = new Point(206, 6);
            closeButton.Size = new Size(80, 32);
            closeButton.Text = "Close";
            closeButton.Click += closeButton_Click;
            // status
            statusStripMain.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStripMain.Location = new Point(0, 438);
            statusStripMain.Size = new Size(600, 22);
            statusLabel.Spring = true;
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 460);
            Controls.Add(contentPanel);
            Controls.Add(statusStripMain);
            Controls.Add(headerPanel);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StockInForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Stock In";
            Load += StockInForm_Load;
            KeyDown += StockInForm_KeyDown;
            headerPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            notesGroupBox.ResumeLayout(false);
            notesGroupBox.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            detailsGroupBox.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel headerPanel;
        private Label labelTitle;
        private Panel contentPanel;
        private GroupBox detailsGroupBox;
        private Label labelProduct;
        private ComboBox productComboBox;
        private Label labelDate;
        private DateTimePicker dateTimePicker;
        private Label labelQuantity;
        private TextBox quantityTextBox;
        private Label labelUnitCost;
        private TextBox unitCostTextBox;
        private Label labelSupplier;
        private ComboBox supplierComboBox;
        private GroupBox notesGroupBox;
        private TextBox notesTextBox;
        private Label validationLabel;
        private Panel buttonsPanel;
        private Button saveButton;
        private Button clearButton;
        private Button closeButton;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel statusLabel;
    }
}
