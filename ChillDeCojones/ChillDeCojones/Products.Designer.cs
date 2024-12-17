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
            this.Fila = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Thumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GTIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newProductButton = new System.Windows.Forms.Button();
            this.NumeroProductosLabel = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.listaProductosDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // listaProductosDataGridView
            // 
            this.listaProductosDataGridView.AllowUserToAddRows = false;
            this.listaProductosDataGridView.AllowUserToDeleteRows = false;
            this.listaProductosDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.listaProductosDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaProductosDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listaProductosDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fila,
            this.Thumbnail,
            this.ID,
            this.SKU,
            this.Label,
            this.GTIN});
            this.listaProductosDataGridView.Location = new System.Drawing.Point(70, 106);
            this.listaProductosDataGridView.MultiSelect = false;
            this.listaProductosDataGridView.Name = "listaProductosDataGridView";
            this.listaProductosDataGridView.ReadOnly = true;
            this.listaProductosDataGridView.RowHeadersVisible = false;
            this.listaProductosDataGridView.RowHeadersWidth = 51;
            this.listaProductosDataGridView.RowTemplate.Height = 100;
            this.listaProductosDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listaProductosDataGridView.Size = new System.Drawing.Size(1741, 792);
            this.listaProductosDataGridView.TabIndex = 1;
            this.listaProductosDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.listaProductosDataGridView_CellClick);
            // 
            // Fila
            // 
            this.Fila.HeaderText = "Fila";
            this.Fila.MinimumWidth = 6;
            this.Fila.Name = "Fila";
            this.Fila.ReadOnly = true;
            this.Fila.Visible = false;
            // 
            // Thumbnail
            // 
            this.Thumbnail.HeaderText = "Thumbnail";
            this.Thumbnail.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Thumbnail.MinimumWidth = 6;
            this.Thumbnail.Name = "Thumbnail";
            this.Thumbnail.ReadOnly = true;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
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
            // NumeroProductosLabel
            // 
            this.NumeroProductosLabel.AutoSize = true;
            this.NumeroProductosLabel.Font = new System.Drawing.Font("Dubai", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumeroProductosLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.NumeroProductosLabel.Location = new System.Drawing.Point(67, 58);
            this.NumeroProductosLabel.Name = "NumeroProductosLabel";
            this.NumeroProductosLabel.Size = new System.Drawing.Size(157, 39);
            this.NumeroProductosLabel.TabIndex = 3;
            this.NumeroProductosLabel.Text = "9999 Products";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 435;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "SKU";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 435;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Label";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 435;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "GTIN";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // Products
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.NumeroProductosLabel);
            this.Controls.Add(this.newProductButton);
            this.Controls.Add(this.listaProductosDataGridView);
            this.Name = "Products";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listaProductosDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView listaProductosDataGridView;
        private System.Windows.Forms.Button newProductButton;
        private System.Windows.Forms.Label NumeroProductosLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fila;
        private System.Windows.Forms.DataGridViewImageColumn Thumbnail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.DataGridViewTextBoxColumn GTIN;
    }
}