using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class frmAddProduct : Form
    {
        SqlConnection connection;
        public frmAddProduct()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillProductData();
            FillPurchasedInfoProductData();
        }

        public void FillProductData()
        {
            string query = @"SELECT * FROM Product ";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvProduct.DataSource = tb1;
            connection.Close();
        }

        private void FillPurchasedInfoProductData()
        {
            string query = @"SELECT OrderDetailsID, OrderID, ProductID, Quantity, UnitPrice
                            FROM OrderDetails
                            ORDER BY OrderID;";
            DataTable tb2 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb2);
            dgvPurchasedInfoProduct.DataSource = tb2;
            connection.Close();
        }

        private void dgvPurchasedInfoProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row index
            {
                try
                {
                    DataGridViewRow row = dgvPurchasedInfoProduct.Rows[e.RowIndex];
                    txtOrderDetailsID.Text = row.Cells["OrderDetailsID"].Value?.ToString() ?? string.Empty;
                    txtProductID.Text = row.Cells["ProductID"].Value?.ToString() ?? string.Empty;
                    txtOderID.Text = row.Cells["OrderID"].Value?.ToString() ?? string.Empty;
                    txtQuantity.Text = row.Cells["Quantity"].Value?.ToString() ?? string.Empty;
                    txtUnitPrice.Text = row.Cells["UnitPrice"].Value?.ToString() ?? string.Empty;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred while populating the fields: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
            ////txtProductID.Text = row.Cells["ProductID"].Value?.ToString();  
            //txtUnitPrice.Text = row.Cells["SellingPrice"].Value?.ToString();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {           
            try
            {
                // SQL command to insert into OrderDetails
                string queryOrderDetails = "INSERT INTO OrderDetails (OrderID, ProductID, Quantity, UnitPrice) " +
                                            "VALUES (@OrderID, @ProductID, @Quantity, @UnitPrice)";

                // SQL command to insert into InventoryTransaction
                string queryInsertInventoryTransaction = "INSERT INTO InventoryTransaction (ProductCode, EmployeeCode, TransactionType, Quantity, TransactionDate) " +
                                                         "VALUES ((SELECT ProductCode FROM Product WHERE ProductID = @ProductID), 'E003', 'Export', @Quantity, @TransactionDate);";

                using (SqlCommand cmdOrderDetails = new SqlCommand(queryOrderDetails, connection))
                using (SqlCommand cmdInsertInventoryTransaction = new SqlCommand(queryInsertInventoryTransaction, connection))
                {
                    connection.Open();

                    // Add parameters for OrderDetails
                    cmdOrderDetails.Parameters.AddWithValue("@OrderID", txtOderID.Text);
                    cmdOrderDetails.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmdOrderDetails.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                    cmdOrderDetails.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text));

                    // Execute insertion into OrderDetails
                    cmdOrderDetails.ExecuteNonQuery();

                    // Add parameters for InventoryTransaction
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@TransactionDate", DateTime.Now); 

                    // Execute insertion into InventoryTransaction
                    cmdInsertInventoryTransaction.ExecuteNonQuery();

                    connection.Close();

                    // Refresh displayed data
                    FillPurchasedInfoProductData();
                    MessageBox.Show("Product added successfully and inventory updated.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed in case of an error
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnUpdateProduct_Click(object sender, EventArgs e)
        {
            try
            {
                // SQL command to get the current quantity from OrderDetails
                string queryGetCurrentQuantity = "SELECT Quantity FROM OrderDetails WHERE OrderID = @OrderID AND ProductID = @ProductID";

                // SQL command to update OrderDetails
                string queryUpdateOrderDetails = "UPDATE OrderDetails SET " +
                             "OrderID = @OrderID, " +
                             "ProductID = @ProductID, " +
                             "Quantity = @Quantity, " +
                             "UnitPrice = @UnitPrice " +
                             "WHERE OrderDetailsID = @OrderDetailsID";

                // SQL command to insert into InventoryTransaction for adjustment
                string queryInsertInventoryTransaction = "INSERT INTO InventoryTransaction (ProductCode, EmployeeCode, TransactionType, Quantity, TransactionDate) " +
                                                         "VALUES ((SELECT ProductCode FROM Product WHERE ProductID = @ProductID), 'E003', @TransactionType, @Quantity, @TransactionDate);";

                using (SqlCommand cmdGetCurrentQuantity = new SqlCommand(queryGetCurrentQuantity, connection))
                using (SqlCommand cmdUpdateOrderDetails = new SqlCommand(queryUpdateOrderDetails, connection))
                using (SqlCommand cmdInsertInventoryTransaction = new SqlCommand(queryInsertInventoryTransaction, connection))
                {
                    connection.Open();

                    // Add parameters for getting current quantity
                    cmdGetCurrentQuantity.Parameters.AddWithValue("@OrderID", txtOderID.Text);
                    cmdGetCurrentQuantity.Parameters.AddWithValue("@ProductID", txtProductID.Text);

                    // Get the current quantity
                    object result = cmdGetCurrentQuantity.ExecuteScalar();
                    int currentQuantity = (result != null) ? Convert.ToInt32(result) : 0; // Kiểm tra null
                    int newQuantity = Convert.ToInt32(txtQuantity.Text);
                    int quantityChange = newQuantity - currentQuantity;

                    cmdUpdateOrderDetails.Parameters.AddWithValue("@OrderDetailsID", txtOrderDetailsID.Text);
                    cmdUpdateOrderDetails.Parameters.AddWithValue("@OrderID", txtOderID.Text);
                    cmdUpdateOrderDetails.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmdUpdateOrderDetails.Parameters.AddWithValue("@Quantity", newQuantity);
                    cmdUpdateOrderDetails.Parameters.AddWithValue("@UnitPrice", Convert.ToDecimal(txtUnitPrice.Text));

                    // Execute update on OrderDetails
                    cmdUpdateOrderDetails.ExecuteNonQuery();

                    // Determine the transaction type based on quantity change
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@Quantity", Math.Abs(quantityChange));
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@TransactionDate", DateTime.Now);
                    cmdInsertInventoryTransaction.Parameters.AddWithValue("@TransactionType", quantityChange > 0 ? "Export" : "Import");

                    // Execute insertion into InventoryTransaction
                    cmdInsertInventoryTransaction.ExecuteNonQuery();

                    connection.Close();

                    // Refresh displayed data
                    FillPurchasedInfoProductData();
                    MessageBox.Show("Product updated successfully and inventory adjusted.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed in case of an error
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            try
            {
    
                string queryDeleteOrderDetails = "DELETE FROM OrderDetails WHERE OrderID = @OrderID AND ProductID = @ProductID";

                string queryInsertInventoryTransaction = "INSERT INTO InventoryTransaction (ProductCode, EmployeeCode, TransactionType, Quantity, TransactionDate) " +
                                                         "VALUES ((SELECT ProductCode FROM Product WHERE ProductID = @ProductID), 'E003', 'Import', @Quantity, @TransactionDate);";


                using (SqlCommand cmdDeleteOrderDetails = new SqlCommand(queryDeleteOrderDetails, connection))
                using (SqlCommand cmdAdjustInventoryTransaction = new SqlCommand(queryInsertInventoryTransaction, connection))
                {
                    connection.Open();

                    cmdDeleteOrderDetails.Parameters.AddWithValue("@OrderID", txtOderID.Text);
                    cmdDeleteOrderDetails.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmdDeleteOrderDetails.ExecuteNonQuery();

                    cmdAdjustInventoryTransaction.Parameters.AddWithValue("@ProductID", txtProductID.Text);
                    cmdAdjustInventoryTransaction.Parameters.AddWithValue("@Quantity", Convert.ToInt32(txtQuantity.Text));
                    cmdAdjustInventoryTransaction.Parameters.AddWithValue("@TransactionDate", DateTime.Now); 

                    cmdAdjustInventoryTransaction.ExecuteNonQuery();

                    connection.Close();

                    // Refresh displayed data
                    FillPurchasedInfoProductData();
                    MessageBox.Show("Product deleted successfully and inventory adjusted.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Ensure the connection is closed in case of an error
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmInvoicing invoicing = new frmInvoicing();
            this.Hide();
            invoicing.ShowDialog();
        }
    }   
}
