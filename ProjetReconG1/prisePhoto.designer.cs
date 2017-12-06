using WebEye.Controls.WinForms.WebCameraControl;

namespace projetOxf
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
            this.components = new System.ComponentModel.Container();
            this.webcam = new WebEye.Controls.WinForms.WebCameraControl.WebCameraControl();
            this.btnPrendrePhoto = new MetroFramework.Controls.MetroButton();
            this.timerTraitement = new System.Windows.Forms.Timer(this.components);
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webcam
            // 
            this.webcam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webcam.Location = new System.Drawing.Point(24, 84);
            this.webcam.Margin = new System.Windows.Forms.Padding(2);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(1072, 678);
            this.webcam.TabIndex = 0;
            // 
            // btnPrendrePhoto
            // 
            this.btnPrendrePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrendrePhoto.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPrendrePhoto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPrendrePhoto.Location = new System.Drawing.Point(408, 796);
            this.btnPrendrePhoto.Name = "btnPrendrePhoto";
            this.btnPrendrePhoto.Size = new System.Drawing.Size(304, 40);
            this.btnPrendrePhoto.TabIndex = 9;
            this.btnPrendrePhoto.Text = "Prendre la photo";
            this.btnPrendrePhoto.UseCustomForeColor = true;
            this.btnPrendrePhoto.UseSelectable = true;
            this.btnPrendrePhoto.Click += new System.EventHandler(this.btnPhoto_onclick);
            // 
            // timerTraitement
            // 
            this.timerTraitement.Tick += new System.EventHandler(this.timerTraitement_Tick);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(480, 339);
            this.metroProgressSpinner1.Margin = new System.Windows.Forms.Padding(2);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(160, 173);
            this.metroProgressSpinner1.TabIndex = 10;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Thin", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(467, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 34);
            this.label1.TabIndex = 11;
            this.label1.Text = "Prise de photo";
            // 
            // PrisePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 850);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.btnPrendrePhoto);
            this.Controls.Add(this.webcam);
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "PrisePhoto";
            this.Resizable = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrisePhoto_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private WebCameraControl webcam;
        private MetroFramework.Controls.MetroButton btnPrendrePhoto;
        private System.Windows.Forms.Timer timerTraitement;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private System.Windows.Forms.Label label1;
    }
}