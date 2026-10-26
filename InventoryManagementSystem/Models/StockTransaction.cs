namespace InventoryManagementSystem.Models
{
    public class StockTransaction
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public TransactionType Type { get; set; }
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public int? SupplierId { get; set; }
        public AdjustmentReason Reason { get; set; } = AdjustmentReason.None;
        public string Notes { get; set; } = string.Empty;
    }
}
