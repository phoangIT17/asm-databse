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
    public partial class frmStatistics : Form
    {
        public frmStatistics()
        {
            InitializeComponent();
        }

        private void btnStatisticsImportedProduct_Click(object sender, EventArgs e)
        {
            FrmStatisticsImportedProduct importedProduct = new FrmStatisticsImportedProduct();
            this.Hide();
            importedProduct.ShowDialog();
        }

        private void btnStatisticSalesRevenue_Click(object sender, EventArgs e)
        {
            frmStatisticSalesRevenue frmStatisticSalesRevenue = new frmStatisticSalesRevenue();
            this.Hide();
            frmStatisticSalesRevenue.ShowDialog();  
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
            frmAdmin adminForm = new frmAdmin();
            adminForm.Show();
            this.Hide();
        }
    }
}
