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
            dgvOrderProduct.DataSource = tb1;
            connection.Close();
        }

        private void btnOrderProduct_Click(object sender, EventArgs e)
        {
            // Retrieve product details from the form's text boxes
            string customerId = txtCustomerID.Text;
            string customerName = txtCustomerName.Text;
            string phoneNumber = txtPhoneNumber.Text;
            string address = txtAddress.Text;
            string email = txtEmail.Text;
            string orderDate = txtOrderDate.Text;
            string productName = txtProductName.Text;

            // Parse unit price and quantity for total calculation
            decimal sellingPrice;
            int quantity;

            // Attempt to parse unit price and quantity
            if (decimal.TryParse(txtSellingPrice.Text, out sellingPrice) && int.TryParse(txtQuantity.Text, out quantity))
            {
                decimal total = sellingPrice * quantity;

                // Display customer and order details with total
                MessageBox.Show(
                    $"----------------------------\n" +
                    $"Customer Information:\n" +
                    $"Customer ID: {customerId}\n" +
                    $"Customer Name: {customerName}\n" +
                    $"Phone Number: {phoneNumber}\n" +
                    $"Address: {address}\n" +
                    $"Email: {email}\n" +
                    $"Order Date: {orderDate}\n" +
                    $"----------------------------\n" +
                    $"Order Details:\n" +
                    $"Product Name: {productName}\n" +
                    $"Selling Price: {sellingPrice:N0} VND\n" +
                    $"Quantity: {quantity}\n" +
                    $"----------------------------\n" +
                    $"Total Amount: {total:N0} VND",
                    "Order Summary"
                );
            }
            else
            {
                MessageBox.Show("Please check the Unit Price and Quantity fields. They must be numeric values.", "Input Error");
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            frmPayment frmPayment = new frmPayment();
            frmPayment.Show();
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

        private void dgvOrderProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvOrderProduct.Rows[e.RowIndex];
            txtProductName.Text = row.Cells["ProductName"].Value?.ToString();
            txtSellingPrice.Text = row.Cells["SellingPrice"].Value?.ToString();

        }
    }
}
