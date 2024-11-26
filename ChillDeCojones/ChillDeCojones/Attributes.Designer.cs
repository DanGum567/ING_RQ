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
            this.LabelUserAttributes = new System.Windows.Forms.Label();
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
            this.bInsertar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bInsertar.Location = new System.Drawing.Point(1427, 86);
            this.bInsertar.Name = "bInsertar";
            this.bInsertar.Size = new System.Drawing.Size(182, 37);
            this.bInsertar.TabIndex = 2;
            this.bInsertar.Text = "➕ New attribute";
            this.bInsertar.UseVisualStyleBackColor = true;
            this.bInsertar.Click += new System.EventHandler(this.bInsertar_Click);
            // 
            // LabelUserAttributes
            // 
            this.LabelUserAttributes.AutoSize = true;
            this.LabelUserAttributes.Font = new System.Drawing.Font("Franklin Gothic Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelUserAttributes.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.LabelUserAttributes.Location = new System.Drawing.Point(400, 80);
            this.LabelUserAttributes.Name = "LabelUserAttributes";
            this.LabelUserAttributes.Size = new System.Drawing.Size(173, 29);
            this.LabelUserAttributes.TabIndex = 8;
            this.LabelUserAttributes.Text = "User Attributes";
            // 
            // Attributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.LabelUserAttributes);
            this.Controls.Add(this.bInsertar);
            this.Controls.Add(this.dataGridViewAtributos);
            this.Name = "Attributes";
            this.Text = "Attributes";
            this.Load += new System.EventHandler(this.Attributes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtributos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewAtributos;
        private System.Windows.Forms.Button bInsertar;
        private System.Windows.Forms.Label LabelUserAttributes;
    }
}