namespace Sales_Management
{
    partial class frmSalesStaff
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesStaff));
            this.btnReturn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnSupportCustomer = new System.Windows.Forms.Button();
            this.btnManagementCustomer = new System.Windows.Forms.Button();
            this.btnManagementProduct = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.btnInvoicing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnReturn.Location = new System.Drawing.Point(98, 549);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(188, 49);
            this.btnReturn.TabIndex = 18;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(335, 174);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(690, 424);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLogOut.Location = new System.Drawing.Point(98, 494);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(188, 49);
            this.btnLogOut.TabIndex = 16;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnSupportCustomer
            // 
            this.btnSupportCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnSupportCustomer.Location = new System.Drawing.Point(98, 430);
            this.btnSupportCustomer.Name = "btnSupportCustomer";
            this.btnSupportCustomer.Size = new System.Drawing.Size(188, 58);
            this.btnSupportCustomer.TabIndex = 15;
            this.btnSupportCustomer.Text = "Support Customer";
            this.btnSupportCustomer.UseVisualStyleBackColor = false;
            this.btnSupportCustomer.Click += new System.EventHandler(this.btnSupportCustomer_Click);
            // 
            // btnManagementCustomer
            // 
            this.btnManagementCustomer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnManagementCustomer.Location = new System.Drawing.Point(98, 302);
            this.btnManagementCustomer.Name = "btnManagementCustomer";
            this.btnManagementCustomer.Size = new System.Drawing.Size(188, 58);
            this.btnManagementCustomer.TabIndex = 14;
            this.btnManagementCustomer.Text = "Customer management ";
            this.btnManagementCustomer.UseVisualStyleBackColor = false;
            this.btnManagementCustomer.Click += new System.EventHandler(this.btnManagementCustomer_Click);
            // 
            // btnManagementProduct
            // 
            this.btnManagementProduct.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnManagementProduct.Location = new System.Drawing.Point(98, 238);
            this.btnManagementProduct.Name = "btnManagementProduct";
            this.btnManagementProduct.Size = new System.Drawing.Size(188, 58);
            this.btnManagementProduct.TabIndex = 12;
            this.btnManagementProduct.Text = "Product management";
            this.btnManagementProduct.UseVisualStyleBackColor = false;
            this.btnManagementProduct.Click += new System.EventHandler(this.btnManagementProduct_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(424, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 51);
            this.label1.TabIndex = 11;
            this.label1.Text = "Sales staff";
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDashBoard.Location = new System.Drawing.Point(98, 174);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(188, 58);
            this.btnDashBoard.TabIndex = 10;
            this.btnDashBoard.Text = "Dashboard";
            this.btnDashBoard.UseVisualStyleBackColor = false;
            // 
            // btnInvoicing
            // 
            this.btnInvoicing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnInvoicing.Location = new System.Drawing.Point(98, 366);
            this.btnInvoicing.Name = "btnInvoicing";
            this.btnInvoicing.Size = new System.Drawing.Size(188, 58);
            this.btnInvoicing.TabIndex = 13;
            this.btnInvoicing.Text = "Invoicing";
            this.btnInvoicing.UseVisualStyleBackColor = false;
            this.btnInvoicing.Click += new System.EventHandler(this.btnInvoicing_Click);
            // 
            // frmSalesStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 690);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnSupportCustomer);
            this.Controls.Add(this.btnManagementCustomer);
            this.Controls.Add(this.btnInvoicing);
            this.Controls.Add(this.btnManagementProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDashBoard);
            this.Name = "frmSalesStaff";
            this.Text = "Sales staff";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnSupportCustomer;
        private System.Windows.Forms.Button btnManagementCustomer;
        private System.Windows.Forms.Button btnManagementProduct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Button btnInvoicing;
    }
}