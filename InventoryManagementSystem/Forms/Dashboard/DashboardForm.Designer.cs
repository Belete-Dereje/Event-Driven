using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.Dashboard
{
    partial class DashboardForm
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
            components = new Container();
            headerPanel = new Panel();
            headerRefreshButton = new Button();
            headerLogoutButton = new Button();
            backButton = new Button();
            sidebarPanel = new Panel();
            sideTitleLabel = new Label();
            sideHomeButton = new Button();
            sideProductsButton = new Button();
            sideCategoriesButton = new Button();
            sideSuppliersButton = new Button();
            sideStockInButton = new Button();
            sideStockOutButton = new Button();
            sideAdjustButton = new Button();
            sideTransactionsButton = new Button();
            sideReportsButton = new Button();
            sideLogoutButton = new Button();
            hamburgerButton = new Button();
            hamburgerMenu = new ContextMenuStrip(components);
            fileMenuItem = new ToolStripMenuItem();
            loadSampleDataMenuItem = new ToolStripMenuItem();
            exitMenuItem = new ToolStripMenuItem();
            manageMenuItem = new ToolStripMenuItem();
            productsMenuItem = new ToolStripMenuItem();
            categoriesMenuItem = new ToolStripMenuItem();
            suppliersMenuItem = new ToolStripMenuItem();
            stockInMenuItem = new ToolStripMenuItem();
            stockOutMenuItem = new ToolStripMenuItem();
            transactionsMenuItem = new ToolStripMenuItem();
            reportsMenuItem = new ToolStripMenuItem();
            contentPanel = new Panel();
            listsPanel = new Panel();
            recentTransactionsGroupBox = new GroupBox();
            recentTransactionsListView = new ListView();
            transactionIdColumn = new ColumnHeader();
            transactionProductColumn = new ColumnHeader();
            transactionTypeColumn = new ColumnHeader();
            transactionQuantityColumn = new ColumnHeader();
            transactionDateColumn = new ColumnHeader();
            lowStockGroupBox = new GroupBox();
            lowStockListView = new ListView();
            lowStockCodeColumn = new ColumnHeader();
            lowStockNameColumn = new ColumnHeader();
            lowStockCategoryColumn = new ColumnHeader();
            lowStockQuantityColumn = new ColumnHeader();
            lowStockMinimumColumn = new ColumnHeader();
            lowStockReorderColumn = new ColumnHeader();
            cardsTable = new TableLayoutPanel();
            productsCard = new Panel();
            productsValueLabel = new Label();
            productsTitleLabel = new Label();
            categoriesCard = new Panel();
            categoriesValueLabel = new Label();
            categoriesTitleLabel = new Label();
            suppliersCard = new Panel();
            suppliersValueLabel = new Label();
            suppliersTitleLabel = new Label();
            lowStockCard = new Panel();
            lowStockValueLabel = new Label();
            lowStockTitleLabel = new Label();
            stockInCard = new Panel();
            stockInValueLabel = new Label();
            stockInTitleLabel = new Label();
            stockOutCard = new Panel();
            stockOutValueLabel = new Label();
            stockOutTitleLabel = new Label();
            labelPageTitle = new Label();
            labelPageSubtitle = new Label();
            statusStripMain = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            clockLabel = new ToolStripStatusLabel();
            clockTimer = new System.Windows.Forms.Timer(components);
            headerPanel.SuspendLayout();
            hamburgerMenu.SuspendLayout();
            contentPanel.SuspendLayout();
            listsPanel.SuspendLayout();
            recentTransactionsGroupBox.SuspendLayout();
            lowStockGroupBox.SuspendLayout();
            cardsTable.SuspendLayout();
            productsCard.SuspendLayout();
            categoriesCard.SuspendLayout();
            suppliersCard.SuspendLayout();
            lowStockCard.SuspendLayout();
            stockInCard.SuspendLayout();
            stockOutCard.SuspendLayout();
            statusStripMain.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(33, 97, 173);
            headerPanel.Controls.Add(headerLogoutButton);
            headerPanel.Controls.Add(headerRefreshButton);
            headerPanel.Controls.Add(hamburgerButton);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1200, 64);
            headerPanel.TabIndex = 0;
            // 
            // headerRefreshButton
            // 
            headerRefreshButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            headerRefreshButton.BackColor = Color.FromArgb(33, 97, 173);
            headerRefreshButton.FlatAppearance.BorderColor = Color.FromArgb(180, 205, 235);
            headerRefreshButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 110, 190);
            headerRefreshButton.FlatStyle = FlatStyle.Flat;
            headerRefreshButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerRefreshButton.ForeColor = Color.White;
            headerRefreshButton.Location = new Point(950, 15);
            headerRefreshButton.Name = "headerRefreshButton";
            headerRefreshButton.Size = new Size(96, 34);
            headerRefreshButton.TabIndex = 3;
            headerRefreshButton.Text = "Refresh";
            headerRefreshButton.UseVisualStyleBackColor = false;
            headerRefreshButton.Click += refreshButton_Click;
            // 
            // headerLogoutButton
            // 
            headerLogoutButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            headerLogoutButton.BackColor = Color.FromArgb(192, 57, 43);
            headerLogoutButton.FlatAppearance.BorderColor = Color.FromArgb(231, 76, 60);
            headerLogoutButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(217, 83, 79);
            headerLogoutButton.FlatStyle = FlatStyle.Flat;
            headerLogoutButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            headerLogoutButton.ForeColor = Color.White;
            headerLogoutButton.Location = new Point(1056, 15);
            headerLogoutButton.Name = "headerLogoutButton";
            headerLogoutButton.Size = new Size(96, 34);
            headerLogoutButton.TabIndex = 4;
            headerLogoutButton.Text = "Logout";
            headerLogoutButton.UseVisualStyleBackColor = false;
            headerLogoutButton.Click += logoutButton_Click;
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(21, 45, 82);
            sidebarPanel.Controls.Add(sideTitleLabel);
            sidebarPanel.Controls.Add(sideHomeButton);
            sidebarPanel.Controls.Add(sideProductsButton);
            sidebarPanel.Controls.Add(sideCategoriesButton);
            sidebarPanel.Controls.Add(sideSuppliersButton);
            sidebarPanel.Controls.Add(sideStockInButton);
            sidebarPanel.Controls.Add(sideStockOutButton);
            sidebarPanel.Controls.Add(sideAdjustButton);
            sidebarPanel.Controls.Add(sideTransactionsButton);
            sidebarPanel.Controls.Add(sideReportsButton);
            sidebarPanel.Controls.Add(sideLogoutButton);
            sidebarPanel.Controls.Add(backButton);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(180, 680);
            // sideTitleLabel
            // 
            sideTitleLabel.Dock = DockStyle.Top;
            sideTitleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            sideTitleLabel.ForeColor = Color.White;
            sideTitleLabel.Location = new Point(0, 0);
            sideTitleLabel.Name = "sideTitleLabel";
            sideTitleLabel.Size = new Size(180, 58);
            sideTitleLabel.TabIndex = 0;
            sideTitleLabel.Text = "Inventory\nManager";
            sideTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sideHomeButton
            // 
            sideHomeButton.BackColor = Color.FromArgb(44, 120, 200);
            sideHomeButton.FlatAppearance.BorderSize = 0;
            sideHomeButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(58, 135, 220);
            sideHomeButton.FlatStyle = FlatStyle.Flat;
            sideHomeButton.Font = new Font("Segoe UI", 9.5F);
            sideHomeButton.ForeColor = Color.White;
            sideHomeButton.Location = new Point(0, 66);
            sideHomeButton.Name = "sideHomeButton";
            sideHomeButton.Padding = new Padding(16, 0, 0, 0);
            sideHomeButton.Size = new Size(180, 40);
            sideHomeButton.TabIndex = 0;
            sideHomeButton.Text = "Dashboard";
            sideHomeButton.TextAlign = ContentAlignment.MiddleLeft;
            sideHomeButton.UseVisualStyleBackColor = false;
            sideHomeButton.Click += homeSideButton_Click;
            // 
            // sideProductsButton
            // 
            sideProductsButton.BackColor = Color.FromArgb(21, 45, 82);
            sideProductsButton.FlatAppearance.BorderSize = 0;
            sideProductsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideProductsButton.FlatStyle = FlatStyle.Flat;
            sideProductsButton.Font = new Font("Segoe UI", 9.5F);
            sideProductsButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideProductsButton.Location = new Point(0, 108);
            sideProductsButton.Name = "sideProductsButton";
            sideProductsButton.Padding = new Padding(16, 0, 0, 0);
            sideProductsButton.Size = new Size(180, 40);
            sideProductsButton.TabIndex = 1;
            sideProductsButton.Text = "Products";
            sideProductsButton.TextAlign = ContentAlignment.MiddleLeft;
            sideProductsButton.UseVisualStyleBackColor = false;
            sideProductsButton.Click += productsButton_Click;
            // 
            // sideCategoriesButton
            // 
            sideCategoriesButton.BackColor = Color.FromArgb(21, 45, 82);
            sideCategoriesButton.FlatAppearance.BorderSize = 0;
            sideCategoriesButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideCategoriesButton.FlatStyle = FlatStyle.Flat;
            sideCategoriesButton.Font = new Font("Segoe UI", 9.5F);
            sideCategoriesButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideCategoriesButton.Location = new Point(0, 150);
            sideCategoriesButton.Name = "sideCategoriesButton";
            sideCategoriesButton.Padding = new Padding(16, 0, 0, 0);
            sideCategoriesButton.Size = new Size(180, 40);
            sideCategoriesButton.TabIndex = 2;
            sideCategoriesButton.Text = "Categories";
            sideCategoriesButton.TextAlign = ContentAlignment.MiddleLeft;
            sideCategoriesButton.UseVisualStyleBackColor = false;
            sideCategoriesButton.Click += categoriesButton_Click;
            // 
            // sideSuppliersButton
            // 
            sideSuppliersButton.BackColor = Color.FromArgb(21, 45, 82);
            sideSuppliersButton.FlatAppearance.BorderSize = 0;
            sideSuppliersButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideSuppliersButton.FlatStyle = FlatStyle.Flat;
            sideSuppliersButton.Font = new Font("Segoe UI", 9.5F);
            sideSuppliersButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideSuppliersButton.Location = new Point(0, 192);
            sideSuppliersButton.Name = "sideSuppliersButton";
            sideSuppliersButton.Padding = new Padding(16, 0, 0, 0);
            sideSuppliersButton.Size = new Size(180, 40);
            sideSuppliersButton.TabIndex = 3;
            sideSuppliersButton.Text = "Suppliers";
            sideSuppliersButton.TextAlign = ContentAlignment.MiddleLeft;
            sideSuppliersButton.UseVisualStyleBackColor = false;
            sideSuppliersButton.Click += suppliersButton_Click;
            // 
            // sideStockInButton
            // 
            sideStockInButton.BackColor = Color.FromArgb(21, 45, 82);
            sideStockInButton.FlatAppearance.BorderSize = 0;
            sideStockInButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideStockInButton.FlatStyle = FlatStyle.Flat;
            sideStockInButton.Font = new Font("Segoe UI", 9.5F);
            sideStockInButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideStockInButton.Location = new Point(0, 234);
            sideStockInButton.Name = "sideStockInButton";
            sideStockInButton.Padding = new Padding(16, 0, 0, 0);
            sideStockInButton.Size = new Size(180, 40);
            sideStockInButton.TabIndex = 4;
            sideStockInButton.Text = "Stock In";
            sideStockInButton.TextAlign = ContentAlignment.MiddleLeft;
            sideStockInButton.UseVisualStyleBackColor = false;
            sideStockInButton.Click += stockInButton_Click;
            // 
            // sideStockOutButton
            // 
            sideStockOutButton.BackColor = Color.FromArgb(21, 45, 82);
            sideStockOutButton.FlatAppearance.BorderSize = 0;
            sideStockOutButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideStockOutButton.FlatStyle = FlatStyle.Flat;
            sideStockOutButton.Font = new Font("Segoe UI", 9.5F);
            sideStockOutButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideStockOutButton.Location = new Point(0, 276);
            sideStockOutButton.Name = "sideStockOutButton";
            sideStockOutButton.Padding = new Padding(16, 0, 0, 0);
            sideStockOutButton.Size = new Size(180, 40);
            sideStockOutButton.TabIndex = 5;
            sideStockOutButton.Text = "Stock Out";
            sideStockOutButton.TextAlign = ContentAlignment.MiddleLeft;
            sideStockOutButton.UseVisualStyleBackColor = false;
            sideStockOutButton.Click += stockOutButton_Click;
            // 
            // sideAdjustButton
            // 
            sideAdjustButton.BackColor = Color.FromArgb(21, 45, 82);
            sideAdjustButton.FlatAppearance.BorderSize = 0;
            sideAdjustButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideAdjustButton.FlatStyle = FlatStyle.Flat;
            sideAdjustButton.Font = new Font("Segoe UI", 9.5F);
            sideAdjustButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideAdjustButton.Location = new Point(0, 318);
            sideAdjustButton.Name = "sideAdjustButton";
            sideAdjustButton.Padding = new Padding(16, 0, 0, 0);
            sideAdjustButton.Size = new Size(180, 40);
            sideAdjustButton.TabIndex = 6;
            sideAdjustButton.Text = "Adjustments";
            sideAdjustButton.TextAlign = ContentAlignment.MiddleLeft;
            sideAdjustButton.UseVisualStyleBackColor = false;
            sideAdjustButton.Click += adjustmentsButton_Click;
            // 
            // sideTransactionsButton
            // 
            sideTransactionsButton.BackColor = Color.FromArgb(21, 45, 82);
            sideTransactionsButton.FlatAppearance.BorderSize = 0;
            sideTransactionsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideTransactionsButton.FlatStyle = FlatStyle.Flat;
            sideTransactionsButton.Font = new Font("Segoe UI", 9.5F);
            sideTransactionsButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideTransactionsButton.Location = new Point(0, 360);
            sideTransactionsButton.Name = "sideTransactionsButton";
            sideTransactionsButton.Padding = new Padding(16, 0, 0, 0);
            sideTransactionsButton.Size = new Size(180, 40);
            sideTransactionsButton.TabIndex = 7;
            sideTransactionsButton.Text = "Transactions";
            sideTransactionsButton.TextAlign = ContentAlignment.MiddleLeft;
            sideTransactionsButton.UseVisualStyleBackColor = false;
            sideTransactionsButton.Click += transactionsButton_Click;
            // 
            // sideReportsButton
            // 
            sideReportsButton.BackColor = Color.FromArgb(21, 45, 82);
            sideReportsButton.FlatAppearance.BorderSize = 0;
            sideReportsButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            sideReportsButton.FlatStyle = FlatStyle.Flat;
            sideReportsButton.Font = new Font("Segoe UI", 9.5F);
            sideReportsButton.ForeColor = Color.FromArgb(205, 216, 229);
            sideReportsButton.Location = new Point(0, 402);
            sideReportsButton.Name = "sideReportsButton";
            sideReportsButton.Padding = new Padding(16, 0, 0, 0);
            sideReportsButton.Size = new Size(180, 40);
            sideReportsButton.TabIndex = 8;
            sideReportsButton.Text = "Reports";
            sideReportsButton.TextAlign = ContentAlignment.MiddleLeft;
            sideReportsButton.UseVisualStyleBackColor = false;
            sideReportsButton.Click += reportsButton_Click;
            // 
            // sideLogoutButton
            // 
            sideLogoutButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            sideLogoutButton.BackColor = Color.FromArgb(21, 45, 82);
            sideLogoutButton.FlatAppearance.BorderSize = 0;
            sideLogoutButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 57, 43);
            sideLogoutButton.FlatStyle = FlatStyle.Flat;
            sideLogoutButton.Font = new Font("Segoe UI", 9.5F);
            sideLogoutButton.ForeColor = Color.FromArgb(240, 160, 160);
            sideLogoutButton.Location = new Point(0, 594);
            sideLogoutButton.Name = "sideLogoutButton";
            sideLogoutButton.Padding = new Padding(16, 0, 0, 0);
            sideLogoutButton.Size = new Size(180, 40);
            sideLogoutButton.TabIndex = 9;
            sideLogoutButton.Text = "Logout";
            sideLogoutButton.TextAlign = ContentAlignment.MiddleLeft;
            sideLogoutButton.UseVisualStyleBackColor = false;
            sideLogoutButton.Click += logoutButton_Click;
            // 
            // backButton
            // 
            backButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            backButton.BackColor = Color.FromArgb(15, 33, 62);
            backButton.FlatAppearance.BorderSize = 0;
            backButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 84, 148);
            backButton.FlatStyle = FlatStyle.Flat;
            backButton.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            backButton.ForeColor = Color.White;
            backButton.Location = new Point(0, 636);
            backButton.Name = "backButton";
            backButton.Padding = new Padding(16, 0, 0, 0);
            backButton.Size = new Size(180, 44);
            backButton.TabIndex = 10;
            backButton.Text = "←  Back";
            backButton.TextAlign = ContentAlignment.MiddleLeft;
            backButton.UseVisualStyleBackColor = false;
            backButton.Visible = false;
            backButton.Click += backButton_Click;
            // 
            // hamburgerButton
            // 
            hamburgerButton.BackColor = Color.FromArgb(33, 97, 173);
            hamburgerButton.FlatAppearance.BorderSize = 0;
            hamburgerButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 110, 190);
            hamburgerButton.FlatStyle = FlatStyle.Flat;
            hamburgerButton.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            hamburgerButton.ForeColor = Color.White;
            hamburgerButton.Location = new Point(12, 10);
            hamburgerButton.Name = "hamburgerButton";
            hamburgerButton.Size = new Size(44, 44);
            hamburgerButton.TabIndex = 0;
            hamburgerButton.Text = "☰";
            hamburgerButton.UseVisualStyleBackColor = false;
            hamburgerButton.Click += hamburgerButton_Click;
            // 
            // hamburgerMenu
            // 
            hamburgerMenu.ImageScalingSize = new Size(20, 20);
            hamburgerMenu.Items.AddRange(new ToolStripItem[] { fileMenuItem, manageMenuItem, reportsMenuItem });
            hamburgerMenu.Name = "hamburgerMenu";
            hamburgerMenu.Size = new Size(160, 92);
            // 
            // fileMenuItem
            // 
            fileMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadSampleDataMenuItem, exitMenuItem });
            fileMenuItem.Name = "fileMenuItem";
            fileMenuItem.Size = new Size(159, 22);
            fileMenuItem.Text = "File";
            // 
            // loadSampleDataMenuItem
            // 
            loadSampleDataMenuItem.Name = "loadSampleDataMenuItem";
            loadSampleDataMenuItem.Size = new Size(180, 22);
            loadSampleDataMenuItem.Text = "Load Sample Data";
            loadSampleDataMenuItem.Click += loadSampleDataMenuItem_Click;
            // 
            // exitMenuItem
            // 
            exitMenuItem.Name = "exitMenuItem";
            exitMenuItem.Size = new Size(180, 22);
            exitMenuItem.Text = "Logout (Back to Landing)";
            exitMenuItem.Click += exitMenuItem_Click;
            // 
            // manageMenuItem
            // 
            manageMenuItem.DropDownItems.AddRange(new ToolStripItem[] { productsMenuItem, categoriesMenuItem, suppliersMenuItem, stockInMenuItem, stockOutMenuItem, transactionsMenuItem });
            manageMenuItem.Name = "manageMenuItem";
            manageMenuItem.Size = new Size(159, 22);
            manageMenuItem.Text = "Manage";
            // 
            // productsMenuItem
            // 
            productsMenuItem.Name = "productsMenuItem";
            productsMenuItem.Size = new Size(180, 22);
            productsMenuItem.Text = "Products";
            productsMenuItem.Click += productsButton_Click;
            // 
            // categoriesMenuItem
            // 
            categoriesMenuItem.Name = "categoriesMenuItem";
            categoriesMenuItem.Size = new Size(180, 22);
            categoriesMenuItem.Text = "Categories";
            categoriesMenuItem.Click += categoriesButton_Click;
            // 
            // suppliersMenuItem
            // 
            suppliersMenuItem.Name = "suppliersMenuItem";
            suppliersMenuItem.Size = new Size(180, 22);
            suppliersMenuItem.Text = "Suppliers";
            suppliersMenuItem.Click += suppliersButton_Click;
            // 
            // stockInMenuItem
            // 
            stockInMenuItem.Name = "stockInMenuItem";
            stockInMenuItem.Size = new Size(180, 22);
            stockInMenuItem.Text = "Stock In";
            stockInMenuItem.Click += stockInButton_Click;
            // 
            // stockOutMenuItem
            // 
            stockOutMenuItem.Name = "stockOutMenuItem";
            stockOutMenuItem.Size = new Size(180, 22);
            stockOutMenuItem.Text = "Stock Out";
            stockOutMenuItem.Click += stockOutButton_Click;
            // 
            // transactionsMenuItem
            // 
            transactionsMenuItem.Name = "transactionsMenuItem";
            transactionsMenuItem.Size = new Size(180, 22);
            transactionsMenuItem.Text = "Transactions";
            transactionsMenuItem.Click += transactionsButton_Click;
            // 
            // reportsMenuItem
            // 
            reportsMenuItem.Name = "reportsMenuItem";
            reportsMenuItem.Size = new Size(159, 22);
            reportsMenuItem.Text = "Reports";
            reportsMenuItem.Click += reportsButton_Click;
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Controls.Add(listsPanel);
            contentPanel.Controls.Add(cardsTable);
            contentPanel.Controls.Add(labelPageSubtitle);
            contentPanel.Controls.Add(labelPageTitle);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 64);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(24);
            contentPanel.Size = new Size(1160, 592);
            contentPanel.TabIndex = 1;
            // 
            // listsPanel
            // 
            listsPanel.Controls.Add(recentTransactionsGroupBox);
            listsPanel.Controls.Add(lowStockGroupBox);
            listsPanel.Dock = DockStyle.Top;
            listsPanel.Location = new Point(24, 298);
            listsPanel.Name = "listsPanel";
            listsPanel.Padding = new Padding(0, 12, 0, 0);
            listsPanel.Size = new Size(1112, 372);
            listsPanel.TabIndex = 3;
            // 
            // recentTransactionsGroupBox
            // 
            recentTransactionsGroupBox.BackColor = Color.White;
            recentTransactionsGroupBox.Controls.Add(recentTransactionsListView);
            recentTransactionsGroupBox.Dock = DockStyle.Fill;
            recentTransactionsGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            recentTransactionsGroupBox.Location = new Point(500, 12);
            recentTransactionsGroupBox.Name = "recentTransactionsGroupBox";
            recentTransactionsGroupBox.Padding = new Padding(12);
            recentTransactionsGroupBox.Size = new Size(432, 360);
            recentTransactionsGroupBox.TabIndex = 1;
            recentTransactionsGroupBox.TabStop = false;
            recentTransactionsGroupBox.Text = "Recent Transactions";
            // 
            // recentTransactionsListView
            // 
            recentTransactionsListView.Columns.AddRange(new ColumnHeader[] { transactionIdColumn, transactionProductColumn, transactionTypeColumn, transactionQuantityColumn, transactionDateColumn });
            recentTransactionsListView.Dock = DockStyle.Fill;
            recentTransactionsListView.Font = new Font("Segoe UI", 9F);
            recentTransactionsListView.FullRowSelect = true;
            recentTransactionsListView.GridLines = true;
            recentTransactionsListView.Location = new Point(12, 28);
            recentTransactionsListView.MultiSelect = false;
            recentTransactionsListView.Name = "recentTransactionsListView";
            recentTransactionsListView.Size = new Size(408, 320);
            recentTransactionsListView.TabIndex = 0;
            recentTransactionsListView.UseCompatibleStateImageBehavior = false;
            recentTransactionsListView.View = View.Details;
            recentTransactionsListView.SelectedIndexChanged += recentTransactionsListView_SelectedIndexChanged;
            // 
            // transactionIdColumn
            // 
            transactionIdColumn.Text = "ID";
            transactionIdColumn.Width = 40;
            // 
            // transactionProductColumn
            // 
            transactionProductColumn.Text = "Product";
            transactionProductColumn.Width = 120;
            // 
            // transactionTypeColumn
            // 
            transactionTypeColumn.Text = "Type";
            transactionTypeColumn.Width = 65;
            // 
            // transactionQuantityColumn
            // 
            transactionQuantityColumn.Text = "Qty";
            transactionQuantityColumn.TextAlign = HorizontalAlignment.Right;
            transactionQuantityColumn.Width = 45;
            // 
            // transactionDateColumn
            // 
            transactionDateColumn.Text = "Date";
            transactionDateColumn.Width = 100;
            // 
            // lowStockGroupBox
            // 
            lowStockGroupBox.BackColor = Color.White;
            lowStockGroupBox.Controls.Add(lowStockListView);
            lowStockGroupBox.Dock = DockStyle.Left;
            lowStockGroupBox.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lowStockGroupBox.Location = new Point(0, 12);
            lowStockGroupBox.Name = "lowStockGroupBox";
            lowStockGroupBox.Padding = new Padding(12);
            lowStockGroupBox.Size = new Size(500, 360);
            lowStockGroupBox.TabIndex = 0;
            lowStockGroupBox.TabStop = false;
            lowStockGroupBox.Text = "Low Stock Products";
            // 
            // lowStockListView
            // 
            lowStockListView.Columns.AddRange(new ColumnHeader[] { lowStockCodeColumn, lowStockNameColumn, lowStockCategoryColumn, lowStockQuantityColumn, lowStockMinimumColumn, lowStockReorderColumn });
            lowStockListView.Dock = DockStyle.Fill;
            lowStockListView.Font = new Font("Segoe UI", 9F);
            lowStockListView.FullRowSelect = true;
            lowStockListView.GridLines = true;
            lowStockListView.Location = new Point(12, 28);
            lowStockListView.MultiSelect = false;
            lowStockListView.Name = "lowStockListView";
            lowStockListView.Size = new Size(476, 320);
            lowStockListView.TabIndex = 0;
            lowStockListView.UseCompatibleStateImageBehavior = false;
            lowStockListView.View = View.Details;
            lowStockListView.SelectedIndexChanged += lowStockListView_SelectedIndexChanged;
            // 
            // lowStockCodeColumn
            // 
            lowStockCodeColumn.Text = "Code";
            lowStockCodeColumn.Width = 65;
            // 
            // lowStockNameColumn
            // 
            lowStockNameColumn.Text = "Product";
            lowStockNameColumn.Width = 135;
            // 
            // lowStockCategoryColumn
            // 
            lowStockCategoryColumn.Text = "Category";
            lowStockCategoryColumn.Width = 85;
            // 
            // lowStockQuantityColumn
            // 
            lowStockQuantityColumn.Text = "Qty";
            lowStockQuantityColumn.TextAlign = HorizontalAlignment.Right;
            lowStockQuantityColumn.Width = 50;
            // 
            // lowStockMinimumColumn
            // 
            lowStockMinimumColumn.Text = "Minimum";
            lowStockMinimumColumn.TextAlign = HorizontalAlignment.Right;
            lowStockMinimumColumn.Width = 55;
            // 
            // lowStockReorderColumn
            // 
            lowStockReorderColumn.Text = "Reorder";
            lowStockReorderColumn.TextAlign = HorizontalAlignment.Right;
            lowStockReorderColumn.Width = 60;
            // 
            // cardsTable
            // 
            cardsTable.ColumnCount = 3;
            cardsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            cardsTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));
            cardsTable.Controls.Add(productsCard, 0, 0);
            cardsTable.Controls.Add(categoriesCard, 1, 0);
            cardsTable.Controls.Add(suppliersCard, 2, 0);
            cardsTable.Controls.Add(lowStockCard, 0, 1);
            cardsTable.Controls.Add(stockInCard, 1, 1);
            cardsTable.Controls.Add(stockOutCard, 2, 1);
            cardsTable.Dock = DockStyle.Top;
            cardsTable.Location = new Point(24, 88);
            cardsTable.Name = "cardsTable";
            cardsTable.RowCount = 2;
            cardsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardsTable.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardsTable.Size = new Size(932, 210);
            cardsTable.TabIndex = 2;
            // 
            // productsCard
            // 
            productsCard.BackColor = Color.White;
            productsCard.BorderStyle = BorderStyle.FixedSingle;
            productsCard.Controls.Add(productsValueLabel);
            productsCard.Controls.Add(productsTitleLabel);
            productsCard.Dock = DockStyle.Fill;
            productsCard.Location = new Point(8, 8);
            productsCard.Margin = new Padding(8);
            productsCard.Name = "productsCard";
            productsCard.Padding = new Padding(16, 12, 16, 12);
            productsCard.Size = new Size(294, 89);
            productsCard.TabIndex = 0;
            // 
            // productsValueLabel
            // 
            productsValueLabel.Dock = DockStyle.Fill;
            productsValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            productsValueLabel.ForeColor = Color.FromArgb(33, 97, 173);
            productsValueLabel.Location = new Point(16, 37);
            productsValueLabel.Name = "productsValueLabel";
            productsValueLabel.Size = new Size(260, 38);
            productsValueLabel.TabIndex = 1;
            productsValueLabel.Text = "0";
            productsValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // productsTitleLabel
            // 
            productsTitleLabel.Dock = DockStyle.Top;
            productsTitleLabel.Font = new Font("Segoe UI", 10F);
            productsTitleLabel.ForeColor = Color.FromArgb(90, 90, 90);
            productsTitleLabel.Location = new Point(16, 12);
            productsTitleLabel.Name = "productsTitleLabel";
            productsTitleLabel.Size = new Size(260, 25);
            productsTitleLabel.TabIndex = 0;
            productsTitleLabel.Text = "Total Products";
            // 
            // categoriesCard
            // 
            categoriesCard.BackColor = Color.White;
            categoriesCard.BorderStyle = BorderStyle.FixedSingle;
            categoriesCard.Controls.Add(categoriesValueLabel);
            categoriesCard.Controls.Add(categoriesTitleLabel);
            categoriesCard.Dock = DockStyle.Fill;
            categoriesCard.Location = new Point(318, 8);
            categoriesCard.Margin = new Padding(8);
            categoriesCard.Name = "categoriesCard";
            categoriesCard.Padding = new Padding(16, 12, 16, 12);
            categoriesCard.Size = new Size(294, 89);
            categoriesCard.TabIndex = 1;
            // 
            // categoriesValueLabel
            // 
            categoriesValueLabel.Dock = DockStyle.Fill;
            categoriesValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            categoriesValueLabel.ForeColor = Color.FromArgb(142, 68, 173);
            categoriesValueLabel.Location = new Point(16, 37);
            categoriesValueLabel.Name = "categoriesValueLabel";
            categoriesValueLabel.Size = new Size(260, 38);
            categoriesValueLabel.TabIndex = 1;
            categoriesValueLabel.Text = "0";
            categoriesValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // categoriesTitleLabel
            // 
            categoriesTitleLabel.Dock = DockStyle.Top;
            categoriesTitleLabel.Font = new Font("Segoe UI", 10F);
            categoriesTitleLabel.ForeColor = Color.FromArgb(90, 90, 90);
            categoriesTitleLabel.Location = new Point(16, 12);
            categoriesTitleLabel.Name = "categoriesTitleLabel";
            categoriesTitleLabel.Size = new Size(260, 25);
            categoriesTitleLabel.TabIndex = 0;
            categoriesTitleLabel.Text = "Total Categories";
            // 
            // suppliersCard
            // 
            suppliersCard.BackColor = Color.White;
            suppliersCard.BorderStyle = BorderStyle.FixedSingle;
            suppliersCard.Controls.Add(suppliersValueLabel);
            suppliersCard.Controls.Add(suppliersTitleLabel);
            suppliersCard.Dock = DockStyle.Fill;
            suppliersCard.Location = new Point(628, 8);
            suppliersCard.Margin = new Padding(8);
            suppliersCard.Name = "suppliersCard";
            suppliersCard.Padding = new Padding(16, 12, 16, 12);
            suppliersCard.Size = new Size(296, 89);
            suppliersCard.TabIndex = 2;
            // 
            // suppliersValueLabel
            // 
            suppliersValueLabel.Dock = DockStyle.Fill;
            suppliersValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            suppliersValueLabel.ForeColor = Color.FromArgb(22, 160, 133);
            suppliersValueLabel.Location = new Point(16, 37);
            suppliersValueLabel.Name = "suppliersValueLabel";
            suppliersValueLabel.Size = new Size(262, 38);
            suppliersValueLabel.TabIndex = 1;
            suppliersValueLabel.Text = "0";
            suppliersValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // suppliersTitleLabel
            // 
            suppliersTitleLabel.Dock = DockStyle.Top;
            suppliersTitleLabel.Font = new Font("Segoe UI", 10F);
            suppliersTitleLabel.ForeColor = Color.FromArgb(90, 90, 90);
            suppliersTitleLabel.Location = new Point(16, 12);
            suppliersTitleLabel.Name = "suppliersTitleLabel";
            suppliersTitleLabel.Size = new Size(262, 25);
            suppliersTitleLabel.TabIndex = 0;
            suppliersTitleLabel.Text = "Total Suppliers";
            // 
            // lowStockCard
            // 
            lowStockCard.BackColor = Color.White;
            lowStockCard.BorderStyle = BorderStyle.FixedSingle;
            lowStockCard.Controls.Add(lowStockValueLabel);
            lowStockCard.Controls.Add(lowStockTitleLabel);
            lowStockCard.Dock = DockStyle.Fill;
            lowStockCard.Location = new Point(8, 113);
            lowStockCard.Margin = new Padding(8);
            lowStockCard.Name = "lowStockCard";
            lowStockCard.Padding = new Padding(16, 12, 16, 12);
            lowStockCard.Size = new Size(294, 89);
            lowStockCard.TabIndex = 3;
            // 
            // lowStockValueLabel
            // 
            lowStockValueLabel.Dock = DockStyle.Fill;
            lowStockValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lowStockValueLabel.ForeColor = Color.FromArgb(192, 57, 43);
            lowStockValueLabel.Location = new Point(16, 37);
            lowStockValueLabel.Name = "lowStockValueLabel";
            lowStockValueLabel.Size = new Size(260, 38);
            lowStockValueLabel.TabIndex = 1;
            lowStockValueLabel.Text = "0";
            lowStockValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lowStockTitleLabel
            // 
            lowStockTitleLabel.Dock = DockStyle.Top;
            lowStockTitleLabel.Font = new Font("Segoe UI", 10F);
            lowStockTitleLabel.ForeColor = Color.FromArgb(90, 90, 90);
            lowStockTitleLabel.Location = new Point(16, 12);
            lowStockTitleLabel.Name = "lowStockTitleLabel";
            lowStockTitleLabel.Size = new Size(260, 25);
            lowStockTitleLabel.TabIndex = 0;
            lowStockTitleLabel.Text = "Low Stock Items";
            // 
            // stockInCard
            // 
            stockInCard.BackColor = Color.White;
            stockInCard.BorderStyle = BorderStyle.FixedSingle;
            stockInCard.Controls.Add(stockInValueLabel);
            stockInCard.Controls.Add(stockInTitleLabel);
            stockInCard.Dock = DockStyle.Fill;
            stockInCard.Location = new Point(318, 113);
            stockInCard.Margin = new Padding(8);
            stockInCard.Name = "stockInCard";
            stockInCard.Padding = new Padding(16, 12, 16, 12);
            stockInCard.Size = new Size(294, 89);
            stockInCard.TabIndex = 4;
            // 
            // stockInValueLabel
            // 
            stockInValueLabel.Dock = DockStyle.Fill;
            stockInValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            stockInValueLabel.ForeColor = Color.FromArgb(39, 174, 96);
            stockInValueLabel.Location = new Point(16, 37);
            stockInValueLabel.Name = "stockInValueLabel";
            stockInValueLabel.Size = new Size(260, 38);
            stockInValueLabel.TabIndex = 1;
            stockInValueLabel.Text = "0";
            stockInValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stockInTitleLabel
            // 
            stockInTitleLabel.Dock = DockStyle.Top;
            stockInTitleLabel.Font = new Font("Segoe UI", 10F);
            stockInTitleLabel.ForeColor = Color.FromArgb(90, 90, 90);
            stockInTitleLabel.Location = new Point(16, 12);
            stockInTitleLabel.Name = "stockInTitleLabel";
            stockInTitleLabel.Size = new Size(260, 25);
            stockInTitleLabel.TabIndex = 0;
            stockInTitleLabel.Text = "Stock In (Today / Total)";
            // 
            // stockOutCard
            // 
            stockOutCard.BackColor = Color.White;
            stockOutCard.BorderStyle = BorderStyle.FixedSingle;
            stockOutCard.Controls.Add(stockOutValueLabel);
            stockOutCard.Controls.Add(stockOutTitleLabel);
            stockOutCard.Dock = DockStyle.Fill;
            stockOutCard.Location = new Point(628, 113);
            stockOutCard.Margin = new Padding(8);
            stockOutCard.Name = "stockOutCard";
            stockOutCard.Padding = new Padding(16, 12, 16, 12);
            stockOutCard.Size = new Size(296, 89);
            stockOutCard.TabIndex = 5;
            // 
            // stockOutValueLabel
            // 
            stockOutValueLabel.Dock = DockStyle.Fill;
            stockOutValueLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            stockOutValueLabel.ForeColor = Color.FromArgb(211, 84, 0);
            stockOutValueLabel.Location = new Point(16, 37);
            stockOutValueLabel.Name = "stockOutValueLabel";
            stockOutValueLabel.Size = new Size(262, 38);
            stockOutValueLabel.TabIndex = 1;
            stockOutValueLabel.Text = "0";
            stockOutValueLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stockOutTitleLabel
            // 
            stockOutTitleLabel.Dock = DockStyle.Top;
            stockOutTitleLabel.Font = new Font("Segoe UI", 10F);
            stockOutTitleLabel.ForeColor = Color.FromArgb(90, 90, 90);
            stockOutTitleLabel.Location = new Point(16, 12);
            stockOutTitleLabel.Name = "stockOutTitleLabel";
            stockOutTitleLabel.Size = new Size(262, 25);
            stockOutTitleLabel.TabIndex = 0;
            stockOutTitleLabel.Text = "Stock Out (Today / Total)";
            // 
            // labelPageTitle
            // 
            labelPageTitle.Dock = DockStyle.Top;
            labelPageTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            labelPageTitle.ForeColor = Color.FromArgb(35, 45, 60);
            labelPageTitle.Location = new Point(24, 24);
            labelPageTitle.Name = "labelPageTitle";
            labelPageTitle.Size = new Size(932, 38);
            labelPageTitle.TabIndex = 0;
            labelPageTitle.Text = "Inventory Dashboard";
            labelPageTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelPageSubtitle
            // 
            labelPageSubtitle.Dock = DockStyle.Top;
            labelPageSubtitle.Font = new Font("Segoe UI", 9.5F);
            labelPageSubtitle.ForeColor = Color.FromArgb(100, 110, 125);
            labelPageSubtitle.Location = new Point(24, 62);
            labelPageSubtitle.Name = "labelPageSubtitle";
            labelPageSubtitle.Size = new Size(932, 26);
            labelPageSubtitle.TabIndex = 1;
            labelPageSubtitle.Text = "Overview of products, suppliers, stock movement and low-stock alerts";
            labelPageSubtitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusStripMain
            // 
            statusStripMain.BackColor = Color.White;
            statusStripMain.Items.AddRange(new ToolStripItem[] { statusLabel, clockLabel });
            statusStripMain.Location = new Point(0, 758);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(1200, 22);
            statusStripMain.TabIndex = 3;
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(1122, 17);
            statusLabel.Spring = true;
            statusLabel.Text = "Ready";
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clockLabel
            // 
            clockLabel.Name = "clockLabel";
            clockLabel.Size = new Size(63, 17);
            clockLabel.Text = "clockLabel";
            // 
            // clockTimer
            // 
            clockTimer.Interval = 1000;
            clockTimer.Tick += clockTimer_Tick;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1240, 740);
            Controls.Add(contentPanel);
            Controls.Add(statusStripMain);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Font = new Font("Segoe UI", 9F);
            MinimumSize = new Size(1080, 640);
            Name = "DashboardForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Management System - Dashboard";
            Load += DashboardForm_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            hamburgerMenu.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            listsPanel.ResumeLayout(false);
            recentTransactionsGroupBox.ResumeLayout(false);
            lowStockGroupBox.ResumeLayout(false);
            cardsTable.ResumeLayout(false);
            productsCard.ResumeLayout(false);
            categoriesCard.ResumeLayout(false);
            suppliersCard.ResumeLayout(false);
            lowStockCard.ResumeLayout(false);
            stockInCard.ResumeLayout(false);
            stockOutCard.ResumeLayout(false);
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel headerPanel;
        private Button hamburgerButton;
        private Button backButton;
        private Panel sidebarPanel;
        private Label sideTitleLabel;
        private Button sideHomeButton;
        private Button sideProductsButton;
        private Button sideCategoriesButton;
        private Button sideSuppliersButton;
        private Button sideStockInButton;
        private Button sideStockOutButton;
        private Button sideAdjustButton;
        private Button sideTransactionsButton;
        private Button sideReportsButton;
        private Button sideLogoutButton;
        private Button headerRefreshButton;
        private Button headerLogoutButton;
        private ContextMenuStrip hamburgerMenu;
        private ToolStripMenuItem fileMenuItem;
        private ToolStripMenuItem loadSampleDataMenuItem;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem manageMenuItem;
        private ToolStripMenuItem productsMenuItem;
        private ToolStripMenuItem categoriesMenuItem;
        private ToolStripMenuItem suppliersMenuItem;
        private ToolStripMenuItem stockInMenuItem;
        private ToolStripMenuItem stockOutMenuItem;
        private ToolStripMenuItem transactionsMenuItem;
        private ToolStripMenuItem reportsMenuItem;
        private Panel contentPanel;
        private Label labelPageTitle;
        private Label labelPageSubtitle;
        private TableLayoutPanel cardsTable;
        private Panel productsCard;
        private Label productsValueLabel;
        private Label productsTitleLabel;
        private Panel categoriesCard;
        private Label categoriesValueLabel;
        private Label categoriesTitleLabel;
        private Panel suppliersCard;
        private Label suppliersValueLabel;
        private Label suppliersTitleLabel;
        private Panel lowStockCard;
        private Label lowStockValueLabel;
        private Label lowStockTitleLabel;
        private Panel stockInCard;
        private Label stockInValueLabel;
        private Label stockInTitleLabel;
        private Panel stockOutCard;
        private Label stockOutValueLabel;
        private Label stockOutTitleLabel;
        private Panel listsPanel;
        private GroupBox lowStockGroupBox;
        private ListView lowStockListView;
        private ColumnHeader lowStockCodeColumn;
        private ColumnHeader lowStockNameColumn;
        private ColumnHeader lowStockCategoryColumn;
        private ColumnHeader lowStockQuantityColumn;
        private ColumnHeader lowStockMinimumColumn;
        private ColumnHeader lowStockReorderColumn;
        private GroupBox recentTransactionsGroupBox;
        private ListView recentTransactionsListView;
        private ColumnHeader transactionIdColumn;
        private ColumnHeader transactionProductColumn;
        private ColumnHeader transactionTypeColumn;
        private ColumnHeader transactionQuantityColumn;
        private ColumnHeader transactionDateColumn;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel statusLabel;
        private ToolStripStatusLabel clockLabel;
        private System.Windows.Forms.Timer clockTimer;
    }
}
