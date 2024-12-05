using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class frmCustomerManagement : Form
    {
        SqlConnection connection;

        public frmCustomerManagement()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security=True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillCustomerData(); 
        }

        public void FillCustomerData()
        {
            string query = "SELECT * FROM Customer;";
            DataTable customerTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            adapter.Fill(customerTable);
            dgvCustomer.DataSource = customerTable; 
            connection.Close(); 
        }

        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvCustomer.Rows[e.RowIndex];
            txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString();
            txtCustomerName.Text = row.Cells["CustomerName"].Value?.ToString();
            txtBirthdate.Text = row.Cells["Birthdate"].Value?.ToString();
            txtPhoneNumber.Text = row.Cells["PhoneNumber"].Value?.ToString();
            txtAddress.Text = row.Cells["Address"].Value?.ToString();
            txtEmail.Text = row.Cells["Email"].Value?.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            // Validate input 
            if (!IsValidInput()) return;

            try
            {
                // Check if phone number is unique
                if (!IsPhoneNumberUnique(txtPhoneNumber.Text))
                {
                    MessageBox.Show("Phone number already exists. Please enter a different number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Insert new customer 
                string insertQuery = "INSERT INTO Customer (CustomerName, Birthdate, PhoneNumber, Address, Email) " +
                                     "VALUES (@customername, @birthdate, @phonenumber, @address, @email)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@customername", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@birthdate", txtBirthdate.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    connection.Open(); 
                    cmd.ExecuteNonQuery(); 
                    connection.Close(); 

                    FillCustomerData(); 
                    MessageBox.Show("Customer added successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Validate input 
            if (!IsValidInput()) return;

            try
            {
                // Ensure a customer is selected for update
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Please select a customer to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update customer details 
                string updateQuery = "UPDATE Customer SET CustomerName=@customername, Birthdate=@birthdate, PhoneNumber=@phonenumber, " +
                                     "Address=@address, Email=@email WHERE CustomerID=@customerid";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@customerid", int.Parse(txtCustomerID.Text));
                    cmd.Parameters.AddWithValue("@customername", txtCustomerName.Text);
                    cmd.Parameters.AddWithValue("@birthdate", txtBirthdate.Text);
                    cmd.Parameters.AddWithValue("@phonenumber", txtPhoneNumber.Text);
                    cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                    connection.Open(); 
                    int affectedRows = cmd.ExecuteNonQuery(); 
                    connection.Close(); 

                    if (affectedRows > 0)
                    {
                        FillCustomerData(); 
                        MessageBox.Show("Customer updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No customer found to update.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (string.IsNullOrWhiteSpace(txtCustomerID.Text))
                {
                    MessageBox.Show("Please select a customer to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!int.TryParse(txtCustomerID.Text, out int customerId))
                {
                    MessageBox.Show("Customer ID must be an integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string deleteQuery = "DELETE FROM Customer WHERE CustomerID = @customerid";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@customerid", customerId);
                    connection.Open(); 
                    cmd.ExecuteNonQuery(); 
                    connection.Close(); 

                    FillCustomerData(); 
                    MessageBox.Show("Customer deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Validate search input
            if (string.IsNullOrWhiteSpace(txtSearchByName.Text))
            {
                MessageBox.Show("Please enter a customer name to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Search for customers by name
            string searchQuery = "SELECT * FROM Customer WHERE CustomerName LIKE '%' + @customername + '%'";
            DataTable searchResults = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@customername", txtSearchByName.Text);
                adapter.Fill(searchResults);

                dgvCustomer.DataSource = searchResults.Rows.Count > 0 ? searchResults : null;
                if (searchResults.Rows.Count == 0)
                {
                    MessageBox.Show("No customers found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string sortQuery = "SELECT * FROM Customer ORDER BY CustomerID ASC";
            DataTable sortedData = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sortQuery, connection))
            {
                adapter.Fill(sortedData);
                dgvCustomer.DataSource = sortedData; 
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtCustomerName.Clear();
            txtBirthdate.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            dgvCustomer.ClearSelection(); 
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmSalesStaff frmSalesStaff = new frmSalesStaff();
            this.Hide();
            frmSalesStaff.ShowDialog();
        }

        private void btnReturnInvoice_Click(object sender, EventArgs e)
        {
            frmInvoicing frmInvoicing = new frmInvoicing();
            this.Hide();
            frmInvoicing.ShowDialog();
        }

        private bool IsValidInput()
        {
            // Validate input fields for empty or invalid data
            if (string.IsNullOrWhiteSpace(txtCustomerName.Text) ||
                string.IsNullOrWhiteSpace(txtPhoneNumber.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtBirthdate.Text))
            {
                MessageBox.Show("All fields must be filled.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check that the phone number is a number and has a valid length 10-11 characters.
            if (txtPhoneNumber.Text.Length < 10 || txtPhoneNumber.Text.Length > 11)
            {
                MessageBox.Show("The phone number must have between 10 to 11 characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate email format
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Invalid email format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check the date of birth format
            if (!DateTime.TryParse(txtBirthdate.Text, out DateTime birthdate))
            {
                MessageBox.Show("Invalid date format. Please enter a date in MM/dd/yyyy format.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validate that phone number is an integer
            if (!IsPhoneNumberInteger(txtPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must be an integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check that the customer's name does not contain special characters.
            if (!IsValidCustomerName(txtCustomerName.Text))
            {
                MessageBox.Show("Customer names must not contain special characters.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true; 
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool IsValidCustomerName(string customerName)
        {
            string pattern = @"^[a-zA-Z\s]+$";
            return Regex.IsMatch(customerName, pattern);
        }

        private bool IsPhoneNumberUnique(string phoneNumber)
        {
            string query = "SELECT COUNT(*) FROM Customer WHERE PhoneNumber = @phonenumber";
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@phonenumber", phoneNumber);
                connection.Open(); 
                int count = (int)cmd.ExecuteScalar(); 
                connection.Close(); 

                return count == 0;
            }
        }
        private bool IsPhoneNumberInteger(string phoneNumber)
        {
            return phoneNumber.All(char.IsDigit); 
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
