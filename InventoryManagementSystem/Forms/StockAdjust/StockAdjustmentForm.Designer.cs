using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.StockAdjust
{
    partial class StockAdjustmentForm
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
            formPanel = new Panel();
            productGroupBox = new GroupBox();
            productComboBox = new ComboBox();
            productLabel = new Label();
            directionGroupBox = new GroupBox();
            increaseRadioButton = new RadioButton();
            decreaseRadioButton = new RadioButton();
            detailsGroupBox = new GroupBox();
            dateTimePicker = new DateTimePicker();
            reasonComboBox = new ComboBox();
            notesTextBox = new TextBox();
            quantityTextBox = new TextBox();
            quantityLabel = new Label();
            reasonLabel = new Label();
            notesLabel = new Label();
            dateLabel = new Label();
            validationLabel = new Label();
            buttonsPanel = new Panel();
            clearButton = new Button();
            saveButton = new Button();
            closeButton = new Button();
            bottomPanel = new Panel();
            statusLabel = new Label();
            headerPanel.SuspendLayout();
            formPanel.SuspendLayout();
            productGroupBox.SuspendLayout();
            directionGroupBox.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            buttonsPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            //
            // headerPanel
            //
            headerPanel.BackColor = Color.FromArgb(33, 97, 173);
            headerPanel.Controls.Add(labelTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Size = new Size(560, 44);
            //
            // labelTitle
            //
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Text = "Stock Adjustment";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            labelTitle.Padding = new Padding(16, 0, 0, 0);
            //
            // formPanel
            //
            formPanel.BackColor = Color.FromArgb(245, 247, 250);
            formPanel.Controls.Add(buttonsPanel);
            formPanel.Controls.Add(validationLabel);
            formPanel.Controls.Add(detailsGroupBox);
            formPanel.Controls.Add(directionGroupBox);
            formPanel.Controls.Add(productGroupBox);
            formPanel.Dock = DockStyle.Fill;
            formPanel.Padding = new Padding(16);
            //
            // productGroupBox
            //
            productGroupBox.BackColor = Color.White;
            productGroupBox.Controls.Add(productComboBox);
            productGroupBox.Controls.Add(productLabel);
            productGroupBox.Dock = DockStyle.Top;
            productGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            productGroupBox.Padding = new Padding(12);
            productGroupBox.Size = new Size(528, 76);
            productGroupBox.Text = "Product";
            //
            // productLabel
            //
            productLabel.AutoSize = true;
            productLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            productLabel.Location = new Point(12, 22);
            productLabel.Text = "Product (Code - Name, current quantity):";
            //
            // productComboBox
            //
            productComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            productComboBox.Font = new Font("Segoe UI", 9F);
            productComboBox.Location = new Point(12, 42);
            productComboBox.Size = new Size(480, 23);
            //
            // directionGroupBox
            //
            directionGroupBox.BackColor = Color.White;
            directionGroupBox.Controls.Add(increaseRadioButton);
            directionGroupBox.Controls.Add(decreaseRadioButton);
            directionGroupBox.Dock = DockStyle.Top;
            directionGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            directionGroupBox.Padding = new Padding(12);
            directionGroupBox.Size = new Size(528, 76);
            directionGroupBox.Text = "Adjustment Direction (mandatory reason required for both)";
            //
            // increaseRadioButton
            //
            increaseRadioButton.AutoSize = true;
            increaseRadioButton.Font = new Font("Segoe UI", 9F);
            increaseRadioButton.Location = new Point(16, 32);
            increaseRadioButton.Text = "Increase (+) - stock found, returned to supplier shelf";
            increaseRadioButton.UseVisualStyleBackColor = true;
            //
            // decreaseRadioButton
            //
            decreaseRadioButton.AutoSize = true;
            decreaseRadioButton.Font = new Font("Segoe UI", 9F);
            decreaseRadioButton.Location = new Point(260, 32);
            decreaseRadioButton.Text = "Decrease (-) - damaged, expired, lost";
            decreaseRadioButton.UseVisualStyleBackColor = true;
            //
            // detailsGroupBox
            //
            detailsGroupBox.BackColor = Color.White;
            detailsGroupBox.Controls.Add(dateTimePicker);
            detailsGroupBox.Controls.Add(reasonComboBox);
            detailsGroupBox.Controls.Add(notesTextBox);
            detailsGroupBox.Controls.Add(quantityTextBox);
            detailsGroupBox.Controls.Add(quantityLabel);
            detailsGroupBox.Controls.Add(reasonLabel);
            detailsGroupBox.Controls.Add(notesLabel);
            detailsGroupBox.Controls.Add(dateLabel);
            detailsGroupBox.Dock = DockStyle.Top;
            detailsGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            detailsGroupBox.Padding = new Padding(12);
            detailsGroupBox.Size = new Size(528, 178);
            detailsGroupBox.Text = "Adjustment Details";
            //
            // quantityLabel
            //
            quantityLabel.AutoSize = true;
            quantityLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            quantityLabel.Location = new Point(12, 24);
            quantityLabel.Text = "Quantity (greater than zero):";
            //
            // quantityTextBox
            //
            quantityTextBox.Font = new Font("Segoe UI", 9F);
            quantityTextBox.Location = new Point(190, 21);
            quantityTextBox.Size = new Size(140, 23);
            //
            // reasonLabel
            //
            reasonLabel.AutoSize = true;
            reasonLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            reasonLabel.Location = new Point(12, 56);
            reasonLabel.Text = "Reason (mandatory):";
            //
            // reasonComboBox
            //
            reasonComboBox.DisplayMember = "Display";
            reasonComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            reasonComboBox.Font = new Font("Segoe UI", 9F);
            reasonComboBox.Location = new Point(190, 51);
            reasonComboBox.Size = new Size(300, 23);
            //
            // dateLabel
            //
            dateLabel.AutoSize = true;
            dateLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            dateLabel.Location = new Point(12, 88);
            dateLabel.Text = "Date (not in the future):";
            //
            // dateTimePicker
            //
            dateTimePicker.Font = new Font("Segoe UI", 9F);
            dateTimePicker.Format = DateTimePickerFormat.Short;
            dateTimePicker.Location = new Point(190, 83);
            dateTimePicker.Size = new Size(160, 23);
            //
            // notesLabel
            //
            notesLabel.AutoSize = true;
            notesLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            notesLabel.Location = new Point(12, 120);
            notesLabel.Text = "Notes:";
            //
            // notesTextBox
            //
            notesTextBox.Font = new Font("Segoe UI", 9F);
            notesTextBox.Location = new Point(190, 117);
            notesTextBox.Multiline = true;
            notesTextBox.Size = new Size(300, 44);
            //
            // validationLabel
            //
            validationLabel.Dock = DockStyle.Top;
            validationLabel.Font = new Font("Segoe UI", 9F);
            validationLabel.ForeColor = Color.FromArgb(192, 57, 43);
            validationLabel.Size = new Size(528, 18);
            //
            // buttonsPanel
            //
            buttonsPanel.Controls.Add(saveButton);
            buttonsPanel.Controls.Add(clearButton);
            buttonsPanel.Controls.Add(closeButton);
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.Location = new Point(16, 320);
            buttonsPanel.Size = new Size(528, 44);
            //
            // saveButton
            //
            saveButton.BackColor = Color.FromArgb(39, 174, 96);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(0, 4);
            saveButton.Size = new Size(150, 36);
            saveButton.Text = "Save Adjustment";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            //
            // clearButton
            //
            clearButton.BackColor = Color.FromArgb(236, 239, 242);
            clearButton.FlatStyle = FlatStyle.Flat;
            clearButton.Font = new Font("Segoe UI", 9F);
            clearButton.Location = new Point(158, 4);
            clearButton.Size = new Size(90, 36);
            clearButton.Text = "Clear";
            clearButton.UseVisualStyleBackColor = false;
            clearButton.Click += clearButton_Click;
            //
            // closeButton
            //
            closeButton.BackColor = Color.FromArgb(236, 239, 242);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 9F);
            closeButton.Location = new Point(256, 4);
            closeButton.Size = new Size(90, 36);
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            //
            // bottomPanel
            //
            bottomPanel.Controls.Add(statusLabel);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Size = new Size(560, 26);
            //
            // statusLabel
            //
            statusLabel.Dock = DockStyle.Fill;
            statusLabel.Font = new Font("Segoe UI", 8.5F);
            statusLabel.ForeColor = Color.FromArgb(80, 90, 105);
            statusLabel.Text = "Ready.";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            statusLabel.Padding = new Padding(16, 4, 0, 0);
            //
            // StockAdjustmentForm
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(560, 420);
            Controls.Add(formPanel);
            Controls.Add(bottomPanel);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            KeyPreview = true;
            MinimizeBox = false;
            Name = "StockAdjustmentForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Stock Adjustment";
            Load += StockAdjustmentForm_Load;
            KeyDown += StockAdjustmentForm_KeyDown;
            headerPanel.ResumeLayout(false);
            formPanel.ResumeLayout(false);
            productGroupBox.ResumeLayout(false);
            productGroupBox.PerformLayout();
            directionGroupBox.ResumeLayout(false);
            directionGroupBox.PerformLayout();
            detailsGroupBox.ResumeLayout(false);
            detailsGroupBox.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel headerPanel;
        private Label labelTitle;
        private Panel formPanel;
        private GroupBox productGroupBox;
        private Label productLabel;
        private ComboBox productComboBox;
        private GroupBox directionGroupBox;
        private RadioButton increaseRadioButton;
        private RadioButton decreaseRadioButton;
        private GroupBox detailsGroupBox;
        private Label quantityLabel;
        private TextBox quantityTextBox;
        private Label reasonLabel;
        private ComboBox reasonComboBox;
        private Label dateLabel;
        private DateTimePicker dateTimePicker;
        private Label notesLabel;
        private TextBox notesTextBox;
        private Label validationLabel;
        private Panel buttonsPanel;
        private Button saveButton;
        private Button clearButton;
        private Button closeButton;
        private Panel bottomPanel;
        private Label statusLabel;
    }
}
