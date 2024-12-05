namespace ChillDeCojones
{
    partial class Dashboard
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
            this.labelDashboard = new System.Windows.Forms.Label();
            this.numeroRelaciones = new System.Windows.Forms.Label();
            this.numeroCategorias = new System.Windows.Forms.Label();
            this.numeroAtributos = new System.Windows.Forms.Label();
            this.numeroProductos = new System.Windows.Forms.Label();
            this.bExport = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelDashboard
            // 
            this.labelDashboard.AutoSize = true;
            this.labelDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDashboard.Location = new System.Drawing.Point(224, 149);
            this.labelDashboard.Name = "labelDashboard";
            this.labelDashboard.Size = new System.Drawing.Size(92, 32);
            this.labelDashboard.TabIndex = 0;
            this.labelDashboard.Text = "label1";
            // 
            // numeroRelaciones
            // 
            this.numeroRelaciones.AutoSize = true;
            this.numeroRelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroRelaciones.Location = new System.Drawing.Point(689, 130);
            this.numeroRelaciones.Name = "numeroRelaciones";
            this.numeroRelaciones.Size = new System.Drawing.Size(252, 32);
            this.numeroRelaciones.TabIndex = 1;
            this.numeroRelaciones.Text = "numeroRelaciones";
            // 
            // numeroCategorias
            // 
            this.numeroCategorias.AutoSize = true;
            this.numeroCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCategorias.Location = new System.Drawing.Point(480, 53);
            this.numeroCategorias.Name = "numeroCategorias";
            this.numeroCategorias.Size = new System.Drawing.Size(248, 32);
            this.numeroCategorias.TabIndex = 2;
            this.numeroCategorias.Text = "numeroCategorias";
            // 
            // numeroAtributos
            // 
            this.numeroAtributos.AutoSize = true;
            this.numeroAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroAtributos.Location = new System.Drawing.Point(703, 265);
            this.numeroAtributos.Name = "numeroAtributos";
            this.numeroAtributos.Size = new System.Drawing.Size(223, 32);
            this.numeroAtributos.TabIndex = 3;
            this.numeroAtributos.Text = "numeroAtributos";
            // 
            // numeroProductos
            // 
            this.numeroProductos.AutoSize = true;
            this.numeroProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroProductos.Location = new System.Drawing.Point(412, 229);
            this.numeroProductos.Name = "numeroProductos";
            this.numeroProductos.Size = new System.Drawing.Size(238, 32);
            this.numeroProductos.TabIndex = 4;
            this.numeroProductos.Text = "numeroProductos";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(486, 439);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(212, 66);
            this.bExport.TabIndex = 5;
            this.bExport.Text = "Export";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.numeroProductos);
            this.Controls.Add(this.numeroAtributos);
            this.Controls.Add(this.numeroCategorias);
            this.Controls.Add(this.numeroRelaciones);
            this.Controls.Add(this.labelDashboard);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDashboard;
        private System.Windows.Forms.Label numeroRelaciones;
        private System.Windows.Forms.Label numeroCategorias;
        private System.Windows.Forms.Label numeroAtributos;
        private System.Windows.Forms.Label numeroProductos;
        private System.Windows.Forms.Button bExport;
    }
}