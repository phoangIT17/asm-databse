using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Versioning;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class frmProductManagement : Form
    {
        SqlConnection connection;

        public frmProductManagement()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillProductData();
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

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
            txtProductID.Text = row.Cells["ProductID"].Value?.ToString();
            txtProductCode.Text = row.Cells["ProductCode"].Value?.ToString();
            txtProductName.Text = row.Cells["ProductName"].Value?.ToString();
            txtProductBrand.Text = row.Cells["ProductBrand"].Value?.ToString();
            txtSellingPrice.Text = row.Cells["SellingPrice"].Value?.ToString();
            txtDiscount.Text = row.Cells["Discount"].Value?.ToString();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                // Insert product into the database
                string insertQuery = "INSERT INTO Product (ProductCode, ProductName, ProductBrand, SellingPrice, Discount) " +
                                     "VALUES (@productcode, @productname, @productbrand, @sellingprice, @discount)";
                using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@productcode", txtProductCode.Text);
                    cmd.Parameters.AddWithValue("@productname", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@productbrand", txtProductBrand.Text);
                    cmd.Parameters.AddWithValue("@sellingprice", decimal.Parse(txtSellingPrice.Text));
                    cmd.Parameters.AddWithValue("@discount", decimal.Parse(txtDiscount.Text));

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillProductData();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs()) return;

            try
            {
                // Update product in the database
                string updateQuery = "UPDATE Product SET ProductCode = @productcode, ProductName = @productname, ProductBrand = @productbrand, " +
                     "SellingPrice = @sellingprice, Discount = @discount WHERE ProductID = @productid";
                using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@productid", txtProductID.Text);
                    cmd.Parameters.AddWithValue("@productcode", txtProductCode.Text);
                    cmd.Parameters.AddWithValue("@productname", txtProductName.Text);
                    cmd.Parameters.AddWithValue("@productbrand", txtProductBrand.Text);
                    cmd.Parameters.AddWithValue("@sellingprice", decimal.Parse(txtSellingPrice.Text));
                    cmd.Parameters.AddWithValue("@discount", decimal.Parse(txtDiscount.Text));

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();

                    FillProductData();
                    MessageBox.Show("Product updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                // Delete product from the database
                string deleteQuery = "DELETE FROM Product WHERE ProductID = @productid";
                using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@productid", txtProductID.Text);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    FillProductData();
                    MessageBox.Show("Product deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (string.IsNullOrWhiteSpace(txtSearchProductName.Text))
            {
                MessageBox.Show("Please enter a product name to search.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchQuery = "SELECT * FROM Product WHERE ProductName LIKE '%' + @productname + '%'";
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@productname", txtSearchProductName.Text);
                adapter.Fill(dataTable);

                dgvProduct.DataSource = dataTable.Rows.Count > 0 ? dataTable : null;
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No products found.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            frmShowQuantityInStock frmUpdateInventory = new frmShowQuantityInStock();
            frmUpdateInventory.FormClosed += (s, args) => FillProductData();
            this.Hide();
            frmUpdateInventory.ShowDialog();
        }

        private void btnManageImage_Click(object sender, EventArgs e)
        {
            frmImageManagement manageImageForm = new frmImageManagement();
            manageImageForm.FormClosed += (s, args) => FillProductData();
            this.Hide();
            manageImageForm.ShowDialog();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmSalesStaff frmSalesStaff = new frmSalesStaff();
            this.Hide();
            frmSalesStaff.ShowDialog();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Clear();
            txtProductCode.Clear();
            txtProductName.Clear();
            txtProductBrand.Clear();
            txtSellingPrice.Clear();
            txtDiscount.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Validate input fields
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtProductCode.Text) ||
                string.IsNullOrWhiteSpace(txtProductName.Text) ||
                string.IsNullOrWhiteSpace(txtProductBrand.Text) ||
                string.IsNullOrWhiteSpace(txtSellingPrice.Text) ||
                string.IsNullOrWhiteSpace(txtDiscount.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if ProductCode is unique
            if (IsProductCodeDuplicate(txtProductCode.Text))
            {
                MessageBox.Show("Product code already exists. Please enter a unique product code.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if SellingPrice is a positive number
            if (!decimal.TryParse(txtSellingPrice.Text, out decimal sellingPrice) || sellingPrice <= 0)
            {
                MessageBox.Show("Selling price must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Check if Discount is a positive number
            if (!decimal.TryParse(txtDiscount.Text, out decimal discount) || discount < 0)
            {
                MessageBox.Show("Discount must be a non-negative number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // Check for duplicate product code in the database
        private bool IsProductCodeDuplicate(string productCode)
        {
            string checkQuery = "SELECT COUNT(*) FROM Product WHERE ProductCode = @productcode";
            using (SqlCommand cmd = new SqlCommand(checkQuery, connection))
            {
                cmd.Parameters.AddWithValue("@productcode", productCode);
                connection.Open();
                int count = (int)cmd.ExecuteScalar();
                connection.Close();
                return count > 0;
            }
        }

    }
}
