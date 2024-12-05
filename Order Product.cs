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
    public partial class frmOrderProduct : Form
    {
        SqlConnection connection;
        public frmOrderProduct()
        {
            InitializeComponent();
            txtEmployeeID.Text = "    2";
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillOrderProductData();
        }

        public void FillOrderProductData()
        {
            string query = @"SELECT * FROM Orders;";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvOrderProduct.DataSource = tb1;
            connection.Close();
        }
        private void dgvOrderProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvOrderProduct.Rows[e.RowIndex];
            txtOrderID.Text = row.Cells["OrderID"].Value?.ToString();
            txtOrderDate.Text = row.Cells["OrderDate"].Value?.ToString();
            txtEmployeeID.Text = row.Cells["EmployeeID"].Value?.ToString();
            txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString();
            txtShippingAddress.Text = row.Cells["ShippingAddress"].Value?.ToString();
            cboStatus.Text = row.Cells["Status"].Value?.ToString();
        }

        private void btnInsertOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Orders (CustomerID,EmployeeID,OrderDate,ShippingAddress,Status) " +
                                "VALUES (@CustomerID, @EmployeeID, @OrderDate, @ShippingAddress, @Status)";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    DateTime orderDate = string.IsNullOrWhiteSpace(txtOrderDate.Text)
                             ? DateTime.Now
                             : DateTime.Parse(txtOrderDate.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.Parameters.AddWithValue("@ShippingAddress", txtShippingAddress.Text);
                    cmd.Parameters.AddWithValue("@Status", cboStatus.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillOrderProductData();
                    MessageBox.Show("Product added successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "UPDATE Orders " +
                               "SET CustomerID = @CustomerID, EmployeeID = @EmployeeID, OrderDate = @OrderDate, " +
                               "ShippingAddress = @ShippingAddress, Status = @Status " +
                               "WHERE OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    cmd.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    DateTime orderDate = string.IsNullOrWhiteSpace(txtOrderDate.Text)
                             ? DateTime.Now
                             : DateTime.Parse(txtOrderDate.Text);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);
                    cmd.Parameters.AddWithValue("@ShippingAddress", txtShippingAddress.Text);
                    cmd.Parameters.AddWithValue("@Status", cboStatus.Text);
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        FillOrderProductData();
                        MessageBox.Show("Order updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Order not found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnDeleteOrder_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "DELETE FROM Orders WHERE OrderID = @OrderID";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@OrderID", txtOrderID.Text);

                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    connection.Close();

                    if (rowsAffected > 0)
                    {
                        FillOrderProductData();
                        MessageBox.Show("Order deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Order not found.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
