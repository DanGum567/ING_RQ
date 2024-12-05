namespace ChillDeCojones
{
    partial class Relaciones
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
            this.labelNumeroRelaciones = new System.Windows.Forms.Label();
            this.dataGridViewRelaciones = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // labelNumeroRelaciones
            // 
            this.labelNumeroRelaciones.AutoSize = true;
            this.labelNumeroRelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroRelaciones.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelNumeroRelaciones.Location = new System.Drawing.Point(157, 129);
            this.labelNumeroRelaciones.Name = "labelNumeroRelaciones";
            this.labelNumeroRelaciones.Size = new System.Drawing.Size(194, 32);
            this.labelNumeroRelaciones.TabIndex = 0;
            this.labelNumeroRelaciones.Text = " Relationships";
            this.labelNumeroRelaciones.Click += new System.EventHandler(this.label1_Click);
            // 
            // dataGridViewRelaciones
            // 
            this.dataGridViewRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRelaciones.Location = new System.Drawing.Point(163, 208);
            this.dataGridViewRelaciones.Name = "dataGridViewRelaciones";
            this.dataGridViewRelaciones.RowHeadersWidth = 51;
            this.dataGridViewRelaciones.RowTemplate.Height = 24;
            this.dataGridViewRelaciones.Size = new System.Drawing.Size(1131, 400);
            this.dataGridViewRelaciones.TabIndex = 1;
            this.dataGridViewRelaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Relaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.dataGridViewRelaciones);
            this.Controls.Add(this.labelNumeroRelaciones);
            this.Name = "Relaciones";
            this.Text = "Relaciones";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRelaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelNumeroRelaciones;
        private System.Windows.Forms.DataGridView dataGridViewRelaciones;
    }
}