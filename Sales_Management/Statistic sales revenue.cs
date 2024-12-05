using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class frmStatisticSalesRevenue : Form
    {
        SqlConnection connection;

        public frmStatisticSalesRevenue()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security=True;");
            connection.Open();
            FormatImageColumn();
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void FormatImageColumn()
        {
            dgvSalesRevenue.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            foreach (DataGridViewColumn column in dgvSalesRevenue.Columns)
            {
                column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
       
    private DataTable LoadData(DateTime startDate, DateTime endDate)
        {
            string query = @"
                SELECT 
                    o.OrderID,
                    o.OrderDate,
                    p.ProductCode,
                    e.EmployeeCode,
                    od.Quantity,
                    od.UnitPrice,
                    ISNULL(p.Discount, 0) AS Discount,
                    (ISNULL(od.Quantity, 0) * ISNULL(od.UnitPrice, 0) * (1 - ISNULL(p.Discount, 0) / 100)) AS TotalPrice
                FROM Orders o
                JOIN OrderDetails od ON o.OrderID = od.OrderID
                JOIN Product p ON od.ProductID = p.ProductID
                JOIN Employee e ON o.EmployeeID = e.EmployeeID
                WHERE o.OrderDate BETWEEN @StartDate AND @EndDate
                ORDER BY o.OrderDate";

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
        private string FormatAsVND(decimal amount)
        {
            return string.Format("{0:N0} VND", amount); 
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
                dgvSalesRevenue.DataSource = dt;

                // Calculate total revenue safely.
                decimal totalRevenue = 0;

                if (dt.Columns.Contains("TotalPrice"))
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        if (row["TotalPrice"] != DBNull.Value)
                        {
                            try
                            {
                                totalRevenue += Convert.ToDecimal(row["TotalPrice"]);
                            }
                            catch (InvalidCastException)
                            {
                                MessageBox.Show("Invalid data type found in 'TotalPrice'. Please check the database values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                txtTotalRevenue.Text = FormatAsVND(totalRevenue);
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
