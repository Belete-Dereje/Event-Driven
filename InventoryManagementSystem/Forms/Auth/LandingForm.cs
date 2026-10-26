using System;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Forms.Dashboard;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;

namespace InventoryManagementSystem.Forms.Auth
{
    public partial class LandingForm : Form
    {
        private readonly UserStore userStore;
        private readonly AuthService authService;
        private readonly InMemoryDataStore dataStore;
        public User? LoggedInUser { get; private set; }

        public LandingForm(UserStore userStore, AuthService authService, InMemoryDataStore dataStore)
        {
            this.userStore = userStore;
            this.authService = authService;
            this.dataStore = dataStore;
            InitializeComponent();
        }

        public LandingForm(UserStore userStore, AuthService authService)
            : this(userStore, authService, new InMemoryDataStore())
        {
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                using (LoginForm loginForm = new LoginForm(authService, userStore))
                {
                    DialogResult result = loginForm.ShowDialog();
                    if (result == DialogResult.OK && loginForm.LoggedInUser != null)
                    {
                        LoggedInUser = loginForm.LoggedInUser;
                        this.ShowInTaskbar = false;

                        DashboardService dashboardService = new DashboardService(dataStore);
                        DashboardForm dashboardForm = new DashboardForm(dashboardService, LoggedInUser);

                        dashboardForm.FormClosed += (s, args) =>
                        {
                            LoggedInUser = null;
                            if (!this.IsDisposed)
                            {
                                this.ShowInTaskbar = true;
                                this.Show();
                                this.BringToFront();
                                this.Activate();
                            }
                        };

                        dashboardForm.Show();
                    }
                    else
                    {
                        // User clicked Back or cancelled
                        this.ShowInTaskbar = true;
                        this.Show();
                        this.BringToFront();
                        this.Activate();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ShowInTaskbar = true;
                this.Show();
                this.BringToFront();
                this.Activate();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Hide();

                string? newlyRegisteredUsername = null;
                using (RegisterForm registerForm = new RegisterForm(authService))
                {
                    DialogResult result = registerForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        newlyRegisteredUsername = registerForm.RegisteredUsername;
                    }
                }

                // If registration succeeded, transition directly to LoginForm with the new username
                if (!string.IsNullOrWhiteSpace(newlyRegisteredUsername))
                {
                    using (LoginForm loginForm = new LoginForm(authService, userStore, newlyRegisteredUsername))
                    {
                        DialogResult loginResult = loginForm.ShowDialog();
                        if (loginResult == DialogResult.OK && loginForm.LoggedInUser != null)
                        {
                            LoggedInUser = loginForm.LoggedInUser;
                            this.ShowInTaskbar = false;

                            DashboardService dashboardService = new DashboardService(dataStore);
                            DashboardForm dashboardForm = new DashboardForm(dashboardService, LoggedInUser);

                            dashboardForm.FormClosed += (s, args) =>
                            {
                                LoggedInUser = null;
                                if (!this.IsDisposed)
                                {
                                    this.ShowInTaskbar = true;
                                    this.Show();
                                    this.BringToFront();
                                    this.Activate();
                                }
                            };

                            dashboardForm.Show();
                            return;
                        }
                    }
                }

                if (!this.IsDisposed)
                {
                    this.ShowInTaskbar = true;
                    this.Show();
                    this.BringToFront();
                    this.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.StackTrace, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ShowInTaskbar = true;
                this.Show();
                this.BringToFront();
                this.Activate();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LandingForm_Load(object sender, EventArgs e)
        {
            AcceptButton = loginButton;
            CancelButton = exitButton;
        }

        private void LandingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Application.Exit();
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            Application.Exit();
        }
    }
}
