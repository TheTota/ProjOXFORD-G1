//-----------------------------------------------------------------------
// <copyright file="PrisePhoto.Designer.cs" company="SIO">
//     Copyright (c) SIO. All rights reserved.
// </copyright>
// <author>Thomas Cianfarani</author>
// <author>Mehdi Ben Bahri</author>
// <author>Léo Espeu</author>
//-----------------------------------------------------------------------

using WebEye.Controls.WinForms.WebCameraControl;

namespace ProjetOxf
{
    /// <content> Formulaire de prise de photo. </content>
    public partial class PrisePhoto
    {
        /// <summary> Required designer variable. </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> Clean up any resources being used. </summary>
        ///
        /// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>
        ///
        /// <param name="disposing">
        ///     true if managed resources should be disposed; otherwise, false.
        /// </param>

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary> Required method for Designer support - do not modify the contents of this method with
        /// the code editor. </summary>
        ///
        /// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webcam = new WebEye.Controls.WinForms.WebCameraControl.WebCameraControl();
            this.btnPrendrePhoto = new MetroFramework.Controls.MetroButton();
            this.timerTraitement = new System.Windows.Forms.Timer(this.components);
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.SuspendLayout();
            // 
            // webcam
            // 
            this.webcam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webcam.Location = new System.Drawing.Point(30, 77);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(683, 373);
            this.webcam.TabIndex = 0;
            // 
            // btnPrendrePhoto
            // 
            this.btnPrendrePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrendrePhoto.Location = new System.Drawing.Point(166, 468);
            this.btnPrendrePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrendrePhoto.Name = "btnPrendrePhoto";
            this.btnPrendrePhoto.Size = new System.Drawing.Size(405, 38);
            this.btnPrendrePhoto.TabIndex = 9;
            this.btnPrendrePhoto.Text = "Prendre la photo";
            this.btnPrendrePhoto.UseSelectable = true;
            this.btnPrendrePhoto.Click += new System.EventHandler(this.BtnPhoto_onclick);
            // 
            // timerTraitement
            // 
            this.timerTraitement.Tick += new System.EventHandler(this.TimerTraitement_Tick);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(244, 159);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(213, 213);
            this.metroProgressSpinner1.TabIndex = 10;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Visible = false;
            // 
            // PrisePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 523);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.btnPrendrePhoto);
            this.Controls.Add(this.webcam);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "PrisePhoto";
            this.Padding = new System.Windows.Forms.Padding(27, 74, 27, 25);
            this.Resizable = false;
            this.Text = "Prise de photo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrisePhoto_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary> The webcam. </summary>
        private WebCameraControl webcam;
        /// <summary> The button prendre photo. </summary>
        private MetroFramework.Controls.MetroButton btnPrendrePhoto;
        /// <summary> The timer traitement. </summary>
        private System.Windows.Forms.Timer timerTraitement;
        /// <summary> The first metro progress spinner. </summary>
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
    }
}