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
            this.labelUserAttributes = new System.Windows.Forms.Label();
            this.thumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.bCategoria = new System.Windows.Forms.Button();
            this.dCategoria = new System.Windows.Forms.DataGridView();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.discardThumbailButton = new System.Windows.Forms.Button();
            this.ListViewAtributosUsuario = new System.Windows.Forms.ListView();
            this.Nombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Valor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Location = new System.Drawing.Point(1566, 220);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(218, 23);
            this.saveChangesButton.TabIndex = 1;
            this.saveChangesButton.Text = "💾 Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // discardChangesButton
            // 
            this.discardChangesButton.Location = new System.Drawing.Point(1566, 267);
            this.discardChangesButton.Name = "discardChangesButton";
            this.discardChangesButton.Size = new System.Drawing.Size(218, 23);
            this.discardChangesButton.TabIndex = 2;
            this.discardChangesButton.Text = "❌ Discard Changes";
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
            // labelUserAttributes
            // 
            this.labelUserAttributes.AutoSize = true;
            this.labelUserAttributes.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserAttributes.Location = new System.Drawing.Point(92, 449);
            this.labelUserAttributes.Name = "labelUserAttributes";
            this.labelUserAttributes.Size = new System.Drawing.Size(105, 17);
            this.labelUserAttributes.TabIndex = 12;
            this.labelUserAttributes.Text = "User Attributes";
            // 
            // thumbnailPictureBox
            // 
            this.thumbnailPictureBox.BackgroundImage = global::ChillDeCojones.Properties.Resources.imagenPredeterminadaProducto;
            this.thumbnailPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.thumbnailPictureBox.Location = new System.Drawing.Point(95, 83);
            this.thumbnailPictureBox.Name = "thumbnailPictureBox";
            this.thumbnailPictureBox.Size = new System.Drawing.Size(194, 200);
            this.thumbnailPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thumbnailPictureBox.TabIndex = 0;
            this.thumbnailPictureBox.TabStop = false;
            // 
            // bCategoria
            // 
            this.bCategoria.Location = new System.Drawing.Point(1159, 124);
            this.bCategoria.Name = "bCategoria";
            this.bCategoria.Size = new System.Drawing.Size(153, 32);
            this.bCategoria.TabIndex = 16;
            this.bCategoria.Text = "Add category";
            this.bCategoria.UseVisualStyleBackColor = true;
            this.bCategoria.Click += new System.EventHandler(this.bCategoria_Click);
            // 
            // dCategoria
            // 
            this.dCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dCategoria.Location = new System.Drawing.Point(1159, 180);
            this.dCategoria.Name = "dCategoria";
            this.dCategoria.RowHeadersWidth = 51;
            this.dCategoria.RowTemplate.Height = 24;
            this.dCategoria.Size = new System.Drawing.Size(342, 143);
            this.dCategoria.TabIndex = 17;
            this.dCategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dCategoria_CellClick);
            // 
            // cbCategoria
            // 
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(1331, 129);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(170, 24);
            this.cbCategoria.TabIndex = 18;
            this.cbCategoria.SelectionChangeCommitted += new System.EventHandler(this.cbCategoria_SelectionChangeCommitted);
            // 
            // discardThumbailButton
            // 
            this.discardThumbailButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardThumbailButton.Location = new System.Drawing.Point(95, 346);
            this.discardThumbailButton.Name = "discardThumbailButton";
            this.discardThumbailButton.Size = new System.Drawing.Size(194, 31);
            this.discardThumbailButton.TabIndex = 19;
            this.discardThumbailButton.Text = "Discard thumbnail";
            this.discardThumbailButton.UseVisualStyleBackColor = true;
            this.discardThumbailButton.Click += new System.EventHandler(this.discardThumbailButton_Click);
            // 
            // ListViewAtributosUsuario
            // 
            this.ListViewAtributosUsuario.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Nombre,
            this.Valor});
            this.ListViewAtributosUsuario.HideSelection = false;
            this.ListViewAtributosUsuario.Location = new System.Drawing.Point(95, 502);
            this.ListViewAtributosUsuario.Name = "ListViewAtributosUsuario";
            this.ListViewAtributosUsuario.Size = new System.Drawing.Size(466, 433);
            this.ListViewAtributosUsuario.TabIndex = 20;
            this.ListViewAtributosUsuario.UseCompatibleStateImageBehavior = false;
            this.ListViewAtributosUsuario.View = System.Windows.Forms.View.Details;
            // 
            // Nombre
            // 
            this.Nombre.Text = "Nombre";
            // 
            // Valor
            // 
            this.Valor.Text = "Valor";
            // 
            // ProductDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.ListViewAtributosUsuario);
            this.Controls.Add(this.discardThumbailButton);
            this.Controls.Add(this.cbCategoria);
            this.Controls.Add(this.dCategoria);
            this.Controls.Add(this.bCategoria);
            this.Controls.Add(this.labelUserAttributes);
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
            ((System.ComponentModel.ISupportInitialize)(this.dCategoria)).EndInit();
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
        private System.Windows.Forms.Label labelUserAttributes;
        private System.Windows.Forms.Button bCategoria;
        private System.Windows.Forms.DataGridView dCategoria;
        private System.Windows.Forms.ComboBox cbCategoria;
        private System.Windows.Forms.Button discardThumbailButton;
        private System.Windows.Forms.ListView ListViewAtributosUsuario;
        private System.Windows.Forms.ColumnHeader Nombre;
        private System.Windows.Forms.ColumnHeader Valor;
    }
}