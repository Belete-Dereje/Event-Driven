namespace InventoryManagementSystem.Models
{
    public class TransactionListItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string TypeName { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public DateTime Date { get; set; }
        public decimal UnitCost { get; set; }
        public decimal UnitPrice { get; set; }
        public string Reason { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }
}
