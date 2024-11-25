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
            this.dataGridViewCategoria.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCategoria.Size = new System.Drawing.Size(1216, 485);
            this.dataGridViewCategoria.TabIndex = 0;
            // 
            // bInsertarCategoria
            // 
            this.bInsertarCategoria.Location = new System.Drawing.Point(1460, 144);
            this.bInsertarCategoria.Name = "bInsertarCategoria";
            this.bInsertarCategoria.Size = new System.Drawing.Size(75, 23);
            this.bInsertarCategoria.TabIndex = 1;
            this.bInsertarCategoria.Text = "+";
            this.bInsertarCategoria.UseVisualStyleBackColor = true;
            this.bInsertarCategoria.Click += new System.EventHandler(this.bInsertarCategoria_Click);
            // 
            // Categorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.bInsertarCategoria);
            this.Controls.Add(this.dataGridViewCategoria);
            this.Name = "Categorias";
            this.Text = "Categorias";
            this.Load += new System.EventHandler(this.Categorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewCategoria;
        private System.Windows.Forms.Button bInsertarCategoria;
    }
}