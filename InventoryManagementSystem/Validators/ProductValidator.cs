using InventoryManagementSystem.Helpers;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Validators
{
    public static class ProductValidator
    {
        public static string? Validate(Product product, decimal quantity, string quantityFieldName = "Initial quantity")
        {
            string cleanCode = product.Code.Trim();
            string cleanName = product.Name.Trim();
            string cleanUnit = product.Unit.Trim();

            if (cleanCode.Length == 0)
            {
                return "Product code is required.";
            }

            if (cleanCode.Length > 30)
            {
                return "Product code cannot exceed 30 characters.";
            }

            if (cleanName.Length == 0)
            {
                return "Product name is required.";
            }

            if (cleanName.Length < 2)
            {
                return "Product name must be at least 2 characters.";
            }

            if (cleanName.Length > 100)
            {
                return "Product name cannot exceed 100 characters.";
            }

            if (product.CategoryId <= 0)
            {
                return "Please select a category.";
            }

            if (product.SupplierId <= 0)
            {
                return "Please select a supplier.";
            }

            if (cleanUnit.Length == 0)
            {
                return "Please select a unit.";
            }

            if (product.PurchaseCost < 0)
            {
                return "Purchase cost cannot be negative.";
            }

            if (product.SellingPrice < 0)
            {
                return "Selling price cannot be negative.";
            }

            if (quantity < 0)
            {
                return quantityFieldName + " cannot be negative.";
            }

            if (product.MinimumStock < 0)
            {
                return "Minimum stock cannot be negative.";
            }

            if (!ProductUnits.AllowsDecimal(cleanUnit))
            {
                if (quantity != decimal.Truncate(quantity))
                {
                    return quantityFieldName + " must be a whole number for the unit \"" + cleanUnit + "\".";
                }

                if (product.MinimumStock != decimal.Truncate(product.MinimumStock))
                {
                    return "Minimum stock must be a whole number for the unit \"" + cleanUnit + "\".";
                }
            }

            if (product.Description.Trim().Length > 200)
            {
                return "Description cannot exceed 200 characters.";
            }

            if (product.Barcode.Trim().Length > 50)
            {
                return "Barcode/SKU cannot exceed 50 characters.";
            }

            if (product.StorageLocation.Trim().Length > 100)
            {
                return "Storage location cannot exceed 100 characters.";
            }

            return null;
        }
    }
}
