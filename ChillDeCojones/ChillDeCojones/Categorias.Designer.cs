namespace ChillDeCojones
{
    partial class Categorias
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
            this.dataGridViewCategoria = new System.Windows.Forms.DataGridView();
            this.bInsertarCategoria = new System.Windows.Forms.Button();
            this.categoriesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewCategoria
            // 
            this.dataGridViewCategoria.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewCategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCategoria.Location = new System.Drawing.Point(319, 173);
            this.dataGridViewCategoria.Name = "dataGridViewCategoria";
            this.dataGridViewCategoria.RowHeadersWidth = 51;
            this.dataGridViewCategoria.RowTemplate.Height = 24;
            this.dataGridViewCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridViewCategoria.Size = new System.Drawing.Size(1216, 485);
            this.dataGridViewCategoria.TabIndex = 0;
            this.dataGridViewCategoria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCategoria_CellClick);
            // 
            // bInsertarCategoria
            // 
            this.bInsertarCategoria.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInsertarCategoria.Location = new System.Drawing.Point(1366, 134);
            this.bInsertarCategoria.Name = "bInsertarCategoria";
            this.bInsertarCategoria.Size = new System.Drawing.Size(169, 33);
            this.bInsertarCategoria.TabIndex = 1;
            this.bInsertarCategoria.Text = "➕ New category";
            this.bInsertarCategoria.UseVisualStyleBackColor = true;
            this.bInsertarCategoria.Click += new System.EventHandler(this.bInsertarCategoria_Click);
            // 
            // categoriesLabel
            // 
            this.categoriesLabel.AutoSize = true;
            this.categoriesLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoriesLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.categoriesLabel.Location = new System.Drawing.Point(314, 118);
            this.categoriesLabel.Name = "categoriesLabel";
            this.categoriesLabel.Size = new System.Drawing.Size(127, 29);
            this.categoriesLabel.TabIndex = 7;
            this.categoriesLabel.Text = "Categories";
            // 
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.categoriesLabel);
            this.Controls.Add(this.bInsertarCategoria);
            this.Controls.Add(this.dataGridViewCategoria);
            this.Name = "Categorias";
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.Categorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoria)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCategoria;
        private System.Windows.Forms.Button bInsertarCategoria;
        private System.Windows.Forms.Label categoriesLabel;
    }
}