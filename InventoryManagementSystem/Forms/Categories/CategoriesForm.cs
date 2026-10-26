using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Categories
{
    public partial class CategoriesForm : Form
    {
        private readonly CategoryService categoryService;
        private int selectedCategoryId;
        private bool isRefreshingList;

        public CategoriesForm()
            : this(new CategoryService(new InMemoryDataStore()))
        {
        }

        public CategoriesForm(CategoryService categoryService)
        {
            this.categoryService = categoryService;
            InitializeComponent();
        }

        private void CategoriesForm_Load(object sender, EventArgs e)
        {
            ResetForm();
            LoadCategories();
            statusLabel.Text = "Ready. Add a new category or select one to edit.";
        }

        private void CategoriesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void LoadCategories()
        {
            isRefreshingList = true;
            categoriesListView.BeginUpdate();
            categoriesListView.Items.Clear();

            List<Category> categories = categoryService.Search(searchTextBox.Text);

            foreach (Category category in categories)
            {
                ListViewItem row = new ListViewItem(category.Id.ToString());
                row.SubItems.Add(category.Name);
                row.SubItems.Add(category.Description);
                row.SubItems.Add(categoryService.GetProductCount(category.Id).ToString());
                row.Tag = category.Id;
                categoriesListView.Items.Add(row);
            }

            categoriesListView.EndUpdate();
            isRefreshingList = false;

            int totalCategories = categoryService.GetAll().Count;
            countLabel.Text = "Showing " + categories.Count + " of " + totalCategories + " categories";
            UpdateButtonStates();
        }

        private void ResetForm()
        {
            selectedCategoryId = 0;

            isRefreshingList = true;
            categoriesListView.SelectedItems.Clear();
            isRefreshingList = false;

            nameTextBox.Clear();
            descriptionTextBox.Clear();
            validationLabel.Text = string.Empty;
            UpdateButtonStates();
            nameTextBox.Focus();
        }

        private void UpdateButtonStates()
        {
            bool hasSelection = selectedCategoryId > 0;
            deleteButton.Enabled = hasSelection;
            saveButton.Text = hasSelection ? "Update Category" : "Add Category";
        }

        private void SelectCategoryInList(int categoryId)
        {
            foreach (ListViewItem row in categoriesListView.Items)
            {
                if (row.Tag != null && (int)row.Tag == categoryId)
                {
                    row.Selected = true;
                    row.EnsureVisible();
                    return;
                }
            }
        }

        private void categoriesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isRefreshingList)
            {
                return;
            }

            if (categoriesListView.SelectedItems.Count == 0)
            {
                ResetForm();
                return;
            }

            ListViewItem row = categoriesListView.SelectedItems[0];

            if (row.Tag == null)
            {
                return;
            }

            int categoryId = (int)row.Tag;
            Category? category = categoryService.GetById(categoryId);

            if (category == null)
            {
                return;
            }

            selectedCategoryId = category.Id;
            nameTextBox.Text = category.Name;
            descriptionTextBox.Text = category.Description;
            validationLabel.Text = string.Empty;
            UpdateButtonStates();
            statusLabel.Text = "Selected category: " + category.Name;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadCategories();

            if (selectedCategoryId > 0)
            {
                SelectCategoryInList(selectedCategoryId);
            }
        }

        private void clearSearchButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            searchTextBox.Focus();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            statusLabel.Text = "Enter a name and description for the new category.";
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string categoryName = nameTextBox.Text;
            string description = descriptionTextBox.Text;
            bool isNewCategory = selectedCategoryId == 0;

            string? errorMessage;

            if (isNewCategory)
            {
                errorMessage = categoryService.Add(categoryName, description);
            }
            else
            {
                errorMessage = categoryService.Update(selectedCategoryId, categoryName, description);
            }

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int categoryIdToSelect = selectedCategoryId;

            if (isNewCategory)
            {
                Category? createdCategory = categoryService.FindByName(categoryName);

                if (createdCategory != null)
                {
                    categoryIdToSelect = createdCategory.Id;
                }
            }

            if (searchTextBox.Text.Length > 0)
            {
                searchTextBox.Clear();
            }
            else
            {
                LoadCategories();
            }

            if (categoryIdToSelect > 0)
            {
                SelectCategoryInList(categoryIdToSelect);
            }
            else
            {
                ResetForm();
            }

            statusLabel.Text = isNewCategory
                ? "Category added successfully."
                : "Category updated successfully.";
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (selectedCategoryId == 0)
            {
                return;
            }

            DialogResult answer = MessageBox.Show(
                "Are you sure you want to delete the category \"" + nameTextBox.Text + "\"?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (answer != DialogResult.Yes)
            {
                return;
            }

            string? errorMessage = categoryService.Delete(selectedCategoryId);

            if (errorMessage != null)
            {
                validationLabel.Text = errorMessage;
                MessageBox.Show(errorMessage, "Cannot Delete Category", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ResetForm();
            LoadCategories();
            statusLabel.Text = "Category deleted successfully.";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            int categoryIdToKeep = selectedCategoryId;
            LoadCategories();

            if (categoryIdToKeep > 0)
            {
                SelectCategoryInList(categoryIdToKeep);
            }

            statusLabel.Text = "Category list refreshed.";
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            ResetForm();
            statusLabel.Text = "Changes cancelled.";
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
