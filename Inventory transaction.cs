﻿using System;
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
    public partial class frmInventoryTransaction : Form
    {
        SqlConnection connection;
        public frmInventoryTransaction()
        {
            InitializeComponent();
            txtEmployeeCode.Text = "  E003";
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            txtProductCode.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            txtProductCode.AutoCompleteSource = AutoCompleteSource.CustomSource;
            FillData();
            LoadProductCodes(); 
        }
        private void LoadProductCodes()
        {
            try
            {
                string query = "SELECT DISTINCT ProductCode FROM Product"; 
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection productCodes = new AutoCompleteStringCollection();

                while (reader.Read())
                {
                    productCodes.Add(reader["ProductCode"].ToString());
                }
                connection.Close();

                txtProductCode.AutoCompleteCustomSource = productCodes;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product codes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connection.Close();
            }
        }

        public void FillData()
        {
            string query = "SELECT * FROM InventoryTransaction";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvInventoryTransaction.DataSource = tb1;
            connection.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvInventoryTransaction.Rows[e.RowIndex];
            txtInventoryTransactionID.Text = row.Cells["InventoryTransactionID"].Value?.ToString();
            txtProductCode.Text = row.Cells["ProductCode"].Value?.ToString();
            txtEmployeeCode.Text = row.Cells["EmployeeCode"].Value?.ToString();
            cboTransactionType.Text = row.Cells["TransactionType"].Value?.ToString();
            txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();
            txtTransactionDate.Text = row.Cells["TransactionDate"].Value?.ToString();
        }

        private bool ValidateTransaction()
        {
            // Check if all required fields are filled
            if (string.IsNullOrWhiteSpace(txtProductCode.Text) ||
                string.IsNullOrWhiteSpace(txtEmployeeCode.Text) ||
                string.IsNullOrWhiteSpace(cboTransactionType.Text) ||
                string.IsNullOrWhiteSpace(txtQuantity.Text)) 
            {
                MessageBox.Show("Please fill in all the required fields.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if quantity is a positive integer
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Quantity must be a positive integer.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Check if transaction date is in the correct format
            if (!DateTime.TryParse(txtTransactionDate.Text, out _))
            {
                MessageBox.Show("Transaction date must be in a valid date format MM/DD/YYYY.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Validate that export quantity does not exceed available stock
            if (cboTransactionType.Text.Equals("Export", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    string stockQuery = "SELECT SUM(CASE WHEN TransactionType = 'Import' THEN Quantity ELSE -Quantity END) AS StockQuantity " +
                                        "FROM InventoryTransaction WHERE ProductCode = @productCode";
                    using (SqlCommand cmd = new SqlCommand(stockQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@productCode", txtProductCode.Text);

                        connection.Open();
                        object result = cmd.ExecuteScalar();
                        connection.Close();

                        int availableStock = result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;

                        if (quantity > availableStock)
                        {
                            MessageBox.Show($"Export quantity cannot exceed the Import quantity of {availableStock}.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error validating stock quantity: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    connection.Close();
                    return false;
                }
            }

            return true;
        }


        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate transaction
                if (!ValidateTransaction())
                {
                    return;
                }

                // Insert transaction
                string insertQuery = "INSERT INTO InventoryTransaction (ProductCode, EmployeeCode,TransactionType, Quantity, TransactionDate) " +
                                     "VALUES (@productcode, @employeecode ,@transactiontype, @quantity, @transactiondate)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@productcode", txtProductCode.Text);
                    cmd.Parameters.AddWithValue("@employeecode", txtEmployeeCode.Text);
                    cmd.Parameters.AddWithValue("@transactiontype", cboTransactionType.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@transactiondate", string.IsNullOrWhiteSpace(txtTransactionDate.Text)
                                                  ? (object)DateTime.Now
                                                  : DateTime.Parse(txtTransactionDate.Text));
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillData();
                    MessageBox.Show("Transaction added successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (string.IsNullOrWhiteSpace(txtInventoryTransactionID.Text))
                {
                    MessageBox.Show("Please select a transaction to update.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate transaction
                if (!ValidateTransaction())
                {
                    return;
                }

                // Update transaction
                string updateQuery = "UPDATE InventoryTransaction SET ProductCode = @productcode, " +
                                     "EmployeeCode = @employeecode, TransactionType = @transactiontype, " +
                                     "Quantity = @quantity, TransactionDate = @transactiondate " +
                                     "WHERE InventoryTransactionID = @transactionID";

                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@transactionID", txtInventoryTransactionID.Text);
                    cmd.Parameters.AddWithValue("@productcode", txtProductCode.Text);
                    cmd.Parameters.AddWithValue("@employeecode", txtEmployeeCode.Text);
                    cmd.Parameters.AddWithValue("@transactiontype", cboTransactionType.Text);
                    cmd.Parameters.AddWithValue("@quantity", txtQuantity.Text);
                    cmd.Parameters.AddWithValue("@transactiondate", string.IsNullOrWhiteSpace(txtTransactionDate.Text)
                                                          ? (object)DateTime.Now
                                                          : DateTime.Parse(txtTransactionDate.Text));
                    
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillData();
                    MessageBox.Show("Transaction updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (string.IsNullOrWhiteSpace(txtInventoryTransactionID.Text))
                {
                    MessageBox.Show("Please select a transaction to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string deleteQuery = "DELETE FROM InventoryTransaction WHERE InventoryTransactionID = @transactionID";

                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@transactionID", txtInventoryTransactionID.Text); 

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillData();
                    MessageBox.Show("Transaction deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtInventoryTransactionID.Clear();
            txtProductCode.Clear();
            cboTransactionType.SelectedIndex = -1;
            txtQuantity.Clear();
            txtTransactionDate.Clear();
            dgvInventoryTransaction.ClearSelection();
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
            frmLogin Login = new frmLogin();
            Login.Show();
            this.Hide();
        }

        private void btnShowQuantityInStock_Click(object sender, EventArgs e)
        {
            frmShowQuantityInStock showQuantityInStock = new frmShowQuantityInStock();
            this.Hide();
            showQuantityInStock.Show();
        }
       
    }

}