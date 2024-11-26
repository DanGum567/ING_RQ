namespace ChillDeCojones
{
    partial class Products
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
            this.listaProductosDataGridView = new System.Windows.Forms.DataGridView();
            this.Thumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newProductButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.listaProductosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // listaProductosDataGridView
            // 
            this.listaProductosDataGridView.AllowUserToAddRows = false;
            this.listaProductosDataGridView.AllowUserToDeleteRows = false;
            this.listaProductosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaProductosDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.listaProductosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaProductosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Thumbnail,
            this.SKU,
            this.Label,
            this.GTIN,
            this.LastModification,
            this.CreationDate,
            this.ID});
            this.listaProductosDataGridView.Location = new System.Drawing.Point(70, 106);
            this.listaProductosDataGridView.MultiSelect = false;
            this.listaProductosDataGridView.Name = "listaProductosDataGridView";
            this.listaProductosDataGridView.ReadOnly = true;
            this.listaProductosDataGridView.RowHeadersWidth = 51;
            this.listaProductosDataGridView.RowTemplate.Height = 24;
            this.listaProductosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaProductosDataGridView.Size = new System.Drawing.Size(1741, 792);
            this.listaProductosDataGridView.TabIndex = 1;
            this.listaProductosDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaProductosDataGridView_CellClick);
            this.listaProductosDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaProductosDataGridView_CellContentClick);
            // 
            // Thumbnail
            // 
            this.Thumbnail.HeaderText = "Thumbnail";
            this.Thumbnail.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Thumbnail.MinimumWidth = 6;
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.ReadOnly = true;
            // 
            // SKU
            // 
            this.SKU.HeaderText = "SKU";
            this.SKU.MinimumWidth = 6;
            this.SKU.Name = "SKU";
            this.SKU.ReadOnly = true;
            // 
            // Label
            // 
            this.Label.HeaderText = "Label";
            this.Label.MinimumWidth = 6;
            this.Label.Name = "Label";
            this.Label.ReadOnly = true;
            // 
            // GTIN
            // 
            this.GTIN.HeaderText = "GTIN";
            this.GTIN.MinimumWidth = 6;
            this.GTIN.Name = "GTIN";
            this.GTIN.ReadOnly = true;
            this.GTIN.Visible = false;
            // 
            // LastModification
            // 
            this.LastModification.HeaderText = "Last Modification";
            this.LastModification.MinimumWidth = 6;
            this.LastModification.Name = "LastModification";
            this.LastModification.ReadOnly = true;
            this.LastModification.Visible = false;
            // 
            // CreationDate
            // 
            this.CreationDate.HeaderText = "Creation Date";
            this.CreationDate.MinimumWidth = 6;
            this.CreationDate.Name = "CreationDate";
            this.CreationDate.ReadOnly = true;
            this.CreationDate.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // newProductButton
            // 
            this.newProductButton.Location = new System.Drawing.Point(1572, 51);
            this.newProductButton.Name = "newProductButton";
            this.newProductButton.Size = new System.Drawing.Size(239, 23);
            this.newProductButton.TabIndex = 2;
            this.newProductButton.Text = "+ Add new product";
            this.newProductButton.UseVisualStyleBackColor = true;
            this.newProductButton.Click += new System.EventHandler(this.newProductButton_Click);
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.newProductButton);
            this.Controls.Add(this.listaProductosDataGridView);
            this.Name = "Products";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaProductosDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listaProductosDataGridView;
        private System.Windows.Forms.Button newProductButton;
        private System.Windows.Forms.DataGridViewImageColumn Thumbnail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModification;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}