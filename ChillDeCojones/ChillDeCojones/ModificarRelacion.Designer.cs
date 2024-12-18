namespace ChillDeCojones
{
    partial class ModificarRelacion
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
            this.bCancel = new System.Windows.Forms.Button();
            this.bAccept = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.thumbnail2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.thumbnail = new System.Windows.Forms.DataGridViewImageColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SKU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tLabel = new System.Windows.Forms.TextBox();
            this.labelNombreRelacion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(708, 508);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(151, 23);
            this.bCancel.TabIndex = 11;
            this.bCancel.Text = "Discard Changes";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bAccept
            // 
            this.bAccept.Location = new System.Drawing.Point(314, 508);
            this.bAccept.Name = "bAccept";
            this.bAccept.Size = new System.Drawing.Size(139, 23);
            this.bAccept.TabIndex = 10;
            this.bAccept.Text = "Save Changes";
            this.bAccept.UseVisualStyleBackColor = true;
            this.bAccept.Click += new System.EventHandler(this.bAccept_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thumbnail2,
            this.ID2,
            this.SKU2,
            this.Label2});
            this.dataGridView2.Location = new System.Drawing.Point(578, 203);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(501, 240);
            this.dataGridView2.TabIndex = 9;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            this.dataGridView2.SelectionChanged += new System.EventHandler(this.dataGridView2_SelectionChanged);
            // 
            // thumbnail2
            // 
            this.thumbnail2.HeaderText = "thumbnail";
            this.thumbnail2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.thumbnail2.MinimumWidth = 6;
            this.thumbnail2.Name = "thumbnail2";
            this.thumbnail2.ReadOnly = true;
            this.thumbnail2.Width = 125;
            // 
            // ID2
            // 
            this.ID2.HeaderText = "ID";
            this.ID2.MinimumWidth = 6;
            this.ID2.Name = "ID2";
            this.ID2.ReadOnly = true;
            this.ID2.Width = 125;
            // 
            // SKU2
            // 
            this.SKU2.HeaderText = "SKU";
            this.SKU2.MinimumWidth = 6;
            this.SKU2.Name = "SKU2";
            this.SKU2.ReadOnly = true;
            this.SKU2.Width = 125;
            // 
            // Label2
            // 
            this.Label2.HeaderText = "Label";
            this.Label2.MinimumWidth = 6;
            this.Label2.Name = "Label2";
            this.Label2.ReadOnly = true;
            this.Label2.Width = 125;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.thumbnail,
            this.ID,
            this.SKU,
            this.Label});
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(43, 203);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(504, 240);
            this.dataGridView1.TabIndex = 8;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // thumbnail
            // 
            this.thumbnail.HeaderText = "thumbnail";
            this.thumbnail.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.thumbnail.MinimumWidth = 6;
            this.thumbnail.Name = "thumbnail";
            this.thumbnail.ReadOnly = true;
            this.thumbnail.Width = 125;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ID.Width = 125;
            // 
            // SKU
            // 
            this.SKU.HeaderText = "SKU";
            this.SKU.MinimumWidth = 6;
            this.SKU.Name = "SKU";
            this.SKU.ReadOnly = true;
            this.SKU.Width = 125;
            // 
            // Label
            // 
            this.Label.HeaderText = "Label";
            this.Label.MinimumWidth = 6;
            this.Label.Name = "Label";
            this.Label.ReadOnly = true;
            this.Label.Width = 125;
            // 
            // tLabel
            // 
            this.tLabel.Location = new System.Drawing.Point(520, 142);
            this.tLabel.Name = "tLabel";
            this.tLabel.Size = new System.Drawing.Size(277, 22);
            this.tLabel.TabIndex = 7;
            // 
            // labelNombreRelacion
            // 
            this.labelNombreRelacion.AutoSize = true;
            this.labelNombreRelacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNombreRelacion.Location = new System.Drawing.Point(96, 132);
            this.labelNombreRelacion.Name = "labelNombreRelacion";
            this.labelNombreRelacion.Size = new System.Drawing.Size(333, 32);
            this.labelNombreRelacion.TabIndex = 6;
            this.labelNombreRelacion.Text = "Label Relationship Name";
            // 
            // ModificarRelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 663);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bAccept);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tLabel);
            this.Controls.Add(this.labelNombreRelacion);
            this.Name = "ModificarRelacion";
            this.Text = "ModificarRelacion";
            this.Load += new System.EventHandler(this.ModificarRelacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Button bAccept;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewImageColumn thumbnail2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewImageColumn thumbnail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SKU;
        private System.Windows.Forms.DataGridViewTextBoxColumn Label;
        private System.Windows.Forms.TextBox tLabel;
        private System.Windows.Forms.Label labelNombreRelacion;
    }
}