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

namespace Sales_Management
{
    public partial class frmSupportCustomer : Form
    {
        SqlConnection connection;
        public frmSupportCustomer()
        {
            InitializeComponent();
            txtEmployeeID.Text = "    2";
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillData();
        }

        public void FillData()
        {
            string query = "SELECT * FROM Support;";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvSupport.DataSource = tb1;
            connection.Close();
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvSupport.Rows[e.RowIndex];
            txtSupportID.Text = row.Cells["SupportID"].Value?.ToString();
            txtEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString();
            txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString();          
            txtSupportDate.Text = row.Cells["SupportDate"].Value?.ToString();
            cboSupportType.Text = row.Cells["SupportType"].Value?.ToString();
            txtIssueDescription.Text = row.Cells["IssueDescription"].Value?.ToString();
        }

        private bool ValidateFields()
        {
            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(txtEmployeeID.Text) ||
                string.IsNullOrWhiteSpace(txtCustomerID.Text) ||
                string.IsNullOrWhiteSpace(txtSupportDate.Text) ||
                string.IsNullOrWhiteSpace(cboSupportType.Text) ||
                string.IsNullOrWhiteSpace(txtIssueDescription.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

                DateTime supportDate;
                if (!DateTime.TryParse(txtSupportDate.Text, out supportDate))
                {
                    MessageBox.Show("Support Date must be in the format MM/dd/yyyy.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupportDate.Focus();
                    return false;
                }

                return true; 
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {

                if (!ValidateFields())
                {
                    return; // Exit the method if validation fails
                }

                // Insert Support transaction
                string insertQuery = "INSERT INTO Support (EmployeeID, CustomerID, SupportDate, SupportType, IssueDescription) " +
                                     "VALUES (@employeeid, @customerid, @supportdate, @supporttype, @issuedescription)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    // Add parameters for the query
                    cmd.Parameters.AddWithValue("@employeeid", txtEmployeeID.Text);
                    cmd.Parameters.AddWithValue("@customerid", txtCustomerID.Text);
                    cmd.Parameters.AddWithValue("@supportdate", string.IsNullOrWhiteSpace(txtSupportDate.Text)
                                                 ? (object)DateTime.Now
                                                 : DateTime.Parse(txtSupportDate.Text));
                    cmd.Parameters.AddWithValue("@supporttype", cboSupportType.Text);
                    cmd.Parameters.AddWithValue("@issuedescription", txtIssueDescription.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    FillData();

                    MessageBox.Show("Support customer added successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (!ValidateFields())
                {
                    return; 
                }

                // Update Support transaction
                string updateQuery = "UPDATE Support SET EmployeeID = @employeeid, CustomerID = @customerid, " +
                                     "SupportDate = @supportdate, SupportType = @supporttype, IssueDescription = @issuedescription " +
                                     "WHERE SupportID = @supportid";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    // Add parameters for the query
                    cmd.Parameters.AddWithValue("@employeeid", txtEmployeeID.Text);
                    cmd.Parameters.AddWithValue("@customerid", txtCustomerID.Text);
                    cmd.Parameters.AddWithValue("@supportdate", string.IsNullOrWhiteSpace(txtSupportDate.Text)
                                                ? (object)DateTime.Now
                                                : DateTime.Parse(txtSupportDate.Text));
                    cmd.Parameters.AddWithValue("@supporttype", cboSupportType.Text);
                    cmd.Parameters.AddWithValue("@issuedescription", txtIssueDescription.Text);
                    cmd.Parameters.AddWithValue("@supportid", txtSupportID.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    FillData();

                    MessageBox.Show("Support transaction updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Delete Support transaction
                string deleteQuery = "DELETE FROM Support WHERE SupportID = @supportid";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    // Add parameters for the query
                    cmd.Parameters.AddWithValue("@supportid", txtSupportID.Text);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    FillData();

                    MessageBox.Show("Support transaction deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSupportID.Clear();
            txtEmployeeID.Clear();
            txtCustomerID.Clear();
            txtSupportDate.Clear();
            txtIssueDescription.Clear();
            cboSupportType.SelectedIndex = -1;
            dgvSupport.ClearSelection();
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
            frmSalesStaff frmSalesStaff = new frmSalesStaff();
            this.Hide();
            frmSalesStaff.ShowDialog();
        }
    }
}
