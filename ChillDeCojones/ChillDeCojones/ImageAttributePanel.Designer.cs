namespace ChillDeCojones
{
    partial class ImageAttributePanel
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
            this.ImagePictureBox = new System.Windows.Forms.PictureBox();
            this.UploadImageLabel = new System.Windows.Forms.Button();
            this.DiscardImageButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImagePictureBox
            // 
            this.ImagePictureBox.BackgroundImage = global::ChillDeCojones.Properties.Resources.imagenPredeterminadaProducto;
            this.ImagePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ImagePictureBox.Location = new System.Drawing.Point(12, 12);
            this.ImagePictureBox.Name = "ImagePictureBox";
            this.ImagePictureBox.Size = new System.Drawing.Size(133, 132);
            this.ImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePictureBox.TabIndex = 0;
            this.ImagePictureBox.TabStop = false;
            // 
            // UploadImageLabel
            // 
            this.UploadImageLabel.Location = new System.Drawing.Point(181, 39);
            this.UploadImageLabel.Name = "UploadImageLabel";
            this.UploadImageLabel.Size = new System.Drawing.Size(178, 33);
            this.UploadImageLabel.TabIndex = 1;
            this.UploadImageLabel.Text = "Upload image";
            this.UploadImageLabel.UseVisualStyleBackColor = true;
            // 
            // DiscardImageButton
            // 
            this.DiscardImageButton.Location = new System.Drawing.Point(181, 96);
            this.DiscardImageButton.Name = "DiscardImageButton";
            this.DiscardImageButton.Size = new System.Drawing.Size(178, 35);
            this.DiscardImageButton.TabIndex = 2;
            this.DiscardImageButton.Text = "Discard image";
            this.DiscardImageButton.UseVisualStyleBackColor = true;
            // 
            // ImageAttributePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 153);
            this.Controls.Add(this.DiscardImageButton);
            this.Controls.Add(this.UploadImageLabel);
            this.Controls.Add(this.ImagePictureBox);
            this.Name = "ImageAttributePanel";
            this.Text = "ImageAttributePanel";
            ((System.ComponentModel.ISupportInitialize)(this.ImagePictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImagePictureBox;
        private System.Windows.Forms.Button UploadImageLabel;
        private System.Windows.Forms.Button DiscardImageButton;
    }
}