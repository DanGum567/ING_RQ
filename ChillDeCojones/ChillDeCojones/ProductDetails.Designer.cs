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
            this.saveChangesButton = new System.Windows.Forms.Button();
            this.discardChangesButton = new System.Windows.Forms.Button();
            this.productLabelTextBox = new System.Windows.Forms.TextBox();
            this.skuTextBox = new System.Windows.Forms.TextBox();
            this.gtinTextBox = new System.Windows.Forms.TextBox();
            this.skuLabel = new System.Windows.Forms.Label();
            this.gtinLabel = new System.Windows.Forms.Label();
            this.uploadThumbnailButton = new System.Windows.Forms.Button();
            this.labelCreated = new System.Windows.Forms.Label();
            this.labelModified = new System.Windows.Forms.Label();
            this.lAtributosUsuario = new System.Windows.Forms.ListView();
            this.labelUserAttributes = new System.Windows.Forms.Label();
            this.thumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.lCategorias = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).BeginInit();
            this.SuspendLayout();
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
            this.productLabelTextBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabelTextBox.Location = new System.Drawing.Point(378, 83);
            this.productLabelTextBox.Name = "productLabelTextBox";
            this.productLabelTextBox.Size = new System.Drawing.Size(614, 22);
            this.productLabelTextBox.TabIndex = 3;
            this.productLabelTextBox.Text = "Product name";
            // 
            // skuTextBox
            // 
            this.skuTextBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.skuTextBox.Location = new System.Drawing.Point(483, 177);
            this.skuTextBox.Name = "skuTextBox";
            this.skuTextBox.Size = new System.Drawing.Size(217, 22);
            this.skuTextBox.TabIndex = 4;
            // 
            // gtinTextBox
            // 
            this.gtinTextBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gtinTextBox.Location = new System.Drawing.Point(483, 224);
            this.gtinTextBox.Name = "gtinTextBox";
            this.gtinTextBox.Size = new System.Drawing.Size(217, 22);
            this.gtinTextBox.TabIndex = 5;
            // 
            // skuLabel
            // 
            this.skuLabel.AutoSize = true;
            this.skuLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skuLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.skuLabel.Location = new System.Drawing.Point(375, 180);
            this.skuLabel.Name = "skuLabel";
            this.skuLabel.Size = new System.Drawing.Size(34, 17);
            this.skuLabel.TabIndex = 6;
            this.skuLabel.Text = "SKU";
            // 
            // gtinLabel
            // 
            this.gtinLabel.AutoSize = true;
            this.gtinLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtinLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.gtinLabel.Location = new System.Drawing.Point(375, 226);
            this.gtinLabel.Name = "gtinLabel";
            this.gtinLabel.Size = new System.Drawing.Size(37, 17);
            this.gtinLabel.TabIndex = 7;
            this.gtinLabel.Text = "GTIN";
            // 
            // uploadThumbnailButton
            // 
            this.uploadThumbnailButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadThumbnailButton.Location = new System.Drawing.Point(95, 299);
            this.uploadThumbnailButton.Name = "uploadThumbnailButton";
            this.uploadThumbnailButton.Size = new System.Drawing.Size(194, 31);
            this.uploadThumbnailButton.TabIndex = 8;
            this.uploadThumbnailButton.Text = "Upload thumbnail";
            this.uploadThumbnailButton.UseVisualStyleBackColor = true;
            this.uploadThumbnailButton.Click += new System.EventHandler(this.uploadThumbnailButton_Click);
            // 
            // labelCreated
            // 
            this.labelCreated.AutoSize = true;
            this.labelCreated.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreated.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.labelCreated.Location = new System.Drawing.Point(375, 267);
            this.labelCreated.Name = "labelCreated";
            this.labelCreated.Size = new System.Drawing.Size(59, 17);
            this.labelCreated.TabIndex = 9;
            this.labelCreated.Text = "Created";
            // 
            // labelModified
            // 
            this.labelModified.AutoSize = true;
            this.labelModified.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModified.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.labelModified.Location = new System.Drawing.Point(375, 299);
            this.labelModified.Name = "labelModified";
            this.labelModified.Size = new System.Drawing.Size(68, 17);
            this.labelModified.TabIndex = 10;
            this.labelModified.Text = "Modified ";
            // 
            // lAtributosUsuario
            // 
            this.lAtributosUsuario.HideSelection = false;
            this.lAtributosUsuario.Location = new System.Drawing.Point(95, 385);
            this.lAtributosUsuario.Name = "lAtributosUsuario";
            this.lAtributosUsuario.Size = new System.Drawing.Size(339, 261);
            this.lAtributosUsuario.TabIndex = 11;
            this.lAtributosUsuario.UseCompatibleStateImageBehavior = false;
            // 
            // labelUserAttributes
            // 
            this.labelUserAttributes.AutoSize = true;
            this.labelUserAttributes.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserAttributes.Location = new System.Drawing.Point(137, 347);
            this.labelUserAttributes.Name = "labelUserAttributes";
            this.labelUserAttributes.Size = new System.Drawing.Size(105, 17);
            this.labelUserAttributes.TabIndex = 12;
            this.labelUserAttributes.Text = "User Attributes";
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
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(121, 97);
            this.listView1.TabIndex = 13;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // lCategorias
            // 
            this.lCategorias.HideSelection = false;
            this.lCategorias.Location = new System.Drawing.Point(1072, 157);
            this.lCategorias.Name = "lCategorias";
            this.lCategorias.Size = new System.Drawing.Size(250, 97);
            this.lCategorias.TabIndex = 14;
            this.lCategorias.UseCompatibleStateImageBehavior = false;

            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.lCategorias);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.labelUserAttributes);
            this.Controls.Add(this.lAtributosUsuario);
            this.Controls.Add(this.labelModified);
            this.Controls.Add(this.labelCreated);
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
        private System.Windows.Forms.Label labelCreated;
        private System.Windows.Forms.Label labelModified;
        private System.Windows.Forms.ListView lAtributosUsuario;
        private System.Windows.Forms.Label labelUserAttributes;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView lCategorias;
    }
}