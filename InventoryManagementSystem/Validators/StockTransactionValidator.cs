using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Validators
{
    public static class StockTransactionValidator
    {
        public static string? Validate(
            Product product,
            decimal quantity,
            decimal unitAmount,
            string unitAmountName,
            string notes)
        {
            if (quantity <= 0)
            {
                return "Quantity must be greater than zero.";
            }

            if (!ProductUnits.AllowsDecimal(product.Unit) &&
                quantity != decimal.Truncate(quantity))
            {
                return "Quantity must be a whole number for the unit \"" + product.Unit + "\".";
            }

            if (unitAmount < 0)
            {
                return unitAmountName + " cannot be negative.";
            }

            if (notes.Trim().Length > 250)
            {
                return "Notes cannot exceed 250 characters.";
            }

            return null;
        }
    }
}
