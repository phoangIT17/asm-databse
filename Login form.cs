using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using BCrypt.Net; 

namespace Sales_Management
{
    public partial class frmLogin : Form
    {
        private readonly SqlConnection connection;
        private readonly Dictionary<string, string> users = new Dictionary<string, string>();
        private readonly Dictionary<string, string> roles = new Dictionary<string, string>();

        public frmLogin()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security=True;");
            LoadUserData();
        }

        private void LoadUserData()
        {
            users.Clear(); 
            roles.Clear(); 

            try
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Username, Password, Authority FROM Employee", connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string username = reader["Username"].ToString();
                            string hashedPassword = reader["Password"].ToString(); 
                            string authority = reader["Authority"].ToString();

                            // Check if the username is already added
                            if (!users.ContainsKey(username))
                            {
                                users.Add(username, hashedPassword);
                                roles.Add(username, authority);
                                Console.WriteLine($"Loaded user: {username}, authority: {authority}"); 
                            }
                        }
                    }
                }

                MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading user data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if the username or password fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate the username and password 
            if (users.ContainsKey(username) && BCrypt.Net.BCrypt.Verify(password, users[username]))
            {
                string role = roles[username];
                Form nextForm;

                switch (role.ToLower())
                {
                    case "admin":
                        nextForm = new frmAdmin();
                        break;
                    case "sales":
                        nextForm = new frmSalesStaff();
                        break;
                    case "warehouse":
                        nextForm = new frmInventoryTransaction();
                        break;
                    default:
                        MessageBox.Show("Undefined role.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                nextForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Incorrect username or password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            frmChangePassword changePasswordForm = new frmChangePassword(users); 
            changePasswordForm.ShowDialog();
        }
    }
}
