using InventoryManagementSystem.Data;
using InventoryManagementSystem.Forms.Auth;
using InventoryManagementSystem.Forms.Dashboard;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += (sender, e) =>
            {
                MessageBox.Show(
                    e.Exception.Message + "\n\n" + e.Exception.StackTrace,
                    "Application Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                MessageBox.Show(
                    e.ExceptionObject.ToString(),
                    "Fatal Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            };

            UserStore userStore = new UserStore();
            AuthService authService = new AuthService(userStore);
            InMemoryDataStore dataStore = new InMemoryDataStore();

            Application.Run(new LandingForm(userStore, authService, dataStore));
        }
    }
}
