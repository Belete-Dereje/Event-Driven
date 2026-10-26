using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.Suppliers
{
    partial class SuppliersForm
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
            closeButton = new Button();
            labelFormSubtitle = new Label();
            labelFormTitle = new Label();
            contentPanel = new Panel();
            mainTable = new TableLayoutPanel();
            listGroupBox = new GroupBox();
            suppliersListView = new ListView();
            columnId = new ColumnHeader();
            columnName = new ColumnHeader();
            columnContact = new ColumnHeader();
            columnPhone = new ColumnHeader();
            columnEmail = new ColumnHeader();
            columnStockIns = new ColumnHeader();
            detailsGroupBox = new GroupBox();
            validationLabel = new Label();
            cancelButton = new Button();
            saveButton = new Button();
            hintLabel = new Label();
            addressTextBox = new TextBox();
            labelAddress = new Label();
            emailTextBox = new TextBox();
            labelEmail = new Label();
            phoneTextBox = new TextBox();
            labelPhone = new Label();
            contactTextBox = new TextBox();
            labelContact = new Label();
            nameTextBox = new TextBox();
            labelName = new Label();
            actionsPanel = new Panel();
            clearSearchButton = new Button();
            searchTextBox = new TextBox();
            refreshButton = new Button();
            deleteButton = new Button();
            addButton = new Button();
            statusStripMain = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            countLabel = new ToolStripStatusLabel();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            mainTable.SuspendLayout();
            listGroupBox.SuspendLayout();
            detailsGroupBox.SuspendLayout();
            actionsPanel.SuspendLayout();
            statusStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(30, 90, 160);
            headerPanel.Controls.Add(closeButton);
            headerPanel.Controls.Add(labelFormSubtitle);
            headerPanel.Controls.Add(labelFormTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1100, 52);
            headerPanel.TabIndex = 0;
            // 
            // closeButton
            // 
            closeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            closeButton.BackColor = Color.FromArgb(45, 110, 190);
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 125, 205);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.Font = new Font("Segoe UI", 9.5F);
            closeButton.ForeColor = Color.White;
            closeButton.Location = new Point(1000, 10);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(80, 30);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // labelFormSubtitle
            // 
            labelFormSubtitle.AutoSize = true;
            labelFormSubtitle.Font = new Font("Segoe UI", 8.5F);
            labelFormSubtitle.ForeColor = Color.FromArgb(210, 225, 245);
            labelFormSubtitle.Location = new Point(22, 30);
            labelFormSubtitle.Name = "labelFormSubtitle";
            labelFormSubtitle.Size = new Size(352, 15);
            labelFormSubtitle.TabIndex = 1;
            labelFormSubtitle.Text = "Add, view, edit, search and safely manage your supplier records";
            // 
            // labelFormTitle
            // 
            labelFormTitle.AutoSize = true;
            labelFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelFormTitle.ForeColor = Color.White;
            labelFormTitle.Location = new Point(20, 5);
            labelFormTitle.Name = "labelFormTitle";
            labelFormTitle.Size = new Size(210, 25);
            labelFormTitle.TabIndex = 0;
            labelFormTitle.Text = "Supplier Management";
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Controls.Add(mainTable);
            contentPanel.Controls.Add(actionsPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 52);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(16, 8, 16, 8);
            contentPanel.Size = new Size(1100, 584);
            contentPanel.TabIndex = 1;
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 2;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 420F));
            mainTable.Controls.Add(listGroupBox, 0, 0);
            mainTable.Controls.Add(detailsGroupBox, 1, 0);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(16, 60);
            mainTable.Name = "mainTable";
            mainTable.Padding = new Padding(0, 6, 0, 0);
            mainTable.RowCount = 1;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTable.Size = new Size(1068, 516);
            mainTable.TabIndex = 1;
            // 
            // listGroupBox
            // 
            listGroupBox.BackColor = Color.White;
            listGroupBox.Controls.Add(suppliersListView);
            listGroupBox.Dock = DockStyle.Fill;
            listGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            listGroupBox.Location = new Point(0, 8);
            listGroupBox.Margin = new Padding(0, 0, 8, 0);
            listGroupBox.Name = "listGroupBox";
            listGroupBox.Padding = new Padding(12);
            listGroupBox.Size = new Size(713, 484);
            listGroupBox.TabIndex = 0;
            listGroupBox.TabStop = false;
            listGroupBox.Text = "Supplier List";
            // 
            // suppliersListView
            // 
            suppliersListView.BackColor = Color.White;
            suppliersListView.BorderStyle = BorderStyle.FixedSingle;
            suppliersListView.Columns.AddRange(new ColumnHeader[] { columnId, columnName, columnContact, columnPhone, columnEmail, columnStockIns });
            suppliersListView.Dock = DockStyle.Fill;
            suppliersListView.Font = new Font("Segoe UI", 9.5F);
            suppliersListView.FullRowSelect = true;
            suppliersListView.GridLines = true;
            suppliersListView.HideSelection = false;
            suppliersListView.Location = new Point(12, 30);
            suppliersListView.MultiSelect = false;
            suppliersListView.Name = "suppliersListView";
            suppliersListView.Size = new Size(689, 442);
            suppliersListView.TabIndex = 0;
            suppliersListView.UseCompatibleStateImageBehavior = false;
            suppliersListView.View = View.Details;
            suppliersListView.SelectedIndexChanged += suppliersListView_SelectedIndexChanged;
            suppliersListView.ColumnClick += suppliersListView_ColumnClick;
            // 
            // columnId
            // 
            columnId.Text = "ID";
            columnId.TextAlign = HorizontalAlignment.Center;
            columnId.Width = 40;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 150;
            // 
            // columnContact
            // 
            columnContact.Text = "Contact Person";
            columnContact.Width = 120;
            // 
            // columnPhone
            // 
            columnPhone.Text = "Phone";
            columnPhone.Width = 110;
            // 
            // columnEmail
            // 
            columnEmail.Text = "Email";
            columnEmail.Width = 170;
            // 
            // columnStockIns
            // 
            columnStockIns.Text = "Stock-Ins";
            columnStockIns.TextAlign = HorizontalAlignment.Center;
            columnStockIns.Width = 65;
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.BackColor = Color.White;
            detailsGroupBox.Controls.Add(validationLabel);
            detailsGroupBox.Controls.Add(cancelButton);
            detailsGroupBox.Controls.Add(saveButton);
            detailsGroupBox.Controls.Add(hintLabel);
            detailsGroupBox.Controls.Add(addressTextBox);
            detailsGroupBox.Controls.Add(labelAddress);
            detailsGroupBox.Controls.Add(emailTextBox);
            detailsGroupBox.Controls.Add(labelEmail);
            detailsGroupBox.Controls.Add(phoneTextBox);
            detailsGroupBox.Controls.Add(labelPhone);
            detailsGroupBox.Controls.Add(contactTextBox);
            detailsGroupBox.Controls.Add(labelContact);
            detailsGroupBox.Controls.Add(nameTextBox);
            detailsGroupBox.Controls.Add(labelName);
            detailsGroupBox.Dock = DockStyle.Fill;
            detailsGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            detailsGroupBox.Location = new Point(622, 6);
            detailsGroupBox.Margin = new Padding(0);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Padding = new Padding(12);
            detailsGroupBox.Size = new Size(446, 510);
            detailsGroupBox.TabIndex = 1;
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Supplier Details";
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 9F);
            labelName.ForeColor = Color.FromArgb(70, 80, 95);
            labelName.Location = new Point(14, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(94, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Supplier Name *";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Segoe UI", 9.5F);
            nameTextBox.Location = new Point(14, 38);
            nameTextBox.MaxLength = 100;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(180, 23);
            nameTextBox.TabIndex = 1;
            // 
            // labelContact
            // 
            labelContact.AutoSize = true;
            labelContact.Font = new Font("Segoe UI", 9F);
            labelContact.ForeColor = Color.FromArgb(70, 80, 95);
            labelContact.Location = new Point(206, 20);
            labelContact.Name = "labelContact";
            labelContact.Size = new Size(90, 15);
            labelContact.TabIndex = 2;
            labelContact.Text = "Contact Person";
            // 
            // contactTextBox
            // 
            contactTextBox.Font = new Font("Segoe UI", 9.5F);
            contactTextBox.Location = new Point(206, 38);
            contactTextBox.MaxLength = 100;
            contactTextBox.Name = "contactTextBox";
            contactTextBox.Size = new Size(180, 23);
            contactTextBox.TabIndex = 3;
            // 
            // labelPhone
            // 
            labelPhone.AutoSize = true;
            labelPhone.Font = new Font("Segoe UI", 9F);
            labelPhone.ForeColor = Color.FromArgb(70, 80, 95);
            labelPhone.Location = new Point(14, 66);
            labelPhone.Name = "labelPhone";
            labelPhone.Size = new Size(41, 15);
            labelPhone.TabIndex = 4;
            labelPhone.Text = "Phone";
            // 
            // phoneTextBox
            // 
            phoneTextBox.Font = new Font("Segoe UI", 9.5F);
            phoneTextBox.Location = new Point(14, 84);
            phoneTextBox.MaxLength = 30;
            phoneTextBox.Name = "phoneTextBox";
            phoneTextBox.Size = new Size(180, 23);
            phoneTextBox.TabIndex = 5;
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Font = new Font("Segoe UI", 9F);
            labelEmail.ForeColor = Color.FromArgb(70, 80, 95);
            labelEmail.Location = new Point(206, 66);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(36, 15);
            labelEmail.TabIndex = 6;
            labelEmail.Text = "Email";
            // 
            // emailTextBox
            // 
            emailTextBox.Font = new Font("Segoe UI", 9.5F);
            emailTextBox.Location = new Point(206, 84);
            emailTextBox.MaxLength = 100;
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(180, 23);
            emailTextBox.TabIndex = 7;
            // 
            // labelAddress
            // 
            labelAddress.AutoSize = true;
            labelAddress.Font = new Font("Segoe UI", 9F);
            labelAddress.ForeColor = Color.FromArgb(70, 80, 95);
            labelAddress.Location = new Point(14, 114);
            labelAddress.Name = "labelAddress";
            labelAddress.Size = new Size(52, 15);
            labelAddress.TabIndex = 8;
            labelAddress.Text = "Address";
            // 
            // addressTextBox
            // 
            addressTextBox.Font = new Font("Segoe UI", 9.5F);
            addressTextBox.Location = new Point(14, 132);
            addressTextBox.MaxLength = 200;
            addressTextBox.Multiline = true;
            addressTextBox.Name = "addressTextBox";
            addressTextBox.ScrollBars = ScrollBars.Vertical;
            addressTextBox.Size = new Size(372, 48);
            addressTextBox.TabIndex = 9;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.Font = new Font("Segoe UI", 8.25F);
            hintLabel.ForeColor = Color.FromArgb(120, 130, 145);
            hintLabel.Location = new Point(14, 186);
            hintLabel.MaximumSize = new Size(372, 0);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(368, 26);
            hintLabel.TabIndex = 10;
            hintLabel.Text = "Name is required and must be unique. Other fields are optional.";
            // 
            // validationLabel
            // 
            validationLabel.Font = new Font("Segoe UI", 8.75F);
            validationLabel.ForeColor = Color.FromArgb(192, 57, 43);
            validationLabel.Location = new Point(14, 216);
            validationLabel.Name = "validationLabel";
            validationLabel.Size = new Size(372, 20);
            validationLabel.TabIndex = 13;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(41, 128, 185);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(14, 240);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(130, 32);
            saveButton.TabIndex = 11;
            saveButton.Text = "Add Supplier";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(108, 117, 125);
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 140, 150);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(152, 240);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 32);
            cancelButton.TabIndex = 12;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // actionsPanel
            // 
            actionsPanel.Controls.Add(clearSearchButton);
            actionsPanel.Controls.Add(searchTextBox);
            actionsPanel.Controls.Add(refreshButton);
            actionsPanel.Controls.Add(deleteButton);
            actionsPanel.Controls.Add(addButton);
            actionsPanel.Dock = DockStyle.Top;
            actionsPanel.Location = new Point(20, 16);
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new Size(1060, 48);
            actionsPanel.TabIndex = 0;
            // 
            // clearSearchButton
            // 
            clearSearchButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            clearSearchButton.BackColor = Color.FromArgb(108, 117, 125);
            clearSearchButton.FlatAppearance.BorderSize = 0;
            clearSearchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 140, 150);
            clearSearchButton.FlatStyle = FlatStyle.Flat;
            clearSearchButton.Font = new Font("Segoe UI", 9F);
            clearSearchButton.ForeColor = Color.White;
            clearSearchButton.Location = new Point(968, 8);
            clearSearchButton.Name = "clearSearchButton";
            clearSearchButton.Size = new Size(92, 32);
            clearSearchButton.TabIndex = 4;
            clearSearchButton.Text = "Clear";
            clearSearchButton.UseVisualStyleBackColor = false;
            clearSearchButton.Click += clearSearchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchTextBox.Font = new Font("Segoe UI", 9.5F);
            searchTextBox.Location = new Point(700, 11);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search by name, contact, phone, email or address...";
            searchTextBox.Size = new Size(260, 25);
            searchTextBox.TabIndex = 3;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // refreshButton
            // 
            refreshButton.BackColor = Color.FromArgb(52, 73, 94);
            refreshButton.FlatAppearance.BorderSize = 0;
            refreshButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(68, 95, 122);
            refreshButton.FlatStyle = FlatStyle.Flat;
            refreshButton.Font = new Font("Segoe UI", 9F);
            refreshButton.ForeColor = Color.White;
            refreshButton.Location = new Point(226, 8);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(90, 32);
            refreshButton.TabIndex = 2;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += refreshButton_Click;
            // 
            // deleteButton
            // 
            deleteButton.BackColor = Color.FromArgb(192, 57, 43);
            deleteButton.Enabled = false;
            deleteButton.FlatAppearance.BorderSize = 0;
            deleteButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(231, 76, 60);
            deleteButton.FlatStyle = FlatStyle.Flat;
            deleteButton.Font = new Font("Segoe UI", 9F);
            deleteButton.ForeColor = Color.White;
            deleteButton.Location = new Point(118, 8);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new Size(100, 32);
            deleteButton.TabIndex = 1;
            deleteButton.Text = "Delete";
            deleteButton.UseVisualStyleBackColor = false;
            deleteButton.Click += deleteButton_Click;
            // 
            // addButton
            // 
            addButton.BackColor = Color.FromArgb(39, 174, 96);
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(46, 204, 113);
            addButton.FlatStyle = FlatStyle.Flat;
            addButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            addButton.ForeColor = Color.White;
            addButton.Location = new Point(0, 8);
            addButton.Name = "addButton";
            addButton.Size = new Size(110, 32);
            addButton.TabIndex = 0;
            addButton.Text = "Add New";
            addButton.UseVisualStyleBackColor = false;
            addButton.Click += addButton_Click;
            // 
            // statusStripMain
            // 
            statusStripMain.BackColor = Color.White;
            statusStripMain.Items.AddRange(new ToolStripItem[] { statusLabel, countLabel });
            statusStripMain.Location = new Point(0, 636);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1100, 24);
            statusStripMain.SizingGrip = false;
            statusStripMain.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(949, 19);
            statusLabel.Spring = true;
            statusLabel.Text = "Ready";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // countLabel
            // 
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(102, 19);
            countLabel.Text = "Suppliers: 0";
            // 
            // SuppliersForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1100, 660);
            Controls.Add(contentPanel);
            Controls.Add(statusStripMain);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(0, 0);
            Name = "SuppliersForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Supplier Management";
            Load += SuppliersForm_Load;
            KeyDown += SuppliersForm_KeyDown;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            mainTable.ResumeLayout(false);
            listGroupBox.ResumeLayout(false);
            detailsGroupBox.ResumeLayout(false);
            detailsGroupBox.PerformLayout();
            actionsPanel.ResumeLayout(false);
            actionsPanel.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel headerPanel;
        private Button closeButton;
        private Label labelFormSubtitle;
        private Label labelFormTitle;
        private Panel contentPanel;
        private TableLayoutPanel mainTable;
        private GroupBox listGroupBox;
        private ListView suppliersListView;
        private ColumnHeader columnId;
        private ColumnHeader columnName;
        private ColumnHeader columnContact;
        private ColumnHeader columnPhone;
        private ColumnHeader columnEmail;
        private ColumnHeader columnStockIns;
        private GroupBox detailsGroupBox;
        private Label validationLabel;
        private Button cancelButton;
        private Button saveButton;
        private Label hintLabel;
        private TextBox addressTextBox;
        private Label labelAddress;
        private TextBox emailTextBox;
        private Label labelEmail;
        private TextBox phoneTextBox;
        private Label labelPhone;
        private TextBox contactTextBox;
        private Label labelContact;
        private TextBox nameTextBox;
        private Label labelName;
        private Panel actionsPanel;
        private Button clearSearchButton;
        private TextBox searchTextBox;
        private Button refreshButton;
        private Button deleteButton;
        private Button addButton;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel countLabel;
    }
}
