namespace Sales_Management
{
    partial class frmSupportCustomer
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
            this.txtIssueDescription = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustomerID = new System.Windows.Forms.TextBox();
            this.txtSupportID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgvSupport = new System.Windows.Forms.DataGridView();
            this.SupportID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EmployeeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupportDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupportType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSupportDate = new System.Windows.Forms.TextBox();
            this.cboSupportType = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEmployeeID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupport)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIssueDescription
            // 
            this.txtIssueDescription.Location = new System.Drawing.Point(725, 157);
            this.txtIssueDescription.Name = "txtIssueDescription";
            this.txtIssueDescription.Size = new System.Drawing.Size(181, 22);
            this.txtIssueDescription.TabIndex = 51;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(594, 160);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(110, 16);
            this.label11.TabIndex = 49;
            this.label11.Text = "Issue Description";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(594, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 16);
            this.label5.TabIndex = 48;
            this.label5.Text = "Support Type";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(234, 209);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 16);
            this.label7.TabIndex = 46;
            this.label7.Text = " Support Date";
            // 
            // txtCustomerID
            // 
            this.txtCustomerID.Location = new System.Drawing.Point(348, 160);
            this.txtCustomerID.Name = "txtCustomerID";
            this.txtCustomerID.Size = new System.Drawing.Size(181, 22);
            this.txtCustomerID.TabIndex = 44;
            // 
            // txtSupportID
            // 
            this.txtSupportID.Location = new System.Drawing.Point(348, 112);
            this.txtSupportID.Name = "txtSupportID";
            this.txtSupportID.Size = new System.Drawing.Size(181, 22);
            this.txtSupportID.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(234, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 41;
            this.label4.Text = "Customer ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 39;
            this.label2.Text = "Support ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(427, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(328, 42);
            this.label1.TabIndex = 38;
            this.label1.Text = "Support customer";
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReturn.Location = new System.Drawing.Point(814, 260);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(104, 40);
            this.btnReturn.TabIndex = 71;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.Location = new System.Drawing.Point(697, 260);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(99, 40);
            this.btnExit.TabIndex = 70;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnClear.Location = new System.Drawing.Point(581, 260);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(99, 40);
            this.btnClear.TabIndex = 68;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.Location = new System.Drawing.Point(466, 260);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 40);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnUpdate.Location = new System.Drawing.Point(343, 260);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 40);
            this.btnUpdate.TabIndex = 65;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInsert.Location = new System.Drawing.Point(225, 260);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(99, 40);
            this.btnInsert.TabIndex = 64;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dgvSupport
            // 
            this.dgvSupport.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvSupport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SupportID,
            this.EmployeeID,
            this.CustomerID,
            this.SupportDate,
            this.SupportType,
            this.IssueDescription});
            this.dgvSupport.GridColor = System.Drawing.Color.DimGray;
            this.dgvSupport.Location = new System.Drawing.Point(77, 323);
            this.dgvSupport.Name = "dgvSupport";
            this.dgvSupport.RowHeadersWidth = 51;
            this.dgvSupport.RowTemplate.Height = 24;
            this.dgvSupport.Size = new System.Drawing.Size(1056, 410);
            this.dgvSupport.TabIndex = 63;
            this.dgvSupport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmployee_CellContentClick);
            // 
            // SupportID
            // 
            this.SupportID.DataPropertyName = "SupportID";
            this.SupportID.FillWeight = 80F;
            this.SupportID.HeaderText = "Support ID";
            this.SupportID.MinimumWidth = 6;
            this.SupportID.Name = "SupportID";
            this.SupportID.Width = 110;
            // 
            // EmployeeID
            // 
            this.EmployeeID.DataPropertyName = "EmployeeID";
            this.EmployeeID.HeaderText = "Employee ID";
            this.EmployeeID.MinimumWidth = 6;
            this.EmployeeID.Name = "EmployeeID";
            this.EmployeeID.Width = 110;
            // 
            // CustomerID
            // 
            this.CustomerID.DataPropertyName = "CustomerID";
            this.CustomerID.HeaderText = "Customer ID";
            this.CustomerID.MinimumWidth = 6;
            this.CustomerID.Name = "CustomerID";
            this.CustomerID.Width = 110;
            // 
            // SupportDate
            // 
            this.SupportDate.DataPropertyName = "SupportDate";
            this.SupportDate.HeaderText = "Support Date";
            this.SupportDate.MinimumWidth = 6;
            this.SupportDate.Name = "SupportDate";
            this.SupportDate.Width = 120;
            // 
            // SupportType
            // 
            this.SupportType.DataPropertyName = "SupportType";
            this.SupportType.HeaderText = "Support Type";
            this.SupportType.MinimumWidth = 6;
            this.SupportType.Name = "SupportType";
            this.SupportType.Width = 120;
            // 
            // IssueDescription
            // 
            this.IssueDescription.DataPropertyName = "IssueDescription";
            this.IssueDescription.HeaderText = "Issue Description";
            this.IssueDescription.MinimumWidth = 6;
            this.IssueDescription.Name = "IssueDescription";
            this.IssueDescription.Width = 160;
            // 
            // txtSupportDate
            // 
            this.txtSupportDate.Location = new System.Drawing.Point(348, 209);
            this.txtSupportDate.Name = "txtSupportDate";
            this.txtSupportDate.Size = new System.Drawing.Size(181, 22);
            this.txtSupportDate.TabIndex = 72;
            // 
            // cboSupportType
            // 
            this.cboSupportType.FormattingEnabled = true;
            this.cboSupportType.Items.AddRange(new object[] {
            "Call Support",
            "Email Support",
            "Live Chat",
            "On-Site Support",
            "Video Meeting"});
            this.cboSupportType.Location = new System.Drawing.Point(725, 112);
            this.cboSupportType.Name = "cboSupportType";
            this.cboSupportType.Size = new System.Drawing.Size(181, 24);
            this.cboSupportType.TabIndex = 73;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.txtEmployeeID);
            this.panel1.Location = new System.Drawing.Point(814, 23);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 42);
            this.panel1.TabIndex = 114;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(3, 12);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(138, 16);
            this.label18.TabIndex = 35;
            this.label18.Text = "Hello NguyenVietP";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.txtEmployeeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmployeeID.ForeColor = System.Drawing.Color.Red;
            this.txtEmployeeID.Location = new System.Drawing.Point(147, 9);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Size = new System.Drawing.Size(94, 22);
            this.txtEmployeeID.TabIndex = 19;
            this.txtEmployeeID.Text = "               ";
            // 
            // frmSupportCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 745);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cboSupportType);
            this.Controls.Add(this.txtSupportDate);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgvSupport);
            this.Controls.Add(this.txtIssueDescription);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCustomerID);
            this.Controls.Add(this.txtSupportID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmSupportCustomer";
            this.Text = "Support customer";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupport)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtIssueDescription;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustomerID;
        private System.Windows.Forms.TextBox txtSupportID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.DataGridView dgvSupport;
        private System.Windows.Forms.TextBox txtSupportDate;
        private System.Windows.Forms.ComboBox cboSupportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupportID;
        private System.Windows.Forms.DataGridViewTextBoxColumn EmployeeID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupportDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupportType;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDescription;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEmployeeID;
    }
}