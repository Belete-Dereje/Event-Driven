using System.Text.RegularExpressions;

namespace InventoryManagementSystem.Validators
{
    public static class SupplierValidator
    {
        public static string? Validate(string name, string contactPerson, string phone, string email, string address)
        {
            string cleanName = name.Trim();
            string cleanContactPerson = contactPerson.Trim();
            string cleanPhone = phone.Trim();
            string cleanEmail = email.Trim();
            string cleanAddress = address.Trim();

            if (cleanName.Length == 0)
            {
                return "Supplier name is required.";
            }

            if (cleanName.Length < 2)
            {
                return "Supplier name must be at least 2 characters.";
            }

            if (cleanName.Length > 100)
            {
                return "Supplier name cannot exceed 100 characters.";
            }

            if (cleanContactPerson.Length > 100)
            {
                return "Contact person cannot exceed 100 characters.";
            }

            if (cleanPhone.Length > 30)
            {
                return "Phone number cannot exceed 30 characters.";
            }

            if (cleanPhone.Length > 0 &&
                !Regex.IsMatch(cleanPhone, @"^[0-9+\-() ]+$"))
            {
                return "Phone number may only contain digits, spaces, +, -, and parentheses.";
            }

            if (cleanEmail.Length > 100)
            {
                return "Email cannot exceed 100 characters.";
            }

            if (cleanEmail.Length > 0 &&
                !Regex.IsMatch(cleanEmail, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return "Please enter a valid email address.";
            }

            if (cleanAddress.Length > 200)
            {
                return "Address cannot exceed 200 characters.";
            }

            return null;
        }
    }
}
