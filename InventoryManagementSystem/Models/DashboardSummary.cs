namespace InventoryManagementSystem.Models
{
    public class DashboardSummary
    {
        public int TotalProducts { get; set; }
        public int TotalCategories { get; set; }
        public int TotalSuppliers { get; set; }
        public int LowStockCount { get; set; }
        public int StockInToday { get; set; }
        public int StockOutToday { get; set; }
        public int StockInTotal { get; set; }
        public int StockOutTotal { get; set; }
        public List<LowStockItem> LowStockItems { get; set; } = new List<LowStockItem>();
        public List<TransactionListItem> RecentTransactions { get; set; } = new List<TransactionListItem>();
    }
}
