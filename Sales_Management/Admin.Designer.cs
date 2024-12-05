namespace Sales_Management
{
    partial class frmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnManagementEmployee = new System.Windows.Forms.Button();
            this.btnStastics = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnSalesManagement = new System.Windows.Forms.Button();
            this.btnWarehouseManagement = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDashBoard.Location = new System.Drawing.Point(107, 117);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(188, 58);
            this.btnDashBoard.TabIndex = 0;
            this.btnDashBoard.Text = "Dashboard";
            this.btnDashBoard.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(306, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 51);
            this.label1.TabIndex = 1;
            this.label1.Text = " Administrator";
            // 
            // btnManagementEmployee
            // 
            this.btnManagementEmployee.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnManagementEmployee.Location = new System.Drawing.Point(107, 245);
            this.btnManagementEmployee.Name = "btnManagementEmployee";
            this.btnManagementEmployee.Size = new System.Drawing.Size(188, 58);
            this.btnManagementEmployee.TabIndex = 3;
            this.btnManagementEmployee.Text = "Employee management ";
            this.btnManagementEmployee.UseVisualStyleBackColor = false;
            this.btnManagementEmployee.Click += new System.EventHandler(this.btnManagementEmployee_Click);
            // 
            // btnStastics
            // 
            this.btnStastics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnStastics.Location = new System.Drawing.Point(107, 309);
            this.btnStastics.Name = "btnStastics";
            this.btnStastics.Size = new System.Drawing.Size(188, 58);
            this.btnStastics.TabIndex = 5;
            this.btnStastics.Text = "Statistics";
            this.btnStastics.UseVisualStyleBackColor = false;
            this.btnStastics.Click += new System.EventHandler(this.btnStastics_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLogOut.Location = new System.Drawing.Point(107, 437);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(188, 49);
            this.btnLogOut.TabIndex = 7;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(362, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(676, 424);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnReturn.Location = new System.Drawing.Point(107, 492);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(188, 49);
            this.btnReturn.TabIndex = 9;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnSalesManagement
            // 
            this.btnSalesManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSalesManagement.Location = new System.Drawing.Point(107, 181);
            this.btnSalesManagement.Name = "btnSalesManagement";
            this.btnSalesManagement.Size = new System.Drawing.Size(188, 58);
            this.btnSalesManagement.TabIndex = 10;
            this.btnSalesManagement.Text = "Sales management";
            this.btnSalesManagement.UseVisualStyleBackColor = false;
            this.btnSalesManagement.Click += new System.EventHandler(this.btnSalesManagement_Click);
            // 
            // btnWarehouseManagement
            // 
            this.btnWarehouseManagement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnWarehouseManagement.Location = new System.Drawing.Point(107, 373);
            this.btnWarehouseManagement.Name = "btnWarehouseManagement";
            this.btnWarehouseManagement.Size = new System.Drawing.Size(188, 58);
            this.btnWarehouseManagement.TabIndex = 11;
            this.btnWarehouseManagement.Text = "Inventory transaction";
            this.btnWarehouseManagement.UseVisualStyleBackColor = false;
            this.btnWarehouseManagement.Click += new System.EventHandler(this.btnWarehouseManagement_Click);
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 592);
            this.Controls.Add(this.btnWarehouseManagement);
            this.Controls.Add(this.btnSalesManagement);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnStastics);
            this.Controls.Add(this.btnManagementEmployee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDashBoard);
            this.Name = "frmAdmin";
            this.Text = "Administrator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnManagementEmployee;
        private System.Windows.Forms.Button btnStastics;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnSalesManagement;
        private System.Windows.Forms.Button btnWarehouseManagement;
    }
}

