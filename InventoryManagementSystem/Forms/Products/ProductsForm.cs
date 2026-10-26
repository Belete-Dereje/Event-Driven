using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Products
{
    public partial class ProductsForm : Form
    {
        private readonly ProductService productService;
        private int selectedProductId;
        private bool isRefreshingList;
        private bool isUpdatingFilters;
        private int sortColumn;
        private bool sortAscending = true;

        public ProductsForm()
            : this(new ProductService(new InMemoryDataStore()))
        {
        }

        public ProductsForm(ProductService productService)
        {
            this.productService = productService;
            InitializeComponent();
        }

        private void ProductsForm_Load(object sender, EventArgs e)
        {
            InitializeLookups();
            ResetForm();
            LoadProducts();
            statusLabel.Text = "Ready. Add a new product or select one to edit.";
        }

        private void InitializeLookups()
        {
            isUpdatingFilters = true;

            unitComboBox.Items.AddRange(ProductUnits.All);
            unitComboBox.SelectedIndex = 0;

            statusComboBox.Items.AddRange(new object[] { "Active", "Inactive" });
            statusComboBox.SelectedIndex = 0;

            categoryComboBox.DisplayMember = "Name";
            categoryComboBox.Items.Clear();

            foreach (Category category in productService.GetCategories())
            {
                categoryComboBox.Items.Add(category);
            }

            if (categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = 0;
            }

            supplierComboBox.DisplayMember = "Name";
            supplierComboBox.Items.Clear();

            foreach (Supplier supplier in productService.GetSuppliers())
            {
                supplierComboBox.Items.Add(supplier);
            }

            if (supplierComboBox.Items.Count > 0)
            {
                supplierComboBox.SelectedIndex = 0;
            }

            categoryFilterComboBox.DisplayMember = "Name";
            categoryFilterComboBox.Items.Clear();
            categoryFilterComboBox.Items.Add(new Category { Id = 0, Name = "All Categories" });

            foreach (Category category in productService.GetCategories())
            {
                categoryFilterComboBox.Items.Add(category);
            }

            categoryFilterComboBox.SelectedIndex = 0;

            supplierFilterComboBox.DisplayMember = "Name";
            supplierFilterComboBox.Items.Clear();
            supplierFilterComboBox.Items.Add(new Supplier { Id = 0, Name = "All Suppliers" });

            foreach (Supplier supplier in productService.GetSuppliers())
            {
                supplierFilterComboBox.Items.Add(supplier);
            }

            supplierFilterComboBox.SelectedIndex = 0;

            statusFilterComboBox.Items.Clear();
            statusFilterComboBox.Items.AddRange(new object[]
            {
                "All Stock Statuses",
                "Active",
                "Inactive",
                "Low Stock"
            });
            statusFilterComboBox.SelectedIndex = 0;

            isUpdatingFilters = false;
        }

        private void LoadProducts()
        {
            isRefreshingList = true;
            productsListView.BeginUpdate();
            productsListView.Items.Clear();

            List<Product> products = productService.Search(
                searchTextBox.Text,
                GetSelectedCategoryId(),
                GetSelectedSupplierId(),
                GetSelectedStatusFilter(),
                IsLowStockFilter());

            foreach (Product product in products)
            {
                ListViewItem row = new ListViewItem(product.Code);
                row.SubItems.Add(product.Name);
                row.SubItems.Add(productService.GetCategoryName(product.CategoryId));
                row.SubItems.Add(productService.GetSupplierName(product.SupplierId));
                row.SubItems.Add(product.PurchaseCost.ToString("N2"));
                row.SubItems.Add(product.SellingPrice.ToString("N2"));
                row.SubItems.Add(product.Quantity.ToString("0.###"));
                row.SubItems.Add(product.Unit);
                row.SubItems.Add(product.MinimumStock.ToString("0.###"));
                row.SubItems.Add(product.Status.ToString());
                row.SubItems.Add(product.Barcode);
                row.SubItems.Add(product.StorageLocation);
                row.SubItems.Add(product.Description);
                row.Tag = product.Id;

                if (product.Status == ProductStatus.Inactive)
                {
                    row.ForeColor = Color.FromArgb(130, 130, 130);
                }
                else if (product.Quantity <= product.MinimumStock)
                {
                    row.ForeColor = Color.FromArgb(180, 95, 6);
                }

                productsListView.Items.Add(row);
            }

            productsListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            productsListView.Sort();
            productsListView.EndUpdate();
            isRefreshingList = false;

            UpdateSortIndicator();

            int totalProducts = productService.Search(string.Empty, 0, 0, null, false).Count;
            countLabel.Text = "Showing " + products.Count + " of " + totalProducts + " products";
            UpdateButtonStates();
        }

        private void UpdateSortIndicator()
        {
            foreach (ColumnHeader column in productsListView.Columns)
            {
                column.Text = column.Text.Replace(" \u25B2", string.Empty).Replace(" \u25BC", string.Empty);
            }

            if (sortColumn >= 0 && sortColumn < productsListView.Columns.Count)
            {
                productsListView.Columns[sortColumn].Text += sortAscending ? " \u25B2" : " \u25BC";
            }
        }

        private void ResetForm()
        {
            selectedProductId = 0;

            isRefreshingList = true;
            productsListView.SelectedItems.Clear();
            isRefreshingList = false;

            codeTextBox.Clear();
            nameTextBox.Clear();
            purchaseCostTextBox.Clear();
            sellingPriceTextBox.Clear();
            quantityTextBox.Clear();
            minimumStockTextBox.Clear();
            descriptionTextBox.Clear();
            barcodeTextBox.Clear();
            storageLocationTextBox.Clear();

            if (categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = 0;
            }

            if (supplierComboBox.Items.Count > 0)
            {
                supplierComboBox.SelectedIndex = 0;
            }

            if (unitComboBox.Items.Count > 0)
            {
                unitComboBox.SelectedIndex = 0;
            }

            if (statusComboBox.Items.Count > 0)
            {
                statusComboBox.SelectedIndex = 0;
            }

            quantityTextBox.ReadOnly = false;
            quantityTextBox.BackColor = Color.White;
            statusComboBox.Enabled = false;
            labelQuantity.Text = "Initial Quantity";
            saveButton.Text = "Add Product";
            cancelButton.Text = "Clear";
            validationLabel.Text = string.Empty;
            UpdateButtonStates();
            codeTextBox.Focus();
        }

        private void LoadProduct(Product product)
        {
            selectedProductId = product.Id;
            codeTextBox.Text = product.Code;
            nameTextBox.Text = product.Name;
            SelectCategory(product.CategoryId);
            SelectSupplier(product.SupplierId);
            SelectUnit(product.Unit);
            purchaseCostTextBox.Text = product.PurchaseCost.ToString("0.00");
            sellingPriceTextBox.Text = product.SellingPrice.ToString("0.00");
            quantityTextBox.Text = product.Quantity.ToString("0.###");
            minimumStockTextBox.Text = product.MinimumStock.ToString("0.###");
            descriptionTextBox.Text = product.Description;
            barcodeTextBox.Text = product.Barcode;
            storageLocationTextBox.Text = product.StorageLocation;
            SelectStatus(product.Status);

            quantityTextBox.ReadOnly = true;
            quantityTextBox.BackColor = Color.FromArgb(236, 239, 242);
            statusComboBox.Enabled = true;
            labelQuantity.Text = "Current Quantity";
            saveButton.Text = "Save Changes";
            cancelButton.Text = "Cancel";
            validationLabel.Text = string.Empty;
            UpdateButtonStates();
            statusLabel.Text = "Selected product: " + product.Name;
        }

        private void SelectCategory(int categoryId)
        {
            for (int index = 0; index < categoryComboBox.Items.Count; index++)
            {
                if (categoryComboBox.Items[index] is Category category && category.Id == categoryId)
                {
                    categoryComboBox.SelectedIndex = index;
                    return;
                }
            }

            if (categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = 0;
            }
        }

        private void SelectSupplier(int supplierId)
        {
            for (int index = 0; index < supplierComboBox.Items.Count; index++)
            {
                if (supplierComboBox.Items[index] is Supplier supplier && supplier.Id == supplierId)
                {
                    supplierComboBox.SelectedIndex = index;
                    return;
                }
            }

            if (supplierComboBox.Items.Count > 0)
            {
                supplierComboBox.SelectedIndex = 0;
            }
        }

        private void SelectUnit(string unit)
        {
            int index = unitComboBox.FindStringExact(unit);

            if (index >= 0)
            {
                unitComboBox.SelectedIndex = index;
            }
            else if (unitComboBox.Items.Count > 0)
            {
                unitComboBox.SelectedIndex = 0;
            }
        }

        private void SelectStatus(ProductStatus status)
        {
            int index = statusComboBox.FindStringExact(status.ToString());

            if (index >= 0)
            {
                statusComboBox.SelectedIndex = index;
            }
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedProductId > 0;
            deleteButton.Enabled = hasSelection;
            statusButton.Enabled = hasSelection;

            Product? product = hasSelection ? productService.GetById(selectedProductId) : null;
            statusButton.Text = product != null && product.Status == ProductStatus.Active
                ? "Mark Inactive"
                : "Mark Active";
        }

        private void SelectProductInList(int productId)
        {
            foreach (ListViewItem row in productsListView.Items)
            {
                if (row.Tag != null && (int)row.Tag == productId)
                {
                    row.Selected = true;
                    row.EnsureVisible();
                    return;
                }
            }
        }

        private int GetSelectedCategoryId()
        {
            if (categoryFilterComboBox.SelectedItem is Category category)
            {
                return category.Id;
            }

            return 0;
        }

        private int GetSelectedSupplierId()
        {
            if (supplierFilterComboBox.SelectedItem is Supplier supplier)
            {
                return supplier.Id;
            }

            return 0;
        }

        private ProductStatus? GetSelectedStatusFilter()
        {
            if (statusFilterComboBox.SelectedIndex == 1)
            {
                return ProductStatus.Active;
            }

            if (statusFilterComboBox.SelectedIndex == 2)
            {
                return ProductStatus.Inactive;
            }

            return null;
        }

        private bool IsLowStockFilter()
        {
            return statusFilterComboBox.SelectedIndex == 3;
        }

        private bool TryReadDecimal(TextBox textBox, string fieldName, out decimal value)
        {
            string text = textBox.Text.Trim();

            if (text.Length == 0)
            {
                value = 0;
                return true;
            }

            if (decimal.TryParse(text, NumberStyles.Number, CultureInfo.CurrentCulture, out value))
            {
                return true;
            }

            string errorMessage = fieldName + " must be a valid number.";
            validationLabel.Text = errorMessage;
            MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox.Focus();
            return false;
        }

        private void productsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRefreshingList)
            {
                return;
            }

            if (productsListView.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem row = productsListView.SelectedItems[0];

            if (row.Tag == null)
            {
                return;
            }

            Product? product = productService.GetById((int)row.Tag);

            if (product == null)
            {
                ResetForm();
                return;
            }

            LoadProduct(product);
        }

        private void productsListView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == sortColumn)
            {
                sortAscending = !sortAscending;
            }
            else
            {
                sortColumn = e.Column;
                sortAscending = true;
            }

            productsListView.ListViewItemSorter = new ListViewItemComparer(sortColumn, sortAscending);
            productsListView.Sort();
            UpdateSortIndicator();
            statusLabel.Text = "Sorted by " + productsListView.Columns[sortColumn].Text.TrimEnd(' ', '\u25B2', '\u25BC') + ".";
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (isUpdatingFilters)
            {
                return;
            }

            LoadProducts();

            if (selectedProductId > 0)
            {
                SelectProductInList(selectedProductId);
            }
        }

        private void filterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingFilters)
            {
                return;
            }

            LoadProducts();

            if (selectedProductId > 0)
            {
                SelectProductInList(selectedProductId);
            }
        }

        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            searchTextBox.Focus();
        }

        private void clearFiltersButton_Click(object sender, EventArgs e)
        {
            isUpdatingFilters = true;
            searchTextBox.Clear();
            categoryFilterComboBox.SelectedIndex = 0;
            supplierFilterComboBox.SelectedIndex = 0;
            statusFilterComboBox.SelectedIndex = 0;
            isUpdatingFilters = false;

            LoadProducts();

            if (selectedProductId > 0)
            {
                SelectProductInList(selectedProductId);
            }

            statusLabel.Text = "Search and filters cleared.";
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            statusLabel.Text = "Enter the details for the new product.";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!TryReadDecimal(purchaseCostTextBox, "Purchase cost", out decimal purchaseCost) ||
                !TryReadDecimal(sellingPriceTextBox, "Selling price", out decimal sellingPrice) ||
                !TryReadDecimal(quantityTextBox, "Quantity", out decimal initialQuantity) ||
                !TryReadDecimal(minimumStockTextBox, "Minimum stock", out decimal minimumStock))
            {
                return;
            }

            bool isNewProduct = selectedProductId == 0;
            ProductStatus status = string.Equals(
                statusComboBox.SelectedItem?.ToString(),
                "Inactive",
                StringComparison.OrdinalIgnoreCase)
                ? ProductStatus.Inactive
                : ProductStatus.Active;

            Product draft = new Product();
            draft.Id = selectedProductId;
            draft.Code = codeTextBox.Text;
            draft.Name = nameTextBox.Text;
            draft.CategoryId = categoryComboBox.SelectedItem is Category category ? category.Id : 0;
            draft.SupplierId = supplierComboBox.SelectedItem is Supplier supplier ? supplier.Id : 0;
            draft.Unit = unitComboBox.SelectedItem?.ToString() ?? string.Empty;
            draft.PurchaseCost = purchaseCost;
            draft.SellingPrice = sellingPrice;
            draft.MinimumStock = minimumStock;
            draft.Status = isNewProduct ? ProductStatus.Active : status;
            draft.Description = descriptionTextBox.Text;
            draft.Barcode = barcodeTextBox.Text;
            draft.StorageLocation = storageLocationTextBox.Text;

            if (sellingPrice < purchaseCost)
            {
                DialogResult answer = MessageBox.Show(
                    "The selling price is lower than the purchase cost. Do you want to continue?",
                    "Price Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (answer != DialogResult.Yes)
                {
                    return;
                }
            }

            string? errorMessage;
            int productIdToSelect;

            if (isNewProduct)
            {
                errorMessage = productService.Add(draft, initialQuantity);
                productIdToSelect = draft.Id;
            }
            else
            {
                errorMessage = productService.Update(draft);
                productIdToSelect = selectedProductId;
            }

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedProductId = productIdToSelect;

            if (searchTextBox.Text.Length > 0)
            {
                isUpdatingFilters = true;
                searchTextBox.Clear();
                isUpdatingFilters = false;
            }

            LoadProducts();
            SelectProductInList(productIdToSelect);

            Product? savedProduct = productService.GetById(productIdToSelect);

            if (savedProduct != null)
            {
                LoadProduct(savedProduct);
            }

            statusLabel.Text = isNewProduct
                ? "Product added successfully."
                : "Product updated successfully.";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Are you sure you want to delete the product \"" + nameTextBox.Text + "\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            string? errorMessage = productService.Delete(selectedProductId);

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Cannot Delete Product", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetForm();
            LoadProducts();
            statusLabel.Text = "Product deleted successfully.";
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                return;
            }

            Product? product = productService.GetById(selectedProductId);

            if (product == null)
            {
                ResetForm();
                return;
            }

            ProductStatus newStatus = product.Status == ProductStatus.Active
                ? ProductStatus.Inactive
                : ProductStatus.Active;

            DialogResult answer = MessageBox.Show(
                "Mark product \"" + product.Name + "\" as " + newStatus + "?",
                "Change Product Status",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            string? errorMessage = productService.SetStatus(selectedProductId, newStatus);

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Status Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoadProducts();
            SelectProductInList(selectedProductId);

            Product? updatedProduct = productService.GetById(selectedProductId);

            if (updatedProduct != null)
            {
                LoadProduct(updatedProduct);
            }

            statusLabel.Text = "Product marked as " + newStatus + ".";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            int productIdToKeep = selectedProductId;
            InitializeLookups();
            LoadProducts();

            if (productIdToKeep > 0)
            {
                SelectProductInList(productIdToKeep);
            }

            statusLabel.Text = "Product list refreshed.";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (selectedProductId == 0)
            {
                ResetForm();
                statusLabel.Text = "Form cleared.";
                return;
            }

            Product? product = productService.GetById(selectedProductId);

            if (product != null)
            {
                LoadProduct(product);
                statusLabel.Text = "Changes cancelled.";
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}
