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
    public partial class frmImageManagement : Form
    {
        SqlConnection connection;
        public frmImageManagement()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security = True;");
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.None);
            FillProductImageData();
        }

        public void FillProductImageData()
        {
            string query = @"SELECT * FROM Image;";
            DataTable tb1 = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tb1);
            dgvProductImage.DataSource = tb1;
            connection.Close(); 
        }

        private void dgvProductImage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvProductImage.Rows[e.RowIndex];
            txtImageID.Text = row.Cells["ImageID"].Value?.ToString();
            txtProductID.Text = row.Cells["ProductID"].Value?.ToString();       
            txtImageDescription.Text = row.Cells["ImageDescription"].Value?.ToString();
            byte[] imgData = row.Cells["ImageData"].Value as byte[];

            if (imgData != null)
            {
                using (MemoryStream ms = new MemoryStream(imgData))
                {
                    picProductImage.Image = Image.FromStream(ms); 
                }
            }
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\Dell\\SUM\\Videos\\Desktop\\Downloads\\Product Image";
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    // Show image in PictureBox
                    picProductImage.Image = Image.FromFile(filePath);
                    picProductImage.Tag = filePath;     

                    // Add image into ListView
                    ListViewItem item = new ListViewItem();
                    item.Text = System.IO.Path.GetFileName(filePath);
                    item.Tag = filePath;

                    lvwListImage.Items.Add(item);
                }
            }
        }

        private void lvwListImage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwListImage.SelectedItems.Count > 0)
            {
                string filePath = lvwListImage.SelectedItems[0].Tag.ToString();
                picProductImage.Image = Image.FromFile(filePath);
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO Image (ProductID, ImageDescription, ImageData) " +
                                 "VALUES (@productID, @imageDescription, @imageData);"; 

            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@productID", txtProductID.Text);
                cmd.Parameters.AddWithValue("@imageDescription", txtImageDescription.Text);

                if (picProductImage.Tag != null && System.IO.File.Exists(picProductImage.Tag.ToString()))
                {
                    byte[] imageData = System.IO.File.ReadAllBytes(picProductImage.Tag.ToString());
                    cmd.Parameters.AddWithValue("@imageData", imageData);
                }
                else
                {
                    MessageBox.Show("Please select a valid image before inserting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Product image updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillProductImageData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = "UPDATE Image SET ProductID = @productID, ImageDescription = @imageDescription, " +
                         "ImageData = @imageData WHERE ImageID = @imageID";

            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@imageID", txtImageID.Text);
                cmd.Parameters.AddWithValue("@productID", txtProductID.Text);
                cmd.Parameters.AddWithValue("@imageDescription", txtImageDescription.Text);

                // Check if an image has been selected and the file exists
                if (picProductImage.Tag != null && System.IO.File.Exists(picProductImage.Tag.ToString()))
                {
                    // Convert the selected image to byte[] to store in the database
                    byte[] imageData = System.IO.File.ReadAllBytes(picProductImage.Tag.ToString());
                    cmd.Parameters.AddWithValue("@imageData", imageData);
                }
                else
                {
                    MessageBox.Show("Please select a valid image before updating.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Product image updated successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FillProductImageData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtImageID.Text))
            {
                MessageBox.Show("Please enter a valid ImageID to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string deleteQuery = "DELETE FROM Image WHERE ImageID = @imageID";

            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@imageID", txtImageID.Text);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

                MessageBox.Show("Product image deleted successfully.", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FillProductImageData();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmProductManagement frmProductManagement = new frmProductManagement();
            this.Hide();
            frmProductManagement.ShowDialog();
        }
    }
}
