namespace InventoryManagementSystem.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string Unit { get; set; } = "piece";
        public decimal PurchaseCost { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal MinimumStock { get; set; }
        public ProductStatus Status { get; set; } = ProductStatus.Active;
        public string Description { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string StorageLocation { get; set; } = string.Empty;
    }
}
