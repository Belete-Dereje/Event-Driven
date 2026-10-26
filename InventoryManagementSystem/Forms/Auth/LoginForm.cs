using System;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Forms.Auth
{
    public partial class LoginForm : Form
    {
        private readonly AuthService authService;
        private readonly UserStore userStore;
        private readonly string? initialUsername;
        public User? LoggedInUser { get; private set; }

        public LoginForm(AuthService authService, UserStore userStore, string? initialUsername = null)
        {
            this.authService = authService;
            this.userStore = userStore;
            this.initialUsername = initialUsername;
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            AcceptButton = loginButton;
            CancelButton = cancelButton;
            passwordTextBox.UseSystemPasswordChar = true;
            validationLabel.Text = string.Empty;

            // Do not pre-fill hardcoded credentials; ask user for input
            if (!string.IsNullOrWhiteSpace(initialUsername))
            {
                usernameTextBox.Text = initialUsername;
                passwordTextBox.Clear();
                passwordTextBox.Focus();
            }
            else
            {
                usernameTextBox.Clear();
                passwordTextBox.Clear();
                usernameTextBox.Focus();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            // 1. Validate credentials format
            string? formatError = UserValidator.ValidateLoginCredentials(username, password);
            if (formatError != null)
            {
                validationLabel.Text = formatError;
                if (string.IsNullOrWhiteSpace(username) || username.Trim().Length < 3 || username.Contains(' '))
                {
                    usernameTextBox.SelectAll();
                    usernameTextBox.Focus();
                }
                else
                {
                    passwordTextBox.SelectAll();
                    passwordTextBox.Focus();
                }
                return;
            }

            // 2. Perform authentication
            User? user = authService.Login(username, password);
            if (user == null)
            {
                validationLabel.Text = "Invalid username or password.";
                MessageBox.Show(
                    "Invalid username or password. Please verify your credentials and try again.",
                    "Login Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                passwordTextBox.SelectAll();
                passwordTextBox.Focus();
                return;
            }

            LoggedInUser = user;
            validationLabel.Text = string.Empty;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        private void LoginForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
