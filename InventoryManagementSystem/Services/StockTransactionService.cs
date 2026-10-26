using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Services
{
    public class StockTransactionService
    {
        private readonly InMemoryDataStore store;

        public StockTransactionService(InMemoryDataStore store)
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

            products.Sort(CompareProducts);
            return products;
        }

        public List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>(store.Suppliers);
            suppliers.Sort(CompareSuppliers);
            return suppliers;
        }

        public Product? GetProductById(int productId)
        {
            foreach (Product product in store.Products)
            {
                if (product.Id == productId)
                {
                    return product;
                }
            }

            return null;
        }

        public string? RecordStockIn(
            int productId,
            decimal quantity,
            DateTime date,
            int? supplierId,
            decimal unitCost,
            string notes)
        {
            Product? product = GetProductById(productId);

            if (product == null)
            {
                return "The selected product could not be found.";
            }

            if (product.Status != ProductStatus.Active)
            {
                return "Stock cannot be received for an inactive product.";
            }

            if (supplierId.HasValue && !SupplierExists(supplierId.Value))
            {
                return "The selected supplier could not be found.";
            }

            string? errorMessage = StockTransactionValidator.Validate(
                product,
                quantity,
                unitCost,
                "Unit purchase cost",
                notes);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            StockTransaction transaction = new StockTransaction();
            transaction.Id = store.GetNextTransactionId();
            transaction.ProductId = product.Id;
            transaction.Type = TransactionType.StockIn;
            transaction.Quantity = quantity;
            transaction.Date = date;
            transaction.UnitCost = unitCost;
            transaction.SupplierId = supplierId;
            transaction.Notes = notes.Trim();
            store.Transactions.Add(transaction);

            product.Quantity += quantity;
            return null;
        }

        public string? RecordStockOut(
            int productId,
            decimal quantity,
            DateTime date,
            decimal unitPrice,
            string notes)
        {
            Product? product = GetProductById(productId);

            if (product == null)
            {
                return "The selected product could not be found.";
            }

            if (product.Status != ProductStatus.Active)
            {
                return "Stock cannot be issued for an inactive product.";
            }

            string? errorMessage = StockTransactionValidator.Validate(
                product,
                quantity,
                unitPrice,
                "Selling price",
                notes);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            if (quantity > product.Quantity)
            {
                return "Only "
                    + product.Quantity.ToString("0.###")
                    + " "
                    + product.Unit
                    + "(s) are available for this product.";
            }

            StockTransaction transaction = new StockTransaction();
            transaction.Id = store.GetNextTransactionId();
            transaction.ProductId = product.Id;
            transaction.Type = TransactionType.StockOut;
            transaction.Quantity = -quantity;
            transaction.Date = date;
            transaction.UnitPrice = unitPrice;
            transaction.Notes = notes.Trim();
            store.Transactions.Add(transaction);

            product.Quantity -= quantity;
            return null;
        }

        public List<StockTransactionView> GetStockInTransactions()
        {
            return GetTransactions(TransactionType.StockIn);
        }

        public List<StockTransactionView> GetStockOutTransactions()
        {
            return GetTransactions(TransactionType.StockOut);
        }

        public List<StockTransactionView> GetTransactions(TransactionType? type)
        {
            List<StockTransactionView> views = new List<StockTransactionView>();

            foreach (StockTransaction transaction in store.Transactions)
            {
                if (type != null && transaction.Type != type)
                {
                    continue;
                }

                Product? product = GetProductById(transaction.ProductId);
                StockTransactionView view = new StockTransactionView();
                view.Id = transaction.Id;
                view.ProductId = transaction.ProductId;
                view.ProductCode = product != null ? product.Code : "Unknown";
                view.ProductName = product != null ? product.Name : "Unknown Product";
                view.Type = transaction.Type;
                view.TypeName = GetTypeName(transaction.Type);
                view.Quantity = transaction.Quantity;
                view.Date = transaction.Date;
                view.UnitCost = transaction.UnitCost;
                view.UnitPrice = transaction.UnitPrice;
                view.SupplierId = transaction.SupplierId;
                view.SupplierName = transaction.SupplierId.HasValue
                    ? GetSupplierName(transaction.SupplierId.Value)
                    : string.Empty;
                view.Notes = transaction.Notes;
                views.Add(view);
            }

            views.Sort(CompareTransactions);
            return views;
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

        private string GetSupplierName(int supplierId)
        {
            foreach (Supplier supplier in store.Suppliers)
            {
                if (supplier.Id == supplierId)
                {
                    return supplier.Name;
                }
            }

            return "Unknown Supplier";
        }

        private static string GetTypeName(TransactionType type)
        {
            switch (type)
            {
                case TransactionType.OpeningBalance:
                    return "Opening";
                case TransactionType.StockIn:
                    return "Stock In";
                case TransactionType.StockOut:
                    return "Stock Out";
                case TransactionType.Adjustment:
                    return "Adjustment";
                default:
                    return type.ToString();
            }
        }

        private int CompareProducts(Product first, Product second)
        {
            return string.Compare(first.Code, second.Code, StringComparison.OrdinalIgnoreCase);
        }

        private int CompareSuppliers(Supplier first, Supplier second)
        {
            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }

        private int CompareTransactions(StockTransactionView first, StockTransactionView second)
        {
            int dateComparison = second.Date.CompareTo(first.Date);

            if (dateComparison != 0)
            {
                return dateComparison;
            }

            return second.Id.CompareTo(first.Id);
        }
    }
}
