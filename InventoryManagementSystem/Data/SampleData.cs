using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Data
{
    public static class SampleData
    {
        public static void Load(InMemoryDataStore store)
        {
            store.Clear();

            Category electronics = AddCategory(store, "Electronics", "Electronic devices and accessories");
            Category officeSupplies = AddCategory(store, "Office Supplies", "Everyday office materials");
            Category furniture = AddCategory(store, "Furniture", "Office furniture");
            Category cleaning = AddCategory(store, "Cleaning", "Cleaning and hygiene products");

            Supplier techSource = AddSupplier(store, "TechSource Ltd", "Daniel Bekele", "0911-111-111", "sales@techsource.example", "Addis Ababa");
            Supplier officeMart = AddSupplier(store, "OfficeMart", "Sara Tesfaye", "0922-222-222", "orders@officemart.example", "Addis Ababa");
            Supplier comfort = AddSupplier(store, "Comfort Furnishings", "Yonas Girma", "0933-333-333", "info@comfort.example", "Addis Ababa");

            Product laptop = AddProduct(store, "EL-001", "Laptop 15 inch", electronics.Id, techSource.Id, "piece", 25000, 32000, 3, "Standard business laptop", "8901234567890", "Shelf A1");
            Product usbDrive = AddProduct(store, "EL-002", "USB Flash Drive 64GB", electronics.Id, techSource.Id, "piece", 250, 400, 10, "USB 3.0 flash drive", "8901234567891", "Shelf A2");
            Product paper = AddProduct(store, "OF-001", "A4 Paper Ream", officeSupplies.Id, officeMart.Id, "ream", 180, 250, 20, "500 sheets per ream", "8901234567892", "Shelf B1");
            Product pens = AddProduct(store, "OF-002", "Ballpoint Pen Box", officeSupplies.Id, officeMart.Id, "box", 80, 120, 5, "Box of 50 pens", "8901234567893", "Shelf B2");
            Product chair = AddProduct(store, "FU-001", "Office Chair", furniture.Id, comfort.Id, "piece", 2500, 3500, 4, "Adjustable office chair", "8901234567894", "Floor area C");
            Product sanitizer = AddProduct(store, "CL-001", "Hand Sanitizer 500ml", cleaning.Id, techSource.Id, "bottle", 120, 200, 15, "Alcohol-based hand sanitizer", "8901234567895", "Shelf D1");
            Product notebook = AddProduct(store, "OF-003", "Notebook A5", officeSupplies.Id, officeMart.Id, "piece", 45, 80, 10, "200-page ruled notebook", "8901234567896", "Shelf B3");

            DateTime openingDate = DateTime.Today.AddDays(-30);
            DateTime yesterday = DateTime.Today.AddDays(-1);
            DateTime today = DateTime.Today;

            AddTransaction(store, laptop, TransactionType.OpeningBalance, 10, openingDate, "Opening stock");
            AddTransaction(store, usbDrive, TransactionType.OpeningBalance, 4, openingDate, "Opening stock");
            AddTransaction(store, paper, TransactionType.OpeningBalance, 15, openingDate, "Opening stock");
            AddTransaction(store, pens, TransactionType.OpeningBalance, 2, openingDate, "Opening stock");
            AddTransaction(store, chair, TransactionType.OpeningBalance, 6, openingDate, "Opening stock");
            AddTransaction(store, sanitizer, TransactionType.OpeningBalance, 20, openingDate, "Opening stock");
            AddTransaction(store, notebook, TransactionType.OpeningBalance, 30, openingDate, "Opening stock");

            AddTransaction(store, laptop, TransactionType.StockIn, 3, yesterday, "Regular restock", techSource.Id);
            AddTransaction(store, usbDrive, TransactionType.StockOut, -2, yesterday, "Counter sales");
            AddTransaction(store, notebook, TransactionType.StockOut, -5, yesterday, "School order");
            AddTransaction(store, sanitizer, TransactionType.Adjustment, -2, yesterday, "Bottles damaged in storage", null, AdjustmentReason.Damaged);

            AddTransaction(store, laptop, TransactionType.StockIn, 5, today, "Weekly restock", techSource.Id);
            AddTransaction(store, laptop, TransactionType.StockOut, -2, today, "Customer order");
            AddTransaction(store, usbDrive, TransactionType.StockOut, -1, today, "Counter sales");
            AddTransaction(store, paper, TransactionType.StockIn, 10, today, "Monthly supply", officeMart.Id);
            AddTransaction(store, paper, TransactionType.StockOut, -5, today, "Department request");
            AddTransaction(store, chair, TransactionType.StockOut, -2, today, "New office setup");
            AddTransaction(store, sanitizer, TransactionType.StockOut, -6, today, "Monthly issue");
        }

        private static Category AddCategory(InMemoryDataStore store, string name, string description)
        {
            Category category = new Category();
            category.Id = store.GetNextCategoryId();
            category.Name = name;
            category.Description = description;
            store.Categories.Add(category);
            return category;
        }

        private static Supplier AddSupplier(InMemoryDataStore store, string name, string contactPerson, string phone, string email, string address)
        {
            Supplier supplier = new Supplier();
            supplier.Id = store.GetNextSupplierId();
            supplier.Name = name;
            supplier.ContactPerson = contactPerson;
            supplier.Phone = phone;
            supplier.Email = email;
            supplier.Address = address;
            store.Suppliers.Add(supplier);
            return supplier;
        }

        private static Product AddProduct(InMemoryDataStore store, string code, string name, int categoryId, int supplierId, string unit, decimal purchaseCost, decimal sellingPrice, decimal minimumStock, string description, string barcode, string storageLocation)
        {
            Product product = new Product();
            product.Id = store.GetNextProductId();
            product.Code = code;
            product.Name = name;
            product.CategoryId = categoryId;
            product.SupplierId = supplierId;
            product.Unit = unit;
            product.PurchaseCost = purchaseCost;
            product.SellingPrice = sellingPrice;
            product.MinimumStock = minimumStock;
            product.Description = description;
            product.Barcode = barcode;
            product.StorageLocation = storageLocation;
            product.Quantity = 0;
            product.Status = ProductStatus.Active;
            store.Products.Add(product);
            return product;
        }

        private static void AddTransaction(InMemoryDataStore store, Product product, TransactionType type, decimal quantity, DateTime date, string notes, int? supplierId = null, AdjustmentReason reason = AdjustmentReason.None)
        {
            StockTransaction transaction = new StockTransaction();
            transaction.Id = store.GetNextTransactionId();
            transaction.ProductId = product.Id;
            transaction.Type = type;
            transaction.Quantity = quantity;
            transaction.Date = date;
            transaction.SupplierId = supplierId;
            transaction.Reason = reason;
            transaction.Notes = notes;

            if (type == TransactionType.StockIn || type == TransactionType.OpeningBalance)
            {
                transaction.UnitCost = product.PurchaseCost;
            }

            if (type == TransactionType.StockOut)
            {
                transaction.UnitPrice = product.SellingPrice;
            }

            store.Transactions.Add(transaction);
            product.Quantity = product.Quantity + quantity;
        }
    }
}
