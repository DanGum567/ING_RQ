namespace ChillDeCojones
{
    partial class ModificarAtributo
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
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonDiscard = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.tName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Franklin Gothic Medium", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(79, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Name";
            // 
            // ButtonDiscard
            // 
            this.ButtonDiscard.Location = new System.Drawing.Point(352, 201);
            this.ButtonDiscard.Name = "ButtonDiscard";
            this.ButtonDiscard.Size = new System.Drawing.Size(75, 23);
            this.ButtonDiscard.TabIndex = 9;
            this.ButtonDiscard.Text = "Discard";
            this.ButtonDiscard.UseVisualStyleBackColor = true;
            this.ButtonDiscard.Click += new System.EventHandler(this.ButtonDiscard_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(127, 201);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 8;
            this.ButtonSave.Text = "Save";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // tName
            // 
            this.tName.Location = new System.Drawing.Point(187, 80);
            this.tName.Name = "tName";
            this.tName.Size = new System.Drawing.Size(198, 22);
            this.tName.TabIndex = 7;
            // 
            // ModificarAtributo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ButtonDiscard);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.tName);
            this.Name = "ModificarAtributo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ModificarAtributo";
            this.Load += new System.EventHandler(this.ModificarAtributo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonDiscard;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.TextBox tName;
    }
}