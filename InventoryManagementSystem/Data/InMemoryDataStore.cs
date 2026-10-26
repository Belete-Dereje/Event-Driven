using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data
{
    public class InMemoryDataStore
    {
        private int nextCategoryId = 1;
        private int nextSupplierId = 1;
        private int nextProductId = 1;
        private int nextTransactionId = 1;

        public List<Category> Categories { get; } = new List<Category>();
        public List<Supplier> Suppliers { get; } = new List<Supplier>();
        public List<Product> Products { get; } = new List<Product>();
        public List<StockTransaction> Transactions { get; } = new List<StockTransaction>();

        public int GetNextCategoryId()
        {
            int id = nextCategoryId;
            nextCategoryId++;
            return id;
        }

        public int GetNextSupplierId()
        {
            int id = nextSupplierId;
            nextSupplierId++;
            return id;
        }

        public int GetNextProductId()
        {
            int id = nextProductId;
            nextProductId++;
            return id;
        }

        public int GetNextTransactionId()
        {
            int id = nextTransactionId;
            nextTransactionId++;
            return id;
        }

        public void Clear()
        {
            Categories.Clear();
            Suppliers.Clear();
            Products.Clear();
            Transactions.Clear();

            nextCategoryId = 1;
            nextSupplierId = 1;
            nextProductId = 1;
            nextTransactionId = 1;
        }
    }
}
