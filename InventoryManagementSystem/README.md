# Inventory Management System (IMS)

A C# Windows Forms desktop application developed for the **Event-Driven Programming** course (Phase 1).

## Quick Start
1. Open `InventoryManagementSystem.sln` in **Visual Studio**.
2. Press **F5** to build and run.
3. Sign in with the default credentials:
   - **Username:** `admin`
   - **Password:** `admin123`
   - *(Or click **Register** to create a new user account)*

## Documentation
Comprehensive system documentation, including architecture, folder/file structure, in-memory local storage implementation, validation mechanisms, and core business logic, is available in:
- [SYSTEM_DOCUMENTATION.md](file:///d:/EventDriven/InventoryManagementSystem/Documentation/SYSTEM_DOCUMENTATION.md)

## Key Features
- **In-Memory Local Storage:** Persistent application-session storage via `InMemoryDataStore` and `UserStore` without external database dependencies.
- **Product & Supplier Management:** Product registration with full details (13 columns in list view), category assignment, and supplier selection from registered suppliers.
- **Stock Movement & Auditing:** Real-time Stock In, Stock Out (with negative stock prevention), and Stock Adjustments (damage, expiry, loss).
- **Interactive Dashboard:** Live summary cards (Total Products, Categories, Low Stock Count, Total Stock Valuation), recent stock transactions, and replenishment alerts.
- **Dynamic Navigation:** Host shell layout with breadcrumb back stack and live clock.
- **Two-Tier Validation:** Form input parsing combined with pure static domain validators.
