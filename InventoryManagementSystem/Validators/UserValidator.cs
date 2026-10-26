using System.Text.RegularExpressions;

namespace InventoryManagementSystem.Validators
{
    public static class UserValidator
    {
        public static string? ValidateUsername(string? username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return "Username is required.";
            }

            string clean = username.Trim();

            if (clean.Length < 3)
            {
                return "Username must be at least 3 characters long.";
            }

            if (clean.Length > 30)
            {
                return "Username cannot exceed 30 characters.";
            }

            if (clean.Contains(' '))
            {
                return "Username cannot contain spaces.";
            }

            if (!Regex.IsMatch(clean, "^[a-zA-Z0-9_]+$"))
            {
                return "Username can only contain letters, numbers, and underscores.";
            }

            return null;
        }

        public static string? ValidatePassword(string? password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return "Password is required.";
            }

            if (password.Length < 4)
            {
                return "Password must be at least 4 characters long.";
            }

            if (password.Length > 50)
            {
                return "Password cannot exceed 50 characters.";
            }

            return null;
        }

        public static string? ValidateLoginCredentials(string? username, string? password)
        {
            string? userError = ValidateUsername(username);
            if (userError != null)
            {
                return userError;
            }

            string? passError = ValidatePassword(password);
            if (passError != null)
            {
                return passError;
            }

            return null;
        }

        public static string? ValidateRegistration(string? username, string? password, string? confirmPassword)
        {
            string? userError = ValidateUsername(username);
            if (userError != null)
            {
                return userError;
            }

            string? passError = ValidatePassword(password);
            if (passError != null)
            {
                return passError;
            }

            if (string.IsNullOrEmpty(confirmPassword))
            {
                return "Please confirm your password.";
            }

            if (password != confirmPassword)
            {
                return "Passwords do not match.";
            }

            return null;
        }
    }
}
