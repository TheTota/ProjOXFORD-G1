using WebEye.Controls.WinForms.WebCameraControl;

namespace ProjetReconFormulaire
{
    partial class PrisePhoto
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
            this.webcam = new WebEye.Controls.WinForms.WebCameraControl.WebCameraControl();
            this.btnPrendrePhoto = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // webcam
            // 
            this.webcam.Location = new System.Drawing.Point(30, 77);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(683, 373);
            this.webcam.TabIndex = 0;
            // 
            // btnPrendrePhoto
            // 
            this.btnPrendrePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrendrePhoto.Location = new System.Drawing.Point(146, 468);
            this.btnPrendrePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrendrePhoto.Name = "btnPrendrePhoto";
            this.btnPrendrePhoto.Size = new System.Drawing.Size(405, 38);
            this.btnPrendrePhoto.TabIndex = 9;
            this.btnPrendrePhoto.Text = "Prendre la photo";
            this.btnPrendrePhoto.UseSelectable = true;
            this.btnPrendrePhoto.Click += new System.EventHandler(this.btnPhoto_onclick);
            // 
            // PrisePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 523);
            this.Controls.Add(this.btnPrendrePhoto);
            this.Controls.Add(this.webcam);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PrisePhoto";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Text = "prisePhoto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrisePhoto_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private WebCameraControl webcam;
        private MetroFramework.Controls.MetroButton btnPrendrePhoto;
    }
}