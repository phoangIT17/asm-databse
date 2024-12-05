namespace Sales_Management
{
    partial class frmPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.label1 = new System.Windows.Forms.Label();
            this.lblSelectedBank = new System.Windows.Forms.Label();
            this.pbBIDV = new System.Windows.Forms.PictureBox();
            this.pbTechComBank = new System.Windows.Forms.PictureBox();
            this.pbVietComBank = new System.Windows.Forms.PictureBox();
            this.pbACB = new System.Windows.Forms.PictureBox();
            this.pbTPBank = new System.Windows.Forms.PictureBox();
            this.pbMBank = new System.Windows.Forms.PictureBox();
            this.pbAgriBank = new System.Windows.Forms.PictureBox();
            this.pbVietinBank = new System.Windows.Forms.PictureBox();
            this.pbSHB = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.txtCardholderName = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbBIDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTechComBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVietComBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbACB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTPBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgriBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVietinBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSHB)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(241, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment";
            // 
            // lblSelectedBank
            // 
            this.lblSelectedBank.AutoSize = true;
            this.lblSelectedBank.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSelectedBank.Location = new System.Drawing.Point(43, 82);
            this.lblSelectedBank.Name = "lblSelectedBank";
            this.lblSelectedBank.Size = new System.Drawing.Size(101, 20);
            this.lblSelectedBank.TabIndex = 1;
            this.lblSelectedBank.Text = "Select bank:";
            // 
            // pbBIDV
            // 
            this.pbBIDV.Image = ((System.Drawing.Image)(resources.GetObject("pbBIDV.Image")));
            this.pbBIDV.Location = new System.Drawing.Point(159, 103);
            this.pbBIDV.Name = "pbBIDV";
            this.pbBIDV.Size = new System.Drawing.Size(100, 72);
            this.pbBIDV.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBIDV.TabIndex = 2;
            this.pbBIDV.TabStop = false;
            // 
            // pbTechComBank
            // 
            this.pbTechComBank.Image = ((System.Drawing.Image)(resources.GetObject("pbTechComBank.Image")));
            this.pbTechComBank.Location = new System.Drawing.Point(159, 184);
            this.pbTechComBank.Name = "pbTechComBank";
            this.pbTechComBank.Size = new System.Drawing.Size(100, 72);
            this.pbTechComBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTechComBank.TabIndex = 2;
            this.pbTechComBank.TabStop = false;
            // 
            // pbVietComBank
            // 
            this.pbVietComBank.Image = ((System.Drawing.Image)(resources.GetObject("pbVietComBank.Image")));
            this.pbVietComBank.Location = new System.Drawing.Point(265, 184);
            this.pbVietComBank.Name = "pbVietComBank";
            this.pbVietComBank.Size = new System.Drawing.Size(100, 72);
            this.pbVietComBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVietComBank.TabIndex = 2;
            this.pbVietComBank.TabStop = false;
            // 
            // pbACB
            // 
            this.pbACB.Image = ((System.Drawing.Image)(resources.GetObject("pbACB.Image")));
            this.pbACB.Location = new System.Drawing.Point(371, 103);
            this.pbACB.Name = "pbACB";
            this.pbACB.Size = new System.Drawing.Size(100, 72);
            this.pbACB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbACB.TabIndex = 2;
            this.pbACB.TabStop = false;
            // 
            // pbTPBank
            // 
            this.pbTPBank.Image = ((System.Drawing.Image)(resources.GetObject("pbTPBank.Image")));
            this.pbTPBank.Location = new System.Drawing.Point(159, 262);
            this.pbTPBank.Name = "pbTPBank";
            this.pbTPBank.Size = new System.Drawing.Size(100, 72);
            this.pbTPBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTPBank.TabIndex = 2;
            this.pbTPBank.TabStop = false;
            // 
            // pbMBank
            // 
            this.pbMBank.Image = ((System.Drawing.Image)(resources.GetObject("pbMBank.Image")));
            this.pbMBank.Location = new System.Drawing.Point(265, 103);
            this.pbMBank.Name = "pbMBank";
            this.pbMBank.Size = new System.Drawing.Size(100, 72);
            this.pbMBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMBank.TabIndex = 3;
            this.pbMBank.TabStop = false;
            // 
            // pbAgriBank
            // 
            this.pbAgriBank.Image = ((System.Drawing.Image)(resources.GetObject("pbAgriBank.Image")));
            this.pbAgriBank.Location = new System.Drawing.Point(371, 184);
            this.pbAgriBank.Name = "pbAgriBank";
            this.pbAgriBank.Size = new System.Drawing.Size(100, 72);
            this.pbAgriBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAgriBank.TabIndex = 4;
            this.pbAgriBank.TabStop = false;
            // 
            // pbVietinBank
            // 
            this.pbVietinBank.Image = ((System.Drawing.Image)(resources.GetObject("pbVietinBank.Image")));
            this.pbVietinBank.Location = new System.Drawing.Point(370, 262);
            this.pbVietinBank.Name = "pbVietinBank";
            this.pbVietinBank.Size = new System.Drawing.Size(100, 72);
            this.pbVietinBank.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbVietinBank.TabIndex = 5;
            this.pbVietinBank.TabStop = false;
            // 
            // pbSHB
            // 
            this.pbSHB.Image = ((System.Drawing.Image)(resources.GetObject("pbSHB.Image")));
            this.pbSHB.Location = new System.Drawing.Point(264, 262);
            this.pbSHB.Name = "pbSHB";
            this.pbSHB.Size = new System.Drawing.Size(100, 72);
            this.pbSHB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSHB.TabIndex = 6;
            this.pbSHB.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(78, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(443, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "---------------------Card Information---------------------";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(78, 400);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Card Number:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(78, 434);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cardholder Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(30, 467);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label7.Location = new System.Drawing.Point(78, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Amount:";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(266, 397);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(172, 22);
            this.txtCardNumber.TabIndex = 10;
            // 
            // txtCardholderName
            // 
            this.txtCardholderName.Location = new System.Drawing.Point(266, 434);
            this.txtCardholderName.Name = "txtCardholderName";
            this.txtCardholderName.Size = new System.Drawing.Size(172, 22);
            this.txtCardholderName.TabIndex = 11;
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(266, 489);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(172, 22);
            this.txtAmount.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(449, 491);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "VND";
            // 
            // btnPayment
            // 
            this.btnPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnPayment.Location = new System.Drawing.Point(96, 545);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(87, 37);
            this.btnPayment.TabIndex = 14;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = false;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LightCoral;
            this.btnCancel.Location = new System.Drawing.Point(235, 545);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 37);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReturn.Location = new System.Drawing.Point(389, 545);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(105, 37);
            this.btnReturn.TabIndex = 16;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(630, 604);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.txtCardholderName);
            this.Controls.Add(this.txtCardNumber);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pbSHB);
            this.Controls.Add(this.pbVietinBank);
            this.Controls.Add(this.pbAgriBank);
            this.Controls.Add(this.pbMBank);
            this.Controls.Add(this.pbTPBank);
            this.Controls.Add(this.pbACB);
            this.Controls.Add(this.pbVietComBank);
            this.Controls.Add(this.pbTechComBank);
            this.Controls.Add(this.pbBIDV);
            this.Controls.Add(this.lblSelectedBank);
            this.Controls.Add(this.label1);
            this.Name = "frmPayment";
            this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.pbBIDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTechComBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVietComBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbACB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTPBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbAgriBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbVietinBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSHB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSelectedBank;
        private System.Windows.Forms.PictureBox pbBIDV;
        private System.Windows.Forms.PictureBox pbTechComBank;
        private System.Windows.Forms.PictureBox pbVietComBank;
        private System.Windows.Forms.PictureBox pbACB;
        private System.Windows.Forms.PictureBox pbTPBank;
        private System.Windows.Forms.PictureBox pbMBank;
        private System.Windows.Forms.PictureBox pbAgriBank;
        private System.Windows.Forms.PictureBox pbVietinBank;
        private System.Windows.Forms.PictureBox pbSHB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.TextBox txtCardholderName;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnReturn;
    }
}