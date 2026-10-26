namespace InventoryManagementSystem.Validators
{
    public static class CategoryValidator
    {
        public static string? Validate(string name, string description)
        {
            string cleanName = name.Trim();
            string cleanDescription = description.Trim();

            if (cleanName.Length == 0)
            {
                return "Category name is required.";
            }

            if (cleanName.Length < 2)
            {
                return "Category name must be at least 2 characters.";
            }

            if (cleanName.Length > 50)
            {
                return "Category name cannot exceed 50 characters.";
            }

            if (cleanDescription.Length > 200)
            {
                return "Description cannot exceed 200 characters.";
            }

            return null;
        }
    }
}
