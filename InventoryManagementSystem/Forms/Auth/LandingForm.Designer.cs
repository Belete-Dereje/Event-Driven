using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace InventoryManagementSystem.Forms.Auth
{
    partial class LandingForm
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
            labelSubtitle = new Label();
            contentPanel = new Panel();
            buttonsPanel = new FlowLayoutPanel();
            loginButton = new Button();
            registerButton = new Button();
            exitButton = new Button();
            footerLabel = new Label();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            buttonsPanel.SuspendLayout();
            SuspendLayout();
            headerPanel.BackColor = Color.FromArgb(33, 97, 173);
            headerPanel.Controls.Add(labelSubtitle);
            headerPanel.Controls.Add(labelTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Size = new Size(500, 110);
            labelTitle.Dock = DockStyle.Top;
            labelTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            labelTitle.ForeColor = Color.White;
            labelTitle.Location = new Point(0, 0);
            labelTitle.Size = new Size(500, 60);
            labelTitle.Text = "Inventory Management System";
            labelTitle.TextAlign = ContentAlignment.MiddleCenter;
            labelSubtitle.Dock = DockStyle.Fill;
            labelSubtitle.Font = new Font("Segoe UI", 10F);
            labelSubtitle.ForeColor = Color.FromArgb(230, 240, 250);
            labelSubtitle.Location = new Point(0, 60);
            labelSubtitle.Size = new Size(500, 50);
            labelSubtitle.Text = "Event-Driven Programming - Phase 1";
            labelSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            contentPanel.BackColor = Color.FromArgb(245, 247, 250);
            contentPanel.Controls.Add(footerLabel);
            contentPanel.Controls.Add(buttonsPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 110);
            contentPanel.Padding = new Padding(40);
            contentPanel.Size = new Size(500, 290);
            buttonsPanel.Dock = DockStyle.Top;
            buttonsPanel.FlowDirection = FlowDirection.TopDown;
            buttonsPanel.Location = new Point(40, 40);
            buttonsPanel.Size = new Size(420, 170);
            buttonsPanel.WrapContents = false;
            loginButton.BackColor = Color.FromArgb(33, 97, 173);
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            loginButton.ForeColor = Color.White;
            loginButton.Margin = new Padding(0, 10, 0, 10);
            loginButton.Size = new Size(420, 44);
            loginButton.Text = "Login";
            loginButton.Cursor = Cursors.Hand;
            loginButton.Click += loginButton_Click;
            registerButton.BackColor = Color.White;
            registerButton.FlatAppearance.BorderColor = Color.FromArgb(33, 97, 173);
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            registerButton.ForeColor = Color.FromArgb(33, 97, 173);
            registerButton.Margin = new Padding(0, 0, 0, 10);
            registerButton.Size = new Size(420, 44);
            registerButton.Text = "Register New Account (Employee)";
            registerButton.Cursor = Cursors.Hand;
            registerButton.Click += registerButton_Click;
            exitButton.BackColor = Color.FromArgb(236, 239, 242);
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.FlatStyle = FlatStyle.Flat;
            exitButton.Font = new Font("Segoe UI", 10F);
            exitButton.Margin = new Padding(0, 0, 0, 10);
            exitButton.Size = new Size(420, 44);
            exitButton.Text = "Exit";
            exitButton.Cursor = Cursors.Hand;
            exitButton.Click += exitButton_Click;
            buttonsPanel.Controls.Add(loginButton);
            buttonsPanel.Controls.Add(registerButton);
            buttonsPanel.Controls.Add(exitButton);
            footerLabel.Dock = DockStyle.Bottom;
            footerLabel.Font = new Font("Segoe UI", 8F);
            footerLabel.ForeColor = Color.Gray;
            footerLabel.Location = new Point(40, 230);
            footerLabel.Size = new Size(420, 20);
            footerLabel.Text = "Admin is registered manually. Employees register here.";
            footerLabel.TextAlign = ContentAlignment.MiddleCenter;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 400);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LandingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventory Management System - Welcome";
            Load += LandingForm_Load;
            KeyDown += LandingForm_KeyDown;
            headerPanel.ResumeLayout(false);
            contentPanel.ResumeLayout(false);
            buttonsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel headerPanel;
        private Label labelTitle;
        private Label labelSubtitle;
        private Panel contentPanel;
        private FlowLayoutPanel buttonsPanel;
        private Button loginButton;
        private Button registerButton;
        private Button exitButton;
        private Label footerLabel;
    }
}
