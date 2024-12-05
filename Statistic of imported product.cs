using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace Sales_Management
{
    public partial class FrmStatisticsImportedProduct : Form
    {
        SqlConnection connection;

        public FrmStatisticsImportedProduct()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security=True;");
            connection.Open();
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormatImageColumn();
            FormatTextBox();
            connection.Close();
        }

        private void FormatTextBox()
        {
            txtTotalImportedQuantity.TextAlign = HorizontalAlignment.Center; 
        }

        private void FormatImageColumn()
        {
            var imageColumn = dgvImportedProduct.Columns["ImageData"] as DataGridViewImageColumn;
            if (imageColumn != null)
            {
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dgvImportedProduct.RowTemplate.Height = 100;
            }
            dgvImportedProduct.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvImportedProduct.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvImportedProduct.DefaultCellStyle.Padding = new Padding(5);
        }

        private DataTable LoadData(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    P.ProductCode,
                    P.ProductName,
                    P.ProductBrand,
                    P.SellingPrice,
                    IT.TransactionDate AS Date,
                    I.ImageData, 
                    SUM(IT.Quantity) AS TotalImportedProduct
                FROM 
                    InventoryTransaction IT
                JOIN 
                    Product P ON IT.ProductCode = P.ProductCode
                JOIN 
                    Image I ON P.ProductID = I.ProductID
                WHERE 
                    IT.TransactionType = 'Import' AND 
                    IT.TransactionDate BETWEEN @StartDate AND @EndDate
                GROUP BY 
                    P.ProductCode, 
                    P.ProductName, 
                    P.ProductBrand, 
                    P.SellingPrice, 
                    IT.TransactionDate,  
                    I.ImageData
                ORDER BY 
                    P.ProductCode;";

            try
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Data loading failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value.Date;
            DateTime endDate = dtpEndDate.Value.Date;

            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be earlier than or equal to the end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Load filtered data.
            DataTable dt = LoadData(startDate, endDate);

            if (dt != null)
            {
                // Display data in DataGridView.
                dgvImportedProduct.DataSource = dt;
                int totalImportedQuantity = dt.AsEnumerable().Sum(row => row.Field<int>("TotalImportedProduct"));
                txtTotalImportedQuantity.Text = totalImportedQuantity.ToString(); 
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

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmStatistics frmStatistics = new frmStatistics();
            this.Hide();
            frmStatistics.ShowDialog();
        }
    }
}
