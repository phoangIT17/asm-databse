using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Sales_Management
{
    public partial class frmEmployeeManagement : Form
    {
        SqlConnection connection;
        public frmEmployeeManagement()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillEmployeeData();
        }

        public void FillEmployeeData()
        {
            string query = "SELECT * FROM Employee";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvEmployee.DataSource = tb1;
            connection.Close();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];
            txtEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString();
            txtEmployeeCode.Text = row.Cells["EmployeeCode"].Value?.ToString();
            txtEmployeeName.Text = row.Cells["EmployeeName"].Value?.ToString();
            cboPosition.Text = row.Cells["Position"].Value?.ToString();
            txtUsername.Text = row.Cells["Username"].Value?.ToString();
            txtPassword.Text = row.Cells["Password"].Value?.ToString();
            cboAuthority.SelectedItem = row.Cells["Authority"].Value?.ToString();
        }

        private bool ValidateEmployeeData()
        {
            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(txtEmployeeCode.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeName.Text) ||
                string.IsNullOrWhiteSpace(txtUsername.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                cboPosition.SelectedIndex == -1 ||
                cboAuthority.SelectedIndex == -1)
            {
                MessageBox.Show("All fields must be filled.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the Employee code must be 4 characters or longer
            if (txtEmployeeCode.Text.Length < 4)
            {
                MessageBox.Show("Employee code must be 4 characters or longer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the Employee code does not contain spaces
            if (txtEmployeeCode.Text.Contains(" "))
            {
                MessageBox.Show("Employee code must not contain spaces.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the employee name does not contain special characters
            if (System.Text.RegularExpressions.Regex.IsMatch(txtEmployeeName.Text, @"[^a-zA-Z\s]"))
            {
                MessageBox.Show("Employee name must not contain special characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if the password meets complexity requirements
            if (txtPassword.Text.Length < 8 ||
                !System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, @"[A-Z]") || 
                !System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, @"[a-z]") || 
                !System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, @"\d") ||   
                !System.Text.RegularExpressions.Regex.IsMatch(txtPassword.Text, @"[@$!%*?&]")) 
            {
                MessageBox.Show("Password must be at least 8 characters long and include uppercase, lowercase, digits, and special characters.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate the input data
                if (!ValidateEmployeeData())
                {
                    return; 
                }

                // Hash the password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                // Insert employee
                string insertQuery = "INSERT INTO Employee (EmployeeCode, EmployeeName, Position, Username, Password, Authority) " +
                                     "VALUES (@employeecode, @employeename, @position, @username, @password, @authority)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@employeecode", txtEmployeeCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeename", txtEmployeeName.Text.Trim());
                    cmd.Parameters.AddWithValue("@position", cboPosition.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", hashedPassword); 
                    cmd.Parameters.AddWithValue("@authority", cboAuthority.SelectedItem?.ToString());

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillEmployeeData();
                    MessageBox.Show("Employee added successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an employee is selected for updating
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
                {
                    MessageBox.Show("Please select an employee to update.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Validate the input data
                if (!ValidateEmployeeData())
                {
                    return; 
                }

                // Hash the password
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPassword.Text);

                // Update employee
                string updateQuery = "UPDATE Employee SET EmployeeCode=@employeecode, EmployeeName=@employeename, Position=@position, " +
                                     "Username=@username, Password=@password, Authority=@authority WHERE EmployeeID=@employeeid";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@employeeid", txtEmployeeID.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeecode", txtEmployeeCode.Text.Trim());
                    cmd.Parameters.AddWithValue("@employeename", txtEmployeeName.Text.Trim());
                    cmd.Parameters.AddWithValue("@position", cboPosition.Text.Trim());
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@authority", cboAuthority.SelectedItem?.ToString());

                    connection.Open();
                    int affectedRows = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (affectedRows > 0)
                    {
                        FillEmployeeData();
                        MessageBox.Show("Employee updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No employee found to update.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtEmployeeID.Text))
                {
                    MessageBox.Show("Please select an employee to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Delete the employee
                string deleteQuery = "DELETE FROM Employee WHERE EmployeeID = @employeeid";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@employeeid", txtEmployeeID.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillEmployeeData();
                    MessageBox.Show("Employee deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchEmployeeName.Text))
            {
                MessageBox.Show("Please enter an employee name to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchQuery = "SELECT * FROM Employee WHERE EmployeeName LIKE '%' + @employeename + '%'";
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@employeename", txtSearchEmployeeName.Text);
                adapter.Fill(dataTable);

                dgvEmployee.DataSource = dataTable.Rows.Count > 0 ? dataTable : null;
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No employees found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string sortQuery = "SELECT * FROM Employee ORDER BY EmployeeID ASC";
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sortQuery, connection))
            {
                adapter.Fill(dataTable);
                dgvEmployee.DataSource = dataTable;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtEmployeeCode.Clear();
            txtEmployeeName.Clear();
            cboPosition.SelectedIndex = -1;
            txtUsername.Clear();
            txtPassword.Clear();
            cboAuthority.SelectedIndex = -1;
            dgvEmployee.ClearSelection();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmAdmin adminForm = new frmAdmin();
            this.Hide();
            adminForm.Show();
        }
    }
}
