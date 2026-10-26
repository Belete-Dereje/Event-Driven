using System;
using System.Drawing;
using System.Windows.Forms;
using InventoryManagementSystem.Services;
using InventoryManagementSystem.Validators;

namespace InventoryManagementSystem.Forms.Auth
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService authService;
        public string? RegisteredUsername { get; private set; }

        public RegisterForm(AuthService authService)
        {
            this.authService = authService;
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            AcceptButton = registerButton;
            CancelButton = cancelButton;
            passwordTextBox.UseSystemPasswordChar = true;
            confirmPasswordTextBox.UseSystemPasswordChar = true;
            validationLabel.Text = string.Empty;
            usernameTextBox.Clear();
            passwordTextBox.Clear();
            confirmPasswordTextBox.Clear();
            usernameTextBox.Focus();
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;
            string confirmPassword = confirmPasswordTextBox.Text;

            // 1. Validate format of credentials
            string? validationError = UserValidator.ValidateRegistration(username, password, confirmPassword);
            if (validationError != null)
            {
                validationLabel.Text = validationError;
                MessageBox.Show(validationError, "Registration Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(username) || username.Trim().Length < 3 || username.Contains(' '))
                {
                    usernameTextBox.SelectAll();
                    usernameTextBox.Focus();
                }
                else if (string.IsNullOrEmpty(password) || password.Length < 4)
                {
                    passwordTextBox.SelectAll();
                    passwordTextBox.Focus();
                }
                else
                {
                    confirmPasswordTextBox.SelectAll();
                    confirmPasswordTextBox.Focus();
                }
                return;
            }

            // 2. Perform registration in AuthService
            string? registerError = authService.Register(username, password);
            if (registerError != null)
            {
                validationLabel.Text = registerError;
                MessageBox.Show(registerError, "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                usernameTextBox.SelectAll();
                usernameTextBox.Focus();
                return;
            }

            RegisteredUsername = username.Trim();
            validationLabel.Text = string.Empty;
            MessageBox.Show(
                "Account for \"" + RegisteredUsername + "\" has been created successfully!\nYou can now log in with your credentials.",
                "Registration Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

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
            confirmPasswordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        private void RegisterForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
