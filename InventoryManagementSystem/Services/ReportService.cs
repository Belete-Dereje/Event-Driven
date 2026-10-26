using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class ReportService
    {
        private readonly InMemoryDataStore store;

        public ReportService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public List<InventoryReportItem> GetInventoryReport()
        {
            List<InventoryReportItem> items = new List<InventoryReportItem>();
            foreach (Product product in store.Products)
            {
                items.Add(new InventoryReportItem
                {
                    ProductCode = product.Code,
                    ProductName = product.Name,
                    CategoryName = GetCategoryName(product.CategoryId),
                    Quantity = product.Quantity,
                    Unit = product.Unit,
                    PurchaseCost = product.PurchaseCost,
                    SellingPrice = product.SellingPrice,
                    StockValue = product.Quantity * product.PurchaseCost,
                    MinimumStock = product.MinimumStock,
                    Status = product.Status.ToString()
                });
            }
            items.Sort((a, b) => string.Compare(a.ProductCode, b.ProductCode, StringComparison.OrdinalIgnoreCase));
            return items;
        }

        public List<LowStockItem> GetLowStockReport()
        {
            List<LowStockItem> items = new List<LowStockItem>();
            foreach (Product product in store.Products)
            {
                if (product.Status == ProductStatus.Active && product.Quantity <= product.MinimumStock)
                {
                    items.Add(new LowStockItem
                    {
                        Code = product.Code,
                        Name = product.Name,
                        Category = GetCategoryName(product.CategoryId),
                        Quantity = product.Quantity,
                        MinimumStock = product.MinimumStock,
                        SuggestedReorder = product.MinimumStock - product.Quantity
                    });
                }
            }
            items.Sort((a, b) => (b.MinimumStock - b.Quantity).CompareTo(a.MinimumStock - a.Quantity));
            return items;
        }

        private string GetCategoryName(int categoryId)
        {
            foreach (Category category in store.Categories)
            {
                if (category.Id == categoryId) return category.Name;
            }
            return "Uncategorized";
        }
    }

    public class InventoryReportItem
    {
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = string.Empty;
        public decimal PurchaseCost { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal StockValue { get; set; }
        public decimal MinimumStock { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
