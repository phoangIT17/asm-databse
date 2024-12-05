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
    public partial class frmSalesStaff : Form
    {
        public frmSalesStaff()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnManagementProduct_Click(object sender, EventArgs e)
        {
            frmProductManagement frmProductManagement = new frmProductManagement();
            this.Hide();
            frmProductManagement.Show();
        }

        private void btnManagementCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerManagement frmManagementCustomer = new frmCustomerManagement();
            this.Hide();
            frmManagementCustomer.Show();
        }

        private void btnInvoicing_Click(object sender, EventArgs e)
        {
            frmInvoicing frmInvoicing = new frmInvoicing();
            this.Hide();
            frmInvoicing.Show();
        }

        private void btnSupportCustomer_Click(object sender, EventArgs e)
        {
            frmSupportCustomer frmSupportCustomer = new frmSupportCustomer();
            this.Hide();
            frmSupportCustomer.Show();
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
