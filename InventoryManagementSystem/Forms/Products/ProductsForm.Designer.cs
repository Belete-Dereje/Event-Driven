using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.Products
{
    partial class ProductsForm
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
            productsListView = new ListView();
            columnCode = new ColumnHeader();
            columnName = new ColumnHeader();
            columnCategory = new ColumnHeader();
            columnSupplier = new ColumnHeader();
            columnPurchaseCost = new ColumnHeader();
            columnSellingPrice = new ColumnHeader();
            columnQuantity = new ColumnHeader();
            columnUnit = new ColumnHeader();
            columnMinimumStock = new ColumnHeader();
            columnStatus = new ColumnHeader();
            columnBarcode = new ColumnHeader();
            columnStorageLocation = new ColumnHeader();
            columnDescription = new ColumnHeader();
            detailsGroupBox = new GroupBox();
            validationLabel = new Label();
            cancelButton = new Button();
            saveButton = new Button();
            hintLabel = new Label();
            storageLocationTextBox = new TextBox();
            labelStorageLocation = new Label();
            barcodeTextBox = new TextBox();
            labelBarcode = new Label();
            statusComboBox = new ComboBox();
            labelStatus = new Label();
            descriptionTextBox = new TextBox();
            labelDescription = new Label();
            minimumStockTextBox = new TextBox();
            labelMinimumStock = new Label();
            quantityTextBox = new TextBox();
            labelQuantity = new Label();
            sellingPriceTextBox = new TextBox();
            labelSellingPrice = new Label();
            unitComboBox = new ComboBox();
            labelUnit = new Label();
            purchaseCostTextBox = new TextBox();
            labelPurchaseCost = new Label();
            supplierComboBox = new ComboBox();
            labelSupplier = new Label();
            categoryComboBox = new ComboBox();
            labelCategory = new Label();
            nameTextBox = new TextBox();
            labelName = new Label();
            codeTextBox = new TextBox();
            labelCode = new Label();
            actionsPanel = new Panel();
            clearFiltersButton = new Button();
            statusFilterComboBox = new ComboBox();
            labelStatusFilter = new Label();
            supplierFilterComboBox = new ComboBox();
            labelSupplierFilter = new Label();
            categoryFilterComboBox = new ComboBox();
            labelCategoryFilter = new Label();
            clearSearchButton = new Button();
            searchTextBox = new TextBox();
            refreshButton = new Button();
            statusButton = new Button();
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
            headerPanel.Size = new Size(1180, 52);
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
            closeButton.Location = new Point(1080, 10);
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
            labelFormSubtitle.Size = new Size(420, 15);
            labelFormSubtitle.TabIndex = 1;
            labelFormSubtitle.Text = "Register products, control stock levels, and search or filter the product catalogue";
            // 
            // labelFormTitle
            // 
            labelFormTitle.AutoSize = true;
            labelFormTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelFormTitle.ForeColor = Color.White;
            labelFormTitle.Location = new Point(20, 5);
            labelFormTitle.Name = "labelFormTitle";
            labelFormTitle.Size = new Size(205, 25);
            labelFormTitle.TabIndex = 0;
            labelFormTitle.Text = "Product Management";
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
            contentPanel.Size = new Size(1180, 604);
            contentPanel.TabIndex = 1;
            // 
            // mainTable
            // 
            mainTable.ColumnCount = 2;
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            mainTable.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 430F));
            mainTable.Controls.Add(listGroupBox, 0, 0);
            mainTable.Controls.Add(detailsGroupBox, 1, 0);
            mainTable.Dock = DockStyle.Fill;
            mainTable.Location = new Point(16, 84);
            mainTable.Name = "mainTable";
            mainTable.Padding = new Padding(0, 6, 0, 0);
            mainTable.RowCount = 1;
            mainTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            mainTable.Size = new Size(1148, 512);
            mainTable.TabIndex = 1;
            // 
            // listGroupBox
            // 
            listGroupBox.BackColor = Color.White;
            listGroupBox.Controls.Add(productsListView);
            listGroupBox.Dock = DockStyle.Fill;
            listGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            listGroupBox.Location = new Point(0, 8);
            listGroupBox.Margin = new Padding(0, 0, 8, 0);
            listGroupBox.Name = "listGroupBox";
            listGroupBox.Padding = new Padding(12);
            listGroupBox.Size = new Size(699, 472);
            listGroupBox.TabIndex = 0;
            listGroupBox.TabStop = false;
            listGroupBox.Text = "Product List";
            // 
            // productsListView
            // 
            productsListView.BackColor = Color.White;
            productsListView.BorderStyle = BorderStyle.FixedSingle;
            productsListView.Columns.AddRange(new ColumnHeader[] { columnCode, columnName, columnCategory, columnSupplier, columnPurchaseCost, columnSellingPrice, columnQuantity, columnUnit, columnMinimumStock, columnStatus, columnBarcode, columnStorageLocation, columnDescription });
            productsListView.Dock = DockStyle.Fill;
            productsListView.Font = new Font("Segoe UI", 9.5F);
            productsListView.FullRowSelect = true;
            productsListView.GridLines = true;
            productsListView.HideSelection = false;
            productsListView.Location = new Point(12, 30);
            productsListView.MultiSelect = false;
            productsListView.Name = "productsListView";
            productsListView.Size = new Size(675, 430);
            productsListView.TabIndex = 0;
            productsListView.UseCompatibleStateImageBehavior = false;
            productsListView.View = View.Details;
            productsListView.SelectedIndexChanged += productsListView_SelectedIndexChanged;
            productsListView.ColumnClick += productsListView_ColumnClick;
            // 
            // columnCode
            // 
            columnCode.Text = "Code";
            columnCode.Width = 90;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 140;
            // 
            // columnCategory
            // 
            columnCategory.Text = "Category";
            columnCategory.Width = 110;
            // 
            // columnSupplier
            // 
            columnSupplier.Text = "Supplier";
            columnSupplier.Width = 130;
            // 
            // columnPurchaseCost
            // 
            columnPurchaseCost.Text = "Purchase Cost";
            columnPurchaseCost.TextAlign = HorizontalAlignment.Right;
            columnPurchaseCost.Width = 95;
            // 
            // columnSellingPrice
            // 
            columnSellingPrice.Text = "Selling Price";
            columnSellingPrice.TextAlign = HorizontalAlignment.Right;
            columnSellingPrice.Width = 95;
            // 
            // columnQuantity
            // 
            columnQuantity.Text = "Qty";
            columnQuantity.TextAlign = HorizontalAlignment.Right;
            columnQuantity.Width = 60;
            // 
            // columnUnit
            // 
            columnUnit.Text = "Unit";
            columnUnit.Width = 65;
            // 
            // columnMinimumStock
            // 
            columnMinimumStock.Text = "Min Stock";
            columnMinimumStock.TextAlign = HorizontalAlignment.Right;
            columnMinimumStock.Width = 75;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.Width = 80;
            // 
            // columnBarcode
            // 
            columnBarcode.Text = "Barcode / SKU";
            columnBarcode.Width = 110;
            // 
            // columnStorageLocation
            // 
            columnStorageLocation.Text = "Location";
            columnStorageLocation.Width = 100;
            // 
            // columnDescription
            // 
            columnDescription.Text = "Description";
            columnDescription.Width = 160;
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
            detailsGroupBox.Controls.Add(storageLocationTextBox);
            detailsGroupBox.Controls.Add(labelStorageLocation);
            detailsGroupBox.Controls.Add(barcodeTextBox);
            detailsGroupBox.Controls.Add(labelBarcode);
            detailsGroupBox.Controls.Add(statusComboBox);
            detailsGroupBox.Controls.Add(labelStatus);
            detailsGroupBox.Controls.Add(minimumStockTextBox);
            detailsGroupBox.Controls.Add(labelMinimumStock);
            detailsGroupBox.Controls.Add(quantityTextBox);
            detailsGroupBox.Controls.Add(labelQuantity);
            detailsGroupBox.Controls.Add(sellingPriceTextBox);
            detailsGroupBox.Controls.Add(labelSellingPrice);
            detailsGroupBox.Controls.Add(purchaseCostTextBox);
            detailsGroupBox.Controls.Add(labelPurchaseCost);
            detailsGroupBox.Controls.Add(unitComboBox);
            detailsGroupBox.Controls.Add(labelUnit);
            detailsGroupBox.Controls.Add(supplierComboBox);
            detailsGroupBox.Controls.Add(labelSupplier);
            detailsGroupBox.Controls.Add(categoryComboBox);
            detailsGroupBox.Controls.Add(labelCategory);
            detailsGroupBox.Controls.Add(nameTextBox);
            detailsGroupBox.Controls.Add(labelName);
            detailsGroupBox.Controls.Add(codeTextBox);
            detailsGroupBox.Controls.Add(labelCode);
            detailsGroupBox.Dock = DockStyle.Fill;
            detailsGroupBox.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            detailsGroupBox.Location = new Point(668, 6);
            detailsGroupBox.Margin = new Padding(0);
            detailsGroupBox.Name = "detailsGroupBox";
            detailsGroupBox.Padding = new Padding(12);
            detailsGroupBox.Size = new Size(480, 506);
            detailsGroupBox.TabIndex = 1;
            detailsGroupBox.TabStop = false;
            detailsGroupBox.Text = "Product Details";
            // 
            // labelCode
            // 
            labelCode.AutoSize = true;
            labelCode.Font = new Font("Segoe UI", 9F);
            labelCode.ForeColor = Color.FromArgb(70, 80, 95);
            labelCode.Location = new Point(14, 20);
            labelCode.Name = "labelCode";
            labelCode.Size = new Size(86, 15);
            labelCode.TabIndex = 0;
            labelCode.Text = "Product Code *";
            // 
            // codeTextBox
            // 
            codeTextBox.Font = new Font("Segoe UI", 9.5F);
            codeTextBox.Location = new Point(14, 38);
            codeTextBox.MaxLength = 30;
            codeTextBox.Name = "codeTextBox";
            codeTextBox.Size = new Size(180, 23);
            codeTextBox.TabIndex = 1;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Font = new Font("Segoe UI", 9F);
            labelName.ForeColor = Color.FromArgb(70, 80, 95);
            labelName.Location = new Point(206, 20);
            labelName.Name = "labelName";
            labelName.Size = new Size(88, 15);
            labelName.TabIndex = 2;
            labelName.Text = "Product Name *";
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Segoe UI", 9.5F);
            nameTextBox.Location = new Point(206, 38);
            nameTextBox.MaxLength = 100;
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(180, 23);
            nameTextBox.TabIndex = 3;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Font = new Font("Segoe UI", 9F);
            labelCategory.ForeColor = Color.FromArgb(70, 80, 95);
            labelCategory.Location = new Point(14, 65);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new Size(65, 15);
            labelCategory.TabIndex = 4;
            labelCategory.Text = "Category *";
            // 
            // categoryComboBox
            // 
            categoryComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryComboBox.Font = new Font("Segoe UI", 9.5F);
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(14, 83);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(180, 23);
            categoryComboBox.TabIndex = 5;
            // 
            // labelSupplier
            // 
            labelSupplier.AutoSize = true;
            labelSupplier.Font = new Font("Segoe UI", 9F);
            labelSupplier.ForeColor = Color.FromArgb(70, 80, 95);
            labelSupplier.Location = new Point(206, 65);
            labelSupplier.Name = "labelSupplier";
            labelSupplier.Size = new Size(59, 15);
            labelSupplier.TabIndex = 6;
            labelSupplier.Text = "Supplier *";
            // 
            // supplierComboBox
            // 
            supplierComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierComboBox.Font = new Font("Segoe UI", 9.5F);
            supplierComboBox.FormattingEnabled = true;
            supplierComboBox.Location = new Point(206, 83);
            supplierComboBox.Name = "supplierComboBox";
            supplierComboBox.Size = new Size(180, 23);
            supplierComboBox.TabIndex = 7;
            // 
            // labelUnit
            // 
            labelUnit.AutoSize = true;
            labelUnit.Font = new Font("Segoe UI", 9F);
            labelUnit.ForeColor = Color.FromArgb(70, 80, 95);
            labelUnit.Location = new Point(14, 110);
            labelUnit.Name = "labelUnit";
            labelUnit.Size = new Size(39, 15);
            labelUnit.TabIndex = 8;
            labelUnit.Text = "Unit *";
            // 
            // unitComboBox
            // 
            unitComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            unitComboBox.Font = new Font("Segoe UI", 9.5F);
            unitComboBox.FormattingEnabled = true;
            unitComboBox.Location = new Point(14, 128);
            unitComboBox.Name = "unitComboBox";
            unitComboBox.Size = new Size(180, 23);
            unitComboBox.TabIndex = 9;
            // 
            // labelPurchaseCost
            // 
            labelPurchaseCost.AutoSize = true;
            labelPurchaseCost.Font = new Font("Segoe UI", 9F);
            labelPurchaseCost.ForeColor = Color.FromArgb(70, 80, 95);
            labelPurchaseCost.Location = new Point(206, 110);
            labelPurchaseCost.Name = "labelPurchaseCost";
            labelPurchaseCost.Size = new Size(88, 15);
            labelPurchaseCost.TabIndex = 10;
            labelPurchaseCost.Text = "Purchase Cost *";
            // 
            // purchaseCostTextBox
            // 
            purchaseCostTextBox.Font = new Font("Segoe UI", 9.5F);
            purchaseCostTextBox.Location = new Point(206, 128);
            purchaseCostTextBox.Name = "purchaseCostTextBox";
            purchaseCostTextBox.Size = new Size(180, 23);
            purchaseCostTextBox.TabIndex = 11;
            // 
            // labelSellingPrice
            // 
            labelSellingPrice.AutoSize = true;
            labelSellingPrice.Font = new Font("Segoe UI", 9F);
            labelSellingPrice.ForeColor = Color.FromArgb(70, 80, 95);
            labelSellingPrice.Location = new Point(14, 155);
            labelSellingPrice.Name = "labelSellingPrice";
            labelSellingPrice.Size = new Size(78, 15);
            labelSellingPrice.TabIndex = 12;
            labelSellingPrice.Text = "Selling Price *";
            // 
            // sellingPriceTextBox
            // 
            sellingPriceTextBox.Font = new Font("Segoe UI", 9.5F);
            sellingPriceTextBox.Location = new Point(14, 173);
            sellingPriceTextBox.Name = "sellingPriceTextBox";
            sellingPriceTextBox.Size = new Size(180, 23);
            sellingPriceTextBox.TabIndex = 13;
            // 
            // labelQuantity
            // 
            labelQuantity.AutoSize = true;
            labelQuantity.Font = new Font("Segoe UI", 9F);
            labelQuantity.ForeColor = Color.FromArgb(70, 80, 95);
            labelQuantity.Location = new Point(206, 155);
            labelQuantity.Name = "labelQuantity";
            labelQuantity.Size = new Size(89, 15);
            labelQuantity.TabIndex = 14;
            labelQuantity.Text = "Initial Quantity";
            // 
            // quantityTextBox
            // 
            quantityTextBox.Font = new Font("Segoe UI", 9.5F);
            quantityTextBox.Location = new Point(206, 173);
            quantityTextBox.Name = "quantityTextBox";
            quantityTextBox.Size = new Size(180, 23);
            quantityTextBox.TabIndex = 15;
            // 
            // labelMinimumStock
            // 
            labelMinimumStock.AutoSize = true;
            labelMinimumStock.Font = new Font("Segoe UI", 9F);
            labelMinimumStock.ForeColor = Color.FromArgb(70, 80, 95);
            labelMinimumStock.Location = new Point(14, 200);
            labelMinimumStock.Name = "labelMinimumStock";
            labelMinimumStock.Size = new Size(99, 15);
            labelMinimumStock.TabIndex = 16;
            labelMinimumStock.Text = "Minimum Stock *";
            // 
            // minimumStockTextBox
            // 
            minimumStockTextBox.Font = new Font("Segoe UI", 9.5F);
            minimumStockTextBox.Location = new Point(14, 218);
            minimumStockTextBox.Name = "minimumStockTextBox";
            minimumStockTextBox.Size = new Size(180, 23);
            minimumStockTextBox.TabIndex = 17;
            // 
            // labelStatus
            // 
            labelStatus.AutoSize = true;
            labelStatus.Font = new Font("Segoe UI", 9F);
            labelStatus.ForeColor = Color.FromArgb(70, 80, 95);
            labelStatus.Location = new Point(206, 200);
            labelStatus.Name = "labelStatus";
            labelStatus.Size = new Size(39, 15);
            labelStatus.TabIndex = 18;
            labelStatus.Text = "Status";
            // 
            // statusComboBox
            // 
            statusComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusComboBox.Font = new Font("Segoe UI", 9.5F);
            statusComboBox.FormattingEnabled = true;
            statusComboBox.Location = new Point(206, 218);
            statusComboBox.Name = "statusComboBox";
            statusComboBox.Size = new Size(180, 23);
            statusComboBox.TabIndex = 19;
            // 
            // labelBarcode
            // 
            labelBarcode.AutoSize = true;
            labelBarcode.Font = new Font("Segoe UI", 9F);
            labelBarcode.ForeColor = Color.FromArgb(70, 80, 95);
            labelBarcode.Location = new Point(14, 245);
            labelBarcode.Name = "labelBarcode";
            labelBarcode.Size = new Size(76, 15);
            labelBarcode.TabIndex = 20;
            labelBarcode.Text = "Barcode / SKU";
            // 
            // barcodeTextBox
            // 
            barcodeTextBox.Font = new Font("Segoe UI", 9.5F);
            barcodeTextBox.Location = new Point(14, 263);
            barcodeTextBox.MaxLength = 50;
            barcodeTextBox.Name = "barcodeTextBox";
            barcodeTextBox.Size = new Size(180, 23);
            barcodeTextBox.TabIndex = 21;
            // 
            // labelStorageLocation
            // 
            labelStorageLocation.AutoSize = true;
            labelStorageLocation.Font = new Font("Segoe UI", 9F);
            labelStorageLocation.ForeColor = Color.FromArgb(70, 80, 95);
            labelStorageLocation.Location = new Point(206, 245);
            labelStorageLocation.Name = "labelStorageLocation";
            labelStorageLocation.Size = new Size(88, 15);
            labelStorageLocation.TabIndex = 22;
            labelStorageLocation.Text = "Storage Location";
            // 
            // storageLocationTextBox
            // 
            storageLocationTextBox.Font = new Font("Segoe UI", 9.5F);
            storageLocationTextBox.Location = new Point(206, 263);
            storageLocationTextBox.MaxLength = 100;
            storageLocationTextBox.Name = "storageLocationTextBox";
            storageLocationTextBox.Size = new Size(180, 23);
            storageLocationTextBox.TabIndex = 23;
            // 
            // labelDescription
            // 
            labelDescription.AutoSize = true;
            labelDescription.Font = new Font("Segoe UI", 9F);
            labelDescription.ForeColor = Color.FromArgb(70, 80, 95);
            labelDescription.Location = new Point(14, 290);
            labelDescription.Name = "labelDescription";
            labelDescription.Size = new Size(70, 15);
            labelDescription.TabIndex = 24;
            labelDescription.Text = "Description";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Font = new Font("Segoe UI", 9.5F);
            descriptionTextBox.Location = new Point(14, 308);
            descriptionTextBox.MaxLength = 200;
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.ScrollBars = ScrollBars.Vertical;
            descriptionTextBox.Size = new Size(372, 40);
            descriptionTextBox.TabIndex = 25;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.Font = new Font("Segoe UI", 8.25F);
            hintLabel.ForeColor = Color.FromArgb(120, 130, 145);
            hintLabel.Location = new Point(14, 354);
            hintLabel.MaximumSize = new Size(372, 0);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(370, 26);
            hintLabel.TabIndex = 26;
            hintLabel.Text = "Product code must be unique. Select a supplier from the registered suppliers.";
            // 
            // validationLabel
            // 
            validationLabel.Font = new Font("Segoe UI", 8.75F);
            validationLabel.ForeColor = Color.FromArgb(192, 57, 43);
            validationLabel.Location = new Point(14, 382);
            validationLabel.Name = "validationLabel";
            validationLabel.Size = new Size(372, 20);
            validationLabel.TabIndex = 27;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(41, 128, 185);
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(52, 152, 219);
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            saveButton.ForeColor = Color.White;
            saveButton.Location = new Point(14, 406);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(130, 32);
            saveButton.TabIndex = 28;
            saveButton.Text = "Add Product";
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
            cancelButton.Location = new Point(152, 406);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(100, 32);
            cancelButton.TabIndex = 29;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // actionsPanel
            // 
            actionsPanel.Controls.Add(clearFiltersButton);
            actionsPanel.Controls.Add(statusFilterComboBox);
            actionsPanel.Controls.Add(labelStatusFilter);
            actionsPanel.Controls.Add(supplierFilterComboBox);
            actionsPanel.Controls.Add(labelSupplierFilter);
            actionsPanel.Controls.Add(categoryFilterComboBox);
            actionsPanel.Controls.Add(labelCategoryFilter);
            actionsPanel.Controls.Add(clearSearchButton);
            actionsPanel.Controls.Add(searchTextBox);
            actionsPanel.Controls.Add(refreshButton);
            actionsPanel.Controls.Add(statusButton);
            actionsPanel.Controls.Add(deleteButton);
            actionsPanel.Controls.Add(addButton);
            actionsPanel.Dock = DockStyle.Top;
            actionsPanel.Location = new Point(20, 16);
            actionsPanel.Name = "actionsPanel";
            actionsPanel.Size = new Size(1140, 80);
            actionsPanel.TabIndex = 0;
            // 
            // clearFiltersButton
            // 
            clearFiltersButton.BackColor = Color.FromArgb(108, 117, 125);
            clearFiltersButton.FlatAppearance.BorderSize = 0;
            clearFiltersButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(130, 140, 150);
            clearFiltersButton.FlatStyle = FlatStyle.Flat;
            clearFiltersButton.Font = new Font("Segoe UI", 9F);
            clearFiltersButton.ForeColor = Color.White;
            clearFiltersButton.Location = new Point(608, 50);
            clearFiltersButton.Name = "clearFiltersButton";
            clearFiltersButton.Size = new Size(100, 28);
            clearFiltersButton.TabIndex = 12;
            clearFiltersButton.Text = "Clear Filters";
            clearFiltersButton.UseVisualStyleBackColor = false;
            clearFiltersButton.Click += clearFiltersButton_Click;
            // 
            // statusFilterComboBox
            // 
            statusFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            statusFilterComboBox.Font = new Font("Segoe UI", 9F);
            statusFilterComboBox.FormattingEnabled = true;
            statusFilterComboBox.Location = new Point(468, 52);
            statusFilterComboBox.Name = "statusFilterComboBox";
            statusFilterComboBox.Size = new Size(130, 23);
            statusFilterComboBox.TabIndex = 11;
            statusFilterComboBox.SelectedIndexChanged += filterComboBox_SelectedIndexChanged;
            // 
            // labelStatusFilter
            // 
            labelStatusFilter.AutoSize = true;
            labelStatusFilter.Font = new Font("Segoe UI", 9F);
            labelStatusFilter.ForeColor = Color.FromArgb(70, 80, 95);
            labelStatusFilter.Location = new Point(390, 56);
            labelStatusFilter.Name = "labelStatusFilter";
            labelStatusFilter.Size = new Size(74, 15);
            labelStatusFilter.TabIndex = 10;
            labelStatusFilter.Text = "Stock Status:";
            // 
            // supplierFilterComboBox
            // 
            supplierFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            supplierFilterComboBox.Font = new Font("Segoe UI", 9F);
            supplierFilterComboBox.FormattingEnabled = true;
            supplierFilterComboBox.Location = new Point(254, 52);
            supplierFilterComboBox.Name = "supplierFilterComboBox";
            supplierFilterComboBox.Size = new Size(130, 23);
            supplierFilterComboBox.TabIndex = 9;
            supplierFilterComboBox.SelectedIndexChanged += filterComboBox_SelectedIndexChanged;
            // 
            // labelSupplierFilter
            // 
            labelSupplierFilter.AutoSize = true;
            labelSupplierFilter.Font = new Font("Segoe UI", 9F);
            labelSupplierFilter.ForeColor = Color.FromArgb(70, 80, 95);
            labelSupplierFilter.Location = new Point(198, 56);
            labelSupplierFilter.Name = "labelSupplierFilter";
            labelSupplierFilter.Size = new Size(53, 15);
            labelSupplierFilter.TabIndex = 8;
            labelSupplierFilter.Text = "Supplier:";
            // 
            // categoryFilterComboBox
            // 
            categoryFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            categoryFilterComboBox.Font = new Font("Segoe UI", 9F);
            categoryFilterComboBox.FormattingEnabled = true;
            categoryFilterComboBox.Location = new Point(62, 52);
            categoryFilterComboBox.Name = "categoryFilterComboBox";
            categoryFilterComboBox.Size = new Size(130, 23);
            categoryFilterComboBox.TabIndex = 7;
            categoryFilterComboBox.SelectedIndexChanged += filterComboBox_SelectedIndexChanged;
            // 
            // labelCategoryFilter
            // 
            labelCategoryFilter.AutoSize = true;
            labelCategoryFilter.Font = new Font("Segoe UI", 9F);
            labelCategoryFilter.ForeColor = Color.FromArgb(70, 80, 95);
            labelCategoryFilter.Location = new Point(0, 56);
            labelCategoryFilter.Name = "labelCategoryFilter";
            labelCategoryFilter.Size = new Size(58, 15);
            labelCategoryFilter.TabIndex = 6;
            labelCategoryFilter.Text = "Category:";
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
            clearSearchButton.Location = new Point(1048, 8);
            clearSearchButton.Name = "clearSearchButton";
            clearSearchButton.Size = new Size(92, 32);
            clearSearchButton.TabIndex = 5;
            clearSearchButton.Text = "Clear";
            clearSearchButton.UseVisualStyleBackColor = false;
            clearSearchButton.Click += clearSearchButton_Click;
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            searchTextBox.Font = new Font("Segoe UI", 9.5F);
            searchTextBox.Location = new Point(780, 11);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Search by product code or name...";
            searchTextBox.Size = new Size(260, 25);
            searchTextBox.TabIndex = 4;
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
            refreshButton.Location = new Point(354, 8);
            refreshButton.Name = "refreshButton";
            refreshButton.Size = new Size(90, 32);
            refreshButton.TabIndex = 3;
            refreshButton.Text = "Refresh";
            refreshButton.UseVisualStyleBackColor = false;
            refreshButton.Click += refreshButton_Click;
            // 
            // statusButton
            // 
            statusButton.BackColor = Color.FromArgb(142, 68, 173);
            statusButton.Enabled = false;
            statusButton.FlatAppearance.BorderSize = 0;
            statusButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(155, 89, 182);
            statusButton.FlatStyle = FlatStyle.Flat;
            statusButton.Font = new Font("Segoe UI", 9F);
            statusButton.ForeColor = Color.White;
            statusButton.Location = new Point(226, 8);
            statusButton.Name = "statusButton";
            statusButton.Size = new Size(120, 32);
            statusButton.TabIndex = 2;
            statusButton.Text = "Mark Inactive";
            statusButton.UseVisualStyleBackColor = false;
            statusButton.Click += statusButton_Click;
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
            statusStripMain.Location = new Point(0, 656);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1180, 24);
            statusStripMain.SizingGrip = false;
            statusStripMain.TabIndex = 2;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1029, 19);
            statusLabel.Spring = true;
            statusLabel.Text = "Ready";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // countLabel
            // 
            countLabel.Name = "countLabel";
            countLabel.Size = new Size(102, 19);
            countLabel.Text = "Products: 0";
            // 
            // ProductsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1180, 680);
            Controls.Add(contentPanel);
            Controls.Add(statusStripMain);
            Controls.Add(headerPanel);
            Font = new Font("Segoe UI", 9F);
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(0, 0);
            Name = "ProductsForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Product Management";
            Load += ProductsForm_Load;
            KeyDown += ProductsForm_KeyDown;
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
        private ListView productsListView;
        private ColumnHeader columnCode;
        private ColumnHeader columnName;
        private ColumnHeader columnCategory;
        private ColumnHeader columnSupplier;
        private ColumnHeader columnPurchaseCost;
        private ColumnHeader columnSellingPrice;
        private ColumnHeader columnQuantity;
        private ColumnHeader columnUnit;
        private ColumnHeader columnMinimumStock;
        private ColumnHeader columnStatus;
        private ColumnHeader columnBarcode;
        private ColumnHeader columnStorageLocation;
        private ColumnHeader columnDescription;
        private GroupBox detailsGroupBox;
        private Label validationLabel;
        private Button cancelButton;
        private Button saveButton;
        private Label hintLabel;
        private TextBox storageLocationTextBox;
        private Label labelStorageLocation;
        private TextBox barcodeTextBox;
        private Label labelBarcode;
        private ComboBox statusComboBox;
        private Label labelStatus;
        private TextBox descriptionTextBox;
        private Label labelDescription;
        private TextBox minimumStockTextBox;
        private Label labelMinimumStock;
        private TextBox quantityTextBox;
        private Label labelQuantity;
        private TextBox sellingPriceTextBox;
        private Label labelSellingPrice;
        private ComboBox unitComboBox;
        private Label labelUnit;
        private TextBox purchaseCostTextBox;
        private Label labelPurchaseCost;
        private ComboBox supplierComboBox;
        private Label labelSupplier;
        private ComboBox categoryComboBox;
        private Label labelCategory;
        private TextBox nameTextBox;
        private Label labelName;
        private TextBox codeTextBox;
        private Label labelCode;
        private Panel actionsPanel;
        private Button clearFiltersButton;
        private ComboBox statusFilterComboBox;
        private Label labelStatusFilter;
        private ComboBox supplierFilterComboBox;
        private Label labelSupplierFilter;
        private ComboBox categoryFilterComboBox;
        private Label labelCategoryFilter;
        private Button clearSearchButton;
        private TextBox searchTextBox;
        private Button refreshButton;
        private Button statusButton;
        private Button deleteButton;
        private Button addButton;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel countLabel;
    }
}
