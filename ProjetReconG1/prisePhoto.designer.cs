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
            this.traitementOxfordProgressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webcam
            // 
            this.webcam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webcam.Location = new System.Drawing.Point(32, 103);
            this.webcam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.webcam.Name = "webcam";
            this.webcam.Size = new System.Drawing.Size(1429, 834);
            this.webcam.TabIndex = 0;
            // 
            // btnPrendrePhoto
            // 
            this.btnPrendrePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrendrePhoto.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnPrendrePhoto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnPrendrePhoto.Location = new System.Drawing.Point(544, 980);
            this.btnPrendrePhoto.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrendrePhoto.Name = "btnPrendrePhoto";
            this.btnPrendrePhoto.Size = new System.Drawing.Size(405, 49);
            this.btnPrendrePhoto.TabIndex = 9;
            this.btnPrendrePhoto.Text = "Prendre la photo";
            this.btnPrendrePhoto.UseCustomForeColor = true;
            this.btnPrendrePhoto.UseSelectable = true;
            this.btnPrendrePhoto.Click += new System.EventHandler(this.BtnPhoto_onclick);
            // 
            // timerTraitement
            // 
            this.timerTraitement.Tick += new System.EventHandler(this.TimerTraitement_Tick);
            // 
            // traitementOxfordProgressSpinner
            // 
            this.traitementOxfordProgressSpinner.Location = new System.Drawing.Point(490, 250);
            this.traitementOxfordProgressSpinner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.traitementOxfordProgressSpinner.Maximum = 100;
            this.traitementOxfordProgressSpinner.Name = "traitementOxfordProgressSpinner";
            this.traitementOxfordProgressSpinner.Size = new System.Drawing.Size(500, 500);
            this.traitementOxfordProgressSpinner.TabIndex = 10;
            this.traitementOxfordProgressSpinner.UseSelectable = true;
            this.traitementOxfordProgressSpinner.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(623, 44);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Prise de photo";
            // 
            // PrisePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1493, 1046);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.traitementOxfordProgressSpinner);
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
            this.PerformLayout();

        }

        #endregion

        /// <summary> The webcam. </summary>
        private WebCameraControl webcam;
        /// <summary> The button prendre photo. </summary>
        private MetroFramework.Controls.MetroButton btnPrendrePhoto;
        /// <summary> The timer traitement. </summary>
        private System.Windows.Forms.Timer timerTraitement;
        /// <summary> The first metro progress spinner. </summary>
        private MetroFramework.Controls.MetroProgressSpinner traitementOxfordProgressSpinner;
        private System.Windows.Forms.Label label1;
    }
}