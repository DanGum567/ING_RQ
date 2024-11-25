namespace ChillDeCojones
{
    partial class Attributes
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
            this.dataGridViewAtributos = new System.Windows.Forms.DataGridView();
            this.bInsertar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtributos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAtributos
            // 
            this.dataGridViewAtributos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAtributos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtributos.Location = new System.Drawing.Point(405, 129);
            this.dataGridViewAtributos.Name = "dataGridViewAtributos";
            this.dataGridViewAtributos.RowHeadersWidth = 51;
            this.dataGridViewAtributos.RowTemplate.Height = 24;
            this.dataGridViewAtributos.Size = new System.Drawing.Size(1204, 509);
            this.dataGridViewAtributos.TabIndex = 1;
            this.dataGridViewAtributos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAtributos_CellClick);
            // 
            // bInsertar
            // 
            this.bInsertar.Location = new System.Drawing.Point(1534, 86);
            this.bInsertar.Name = "bInsertar";
            this.bInsertar.Size = new System.Drawing.Size(75, 23);
            this.bInsertar.TabIndex = 2;
            this.bInsertar.Text = "+";
            this.bInsertar.UseVisualStyleBackColor = true;
            this.bInsertar.Click += new System.EventHandler(this.bInsertar_Click);
            // 
            // Attributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.bInsertar);
            this.Controls.Add(this.dataGridViewAtributos);
            this.Name = "Attributes";
            this.Text = "Attributes";
            this.Load += new System.EventHandler(this.Attributes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtributos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAtributos;
        private System.Windows.Forms.Button bInsertar;
    }
}