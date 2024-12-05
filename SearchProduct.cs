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
    public partial class frmSearchProduct : Form
    {
        SqlConnection connection;
        public frmSearchProduct()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillProductData();
        }

        public void FillProductData()
        {
            string query = "SELECT ProductID, ProductCode, ProductName, SellingPrice, ProductImage FROM Product;";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvProduct.DataSource = tb1;
            connection.Close();
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProduct.Rows[e.RowIndex];
            txtProductId.Text = row.Cells["ProductID"].Value?.ToString();
            txtProductCode.Text = row.Cells["ProductCode"].Value?.ToString();
            txtProductName.Text = row.Cells["ProductName"].Value?.ToString();
            txtSellingPrice.Text = row.Cells["SellingPrice"].Value?.ToString();
            txtProductImage.Text = row.Cells["ProductImage"].Value?.ToString();
        }

        private void btnSeatch_Click(object sender, EventArgs e)
        {
            // Check if the search input is empty
            if (string.IsNullOrWhiteSpace(txtProductName.Text))
            {
                MessageBox.Show("Please enter a info product name to search.", "R", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string searchQuery = "SELECT ProductID, ProductCode, ProductName, SellingPrice, ProductImage FROM Product " +
                                 "WHERE ProductName LIKE '%' + @productname + '%'";
            DataTable dataTable = new DataTable();

            using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@productname", txtProductName.Text);
                adapter.Fill(dataTable);

                // Check if any records were found
                if (dataTable.Rows.Count == 0)
                {
                    MessageBox.Show("No products found. Please enter a different name.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvProduct.DataSource = null;
                }
                else
                {
                    dgvProduct.DataSource = dataTable;
                }
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            string sortQuery = "SELECT ProductID, ProductCode, ProductName, SellingPrice, ProductImage FROM Product " +
                               "ORDER BY ProductID ASC";
            DataTable dataTable = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sortQuery, connection))
            {
                adapter.Fill(dataTable);
                dgvProduct.DataSource = dataTable;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductId.Clear();
            txtProductCode.Clear();
            txtProductName.Clear();
            txtSellingPrice.Clear();  
            txtProductImage.Clear();
            dgvProduct.ClearSelection();
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

            frmUser userForm = new frmUser();
            userForm.Show();
            this.Hide();
        }

        
    }
}
