using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class TransactionService
    {
        private readonly InMemoryDataStore store;

        public TransactionService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public List<Product> GetProductFilterList()
        {
            List<Product> products = new List<Product>(store.Products);
            products.Sort(CompareProducts);
            return products;
        }

        public List<TransactionListItem> GetAll(DateTime? fromDate = null, DateTime? toDate = null, TransactionType? type = null, int? productId = null)
        {
            List<TransactionListItem> results = new List<TransactionListItem>();

            foreach (StockTransaction transaction in store.Transactions)
            {
                if (fromDate.HasValue && transaction.Date.Date < fromDate.Value.Date) continue;
                if (toDate.HasValue && transaction.Date.Date > toDate.Value.Date) continue;
                if (type.HasValue && transaction.Type != type.Value) continue;
                if (productId.HasValue && transaction.ProductId != productId.Value) continue;

                TransactionListItem item = new TransactionListItem
                {
                    Id = transaction.Id,
                    ProductId = transaction.ProductId,
                    ProductName = GetProductName(transaction.ProductId),
                    TypeName = GetTransactionTypeName(transaction.Type),
                    Quantity = transaction.Quantity,
                    Date = transaction.Date,
                    UnitCost = transaction.UnitCost,
                    UnitPrice = transaction.UnitPrice,
                    Reason = GetReasonName(transaction.Reason),
                    Notes = transaction.Notes
                };
                results.Add(item);
            }

            results.Sort((a, b) => {
                int dateCompare = b.Date.CompareTo(a.Date);
                if (dateCompare != 0) return dateCompare;
                return b.Id.CompareTo(a.Id);
            });

            return results;
        }

        private string GetReasonName(AdjustmentReason reason)
        {
            switch (reason)
            {
                case AdjustmentReason.Damaged: return "Damaged";
                case AdjustmentReason.Expired: return "Expired";
                case AdjustmentReason.Lost: return "Lost";
                case AdjustmentReason.CountingCorrection: return "Counting Correction";
                case AdjustmentReason.Returned: return "Returned";
                default: return string.Empty;
            }
        }

        private int CompareProducts(Product first, Product second)
        {
            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }

        private string GetProductName(int productId)
        {
            foreach (Product product in store.Products)
            {
                if (product.Id == productId) return product.Name;
            }
            return "Unknown Product";
        }

        private string GetTransactionTypeName(TransactionType type)
        {
            switch (type)
            {
                case TransactionType.OpeningBalance: return "Opening";
                case TransactionType.StockIn: return "Stock In";
                case TransactionType.StockOut: return "Stock Out";
                case TransactionType.Adjustment: return "Adjustment";
                default: return type.ToString();
            }
        }
    }
}
