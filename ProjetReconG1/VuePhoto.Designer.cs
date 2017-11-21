namespace ProjetReconFormulaire
{
    partial class VuePhoto
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
            this.photoUser = new System.Windows.Forms.PictureBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            ((System.ComponentModel.ISupportInitialize)(this.photoUser)).BeginInit();
            this.SuspendLayout();
            // 
            // photoUser
            // 
            this.photoUser.Location = new System.Drawing.Point(23, 59);
            this.photoUser.Name = "photoUser";
            this.photoUser.Size = new System.Drawing.Size(1946, 695);
            this.photoUser.TabIndex = 0;
            this.photoUser.TabStop = false;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(624, 24);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(170, 29);
            this.metroButton1.TabIndex = 1;
            this.metroButton1.Text = "Fermer";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // VuePhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 777);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.photoUser);
            this.Name = "VuePhoto";
            this.Text = "VuePhoto";
            ((System.ComponentModel.ISupportInitialize)(this.photoUser)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MetroFramework.Controls.MetroButton metroButton1;
        internal System.Windows.Forms.PictureBox photoUser;
    }
}