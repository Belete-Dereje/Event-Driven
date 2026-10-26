using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.Auth
{
    partial class LoginForm
    {
        private IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            headerPanel = new Panel();
            labelTitle = new Label();
            contentPanel = new Panel();
            validationLabel = new Label();
            hintLabel = new Label();
            showPasswordCheckBox = new CheckBox();
            buttonsPanel = new Panel();
            cancelButton = new Button();
            loginButton = new Button();
            passwordTextBox = new TextBox();
            labelPassword = new Label();
            usernameTextBox = new TextBox();
            labelUsername = new Label();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(33, 97, 173);
            headerPanel.Controls.Add(labelTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(420, 60);
            headerPanel.TabIndex = 0;
            // 
            // labelTitle
            // 
            labelTitle.Dock = DockStyle.Fill;
            labelTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Name = "labelTitle";
            labelTitle.Padding = new Padding(16, 0, 0, 0);
            labelTitle.Size = new Size(420, 60);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Login";
            labelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Controls.Add(validationLabel);
            contentPanel.Controls.Add(hintLabel);
            contentPanel.Controls.Add(showPasswordCheckBox);
            contentPanel.Controls.Add(buttonsPanel);
            contentPanel.Controls.Add(passwordTextBox);
            contentPanel.Controls.Add(labelPassword);
            contentPanel.Controls.Add(usernameTextBox);
            contentPanel.Controls.Add(labelUsername);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 60);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(20);
            contentPanel.Size = new Size(420, 260);
            contentPanel.TabIndex = 1;
            // 
            // labelUsername
            // 
            labelUsername.AutoSize = true;
            labelUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelUsername.ForeColor = Color.FromArgb(70, 80, 95);
            labelUsername.Location = new Point(20, 16);
            labelUsername.Name = "labelUsername";
            labelUsername.Size = new Size(74, 15);
            labelUsername.TabIndex = 0;
            labelUsername.Text = "Username *";
            // 
            // usernameTextBox
            // 
            usernameTextBox.Font = new Font("Segoe UI", 9.5F);
            usernameTextBox.Location = new Point(20, 36);
            usernameTextBox.MaxLength = 30;
            usernameTextBox.Name = "usernameTextBox";
            usernameTextBox.PlaceholderText = "Enter your username";
            usernameTextBox.Size = new Size(380, 24);
            usernameTextBox.TabIndex = 1;
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelPassword.ForeColor = Color.FromArgb(70, 80, 95);
            labelPassword.Location = new Point(20, 72);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(69, 15);
            labelPassword.TabIndex = 2;
            labelPassword.Text = "Password *";
            // 
            // passwordTextBox
            // 
            passwordTextBox.Font = new Font("Segoe UI", 9.5F);
            passwordTextBox.Location = new Point(20, 92);
            passwordTextBox.MaxLength = 50;
            passwordTextBox.Name = "passwordTextBox";
            passwordTextBox.PlaceholderText = "Enter your password";
            passwordTextBox.Size = new Size(380, 24);
            passwordTextBox.TabIndex = 3;
            passwordTextBox.UseSystemPasswordChar = true;
            // 
            // showPasswordCheckBox
            // 
            showPasswordCheckBox.AutoSize = true;
            showPasswordCheckBox.Font = new Font("Segoe UI", 8.5F);
            showPasswordCheckBox.ForeColor = Color.FromArgb(70, 80, 95);
            showPasswordCheckBox.Location = new Point(20, 124);
            showPasswordCheckBox.Name = "showPasswordCheckBox";
            showPasswordCheckBox.Size = new Size(107, 19);
            showPasswordCheckBox.TabIndex = 4;
            showPasswordCheckBox.Text = "Show Password";
            showPasswordCheckBox.UseVisualStyleBackColor = true;
            showPasswordCheckBox.CheckedChanged += showPasswordCheckBox_CheckedChanged;
            // 
            // hintLabel
            // 
            hintLabel.AutoSize = true;
            hintLabel.Font = new Font("Segoe UI", 8.25F);
            hintLabel.ForeColor = Color.FromArgb(120, 130, 145);
            hintLabel.Location = new Point(20, 148);
            hintLabel.Name = "hintLabel";
            hintLabel.Size = new Size(224, 13);
            hintLabel.TabIndex = 5;
            hintLabel.Text = "Hint: Default Admin is \"admin\" / \"admin123\"";
            // 
            // validationLabel
            // 
            validationLabel.Font = new Font("Segoe UI", 8.75F);
            validationLabel.ForeColor = Color.FromArgb(192, 57, 43);
            validationLabel.Location = new Point(20, 168);
            validationLabel.Name = "validationLabel";
            validationLabel.Size = new Size(380, 20);
            validationLabel.TabIndex = 6;
            // 
            // buttonsPanel
            // 
            buttonsPanel.Controls.Add(cancelButton);
            buttonsPanel.Controls.Add(loginButton);
            buttonsPanel.Dock = DockStyle.Bottom;
            buttonsPanel.Location = new Point(20, 198);
            buttonsPanel.Name = "buttonsPanel";
            buttonsPanel.Size = new Size(380, 42);
            buttonsPanel.TabIndex = 7;
            // 
            // loginButton
            // 
            loginButton.BackColor = Color.FromArgb(33, 97, 173);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.Location = new Point(0, 4);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(100, 34);
            loginButton.TabIndex = 0;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = false;
            loginButton.Click += loginButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(236, 239, 242);
            cancelButton.FlatAppearance.BorderSize = 0;
            cancelButton.FlatStyle = FlatStyle.Flat;
            cancelButton.Font = new Font("Segoe UI", 9F);
            cancelButton.ForeColor = Color.FromArgb(60, 70, 85);
            cancelButton.Location = new Point(108, 4);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(90, 34);
            cancelButton.TabIndex = 1;
            cancelButton.Text = "← Back";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(420, 320);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            KeyDown += LoginForm_KeyDown;
            headerPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel headerPanel;
        private Label labelTitle;
        private Panel contentPanel;
        private Label labelUsername;
        private TextBox usernameTextBox;
        private Label labelPassword;
        private TextBox passwordTextBox;
        private CheckBox showPasswordCheckBox;
        private Label hintLabel;
        private Label validationLabel;
        private Panel buttonsPanel;
        private Button loginButton;
        private Button cancelButton;
    }
}
