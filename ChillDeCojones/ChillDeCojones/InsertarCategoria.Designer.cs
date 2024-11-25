namespace ChillDeCojones
{
    partial class InsertarCategoria
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
            this.tName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bAceptar = new System.Windows.Forms.Button();
            this.bCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(226, 99);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(155, 22);
            this.tName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // bAceptar
            // 
            this.bAceptar.Location = new System.Drawing.Point(90, 188);
            this.bAceptar.Name = "bAceptar";
            this.bAceptar.Size = new System.Drawing.Size(75, 23);
            this.bAceptar.TabIndex = 2;
            this.bAceptar.Text = "Accept";
            this.bAceptar.UseVisualStyleBackColor = true;
            this.bAceptar.Click += new System.EventHandler(this.bAceptar_Click);
            // 
            // bCancelar
            // 
            this.bCancelar.Location = new System.Drawing.Point(323, 188);
            this.bCancelar.Name = "bCancelar";
            this.bCancelar.Size = new System.Drawing.Size(75, 23);
            this.bCancelar.TabIndex = 3;
            this.bCancelar.Text = "Cancel";
            this.bCancelar.UseVisualStyleBackColor = true;
            this.bCancelar.Click += new System.EventHandler(this.bCancelar_Click);
            // 
            // InsertarCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.bCancelar);
            this.Controls.Add(this.bAceptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tName);
            this.Name = "InsertarCategoria";
            this.Text = "InsertarCategoria";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InsertarCategoria_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bAceptar;
        private System.Windows.Forms.Button bCancelar;
    }
}