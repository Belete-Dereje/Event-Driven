using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.Categories
{
    partial class CategoriesForm
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
            categoriesListView = new ListView();
            columnId = new ColumnHeader();
            columnName = new ColumnHeader();
            columnDescription = new ColumnHeader();
            columnProducts = new ColumnHeader();
            detailsGroupBox = new GroupBox();
            validationLabel = new Label();
            cancelButton = new Button();
            saveButton = new Button();
            hintLabel = new Label();
            descriptionTextBox = new TextBox();
            labelDescription = new Label();
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
            headerPanel.Size = new Size(1000, 64);
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
            closeButton.Location = new Point(900, 16);
            closeButton.Name = "closeButton";
            closeButton.Size = new Size(80, 32);
            closeButton.TabIndex = 2;
            closeButton.Text = "Close";
            closeButton.UseVisualStyleBackColor = false;
            closeButton.Click += closeButton_Click;
            // 
            // labelFormSubtitle
            // 
            labelFormSubtitle.AutoSize = true;
            labelFormSubtitle.Font = new Font("Segoe UI", 9F);
            labelFormSubtitle.ForeColor = Color.FromArgb(210, 225, 245);
            labelFormSubtitle.Location = new Point(22, 38);
            labelFormSubtitle.Name = "labelFormSubtitle";
            labelFormSubtitle.Size = new Size(323, 15);
            labelFormSubtitle.TabIndex = 1;
            labelFormSubtitle.Text = "Add, view, edit, search and safely delete product categories";
            // 
            // labelFormTitle
            // 
            labelFormTitle.AutoSize = true;
            labelFormTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelFormTitle.ForeColor = Color.White;
            labelFormTitle.Location = new Point(20, 8);
            labelFormTitle.Name = "labelFormTitle";
            labelFormTitle.Size = new Size(231, 30);
            labelFormTitle.TabIndex = 0;
            labelFormTitle.Text = "Category Management";
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Controls.Add(mainTable);
            contentPanel.Controls.Add(actionsPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 64);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20, 16, 20, 16);
            contentPanel.Size = new Size(1000, 552);
            contentPanel.TabIndex = 1;
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 2;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 360F));
            mainTable.Controls.Add(listGroupBox, 0, 0);
            mainTable.Controls.Add(detailsGroupBox, 1, 0);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(20, 64);
            mainTable.Name = "mainTable";
            mainTable.Padding = new Padding(0, 8, 0, 0);
            mainTable.RowCount = 1;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTable.Size = new Size(960, 472);
            mainTable.TabIndex = 1;
            // 
            // listGroupBox
            // 
            listGroupBox.BackColor = Color.White;
            listGroupBox.Controls.Add(categoriesListView);
            listGroupBox.Dock = DockStyle.Fill;
            listGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            listGroupBox.Location = new Point(0, 8);
            listGroupBox.Margin = new Padding(0, 0, 8, 0);
            listGroupBox.Name = "listGroupBox";
            listGroupBox.Padding = new Padding(12);
            listGroupBox.Size = new Size(606, 464);
            listGroupBox.TabIndex = 0;
            listGroupBox.TabStop = false;
            listGroupBox.Text = "Category List";
            // 
            // categoriesListView
            // 
            categoriesListView.BackColor = Color.White;
            categoriesListView.BorderStyle = BorderStyle.FixedSingle;
            categoriesListView.Columns.AddRange(new ColumnHeader[] { columnId, columnName, columnDescription, columnProducts });
            categoriesListView.Dock = DockStyle.Fill;
            categoriesListView.Font = new Font("Segoe UI", 9.5F);
            categoriesListView.FullRowSelect = true;
            categoriesListView.GridLines = true;
            categoriesListView.HideSelection = false;
            categoriesListView.Location = new Point(12, 30);
            categoriesListView.MultiSelect = false;
            categoriesListView.Name = "categoriesListView";
            categoriesListView.Size = new Size(582, 422);
            categoriesListView.TabIndex = 0;
            categoriesListView.UseCompatibleStateImageBehavior = false;
            categoriesListView.View = View.Details;
            categoriesListView.SelectedIndexChanged += categoriesListView_SelectedIndexChanged;
            // 
            // columnId
            // 
            columnId.Text = "ID";
            columnId.TextAlign = HorizontalAlignment.Center;
            columnId.Width = 50;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 170;
            // 
            // columnDescription
            // 
            columnDescription.Text = "Description";
            columnDescription.Width = 250;
            // 
            // columnProducts
            // 
            columnProducts.Text = "Products";
            columnProducts.TextAlign = HorizontalAlignment.Center;
            columnProducts.Width = 70;
            // 
            // detailsGroupBox
            // 
            detailsGroupBox.BackColor = Color.White;
            detailsGroupBox.Controls.Add(validationLabel);
            detailsGroupBox.Controls.Add(cancelButton);
            detailsGroupBox.Controls.Add(saveButton);
            detailsGroupBox.Controls.Add(hintLabel);
            detailsGroupBox.Controls.Add(descriptionTextBox);
            detailsGroupBox.Controls.Add(labelDescription);
            detailsGroupBox.Controls.Add(nameTextBox);
            detailsGroupBox.Controls.Add(labelName);
            detailsGroupBox.Dock = DockStyle.Fill;
            detailsGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            detailsGroupBox.Location = new Point(614, 8);
            detailsGroupBox.Margin = new Padding(0);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Padding = new Padding(12);
            detailsGroupBox.Size = new Size(346, 464);
            detailsGroupBox.TabIndex = 1;
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Category Details";
            // 
            // validationLabel
            // 
            validationLabel.Font = new Font("Segoe UI", 8.75F);
            validationLabel.ForeColor = Color.FromArgb(192, 57, 43);
            validationLabel.Location = new Point(16, 282);
            validationLabel.Name = "validationLabel";
            validationLabel.Size = new Size(285, 40);
            validationLabel.TabIndex = 7;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(108, 117, 125);
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 140, 150);
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cancelButton.ForeColor = Color.White;
            cancelButton.Location = new Point(164, 330);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(110, 36);
            cancelButton.TabIndex = 6;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(41, 128, 185);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(16, 330);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(140, 36);
            saveButton.TabIndex = 5;
            saveButton.Text = "Add Category";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.Font = new Font("Segoe UI", 8.25F);
            hintLabel.ForeColor = Color.FromArgb(120, 130, 145);
            hintLabel.Location = new Point(16, 234);
            hintLabel.MaximumSize = new Size(285, 0);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(277, 26);
            hintLabel.TabIndex = 4;
            hintLabel.Text = "Name is required, must be unique, and can contain up to 50 characters.";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            descriptionTextBox.Font = new Font("Segoe UI", 9.5F);
            descriptionTextBox.Location = new Point(16, 116);
            descriptionTextBox.MaxLength = 200;
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            descriptionTextBox.Size = new Size(285, 110);
            descriptionTextBox.TabIndex = 3;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9F);
            labelDescription.ForeColor = Color.FromArgb(70, 80, 95);
            labelDescription.Location = new Point(16, 94);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(70, 15);
            labelDescription.TabIndex = 2;
            labelDescription.Text = "Description";
            // 
            // nameTextBox
            // 
            nameTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            nameTextBox.Font = new Font("Segoe UI", 10F);
            nameTextBox.Location = new Point(16, 54);
            nameTextBox.MaxLength = 50;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(285, 25);
            nameTextBox.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 9F);
            labelName.ForeColor = Color.FromArgb(70, 80, 95);
            labelName.Location = new Point(16, 32);
            labelName.Name = "labelName";
            labelName.Size = new Size(96, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Category Name *";
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
            actionsPanel.Size = new Size(960, 48);
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
            clearSearchButton.Location = new Point(868, 8);
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
            searchTextBox.Location = new Point(600, 11);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search by name or description...";
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
            statusStripMain.Location = new Point(0, 616);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1000, 24);
            statusStripMain.SizingGrip = false;
            statusStripMain.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(849, 19);
            statusLabel.Spring = true;
            statusLabel.Text = "Ready";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // countLabel
            // 
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(102, 19);
            countLabel.Text = "Categories: 0";
            // 
            // CategoriesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1000, 640);
            Controls.Add(contentPanel);
            Controls.Add(statusStripMain);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(0, 0);
            Name = "CategoriesForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Category Management";
            Load += CategoriesForm_Load;
            KeyDown += CategoriesForm_KeyDown;
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
        private ListView categoriesListView;
        private ColumnHeader columnId;
        private ColumnHeader columnName;
        private ColumnHeader columnDescription;
        private ColumnHeader columnProducts;
        private GroupBox detailsGroupBox;
        private Label validationLabel;
        private Button cancelButton;
        private Button saveButton;
        private Label hintLabel;
        private TextBox descriptionTextBox;
        private Label labelDescription;
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
