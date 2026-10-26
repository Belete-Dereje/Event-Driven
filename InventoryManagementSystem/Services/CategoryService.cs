using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Services
{
    public class CategoryService
    {
        private readonly InMemoryDataStore store;

        public CategoryService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public List<Category> GetAll()
        {
            List<Category> categories = new List<Category>(store.Categories);
            categories.Sort(CompareCategories);
            return categories;
        }

        public List<Category> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return GetAll();
            }

            string term = searchText.Trim();
            List<Category> results = new List<Category>();

            foreach (Category category in store.Categories)
            {
                if (category.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    category.Description.Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(category);
                }
            }

            results.Sort(CompareCategories);
            return results;
        }

        public Category? GetById(int id)
        {
            foreach (Category category in store.Categories)
            {
                if (category.Id == id)
                {
                    return category;
                }
            }

            return null;
        }

        public Category? FindByName(string name)
        {
            string normalizedName = NormalizeName(name);

            foreach (Category category in store.Categories)
            {
                if (string.Equals(NormalizeName(category.Name), normalizedName, StringComparison.OrdinalIgnoreCase))
                {
                    return category;
                }
            }

            return null;
        }

        public int GetProductCount(int categoryId)
        {
            int count = 0;

            foreach (Product product in store.Products)
            {
                if (product.CategoryId == categoryId)
                {
                    count++;
                }
            }

            return count;
        }

        public string? Add(string name, string description)
        {
            string? errorMessage = CategoryValidator.Validate(name, description);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            if (FindByName(name) != null)
            {
                return "A category with this name already exists.";
            }

            Category category = new Category();
            category.Id = store.GetNextCategoryId();
            category.Name = NormalizeName(name);
            category.Description = description.Trim();
            store.Categories.Add(category);

            return null;
        }

        public string? Update(int id, string name, string description)
        {
            Category? category = GetById(id);

            if (category == null)
            {
                return "The selected category could not be found.";
            }

            string? errorMessage = CategoryValidator.Validate(name, description);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            Category? duplicate = FindByName(name);

            if (duplicate != null && duplicate.Id != id)
            {
                return "A category with this name already exists.";
            }

            category.Name = NormalizeName(name);
            category.Description = description.Trim();

            return null;
        }

        public string? Delete(int id)
        {
            Category? category = GetById(id);

            if (category == null)
            {
                return "The selected category could not be found.";
            }

            int productCount = GetProductCount(id);

            if (productCount > 0)
            {
                return "This category cannot be deleted because it is used by "
                    + productCount
                    + " product(s). Reassign or remove those products first.";
            }

            store.Categories.Remove(category);
            return null;
        }

        private string NormalizeName(string name)
        {
            string cleanedName = name.Trim();

            while (cleanedName.Contains("  "))
            {
                cleanedName = cleanedName.Replace("  ", " ");
            }

            return cleanedName;
        }

        private int CompareCategories(Category first, Category second)
        {
            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
