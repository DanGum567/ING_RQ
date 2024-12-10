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
            this.lCreated = new System.Windows.Forms.Label();
            this.numeroRelaciones = new System.Windows.Forms.Label();
            this.numeroCategorias = new System.Windows.Forms.Label();
            this.numeroAtributos = new System.Windows.Forms.Label();
            this.numeroProductos = new System.Windows.Forms.Label();
            this.bExport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lAccountName = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // lCreated
            // 
            this.lCreated.AutoSize = true;
            this.lCreated.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCreated.Location = new System.Drawing.Point(53, 299);
            this.lCreated.Name = "lCreated";
            this.lCreated.Size = new System.Drawing.Size(123, 32);
            this.lCreated.TabIndex = 0;
            this.lCreated.Text = "Created:";
            // 
            // numeroRelaciones
            // 
            this.numeroRelaciones.AutoSize = true;
            this.numeroRelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroRelaciones.Location = new System.Drawing.Point(35, 31);
            this.numeroRelaciones.Name = "numeroRelaciones";
            this.numeroRelaciones.Size = new System.Drawing.Size(252, 32);
            this.numeroRelaciones.TabIndex = 1;
            this.numeroRelaciones.Text = "numeroRelaciones";
            // 
            // numeroCategorias
            // 
            this.numeroCategorias.AutoSize = true;
            this.numeroCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCategorias.Location = new System.Drawing.Point(35, 79);
            this.numeroCategorias.Name = "numeroCategorias";
            this.numeroCategorias.Size = new System.Drawing.Size(248, 32);
            this.numeroCategorias.TabIndex = 2;
            this.numeroCategorias.Text = "numeroCategorias";
            // 
            // numeroAtributos
            // 
            this.numeroAtributos.AutoSize = true;
            this.numeroAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroAtributos.Location = new System.Drawing.Point(35, 82);
            this.numeroAtributos.Name = "numeroAtributos";
            this.numeroAtributos.Size = new System.Drawing.Size(223, 32);
            this.numeroAtributos.TabIndex = 3;
            this.numeroAtributos.Text = "numeroAtributos";
            // 
            // numeroProductos
            // 
            this.numeroProductos.AutoSize = true;
            this.numeroProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroProductos.Location = new System.Drawing.Point(35, 34);
            this.numeroProductos.Name = "numeroProductos";
            this.numeroProductos.Size = new System.Drawing.Size(238, 32);
            this.numeroProductos.TabIndex = 4;
            this.numeroProductos.Text = "numeroProductos";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(769, 713);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(212, 66);
            this.bExport.TabIndex = 5;
            this.bExport.Text = "Export";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(59, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(177, 162);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(186, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 32);
            this.label1.TabIndex = 7;
            this.label1.Text = "Products";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(186, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Others";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(366, 68);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 387);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numeroCategorias);
            this.panel2.Controls.Add(this.numeroRelaciones);
            this.panel2.Location = new System.Drawing.Point(402, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(726, 143);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.lAccountName);
            this.panel3.Location = new System.Drawing.Point(366, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 56);
            this.panel3.TabIndex = 10;
            // 
            // lAccountName
            // 
            this.lAccountName.AutoSize = true;
            this.lAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAccountName.Location = new System.Drawing.Point(3, 16);
            this.lAccountName.Name = "lAccountName";
            this.lAccountName.Size = new System.Drawing.Size(199, 32);
            this.lAccountName.TabIndex = 11;
            this.lAccountName.Text = "Account Name";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.numeroProductos);
            this.panel4.Controls.Add(this.numeroAtributos);
            this.panel4.Location = new System.Drawing.Point(402, 207);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(726, 143);
            this.panel4.TabIndex = 11;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.lCreated);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lCreated;
        private System.Windows.Forms.Label numeroRelaciones;
        private System.Windows.Forms.Label numeroCategorias;
        private System.Windows.Forms.Label numeroAtributos;
        private System.Windows.Forms.Label numeroProductos;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lAccountName;
        private System.Windows.Forms.Panel panel4;
    }
}