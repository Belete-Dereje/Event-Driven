using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data
{
    public class UserStore
    {
        private int nextUserId = 2;

        public List<User> Users { get; } = new List<User>();

        public UserStore()
        {
            Users.Add(new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                FullName = "System Administrator",
                Role = UserRole.Admin
            });
        }

        public int GetNextUserId()
        {
            int id = nextUserId;
            nextUserId++;
            return id;
        }
    }
}
