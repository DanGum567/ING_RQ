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
            this.createdDateLabel = new System.Windows.Forms.Label();
            this.numeroRelaciones = new System.Windows.Forms.Label();
            this.numeroCategorias = new System.Windows.Forms.Label();
            this.bExport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.numeroProductos = new System.Windows.Forms.Label();
            this.numeroAtributos = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.accountNameLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // createdDateLabel
            // 
            this.createdDateLabel.AutoSize = true;
            this.createdDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdDateLabel.Location = new System.Drawing.Point(77, 478);
            this.createdDateLabel.Name = "createdDateLabel";
            this.createdDateLabel.Size = new System.Drawing.Size(123, 32);
            this.createdDateLabel.TabIndex = 0;
            this.createdDateLabel.Text = "Created:";
            // 
            // numeroRelaciones
            // 
            this.numeroRelaciones.AutoSize = true;
            this.numeroRelaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroRelaciones.Location = new System.Drawing.Point(35, 232);
            this.numeroRelaciones.Name = "numeroRelaciones";
            this.numeroRelaciones.Size = new System.Drawing.Size(299, 32);
            this.numeroRelaciones.TabIndex = 1;
            this.numeroRelaciones.Text = "numberOfRelationship";
            // 
            // numeroCategorias
            // 
            this.numeroCategorias.AutoSize = true;
            this.numeroCategorias.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroCategorias.Location = new System.Drawing.Point(35, 100);
            this.numeroCategorias.Name = "numeroCategorias";
            this.numeroCategorias.Size = new System.Drawing.Size(278, 32);
            this.numeroCategorias.TabIndex = 2;
            this.numeroCategorias.Text = "numberOfCategories";
            // 
            // bExport
            // 
            this.bExport.Location = new System.Drawing.Point(1085, 795);
            this.bExport.Name = "bExport";
            this.bExport.Size = new System.Drawing.Size(212, 66);
            this.bExport.TabIndex = 5;
            this.bExport.Text = "Export";
            this.bExport.UseVisualStyleBackColor = true;
            this.bExport.Click += new System.EventHandler(this.bExport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(541, 225);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1239, 465);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.numeroProductos);
            this.panel2.Controls.Add(this.numeroCategorias);
            this.panel2.Controls.Add(this.numeroAtributos);
            this.panel2.Controls.Add(this.numeroRelaciones);
            this.panel2.Location = new System.Drawing.Point(323, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(659, 303);
            this.panel2.TabIndex = 10;
            // 
            // numeroProductos
            // 
            this.numeroProductos.AutoSize = true;
            this.numeroProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroProductos.Location = new System.Drawing.Point(35, 30);
            this.numeroProductos.Name = "numeroProductos";
            this.numeroProductos.Size = new System.Drawing.Size(252, 32);
            this.numeroProductos.TabIndex = 4;
            this.numeroProductos.Text = "numberOfProducts";
            // 
            // numeroAtributos
            // 
            this.numeroAtributos.AutoSize = true;
            this.numeroAtributos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numeroAtributos.Location = new System.Drawing.Point(35, 164);
            this.numeroAtributos.Name = "numeroAtributos";
            this.numeroAtributos.Size = new System.Drawing.Size(261, 32);
            this.numeroAtributos.TabIndex = 3;
            this.numeroAtributos.Text = "numberOfAttributes";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightPink;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(541, 169);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(461, 56);
            this.panel3.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(198, 32);
            this.label1.TabIndex = 12;
            this.label1.Text = "Account report";
            // 
            // accountNameLabel
            // 
            this.accountNameLabel.AutoSize = true;
            this.accountNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.accountNameLabel.Location = new System.Drawing.Point(77, 421);
            this.accountNameLabel.Name = "accountNameLabel";
            this.accountNameLabel.Size = new System.Drawing.Size(199, 32);
            this.accountNameLabel.TabIndex = 11;
            this.accountNameLabel.Text = "Account Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ChillDeCojones.Properties.Resources.ikea;
            this.pictureBox1.InitialImage = global::ChillDeCojones.Properties.Resources.artworks_DVUwxlYygwLiajW7_ZZhNJg_t1080x1080;
            this.pictureBox1.Location = new System.Drawing.Point(40, 119);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 275);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1884, 959);
            this.Controls.Add(this.accountNameLabel);
            this.Controls.Add(this.bExport);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.createdDateLabel);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label createdDateLabel;
        private System.Windows.Forms.Label numeroRelaciones;
        private System.Windows.Forms.Label numeroCategorias;
        private System.Windows.Forms.Button bExport;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label accountNameLabel;
        private System.Windows.Forms.Label numeroProductos;
        private System.Windows.Forms.Label numeroAtributos;
        private System.Windows.Forms.Label label1;
    }
}