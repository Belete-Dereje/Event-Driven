using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Services
{
    public class ProductService
    {
        private readonly InMemoryDataStore store;

        public ProductService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = new List<Category>(store.Categories);
            categories.Sort(CompareCategories);
            return categories;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>(store.Suppliers);
            suppliers.Sort(CompareSuppliers);
            return suppliers;
        }

        public List<Product> Search(string searchText, int categoryId, ProductStatus? status, bool lowStockOnly)
        {
            return Search(searchText, categoryId, 0, status, lowStockOnly);
        }

        public List<Product> Search(string searchText, int categoryId, int supplierId, ProductStatus? status, bool lowStockOnly)
        {
            string term = searchText.Trim();
            List<Product> results = new List<Product>();

            foreach (Product product in store.Products)
            {
                if (categoryId > 0 && product.CategoryId != categoryId)
                {
                    continue;
                }

                if (supplierId > 0 && product.SupplierId != supplierId)
                {
                    continue;
                }

                if (status != null && product.Status != status)
                {
                    continue;
                }

                if (lowStockOnly &&
                    (product.Status != ProductStatus.Active || product.Quantity > product.MinimumStock))
                {
                    continue;
                }

                if (term.Length > 0 &&
                    !product.Code.Contains(term, StringComparison.OrdinalIgnoreCase) &&
                    !product.Name.Contains(term, StringComparison.OrdinalIgnoreCase) &&
                    !product.Barcode.Contains(term, StringComparison.OrdinalIgnoreCase) &&
                    !GetSupplierName(product.SupplierId).Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                results.Add(product);
            }

            results.Sort(CompareProducts);
            return results;
        }

        public Product? GetById(int id)
        {
            foreach (Product product in store.Products)
            {
                if (product.Id == id)
                {
                    return product;
                }
            }

            return null;
        }

        public Product? FindByCode(string code)
        {
            string cleanCode = code.Trim();

            foreach (Product product in store.Products)
            {
                if (string.Equals(product.Code.Trim(), cleanCode, StringComparison.OrdinalIgnoreCase))
                {
                    return product;
                }
            }

            return null;
        }

        public string GetCategoryName(int categoryId)
        {
            foreach (Category category in store.Categories)
            {
                if (category.Id == categoryId)
                {
                    return category.Name;
                }
            }

            return "Uncategorized";
        }

        public string GetSupplierName(int supplierId)
        {
            foreach (Supplier supplier in store.Suppliers)
            {
                if (supplier.Id == supplierId)
                {
                    return supplier.Name;
                }
            }

            return "Unassigned";
        }

        public int GetTransactionCount(int productId)
        {
            int count = 0;

            foreach (StockTransaction transaction in store.Transactions)
            {
                if (transaction.ProductId == productId)
                {
                    count++;
                }
            }

            return count;
        }

        public string? Add(Product product, decimal initialQuantity)
        {
            string? errorMessage = ProductValidator.Validate(product, initialQuantity);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            if (!CategoryExists(product.CategoryId))
            {
                return "The selected category could not be found.";
            }

            if (!SupplierExists(product.SupplierId))
            {
                return "The selected supplier could not be found.";
            }

            if (FindByCode(product.Code) != null)
            {
                return "A product with this code already exists.";
            }

            product.Id = store.GetNextProductId();
            product.Code = product.Code.Trim();
            product.Name = product.Name.Trim();
            product.Unit = product.Unit.Trim();
            product.Description = product.Description.Trim();
            product.Barcode = product.Barcode.Trim();
            product.StorageLocation = product.StorageLocation.Trim();
            product.Quantity = initialQuantity;
            store.Products.Add(product);

            if (initialQuantity != 0)
            {
                StockTransaction transaction = new StockTransaction();
                transaction.Id = store.GetNextTransactionId();
                transaction.ProductId = product.Id;
                transaction.Type = TransactionType.OpeningBalance;
                transaction.Quantity = initialQuantity;
                transaction.Date = DateTime.Now;
                transaction.UnitCost = product.PurchaseCost;
                transaction.SupplierId = product.SupplierId;
                transaction.Notes = "Opening stock";
                store.Transactions.Add(transaction);
            }

            return null;
        }

        public string? Update(Product product)
        {
            Product? existingProduct = GetById(product.Id);

            if (existingProduct == null)
            {
                return "The selected product could not be found.";
            }

            string? errorMessage = ProductValidator.Validate(product, existingProduct.Quantity, "Current quantity");

            if (errorMessage != null)
            {
                return errorMessage;
            }

            if (!CategoryExists(product.CategoryId))
            {
                return "The selected category could not be found.";
            }

            if (!SupplierExists(product.SupplierId))
            {
                return "The selected supplier could not be found.";
            }

            Product? duplicate = FindByCode(product.Code);

            if (duplicate != null && duplicate.Id != product.Id)
            {
                return "A product with this code already exists.";
            }

            existingProduct.Code = product.Code.Trim();
            existingProduct.Name = product.Name.Trim();
            existingProduct.CategoryId = product.CategoryId;
            existingProduct.SupplierId = product.SupplierId;
            existingProduct.Unit = product.Unit.Trim();
            existingProduct.PurchaseCost = product.PurchaseCost;
            existingProduct.SellingPrice = product.SellingPrice;
            existingProduct.MinimumStock = product.MinimumStock;
            existingProduct.Status = product.Status;
            existingProduct.Description = product.Description.Trim();
            existingProduct.Barcode = product.Barcode.Trim();
            existingProduct.StorageLocation = product.StorageLocation.Trim();

            return null;
        }

        public string? SetStatus(int id, ProductStatus status)
        {
            Product? product = GetById(id);

            if (product == null)
            {
                return "The selected product could not be found.";
            }

            product.Status = status;
            return null;
        }

        public string? Delete(int id)
        {
            Product? product = GetById(id);

            if (product == null)
            {
                return "The selected product could not be found.";
            }

            int transactionCount = GetTransactionCount(id);

            if (transactionCount > 0)
            {
                return "This product cannot be deleted because it has "
                    + transactionCount
                    + " transaction(s). Mark it Inactive instead.";
            }

            store.Products.Remove(product);
            return null;
        }

        private bool CategoryExists(int categoryId)
        {
            foreach (Category category in store.Categories)
            {
                if (category.Id == categoryId)
                {
                    return true;
                }
            }

            return false;
        }

        private bool SupplierExists(int supplierId)
        {
            foreach (Supplier supplier in store.Suppliers)
            {
                if (supplier.Id == supplierId)
                {
                    return true;
                }
            }

            return false;
        }

        private int CompareCategories(Category first, Category second)
        {
            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }

        private int CompareSuppliers(Supplier first, Supplier second)
        {
            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }

        private int CompareProducts(Product first, Product second)
        {
            return string.Compare(first.Code, second.Code, StringComparison.OrdinalIgnoreCase);
        }
    }
}
