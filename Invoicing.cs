using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
namespace Sales_Management
{
    public partial class frmInvoicing : Form
    {
        private SqlConnection connection;

        public frmInvoicing()
        {
            InitializeComponent();
            txtEmployeeCode.Text = "    E002";
            connection = new SqlConnection("Server=DESKTOP-IP1KBSG\\PHAMVANHOANG;Database=Sales_Management_System;Integrated Security=True;");
            connection.Open();
            MessageBox.Show(this, "Successful connection!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PopulateCustomerIDs();
            PopulateOrderIDs();
        }

        private void PopulateCustomerIDs()
        {
            string query = "SELECT CustomerName FROM Customer ORDER BY CustomerName ASC";
            PopulateComboBox(cboCustomerName, query, "CustomerName");
        }

        private void PopulateOrderIDs()
        {
            string query = "SELECT CustomerID FROM Orders ORDER BY CustomerID ASC";
            PopulateComboBox(cboCustomerID, query, "CustomerID");
        }

        private void PopulateComboBox(ComboBox comboBox, string query, string displayMember)
        {
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    DataRow row = dt.NewRow();
                    row[displayMember] = DBNull.Value;
                    dt.Rows.InsertAt(row, 0);

                    comboBox.DisplayMember = displayMember;
                    comboBox.ValueMember = displayMember;
                    comboBox.DataSource = dt;
                    comboBox.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerName.SelectedValue != null && cboCustomerName.SelectedValue != DBNull.Value)
            {
                FetchCustomerDetails(cboCustomerName.SelectedValue.ToString());
            }
            else
            {
                ClearCustomerDetails();
            }
        }

        private void FetchCustomerDetails(string customerName)
        {
            string query = "SELECT * FROM Customer WHERE CustomerName = @CustomerName";
            ExecuteReader(query, reader =>
            {
                if (reader.Read())
                {
                    txtCustomerID.Text = reader["CustomerID"].ToString();
                    txtBirthdate.Text = Convert.ToDateTime(reader["Birthdate"]).ToString("dd/MM/yyyy");
                    txtPhoneNumber.Text = reader["PhoneNumber"].ToString();
                    txtAddress.Text = reader["Address"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                }
            }, ("@CustomerName", customerName));
        }

        private void ClearCustomerDetails()
        {
            txtCustomerID.Clear();
            txtBirthdate.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
        }


        // Get order details information
        private void FetchOrderDetails(string customerID)
        {
            string query = "SELECT * FROM Orders WHERE CustomerID = @CustomerID";
            ExecuteReader(query, reader =>
            {
                if (reader.Read())
                {
                    txtOrderID.Text = reader["OrderID"].ToString();
                    txtEmployeeID.Text = reader["EmployeeID"].ToString();
                    txtOrderDate.Text = Convert.ToDateTime(reader["OrderDate"]).ToString("dd/MM/yyyy");
                    txtShippingAddress.Text = reader["ShippingAddress"].ToString();
                    txtStatus.Text = reader["Status"].ToString();
                }
            }, ("@CustomerID", customerID));

   
            FillProductData(customerID);
        }

        private void ClearOrderDetails()
        {
            txtOrderID.Clear();
            txtEmployeeID.Clear();
            txtOrderDate.Clear();
            txtShippingAddress.Clear();
            txtStatus.Clear();
            dgvListPurchasedProduct.DataSource = null; 
        }

        private void cboCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerID.SelectedValue != null && cboCustomerID.SelectedValue != DBNull.Value)
            {
                FetchOrderDetails(cboCustomerID.SelectedValue.ToString());
            }
            else
            {
                ClearOrderDetails();
            }
        }

        private void ExecuteReader(string query, Action<SqlDataReader> handleData, params (string, object)[] parameters)
        {
            try
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Item1, param.Item2);
                    }

                    if (connection.State == ConnectionState.Closed)
                    {
                        connection.Open();
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        handleData(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing query: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void FillProductData(string orderID)
        {
            string query = "SELECT * FROM OrderDetails WHERE OrderID = @OrderID";
            DataTable tbl = new DataTable();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@OrderID", orderID);
                    adapter.Fill(tbl);
                }

                if (tbl.Rows.Count > 0)
                {
                    dgvListPurchasedProduct.DataSource = tbl;
                }
                else
                {
                    dgvListPurchasedProduct.DataSource = null; 
                    MessageBox.Show("No order details found for this order.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching product data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInsertOrder_Click(object sender, EventArgs e)
        {
            frmOrderProduct orderProduct = new frmOrderProduct();
            orderProduct.ShowDialog();
            PopulateOrderIDs(); 
        }

        private void btnInsertCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerManagement managementCustomer = new frmCustomerManagement();
            this.Hide();
            managementCustomer.ShowDialog();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            frmAddProduct addProduct = new frmAddProduct();
            addProduct.ShowDialog();
        }

        private void btnExportInvoice_Click(object sender, EventArgs e)
        {
            // Check if all required invoice information is filled
            if (string.IsNullOrEmpty(cboCustomerID.Text) || cboCustomerID.SelectedValue == null)
            {
                MessageBox.Show("Invoice printing information cannot be left blank. Please fill in all information before issuing invoice.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // Check if at least one product is added to the invoice
            if (dgvListPurchasedProduct.Rows.Count == 0)
            {
                MessageBox.Show("No products have been added to the invoice yet. Please add products before printing the invoice.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }

            // Put order ID into a variable
            string orderID = cboCustomerID.SelectedValue.ToString();

            string customerName = cboCustomerName.Text.Trim();

            string sanitizedFileName = SanitizeFileName(customerName) + "_Invoice.pdf";

            // Create SaveFileDialog
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                FileName = sanitizedFileName, 
                Filter = "PDF files (*.pdf)|*.pdf",
                Title = "Save Invoice PDF"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Initialize PDF document
                    Document pdfDoc = new Document(PageSize.A4, 25, 25, 30, 30);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    pdfDoc.Open();

                    iTextSharp.text.Font headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
                    Paragraph header = new Paragraph("SALES INVOICE", headerFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(header);
                    pdfDoc.Add(new Paragraph("\n"));

                    // Company information
                    iTextSharp.text.Font companyInfoFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                    Paragraph companyInfo = new Paragraph("COMPANY SALES X\n66 Vo Van Tan, Da Nang\nPhone: 0333456789", companyInfoFont)
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(companyInfo);

                    pdfDoc.Add(new Paragraph("\n"));
                    pdfDoc.Add(new Paragraph("\n"));

                    // Order information
                    PdfPTable invoiceInfoTable = new PdfPTable(4); 
                    invoiceInfoTable.WidthPercentage = 100;
                    invoiceInfoTable.SetWidths(new float[] { 20, 30, 20, 30 }); 

                    // Line 1: Invoice number và Customer ID
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase("Invoice number:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12,
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase(cboCustomerID.Text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, 
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase("Customer ID:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, 
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase(txtOrderID.Text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, 
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });

                    // Line 2: Date và Customer Name
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase("Date:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, 
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL))) { Border = 0 });
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase("Customer Name:", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, 
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });
                    invoiceInfoTable.AddCell(new PdfPCell(new Phrase(txtCustomerID.Text, new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, 
                        iTextSharp.text.Font.NORMAL))) { Border = 0 });

                    // Line 3: Employee ID and Employee Code
                    PdfPCell employeeCodeCell = new PdfPCell(new Phrase($"Employee Code: {txtEmployeeCode.Text}", new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL)))
                    {
                        Border = 0,
                        Colspan = 4, 
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    invoiceInfoTable.AddCell(employeeCodeCell);

                    pdfDoc.Add(invoiceInfoTable);
                    // Header: Product information
                    Paragraph productHeader = new Paragraph("Purchased product information: ");
                    pdfDoc.Add(productHeader);
                    pdfDoc.Add(new Paragraph("\n"));
                    // Product table
                    PdfPTable table = new PdfPTable(6); 
                    table.WidthPercentage = 100;
                    table.SetWidths(new float[] { 5, 25, 15, 10, 15, 15 }); 

                    iTextSharp.text.Font productHeaderFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
                    table.AddCell(new PdfPCell(new Phrase("No.", productHeaderFont)));
                    table.AddCell(new PdfPCell(new Phrase("Product Name", productHeaderFont)));
                    table.AddCell(new PdfPCell(new Phrase("Unit Price", productHeaderFont)));
                    table.AddCell(new PdfPCell(new Phrase("Quantity", productHeaderFont)));
                    table.AddCell(new PdfPCell(new Phrase("Discount (%)", productHeaderFont)));
                    table.AddCell(new PdfPCell(new Phrase("Total Price", productHeaderFont)));

                    // Get product details
                    string query = @"
                                    SELECT 
                                        p.ProductName, 
                                        od.UnitPrice, 
                                        od.Quantity, 
                                        p.Discount, 
                                        (od.UnitPrice * od.Quantity) AS OriginalPrice,
                                        (od.UnitPrice * od.Quantity * (1 - p.Discount / 100.0)) AS TotalPrice
                                    FROM 
                                        OrderDetails od
                                    JOIN 
                                        Product p ON od.ProductID = p.ProductID
                                    WHERE 
                                        od.OrderID = @OrderID;";
                    int index = 1;
                    decimal totalAmount = 0; 
                    decimal totalDiscounted = 0; 

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderID);

                        if (connection.State == ConnectionState.Closed)
                            connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Calculate total amount and total discounted  
                                decimal originalPrice = Convert.ToDecimal(reader["OriginalPrice"]);
                                decimal totalPrice = Convert.ToDecimal(reader["TotalPrice"]);

                                totalAmount += originalPrice;
                                totalDiscounted += totalPrice;

                                // Add data into table
                                table.AddCell(index.ToString());
                                table.AddCell(reader["ProductName"].ToString());
                                table.AddCell($"{Convert.ToDecimal(reader["UnitPrice"])} VND ");
                                table.AddCell(reader["Quantity"].ToString());
                                table.AddCell($"{reader["Discount"]} % ");
                                table.AddCell($"{totalPrice} VND ");

                                index++;
                            }
                        }
                    }

                    decimal totalDiscount = totalAmount - totalDiscounted;

                    pdfDoc.Add(table);

                    Paragraph summary = new Paragraph
                    {
                        Alignment = Element.ALIGN_RIGHT
                    };
                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph summaryParagraph = new Paragraph
                    {
                        Alignment = Element.ALIGN_CENTER         
                    };
                    pdfDoc.Add(new Paragraph("\n"));
                    iTextSharp.text.Font summaryFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.NORMAL);

                    summaryParagraph.Add(new Phrase($"Total original amount: {totalAmount} VND\n", summaryFont));
                    summaryParagraph.Add(new Phrase($"Total discount: {totalDiscount} VND\n", summaryFont));
                    summaryParagraph.Add(new Phrase($"Total amount payment: {totalDiscounted} VND\n", summaryFont));

                    pdfDoc.Add(summaryParagraph);

                    pdfDoc.Add(new Paragraph("\n"));
                    pdfDoc.Add(new Paragraph("\n"));

                    Paragraph line = new Paragraph("-----------------------------------------------------------------")
                    {
                        Alignment = Element.ALIGN_CENTER
                    };
                    pdfDoc.Add(line);

                    Paragraph footer = new Paragraph("Thank you for your purchase!\nWe look forward to serving you again.", new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.ITALIC));
                    footer.Alignment = Element.ALIGN_CENTER;
                    pdfDoc.Add(footer);

                    pdfDoc.Close();
                    writer.Close();

                    MessageBox.Show("Invoice exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting invoice: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private string SanitizeFileName(string fileName)
        {
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                fileName = fileName.Replace(c, '_');
            }
            return fileName;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            frmSalesStaff salesStaff = new frmSalesStaff();
            this.Hide();
            salesStaff.ShowDialog();
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