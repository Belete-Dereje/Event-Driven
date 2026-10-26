namespace InventoryManagementSystem.Models
{
    public class StockTransactionView
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public TransactionType Type { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public int? SupplierId { get; set; }
        public string SupplierName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
