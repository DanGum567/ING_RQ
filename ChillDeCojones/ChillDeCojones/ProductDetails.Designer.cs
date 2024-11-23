namespace ChillDeCojones
{
    partial class ProductDetails
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
            this.thumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.discardChangesButton = new System.Windows.Forms.Button();
            this.productLabelTextBox = new System.Windows.Forms.TextBox();
            this.skuTextBox = new System.Windows.Forms.TextBox();
            this.gtinTextBox = new System.Windows.Forms.TextBox();
            this.skuLabel = new System.Windows.Forms.Label();
            this.gtinLabel = new System.Windows.Forms.Label();
            this.uploadThumbnailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // thumbnailPictureBox
            // 
            this.thumbnailPictureBox.Location = new System.Drawing.Point(95, 83);
            this.thumbnailPictureBox.Name = "thumbnailPictureBox";
            this.thumbnailPictureBox.Size = new System.Drawing.Size(194, 200);
            this.thumbnailPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thumbnailPictureBox.TabIndex = 0;
            this.thumbnailPictureBox.TabStop = false;
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(1374, 157);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(218, 23);
            this.saveChangesButton.TabIndex = 1;
            this.saveChangesButton.Text = "Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // discardChangesButton
            // 
            this.discardChangesButton.Location = new System.Drawing.Point(1374, 223);
            this.discardChangesButton.Name = "discardChangesButton";
            this.discardChangesButton.Size = new System.Drawing.Size(218, 23);
            this.discardChangesButton.TabIndex = 2;
            this.discardChangesButton.Text = "Discard Changes";
            this.discardChangesButton.UseVisualStyleBackColor = true;
            this.discardChangesButton.Click += new System.EventHandler(this.discardChangesButton_Click);
            // 
            // productLabelTextBox
            // 
            this.productLabelTextBox.Location = new System.Drawing.Point(378, 83);
            this.productLabelTextBox.Name = "productLabelTextBox";
            this.productLabelTextBox.Size = new System.Drawing.Size(614, 22);
            this.productLabelTextBox.TabIndex = 3;
            this.productLabelTextBox.Text = "Enter product label here";
            // 
            // skuTextBox
            // 
            this.skuTextBox.Location = new System.Drawing.Point(483, 177);
            this.skuTextBox.Name = "skuTextBox";
            this.skuTextBox.Size = new System.Drawing.Size(217, 22);
            this.skuTextBox.TabIndex = 4;
            // 
            // gtinTextBox
            // 
            this.gtinTextBox.Location = new System.Drawing.Point(483, 224);
            this.gtinTextBox.Name = "gtinTextBox";
            this.gtinTextBox.Size = new System.Drawing.Size(217, 22);
            this.gtinTextBox.TabIndex = 5;
            // 
            // skuLabel
            // 
            this.skuLabel.AutoSize = true;
            this.skuLabel.Location = new System.Drawing.Point(375, 177);
            this.skuLabel.Name = "skuLabel";
            this.skuLabel.Size = new System.Drawing.Size(34, 16);
            this.skuLabel.TabIndex = 6;
            this.skuLabel.Text = "SKU";
            // 
            // gtinLabel
            // 
            this.gtinLabel.AutoSize = true;
            this.gtinLabel.Location = new System.Drawing.Point(375, 230);
            this.gtinLabel.Name = "gtinLabel";
            this.gtinLabel.Size = new System.Drawing.Size(39, 16);
            this.gtinLabel.TabIndex = 7;
            this.gtinLabel.Text = "GTIN";
            // 
            // uploadThumbnailButton
            // 
            this.uploadThumbnailButton.Location = new System.Drawing.Point(95, 334);
            this.uploadThumbnailButton.Name = "uploadThumbnailButton";
            this.uploadThumbnailButton.Size = new System.Drawing.Size(194, 23);
            this.uploadThumbnailButton.TabIndex = 8;
            this.uploadThumbnailButton.Text = "Upload thumbnail";
            this.uploadThumbnailButton.UseVisualStyleBackColor = true;
            this.uploadThumbnailButton.Click += new System.EventHandler(this.uploadThumbnailButton_Click);
            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.uploadThumbnailButton);
            this.Controls.Add(this.gtinLabel);
            this.Controls.Add(this.skuLabel);
            this.Controls.Add(this.gtinTextBox);
            this.Controls.Add(this.skuTextBox);
            this.Controls.Add(this.productLabelTextBox);
            this.Controls.Add(this.discardChangesButton);
            this.Controls.Add(this.saveChangesButton);
            this.Controls.Add(this.thumbnailPictureBox);
            this.Name = "ProductDetails";
            this.Text = "ProductDetails";
            this.Load += new System.EventHandler(this.ProductDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox thumbnailPictureBox;
        private System.Windows.Forms.Button saveChangesButton;
        private System.Windows.Forms.Button discardChangesButton;
        private System.Windows.Forms.TextBox productLabelTextBox;
        private System.Windows.Forms.TextBox skuTextBox;
        private System.Windows.Forms.TextBox gtinTextBox;
        private System.Windows.Forms.Label skuLabel;
        private System.Windows.Forms.Label gtinLabel;
        private System.Windows.Forms.Button uploadThumbnailButton;
    }
}