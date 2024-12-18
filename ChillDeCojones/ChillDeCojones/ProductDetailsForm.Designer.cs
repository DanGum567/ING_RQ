namespace ChillDeCojones
{
    partial class ProductDetailsForm
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
            this.bCategoria = new System.Windows.Forms.Button();
            this.dCategoria = new System.Windows.Forms.DataGridView();
            this.cbCategoria = new System.Windows.Forms.ComboBox();
            this.discardThumbailButton = new System.Windows.Forms.Button();
            this.DeleteProductButton = new System.Windows.Forms.Button();
            this.EditProductButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Text = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Image1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.thumbnailPictureBox = new System.Windows.Forms.PictureBox();
            this.cbRelaciones = new System.Windows.Forms.ComboBox();
            this.dRelaciones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDProductoRelacionado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dCategoria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // saveChangesButton
            // 
            this.saveChangesButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveChangesButton.Location = new System.Drawing.Point(1590, 135);
            this.saveChangesButton.Name = "saveChangesButton";
            this.saveChangesButton.Size = new System.Drawing.Size(220, 40);
            this.saveChangesButton.TabIndex = 1;
            this.saveChangesButton.Text = "💾 Save Changes";
            this.saveChangesButton.UseVisualStyleBackColor = true;
            this.saveChangesButton.Click += new System.EventHandler(this.saveChangesButton_Click);
            // 
            // discardChangesButton
            // 
            this.discardChangesButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardChangesButton.Location = new System.Drawing.Point(1590, 211);
            this.discardChangesButton.Name = "discardChangesButton";
            this.discardChangesButton.Size = new System.Drawing.Size(220, 40);
            this.discardChangesButton.TabIndex = 2;
            this.discardChangesButton.Text = "❌ Discard Changes";
            this.discardChangesButton.UseVisualStyleBackColor = true;
            this.discardChangesButton.Click += new System.EventHandler(this.discardChangesButton_Click);
            // 
            // productLabelTextBox
            // 
            this.productLabelTextBox.Font = new System.Drawing.Font("Franklin Gothic Medium", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.productLabelTextBox.Location = new System.Drawing.Point(378, 83);
            this.productLabelTextBox.Name = "productLabelTextBox";
            this.productLabelTextBox.Size = new System.Drawing.Size(614, 38);
            this.productLabelTextBox.TabIndex = 3;
            this.productLabelTextBox.Text = "Product name";
            // 
            // skuTextBox
            // 
            this.skuTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skuTextBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.skuTextBox.Location = new System.Drawing.Point(483, 177);
            this.skuTextBox.Name = "skuTextBox";
            this.skuTextBox.Size = new System.Drawing.Size(217, 30);
            this.skuTextBox.TabIndex = 4;
            // 
            // gtinTextBox
            // 
            this.gtinTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtinTextBox.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.gtinTextBox.Location = new System.Drawing.Point(483, 224);
            this.gtinTextBox.Name = "gtinTextBox";
            this.gtinTextBox.Size = new System.Drawing.Size(217, 30);
            this.gtinTextBox.TabIndex = 5;
            // 
            // skuLabel
            // 
            this.skuLabel.AutoSize = true;
            this.skuLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.skuLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.skuLabel.Location = new System.Drawing.Point(375, 180);
            this.skuLabel.Name = "skuLabel";
            this.skuLabel.Size = new System.Drawing.Size(50, 25);
            this.skuLabel.TabIndex = 6;
            this.skuLabel.Text = "SKU";
            // 
            // gtinLabel
            // 
            this.gtinLabel.AutoSize = true;
            this.gtinLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gtinLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.gtinLabel.Location = new System.Drawing.Point(375, 226);
            this.gtinLabel.Name = "gtinLabel";
            this.gtinLabel.Size = new System.Drawing.Size(56, 25);
            this.gtinLabel.TabIndex = 7;
            this.gtinLabel.Text = "GTIN";
            // 
            // uploadThumbnailButton
            // 
            this.uploadThumbnailButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadThumbnailButton.Location = new System.Drawing.Point(115, 338);
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
            this.labelCreated.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreated.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.labelCreated.Location = new System.Drawing.Point(375, 267);
            this.labelCreated.Name = "labelCreated";
            this.labelCreated.Size = new System.Drawing.Size(86, 25);
            this.labelCreated.TabIndex = 9;
            this.labelCreated.Text = "Created";
            // 
            // labelModified
            // 
            this.labelModified.AutoSize = true;
            this.labelModified.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModified.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.labelModified.Location = new System.Drawing.Point(375, 299);
            this.labelModified.Name = "labelModified";
            this.labelModified.Size = new System.Drawing.Size(101, 25);
            this.labelModified.TabIndex = 10;
            this.labelModified.Text = "Modified ";
            // 
            // labelUserAttributes
            // 
            this.labelUserAttributes.AutoSize = true;
            this.labelUserAttributes.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserAttributes.Location = new System.Drawing.Point(92, 478);
            this.labelUserAttributes.Name = "labelUserAttributes";
            this.labelUserAttributes.Size = new System.Drawing.Size(153, 25);
            this.labelUserAttributes.TabIndex = 12;
            this.labelUserAttributes.Text = "User Attributes";
            // 
            // bCategoria
            // 
            this.bCategoria.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCategoria.Location = new System.Drawing.Point(1130, 110);
            this.bCategoria.Name = "bCategoria";
            this.bCategoria.Size = new System.Drawing.Size(153, 40);
            this.bCategoria.TabIndex = 16;
            this.bCategoria.Text = "Add category";
            this.bCategoria.UseVisualStyleBackColor = true;
            this.bCategoria.Click += new System.EventHandler(this.bCategoria_Click);
            // 
            // dCategoria
            // 
            this.dCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dCategoria.Location = new System.Drawing.Point(1096, 168);
            this.dCategoria.Name = "dCategoria";
            this.dCategoria.RowHeadersVisible = false;
            this.dCategoria.RowHeadersWidth = 51;
            this.dCategoria.RowTemplate.Height = 24;
            this.dCategoria.Size = new System.Drawing.Size(418, 197);
            this.dCategoria.TabIndex = 17;
            this.dCategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dCategoria_CellClick);
            // 
            // cbCategoria
            // 
            this.cbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCategoria.FormattingEnabled = true;
            this.cbCategoria.Location = new System.Drawing.Point(1302, 115);
            this.cbCategoria.Name = "cbCategoria";
            this.cbCategoria.Size = new System.Drawing.Size(170, 33);
            this.cbCategoria.TabIndex = 18;
            this.cbCategoria.SelectionChangeCommitted += new System.EventHandler(this.cbCategoria_SelectionChangeCommitted);
            // 
            // discardThumbailButton
            // 
            this.discardThumbailButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discardThumbailButton.Location = new System.Drawing.Point(115, 385);
            this.discardThumbailButton.Name = "discardThumbailButton";
            this.discardThumbailButton.Size = new System.Drawing.Size(194, 31);
            this.discardThumbailButton.TabIndex = 19;
            this.discardThumbailButton.Text = "Discard thumbnail";
            this.discardThumbailButton.UseVisualStyleBackColor = true;
            this.discardThumbailButton.Click += new System.EventHandler(this.discardThumbailButton_Click);
            // 
            // DeleteProductButton
            // 
            this.DeleteProductButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteProductButton.Location = new System.Drawing.Point(1590, 291);
            this.DeleteProductButton.Name = "DeleteProductButton";
            this.DeleteProductButton.Size = new System.Drawing.Size(220, 40);
            this.DeleteProductButton.TabIndex = 21;
            this.DeleteProductButton.Text = "🗑️ Delete product";
            this.DeleteProductButton.UseVisualStyleBackColor = true;
            this.DeleteProductButton.Click += new System.EventHandler(this.DeleteProductButton_Click);
            // 
            // EditProductButton
            // 
            this.EditProductButton.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditProductButton.Location = new System.Drawing.Point(1590, 211);
            this.EditProductButton.Name = "EditProductButton";
            this.EditProductButton.Size = new System.Drawing.Size(220, 40);
            this.EditProductButton.TabIndex = 23;
            this.EditProductButton.Text = "✏️ Edit product";
            this.EditProductButton.UseVisualStyleBackColor = true;
            this.EditProductButton.Click += new System.EventHandler(this.EditProductButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Name,
            this.Text,
            this.Image1});
            this.dataGridView1.Location = new System.Drawing.Point(95, 516);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 100;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dataGridView1.Size = new System.Drawing.Size(720, 465);
            this.dataGridView1.TabIndex = 24;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.MinimumWidth = 6;
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Text
            // 
            this.Text.HeaderText = "Text";
            this.Text.MinimumWidth = 6;
            this.Text.Name = "Text";
            this.Text.ReadOnly = true;
            // 
            // Image1
            // 
            this.Image1.HeaderText = "Image";
            this.Image1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.Image1.MinimumWidth = 6;
            this.Image1.Name = "Image1";
            this.Image1.ReadOnly = true;
            // 
            // thumbnailPictureBox
            // 
            this.thumbnailPictureBox.BackgroundImage = global::ChillDeCojones.Properties.Resources.imagenPredeterminadaProducto;
            this.thumbnailPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.thumbnailPictureBox.Location = new System.Drawing.Point(95, 83);
            this.thumbnailPictureBox.Name = "thumbnailPictureBox";
            this.thumbnailPictureBox.Size = new System.Drawing.Size(230, 241);
            this.thumbnailPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.thumbnailPictureBox.TabIndex = 0;
            this.thumbnailPictureBox.TabStop = false;
            // 
            // cbRelaciones
            // 
            this.cbRelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRelaciones.FormattingEnabled = true;
            this.cbRelaciones.Location = new System.Drawing.Point(1528, 470);
            this.cbRelaciones.Name = "cbRelaciones";
            this.cbRelaciones.Size = new System.Drawing.Size(170, 33);
            this.cbRelaciones.TabIndex = 25;
            // 
            // dRelaciones
            // 
            this.dRelaciones.AllowUserToAddRows = false;
            this.dRelaciones.AllowUserToDeleteRows = false;
            this.dRelaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dRelaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dRelaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fila,
            this.IDProductoRelacionado,
            this.dataGridViewImageColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dRelaciones.Location = new System.Drawing.Point(1028, 516);
            this.dRelaciones.Name = "dRelaciones";
            this.dRelaciones.ReadOnly = true;
            this.dRelaciones.RowHeadersVisible = false;
            this.dRelaciones.RowHeadersWidth = 51;
            this.dRelaciones.RowTemplate.Height = 100;
            this.dRelaciones.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dRelaciones.Size = new System.Drawing.Size(720, 465);
            this.dRelaciones.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1033, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Relationships";
            // 
            // Fila
            // 
            this.Fila.HeaderText = "Fila";
            this.Fila.MinimumWidth = 6;
            this.Fila.Name = "Fila";
            this.Fila.ReadOnly = true;
            this.Fila.Visible = false;
            // 
            // IDProductoRelacionado
            // 
            this.IDProductoRelacionado.HeaderText = "IDProductoRelacionado";
            this.IDProductoRelacionado.MinimumWidth = 6;
            this.IDProductoRelacionado.Name = "IDProductoRelacionado";
            this.IDProductoRelacionado.ReadOnly = true;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Thumbail";
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.MinimumWidth = 6;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Label";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "SKU";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // ProductDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 1013);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dRelaciones);
            this.Controls.Add(this.cbRelaciones);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.EditProductButton);
            this.Controls.Add(this.DeleteProductButton);
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
            this.Load += new System.EventHandler(this.ProductDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dCategoria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thumbnailPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dRelaciones)).EndInit();
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
        private System.Windows.Forms.ColumnHeader Value;
        private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel;
        private System.Windows.Forms.Button DeleteProductButton;
        private System.Windows.Forms.Button EditProductButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Text;
        private System.Windows.Forms.DataGridViewImageColumn Image1;
        private System.Windows.Forms.ComboBox cbRelaciones;
        private System.Windows.Forms.DataGridView dRelaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDProductoRelacionado;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}