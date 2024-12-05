using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Management
{
    public partial class frmAdmin : Form
    {
        private Dictionary<string, string> users = new Dictionary<string, string>
        {
            { "admin", "admin123" },
            { "user", "user123" },
            { "warehouse", "warehouse123" }
        };
        public frmAdmin()
        {
            InitializeComponent();
        }

        private void btnManagementEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeManagement frmEmployee = new frmEmployeeManagement();
            this.Hide();
            frmEmployee.Show();
        }

        private void btnStastics_Click(object sender, EventArgs e)
        {
            frmStatistics frmStatistics = new frmStatistics();
            this.Hide();
            frmStatistics.Show();
        }

        private void btnWarehouseManagement_Click(object sender, EventArgs e)
        {
            frmInventoryTransaction frmInventoryTransaction = new frmInventoryTransaction();
            this.Hide();
            frmInventoryTransaction.Show();
        }

        private void btnSalesManagement_Click(object sender, EventArgs e)
        {
            frmSalesStaff frmSalesStaff = new frmSalesStaff();
            this.Hide();
            frmSalesStaff.Show();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
