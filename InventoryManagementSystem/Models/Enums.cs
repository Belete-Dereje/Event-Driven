namespace InventoryManagementSystem.Models
{
    public enum ProductStatus
    {
        Active,
        Inactive
    }

    public enum TransactionType
    {
        OpeningBalance,
        StockIn,
        StockOut,
        Adjustment
    }

    public enum AdjustmentReason
    {
        None,
        Damaged,
        Expired,
        Lost,
        CountingCorrection,
        Returned
    }
}
