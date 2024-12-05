using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class frmShowQuantityInStock : Form
    {
        SqlConnection connection;
        public frmShowQuantityInStock()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillData();
            FormatImageColumn();
        }

        public void FillData()
        {
            string query = @"
                WITH ImageCTE AS (
                    SELECT 
                        ImageID,
                        ProductID,
                        ImageData,
                        ROW_NUMBER() OVER (PARTITION BY ProductID ORDER BY ImageID) AS RowNum
                    FROM 
                        Image
                ),
                TransactionCTE AS (
                    SELECT 
                        it.ProductCode,
                        it.InventoryTransactionID,
                        it.EmployeeCode,
                        it.TransactionType,
                        it.Quantity,
                        ROW_NUMBER() OVER (PARTITION BY it.ProductCode ORDER BY it.InventoryTransactionID ASC) AS RowNum
                    FROM 
                        InventoryTransaction it
                )
                SELECT 
                    MIN(t.InventoryTransactionID) AS InventoryTransactionID,   
                    p.ProductCode,
                    MIN(t.EmployeeCode) AS EmployeeCode,
                    p.ProductName,
                    p.ProductBrand,
                    p.SellingPrice,
                    SUM(
                        CASE 
                            WHEN t.TransactionType = 'Import' THEN t.Quantity
                            WHEN t.TransactionType = 'Export' THEN -t.Quantity
                            ELSE 0
                        END
                    ) AS StockQuantity, 
                    img.ImageData  
                FROM 
                    Product p
                LEFT JOIN 
                    TransactionCTE t ON t.ProductCode = p.ProductCode
                LEFT JOIN 
                    ImageCTE img ON img.ProductID = p.ProductID AND img.RowNum = 1  
                GROUP BY 
                    p.ProductCode, 
                    p.ProductName, 
                    p.ProductBrand, 
                    p.SellingPrice, 
                    img.ImageData
                ORDER BY 
                    InventoryTransactionID ASC;";

            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvInventoryTransaction.DataSource = tb1;
            connection.Close();
        }
        private void FormatImageColumn()
        {
            var imageColumn = dgvInventoryTransaction.Columns["ImageData"] as DataGridViewImageColumn;
            if (imageColumn != null)
            {
                imageColumn.ImageLayout = DataGridViewImageCellLayout.Stretch; 
                dgvInventoryTransaction.RowTemplate.Height = 100; 
            }
            dgvInventoryTransaction.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvInventoryTransaction.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvInventoryTransaction.DefaultCellStyle.Padding = new Padding(5);
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmInventoryTransaction frmInventoryTransaction = new frmInventoryTransaction();
            this.Hide();
            frmInventoryTransaction.ShowDialog();
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
