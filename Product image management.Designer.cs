namespace Sales_Management
{
    partial class frmImageManagement
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
            this.lvwListImage = new System.Windows.Forms.ListView();
            this.picProductImage = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtImageID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtImageDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvProductImage = new System.Windows.Forms.DataGridView();
            this.ImageID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImageData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwListImage
            // 
            this.lvwListImage.HideSelection = false;
            this.lvwListImage.Location = new System.Drawing.Point(692, 142);
            this.lvwListImage.Name = "lvwListImage";
            this.lvwListImage.Size = new System.Drawing.Size(361, 134);
            this.lvwListImage.TabIndex = 0;
            this.lvwListImage.UseCompatibleStateImageBehavior = false;
            this.lvwListImage.SelectedIndexChanged += new System.EventHandler(this.lvwListImage_SelectedIndexChanged);
            // 
            // picProductImage
            // 
            this.picProductImage.Location = new System.Drawing.Point(462, 142);
            this.picProductImage.Name = "picProductImage";
            this.picProductImage.Size = new System.Drawing.Size(185, 134);
            this.picProductImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picProductImage.TabIndex = 1;
            this.picProductImage.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(112, 252);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 65;
            this.label7.Text = "Image Description";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(242, 186);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(181, 22);
            this.txtProductID.TabIndex = 61;
            // 
            // txtImageID
            // 
            this.txtImageID.Location = new System.Drawing.Point(242, 120);
            this.txtImageID.Name = "txtImageID";
            this.txtImageID.Size = new System.Drawing.Size(181, 22);
            this.txtImageID.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(112, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 58;
            this.label3.Text = "Image ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(112, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 57;
            this.label2.Text = "Product ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label1.Location = new System.Drawing.Point(308, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(520, 42);
            this.label1.TabIndex = 70;
            this.label1.Text = "Product image management ";
            // 
            // txtImageDescription
            // 
            this.txtImageDescription.Location = new System.Drawing.Point(242, 249);
            this.txtImageDescription.Name = "txtImageDescription";
            this.txtImageDescription.Size = new System.Drawing.Size(181, 22);
            this.txtImageDescription.TabIndex = 71;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(498, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 16);
            this.label5.TabIndex = 72;
            this.label5.Text = "Product Image";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(832, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 16);
            this.label6.TabIndex = 73;
            this.label6.Text = "List image";
            // 
            // dgvProductImage
            // 
            this.dgvProductImage.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dgvProductImage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductImage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ImageID,
            this.ProductID,
            this.ImageDescription,
            this.ImageData});
            this.dgvProductImage.GridColor = System.Drawing.Color.DimGray;
            this.dgvProductImage.Location = new System.Drawing.Point(162, 374);
            this.dgvProductImage.Name = "dgvProductImage";
            this.dgvProductImage.RowHeadersWidth = 51;
            this.dgvProductImage.RowTemplate.Height = 24;
            this.dgvProductImage.Size = new System.Drawing.Size(839, 317);
            this.dgvProductImage.TabIndex = 74;
            this.dgvProductImage.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductImage_CellContentClick);
            // 
            // ImageID
            // 
            this.ImageID.DataPropertyName = "ImageID";
            this.ImageID.FillWeight = 80F;
            this.ImageID.HeaderText = "Image ID";
            this.ImageID.MinimumWidth = 6;
            this.ImageID.Name = "ImageID";
            this.ImageID.Width = 115;
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.MinimumWidth = 6;
            this.ProductID.Name = "ProductID";
            this.ProductID.Width = 115;
            // 
            // ImageDescription
            // 
            this.ImageDescription.DataPropertyName = "ImageDescription";
            this.ImageDescription.HeaderText = "Image Description";
            this.ImageDescription.MinimumWidth = 6;
            this.ImageDescription.Name = "ImageDescription";
            this.ImageDescription.Width = 180;
            // 
            // ImageData
            // 
            this.ImageData.DataPropertyName = "ImageData";
            this.ImageData.HeaderText = "Image Data";
            this.ImageData.MinimumWidth = 6;
            this.ImageData.Name = "ImageData";
            this.ImageData.Width = 140;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(535, 309);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(99, 40);
            this.btnDelete.TabIndex = 78;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnUpdate.Location = new System.Drawing.Point(412, 309);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 40);
            this.btnUpdate.TabIndex = 77;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnInsert.Location = new System.Drawing.Point(294, 309);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(99, 40);
            this.btnInsert.TabIndex = 76;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = false;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnReturn
            // 
            this.btnReturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReturn.Location = new System.Drawing.Point(664, 309);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(99, 40);
            this.btnReturn.TabIndex = 79;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = false;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadImage.Location = new System.Drawing.Point(783, 309);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(99, 40);
            this.btnLoadImage.TabIndex = 80;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // frmImageManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 703);
            this.Controls.Add(this.btnLoadImage);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnInsert);
            this.Controls.Add(this.dgvProductImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtImageDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.txtImageID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picProductImage);
            this.Controls.Add(this.lvwListImage);
            this.Name = "frmImageManagement";
            this.Text = "Product image management";
            ((System.ComponentModel.ISupportInitialize)(this.picProductImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwListImage;
        private System.Windows.Forms.PictureBox picProductImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtImageID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtImageDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvProductImage;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImageData;
    }
}