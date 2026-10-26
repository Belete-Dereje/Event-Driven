using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class DashboardService
    {
        private readonly InMemoryDataStore store;

        public DashboardService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public InMemoryDataStore Store
        {
            get { return store; }
        }

        public DashboardSummary GetSummary()
        {
            DashboardSummary summary = new DashboardSummary();

            summary.TotalProducts = store.Products.Count;
            summary.TotalCategories = store.Categories.Count;
            summary.TotalSuppliers = store.Suppliers.Count;

            foreach (Product product in store.Products)
            {
                if (product.Status == ProductStatus.Active &&
                    product.Quantity <= product.MinimumStock)
                {
                    LowStockItem item = new LowStockItem();
                    item.Code = product.Code;
                    item.Name = product.Name;
                    item.Category = GetCategoryName(product.CategoryId);
                    item.Quantity = product.Quantity;
                    item.MinimumStock = product.MinimumStock;
                    item.SuggestedReorder = product.MinimumStock - product.Quantity;
                    summary.LowStockItems.Add(item);
                    summary.LowStockCount++;
                }
            }

            summary.LowStockItems.Sort(CompareLowStockItems);

            foreach (StockTransaction transaction in store.Transactions)
            {
                if (transaction.Type == TransactionType.StockIn)
                {
                    summary.StockInTotal++;

                    if (transaction.Date.Date == DateTime.Today)
                    {
                        summary.StockInToday++;
                    }
                }
                else if (transaction.Type == TransactionType.StockOut)
                {
                    summary.StockOutTotal++;

                    if (transaction.Date.Date == DateTime.Today)
                    {
                        summary.StockOutToday++;
                    }
                }
            }

            List<StockTransaction> sortedTransactions = new List<StockTransaction>(store.Transactions);
            sortedTransactions.Sort(CompareTransactions);

            int transactionCount = 0;

            foreach (StockTransaction transaction in sortedTransactions)
            {
                if (transactionCount == 10)
                {
                    break;
                }

                TransactionListItem item = new TransactionListItem();
                item.Id = transaction.Id;
                item.ProductName = GetProductName(transaction.ProductId);
                item.TypeName = GetTransactionTypeName(transaction.Type);
                item.Quantity = transaction.Quantity;
                item.Date = transaction.Date;
                summary.RecentTransactions.Add(item);
                transactionCount++;
            }

            return summary;
        }

        public void LoadSampleData()
        {
            SampleData.Load(store);
        }

        private string GetCategoryName(int categoryId)
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

        private string GetProductName(int productId)
        {
            foreach (Product product in store.Products)
            {
                if (product.Id == productId)
                {
                    return product.Name;
                }
            }

            return "Unknown Product";
        }

        private string GetTransactionTypeName(TransactionType type)
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

        private int CompareLowStockItems(LowStockItem first, LowStockItem second)
        {
            decimal firstShortage = first.MinimumStock - first.Quantity;
            decimal secondShortage = second.MinimumStock - second.Quantity;
            return secondShortage.CompareTo(firstShortage);
        }

        private int CompareTransactions(StockTransaction first, StockTransaction second)
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
