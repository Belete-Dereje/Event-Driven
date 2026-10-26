using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Forms.Categories;
using InventoryManagementSystem.Forms.Products;
using InventoryManagementSystem.Forms.Reports;
using InventoryManagementSystem.Forms.StockAdjust;
using InventoryManagementSystem.Forms.StockIn;
using InventoryManagementSystem.Forms.StockOut;
using InventoryManagementSystem.Forms.Suppliers;
using InventoryManagementSystem.Forms.Transactions;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Dashboard
{
    public partial class DashboardForm : Form
    {
        private readonly DashboardService dashboardService;
        private readonly User currentUser;
        private readonly Stack<Control> navigationHistory = new Stack<Control>();
        private Control? currentView;

        public DashboardForm()
            : this(new DashboardService(new InMemoryDataStore()), new User { Username = "admin", Role = UserRole.Admin, FullName = "System Administrator" })
        {
        }

        public DashboardForm(DashboardService dashboardService, User user)
        {
            this.dashboardService = dashboardService;
            this.currentUser = user;
            InitializeComponent();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            try
            {
                clockTimer.Start();
                UpdateClock();
                ApplyRolePermissions();
                ShowHomeView();
                statusLabel.Text = "Logged in as " + currentUser.FullName + " (" + currentUser.Role + ")";
                this.Text = "Inventory Management System - " + currentUser.Role;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Dashboard Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRolePermissions()
        {
            // All users (Admin and standard users) have full access to all modules
            sideProductsButton.Visible = true;
            sideCategoriesButton.Visible = true;
            sideSuppliersButton.Visible = true;
            sideStockInButton.Visible = true;
            sideStockOutButton.Visible = true;
            sideAdjustButton.Visible = true;
            sideTransactionsButton.Visible = true;
            sideReportsButton.Visible = true;
            sideStockInButton.Text = "Stock In";
            sideStockOutButton.Text = "Stock Out";

            productsMenuItem.Visible = true;
            categoriesMenuItem.Visible = true;
            suppliersMenuItem.Visible = true;
            stockInMenuItem.Visible = true;
            stockOutMenuItem.Visible = true;
            transactionsMenuItem.Visible = true;
            reportsMenuItem.Visible = true;
        }

        private void ShowHomeView()
        {
            currentView = null;
            backButton.Visible = false;
            labelPageTitle.Text = "Inventory Dashboard";
            labelPageSubtitle.Text = "Overview of products, suppliers, stock movement and low-stock alerts";
            contentPanel.Controls.Clear();
            contentPanel.Padding = new Padding(24);
            contentPanel.Controls.Add(listsPanel);
            contentPanel.Controls.Add(cardsTable);
            contentPanel.Controls.Add(labelPageSubtitle);
            contentPanel.Controls.Add(labelPageTitle);
            SetActiveNavButton(sideHomeButton);
            RefreshDashboard();
        }

        private void RefreshDashboard()
        {
            DashboardSummary summary = dashboardService.GetSummary();

            lowStockGroupBox.Text = "Low Stock Products (" + summary.LowStockCount + ")";
            recentTransactionsGroupBox.Text = "Recent Transactions (" + summary.RecentTransactions.Count + ")";

            productsValueLabel.Text = summary.TotalProducts.ToString();
            categoriesValueLabel.Text = summary.TotalCategories.ToString();
            suppliersValueLabel.Text = summary.TotalSuppliers.ToString();
            lowStockValueLabel.Text = summary.LowStockCount.ToString();
            stockInValueLabel.Text = summary.StockInToday + " / " + summary.StockInTotal;
            stockOutValueLabel.Text = summary.StockOutToday + " / " + summary.StockOutTotal;

            lowStockListView.Items.Clear();

            foreach (LowStockItem item in summary.LowStockItems)
            {
                ListViewItem row = new ListViewItem(item.Code);
                row.SubItems.Add(item.Name);
                row.SubItems.Add(item.Category);
                row.SubItems.Add(item.Quantity.ToString("0.##"));
                row.SubItems.Add(item.MinimumStock.ToString("0.##"));
                row.SubItems.Add(item.SuggestedReorder.ToString("0.##"));
                row.ForeColor = Color.FromArgb(192, 57, 43);
                lowStockListView.Items.Add(row);
            }

            recentTransactionsListView.Items.Clear();

            foreach (TransactionListItem item in summary.RecentTransactions)
            {
                ListViewItem row = new ListViewItem(item.Id.ToString());
                row.SubItems.Add(item.ProductName);
                row.SubItems.Add(item.TypeName);
                row.SubItems.Add(item.Quantity.ToString("0.##"));
                row.SubItems.Add(item.Date.ToString("dd MMM yyyy"));
                recentTransactionsListView.Items.Add(row);
            }
        }

        private void hamburgerButton_Click(object sender, EventArgs e)
        {
            hamburgerMenu.Show(hamburgerButton, new Point(0, hamburgerButton.Height));
        }

        private void homeSideButton_Click(object sender, EventArgs e)
        {
            ShowHomeView();
            statusLabel.Text = "Dashboard view.";
        }

        private void adjustmentsButton_Click(object sender, EventArgs e)
        {
            StockService stockService = new StockService(dashboardService.Store);
            StockAdjustmentForm adjustmentForm = new StockAdjustmentForm(stockService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            adjustmentForm.Show();
            ShowView(adjustmentForm, "Stock Adjustments", "Correct inventory quantities with a reason (damaged, expired, lost, returned)", sideAdjustButton);
            RefreshDashboard();
            statusLabel.Text = "Stock Adjustments opened.";
        }

        private void clockTimer_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            clockLabel.Text = DateTime.Now.ToString("dd MMM yyyy  hh:mm:ss tt");
        }

        private void lowStockListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lowStockListView.SelectedItems.Count == 0)
            {
                return;
            }

            statusLabel.Text = "Selected low-stock product: " + lowStockListView.SelectedItems[0].Text;
        }

        private void recentTransactionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (recentTransactionsListView.SelectedItems.Count == 0)
            {
                return;
            }

            statusLabel.Text = "Selected transaction: " + recentTransactionsListView.SelectedItems[0].Text;
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            RefreshDashboard();
            statusLabel.Text = "Dashboard refreshed at " + DateTime.Now.ToShortTimeString();
        }

        private void loadSampleDataMenuItem_Click(object sender, EventArgs e)
        {
            dashboardService.LoadSampleData();
            if (currentView == null)
            {
                RefreshDashboard();
            }
            statusLabel.Text = "Sample data loaded successfully.";
            MessageBox.Show(
                "Sample categories, suppliers, products and transactions have been loaded into memory.",
                "Sample Data",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private static readonly Color NavActiveBackColor = Color.FromArgb(44, 120, 200);
        private static readonly Color NavActiveForeColor = Color.White;
        private static readonly Color NavInactiveBackColor = Color.FromArgb(21, 45, 82);
        private static readonly Color NavInactiveForeColor = Color.FromArgb(205, 216, 229);

        private void SetActiveNavButton(Button? activeButton)
        {
            Button[] navButtons = new Button[]
            {
                sideHomeButton,
                sideProductsButton,
                sideCategoriesButton,
                sideSuppliersButton,
                sideStockInButton,
                sideStockOutButton,
                sideAdjustButton,
                sideTransactionsButton,
                sideReportsButton
            };

            foreach (Button btn in navButtons)
            {
                if (btn == activeButton)
                {
                    btn.BackColor = NavActiveBackColor;
                    btn.ForeColor = NavActiveForeColor;
                }
                else
                {
                    btn.BackColor = NavInactiveBackColor;
                    btn.ForeColor = NavInactiveForeColor;
                }
            }
        }

        private void UpdateNavFromView(Control? view)
        {
            if (view is ProductsForm)
                SetActiveNavButton(sideProductsButton);
            else if (view is CategoriesForm)
                SetActiveNavButton(sideCategoriesButton);
            else if (view is SuppliersForm)
                SetActiveNavButton(sideSuppliersButton);
            else if (view is StockInForm)
                SetActiveNavButton(sideStockInButton);
            else if (view is StockOutForm)
                SetActiveNavButton(sideStockOutButton);
            else if (view is StockAdjustmentForm)
                SetActiveNavButton(sideAdjustButton);
            else if (view is TransactionsForm)
                SetActiveNavButton(sideTransactionsButton);
            else if (view is ReportsForm)
                SetActiveNavButton(sideReportsButton);
            else
                SetActiveNavButton(sideHomeButton);
        }

        private void ShowView(Control view, string title, string subtitle, Button? navButton = null)
        {
            if (currentView != null)
            {
                navigationHistory.Push(currentView);
            }
            else
            {
                navigationHistory.Push(GetHomeViewSnapshot());
            }

            currentView = view;
            contentPanel.Controls.Clear();
            contentPanel.Padding = new Padding(0);
            view.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(view);
            backButton.Visible = navigationHistory.Count > 0;
            labelPageTitle.Text = title;
            labelPageSubtitle.Text = subtitle;

            if (navButton != null)
            {
                SetActiveNavButton(navButton);
            }
            else
            {
                UpdateNavFromView(view);
            }

            if (view is Form childForm)
            {
                childForm.FormClosed += (s, e) =>
                {
                    if (currentView == childForm)
                    {
                        backButton_Click(this, EventArgs.Empty);
                    }
                };
            }
        }

        private Control GetHomeViewSnapshot()
        {
            Panel snapshot = new Panel { Dock = DockStyle.Fill };
            snapshot.Controls.Add(listsPanel);
            snapshot.Controls.Add(cardsTable);
            snapshot.Controls.Add(labelPageSubtitle);
            snapshot.Controls.Add(labelPageTitle);
            return snapshot;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            if (navigationHistory.Count == 0)
            {
                ShowHomeView();
                return;
            }

            Control previous = navigationHistory.Pop();
            contentPanel.Controls.Clear();
            previous.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(previous);

            if (previous is Panel)
            {
                currentView = null;
                contentPanel.Padding = new Padding(24);
                labelPageTitle.Text = "Inventory Dashboard";
                labelPageSubtitle.Text = "Overview of products, suppliers, stock movement and low-stock alerts";
                SetActiveNavButton(sideHomeButton);
                RefreshDashboard();
                navigationHistory.Clear();
                backButton.Visible = false;
                return;
            }

            currentView = previous;
            contentPanel.Padding = new Padding(0);
            backButton.Visible = navigationHistory.Count > 0;
            labelPageTitle.Text = "Inventory Management";
            labelPageSubtitle.Text = "";
            UpdateNavFromView(previous);
        }

        private Control GetHomeViewMarker()
        {
            return contentPanel;
        }

        private void productsButton_Click(object sender, EventArgs e)
        {
            ProductService productService = new ProductService(dashboardService.Store);
            ProductsForm productsForm = new ProductsForm(productService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            productsForm.Show();
            ShowView(productsForm, "Products", "Manage product catalog, pricing and stock levels", sideProductsButton);
            RefreshDashboard();
            statusLabel.Text = "Product management opened.";
        }

        private void categoriesButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService(dashboardService.Store);
            CategoriesForm categoriesForm = new CategoriesForm(categoryService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            categoriesForm.Show();
            ShowView(categoriesForm, "Categories", "Organize products by category", sideCategoriesButton);
            RefreshDashboard();
            statusLabel.Text = "Category management opened.";
        }

        private void suppliersButton_Click(object sender, EventArgs e)
        {
            SupplierService supplierService = new SupplierService(dashboardService.Store);
            SuppliersForm suppliersForm = new SuppliersForm(supplierService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            suppliersForm.Show();
            ShowView(suppliersForm, "Suppliers", "Manage supplier information", sideSuppliersButton);
            RefreshDashboard();
            statusLabel.Text = "Supplier management opened.";
        }

        private void stockInButton_Click(object sender, EventArgs e)
        {
            StockService stockService = new StockService(dashboardService.Store);
            StockInForm stockInForm = new StockInForm(stockService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            stockInForm.Show();
            ShowView(stockInForm, "Stock In", "Receive goods into inventory", sideStockInButton);
            RefreshDashboard();
            statusLabel.Text = "Stock In opened.";
        }

        private void stockOutButton_Click(object sender, EventArgs e)
        {
            StockService stockService = new StockService(dashboardService.Store);
            StockOutForm stockOutForm = new StockOutForm(stockService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            stockOutForm.Show();
            ShowView(stockOutForm, "Stock Out", "Issue goods from inventory", sideStockOutButton);
            RefreshDashboard();
            statusLabel.Text = "Stock Out opened.";
        }

        private void transactionsButton_Click(object sender, EventArgs e)
        {
            TransactionService transactionService = new TransactionService(dashboardService.Store);
            TransactionsForm transactionsForm = new TransactionsForm(transactionService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            transactionsForm.Show();
            ShowView(transactionsForm, "Transactions", "View transaction history", sideTransactionsButton);
            RefreshDashboard();
            statusLabel.Text = "Transactions opened.";
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            ReportService reportService = new ReportService(dashboardService.Store);
            ReportsForm reportsForm = new ReportsForm(reportService)
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };
            reportsForm.Show();
            ShowView(reportsForm, "Reports", "Inventory reports and summaries", sideReportsButton);
            statusLabel.Text = "Reports opened.";
        }

        private void OpenModule(string moduleName)
        {
            statusLabel.Text = moduleName + " screen is not available yet.";
            MessageBox.Show(
                moduleName + " screen will be added in the next step.",
                "Module Not Ready",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void logoutButton_Click(object? sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Are you sure you want to log out and return to the home screen?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Close();
            }
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            logoutButton_Click(sender, e);
        }
    }
}
