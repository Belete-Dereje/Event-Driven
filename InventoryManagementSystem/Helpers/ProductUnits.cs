namespace InventoryManagementSystem.Helpers
{
    public static class ProductUnits
    {
        public static readonly string[] All =
        {
            "piece",
            "box",
            "pack",
            "ream",
            "carton",
            "bottle",
            "kg",
            "g",
            "litre",
            "ml",
            "meter"
        };

        public static bool AllowsDecimal(string unit)
        {
            string cleanUnit = unit.Trim().ToLowerInvariant();

            return cleanUnit == "kg"
                || cleanUnit == "g"
                || cleanUnit == "litre"
                || cleanUnit == "ml"
                || cleanUnit == "meter";
        }
    }
}
