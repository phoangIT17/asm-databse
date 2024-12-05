using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BCrypt.Net;

namespace Sales_Management
{
    public partial class frmChangePassword : Form
    {
        private Dictionary<string, string> _users;

        public frmChangePassword(Dictionary<string, string> users)
        {
            InitializeComponent();
            _users = users;
        }

        private void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            if (_users.ContainsKey(username))
            {
                string hashedPassword = _users[username];
                if (BCrypt.Net.BCrypt.Verify(oldPassword, hashedPassword))
                {
                    string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                    _users[username] = newHashedPassword;

                    MessageBox.Show("Password changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Username does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
