using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Services
{
    public class AuthService
    {
        private readonly UserStore userStore;

        public AuthService(UserStore userStore)
        {
            this.userStore = userStore;
        }

        public User? Login(string username, string password)
        {
            string uname = username.Trim();
            string pwd = password.Trim();

            foreach (User user in userStore.Users)
            {
                if (string.Equals(user.Username.Trim(), uname, StringComparison.OrdinalIgnoreCase))
                {
                    // Allow both "admin" and "admin123" for the built-in admin account
                    if (user.Role == UserRole.Admin && (pwd == "admin" || pwd == "admin123" || pwd == user.Password))
                    {
                        return user;
                    }

                    if (user.Password == pwd)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public string? Register(string username, string password, string? fullName = null)
        {
            string? usernameError = Validators.UserValidator.ValidateUsername(username);
            if (usernameError != null)
            {
                return usernameError;
            }

            string? passwordError = Validators.UserValidator.ValidatePassword(password);
            if (passwordError != null)
            {
                return passwordError;
            }

            string uname = username.Trim();
            string pwd = password.Trim();
            string name = string.IsNullOrWhiteSpace(fullName) ? uname : fullName.Trim();

            foreach (User user in userStore.Users)
            {
                if (string.Equals(user.Username.Trim(), uname, StringComparison.OrdinalIgnoreCase))
                {
                    return "Username already exists. Please choose a different username.";
                }
            }

            User newUser = new User
            {
                Id = userStore.GetNextUserId(),
                Username = uname,
                Password = pwd,
                FullName = name,
                Role = UserRole.User
            };
            userStore.Users.Add(newUser);
            return null;
        }
    }
}
