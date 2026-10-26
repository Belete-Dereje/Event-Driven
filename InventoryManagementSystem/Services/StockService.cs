using InventoryManagementSystem.Data;
using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Services
{
    public class StockService
    {
        private readonly InMemoryDataStore store;

        public StockService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public List<Product> GetActiveProducts()
        {
            List<Product> products = new List<Product>();
            foreach (Product product in store.Products)
            {
                if (product.Status == ProductStatus.Active)
                {
                    products.Add(product);
                }
            }
            products.Sort((a, b) => string.Compare(a.Code, b.Code, StringComparison.OrdinalIgnoreCase));
            return products;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>(store.Suppliers);
            suppliers.Sort((a, b) => string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));
            return suppliers;
        }

        public string? StockIn(int productId, decimal quantity, int? supplierId, decimal unitCost, DateTime date, string notes)
        {
            if (quantity <= 0)
            {
                return "Quantity must be greater than zero.";
            }

            if (date.Date > DateTime.Today)
            {
                return "The transaction date cannot be in the future.";
            }

            Product? product = GetProduct(productId);
            if (product == null)
            {
                return "Product not found.";
            }

            if (product.Status != ProductStatus.Active)
            {
                return "Only active products can receive stock.";
            }

            string? validationError = StockTransactionValidator.Validate(product, quantity, unitCost, "Unit cost", notes);
            if (validationError != null)
            {
                return validationError;
            }

            if (supplierId.HasValue && GetSupplier(supplierId.Value) == null)
            {
                return "Supplier not found.";
            }

            StockTransaction transaction = new StockTransaction
            {
                Id = store.GetNextTransactionId(),
                ProductId = productId,
                Type = TransactionType.StockIn,
                Quantity = quantity,
                Date = date.Date,
                SupplierId = supplierId,
                UnitCost = unitCost >= 0 ? unitCost : product.PurchaseCost,
                Reason = AdjustmentReason.None,
                Notes = notes.Trim()
            };

            store.Transactions.Add(transaction);
            product.Quantity += quantity;

            return null;
        }

        public string? StockOut(int productId, decimal quantity, DateTime date, string notes)
        {
            if (quantity <= 0)
            {
                return "Quantity must be greater than zero.";
            }

            if (date.Date > DateTime.Today)
            {
                return "The transaction date cannot be in the future.";
            }

            Product? product = GetProduct(productId);
            if (product == null)
            {
                return "Product not found.";
            }

            if (product.Status != ProductStatus.Active)
            {
                return "Only active products can have stock issued.";
            }

            string? validationError = StockTransactionValidator.Validate(product, quantity, product.SellingPrice, "Selling price", notes);
            if (validationError != null)
            {
                return validationError;
            }

            if (quantity > product.Quantity)
            {
                return "Insufficient stock. Available quantity is " + product.Quantity.ToString("0.###") + ".";
            }

            StockTransaction transaction = new StockTransaction
            {
                Id = store.GetNextTransactionId(),
                ProductId = productId,
                Type = TransactionType.StockOut,
                Quantity = -quantity,
                Date = date.Date,
                SupplierId = null,
                UnitPrice = product.SellingPrice,
                Reason = AdjustmentReason.None,
                Notes = notes.Trim()
            };

            store.Transactions.Add(transaction);
            product.Quantity -= quantity;

            return null;
        }

        public string? Adjust(int productId, decimal quantity, bool isIncrease, AdjustmentReason reason, DateTime date, string notes)
        {
            if (quantity <= 0)
            {
                return "Quantity must be greater than zero.";
            }

            if (reason == AdjustmentReason.None)
            {
                return "A reason is required for every adjustment.";
            }

            Product? product = GetProduct(productId);
            if (product == null)
            {
                return "Product not found.";
            }

            if (product.Status != ProductStatus.Active)
            {
                return "Only active products can be adjusted.";
            }

            if (date.Date > DateTime.Today)
            {
                return "The adjustment date cannot be in the future.";
            }

            if (!ProductUnits.AllowsDecimal(product.Unit) && quantity != decimal.Truncate(quantity))
            {
                return "Quantity must be a whole number for the unit \"" + product.Unit + "\".";
            }

            if (!isIncrease && quantity > product.Quantity)
            {
                return "Adjustment would reduce the quantity below zero. Available quantity is " + product.Quantity.ToString("0.###") + ".";
            }

            StockTransaction transaction = new StockTransaction
            {
                Id = store.GetNextTransactionId(),
                ProductId = productId,
                Type = TransactionType.Adjustment,
                Quantity = isIncrease ? quantity : -quantity,
                Date = date.Date,
                Reason = reason,
                Notes = notes.Trim()
            };

            store.Transactions.Add(transaction);
            product.Quantity += isIncrease ? quantity : -quantity;

            return null;
        }

        private Product? GetProduct(int productId)
        {
            foreach (Product product in store.Products)
            {
                if (product.Id == productId) return product;
            }
            return null;
        }

        private Supplier? GetSupplier(int supplierId)
        {
            foreach (Supplier supplier in store.Suppliers)
            {
                if (supplier.Id == supplierId) return supplier;
            }
            return null;
        }
    }
}
