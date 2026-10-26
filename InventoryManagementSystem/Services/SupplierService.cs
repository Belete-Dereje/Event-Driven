using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Services
{
    public class SupplierService
    {
        private readonly InMemoryDataStore store;

        public SupplierService(InMemoryDataStore store)
        {
            this.store = store;
        }

        public List<Supplier> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>(store.Suppliers);
            suppliers.Sort(CompareSuppliers);
            return suppliers;
        }

        public List<Supplier> Search(string searchText)
        {
            if (string.IsNullOrWhiteSpace(searchText))
            {
                return GetAll();
            }

            string term = searchText.Trim();
            List<Supplier> results = new List<Supplier>();

            foreach (Supplier supplier in store.Suppliers)
            {
                if (supplier.Name.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    supplier.ContactPerson.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    supplier.Phone.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    supplier.Email.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    supplier.Address.Contains(term, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(supplier);
                }
            }

            results.Sort(CompareSuppliers);
            return results;
        }

        public Supplier? GetById(int id)
        {
            foreach (Supplier supplier in store.Suppliers)
            {
                if (supplier.Id == id)
                {
                    return supplier;
                }
            }

            return null;
        }

        public Supplier? FindByName(string name)
        {
            string normalizedName = NormalizeName(name);

            foreach (Supplier supplier in store.Suppliers)
            {
                if (string.Equals(NormalizeName(supplier.Name), normalizedName, StringComparison.OrdinalIgnoreCase))
                {
                    return supplier;
                }
            }

            return null;
        }

        public int GetTransactionCount(int supplierId)
        {
            int count = 0;

            foreach (StockTransaction transaction in store.Transactions)
            {
                if (transaction.SupplierId == supplierId)
                {
                    count++;
                }
            }

            return count;
        }

        public int GetProductCount(int supplierId)
        {
            int count = 0;

            foreach (Product product in store.Products)
            {
                if (product.SupplierId == supplierId)
                {
                    count++;
                }
            }

            return count;
        }

        public string? Add(string name, string contactPerson, string phone, string email, string address)
        {
            string? errorMessage = SupplierValidator.Validate(name, contactPerson, phone, email, address);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            if (FindByName(name) != null)
            {
                return "A supplier with this name already exists.";
            }

            Supplier supplier = new Supplier();
            supplier.Id = store.GetNextSupplierId();
            supplier.Name = NormalizeName(name);
            supplier.ContactPerson = contactPerson.Trim();
            supplier.Phone = phone.Trim();
            supplier.Email = email.Trim();
            supplier.Address = address.Trim();
            store.Suppliers.Add(supplier);

            return null;
        }

        public string? Update(int id, string name, string contactPerson, string phone, string email, string address)
        {
            Supplier? supplier = GetById(id);

            if (supplier == null)
            {
                return "The selected supplier could not be found.";
            }

            string? errorMessage = SupplierValidator.Validate(name, contactPerson, phone, email, address);

            if (errorMessage != null)
            {
                return errorMessage;
            }

            Supplier? duplicate = FindByName(name);

            if (duplicate != null && duplicate.Id != id)
            {
                return "A supplier with this name already exists.";
            }

            supplier.Name = NormalizeName(name);
            supplier.ContactPerson = contactPerson.Trim();
            supplier.Phone = phone.Trim();
            supplier.Email = email.Trim();
            supplier.Address = address.Trim();

            return null;
        }

        public string? Delete(int id)
        {
            Supplier? supplier = GetById(id);

            if (supplier == null)
            {
                return "The selected supplier could not be found.";
            }

            int productCount = GetProductCount(id);

            if (productCount > 0)
            {
                return "This supplier cannot be deleted because it is assigned to "
                    + productCount
                    + " product(s). Reassign or delete those products first.";
            }

            int transactionCount = GetTransactionCount(id);

            if (transactionCount > 0)
            {
                return "This supplier cannot be deleted because it is used by "
                    + transactionCount
                    + " stock transaction(s). Remove or reassign those transactions first.";
            }

            store.Suppliers.Remove(supplier);
            return null;
        }

        private string NormalizeName(string name)
        {
            string cleanedName = name.Trim();

            while (cleanedName.Contains("  "))
            {
                cleanedName = cleanedName.Replace("  ", " ");
            }

            return cleanedName;
        }

        private int CompareSuppliers(Supplier first, Supplier second)
        {
            return string.Compare(first.Name, second.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
}
