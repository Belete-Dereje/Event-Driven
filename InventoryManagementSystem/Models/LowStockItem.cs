namespace InventoryManagementSystem.Models
{
    public class LowStockItem
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal MinimumStock { get; set; }
        public decimal SuggestedReorder { get; set; }
    }
}
