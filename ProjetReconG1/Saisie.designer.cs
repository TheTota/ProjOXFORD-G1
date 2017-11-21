namespace ProjetReconFormulaire
{
    partial class Saisie
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saisie));
            this.prenom = new MetroFramework.Controls.MetroTextBox();
            this.nom = new MetroFramework.Controls.MetroTextBox();
            this.dateDeNaiss = new MetroFramework.Controls.MetroDateTime();
            this.email = new MetroFramework.Controls.MetroTextBox();
            this.sexeHomme = new MetroFramework.Controls.MetroRadioButton();
            this.sexeFemme = new MetroFramework.Controls.MetroRadioButton();
            this.statut = new MetroFramework.Controls.MetroTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.valide = new MetroFramework.Controls.MetroButton();
            this.prisePhoto = new MetroFramework.Controls.MetroButton();
            this.saisieGroupbox = new System.Windows.Forms.GroupBox();
            this.erreur = new System.Windows.Forms.Label();
            this.imgValide = new System.Windows.Forms.PictureBox();
            this.bVoirPhoto = new MetroFramework.Controls.MetroButton();
            this.saisieGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgValide)).BeginInit();
            this.SuspendLayout();
            // 
            // prenom
            // 
            // 
            // 
            // 
            this.prenom.CustomButton.Image = null;
            this.prenom.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.prenom.CustomButton.Name = "";
            this.prenom.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.prenom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.prenom.CustomButton.TabIndex = 1;
            this.prenom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.prenom.CustomButton.UseSelectable = true;
            this.prenom.CustomButton.Visible = false;
            this.prenom.Lines = new string[0];
            this.prenom.Location = new System.Drawing.Point(182, 82);
            this.prenom.MaxLength = 32767;
            this.prenom.Name = "prenom";
            this.prenom.PasswordChar = '\0';
            this.prenom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.prenom.SelectedText = "";
            this.prenom.SelectionLength = 0;
            this.prenom.SelectionStart = 0;
            this.prenom.ShortcutsEnabled = true;
            this.prenom.Size = new System.Drawing.Size(184, 23);
            this.prenom.TabIndex = 2;
            this.prenom.UseSelectable = true;
            this.prenom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.prenom.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // nom
            // 
            // 
            // 
            // 
            this.nom.CustomButton.Image = null;
            this.nom.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.nom.CustomButton.Name = "";
            this.nom.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.nom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nom.CustomButton.TabIndex = 1;
            this.nom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nom.CustomButton.UseSelectable = true;
            this.nom.CustomButton.Visible = false;
            this.nom.Lines = new string[0];
            this.nom.Location = new System.Drawing.Point(182, 51);
            this.nom.MaxLength = 32767;
            this.nom.Name = "nom";
            this.nom.PasswordChar = '\0';
            this.nom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nom.SelectedText = "";
            this.nom.SelectionLength = 0;
            this.nom.SelectionStart = 0;
            this.nom.ShortcutsEnabled = true;
            this.nom.Size = new System.Drawing.Size(184, 23);
            this.nom.TabIndex = 1;
            this.nom.UseSelectable = true;
            this.nom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nom.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dateDeNaiss
            // 
            this.dateDeNaiss.Location = new System.Drawing.Point(182, 111);
            this.dateDeNaiss.MinimumSize = new System.Drawing.Size(0, 29);
            this.dateDeNaiss.Name = "dateDeNaiss";
            this.dateDeNaiss.Size = new System.Drawing.Size(184, 30);
            this.dateDeNaiss.TabIndex = 3;
            this.dateDeNaiss.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // email
            // 
            // 
            // 
            // 
            this.email.CustomButton.Image = null;
            this.email.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.email.CustomButton.Name = "";
            this.email.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.email.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.email.CustomButton.TabIndex = 1;
            this.email.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.email.CustomButton.UseSelectable = true;
            this.email.CustomButton.Visible = false;
            this.email.Lines = new string[0];
            this.email.Location = new System.Drawing.Point(182, 147);
            this.email.MaxLength = 32767;
            this.email.Name = "email";
            this.email.PasswordChar = '\0';
            this.email.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.email.SelectedText = "";
            this.email.SelectionLength = 0;
            this.email.SelectionStart = 0;
            this.email.ShortcutsEnabled = true;
            this.email.Size = new System.Drawing.Size(184, 23);
            this.email.TabIndex = 4;
            this.email.UseSelectable = true;
            this.email.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.email.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sexeHomme
            // 
            this.sexeHomme.AutoSize = true;
            this.sexeHomme.Location = new System.Drawing.Point(200, 176);
            this.sexeHomme.Name = "sexeHomme";
            this.sexeHomme.Size = new System.Drawing.Size(67, 15);
            this.sexeHomme.TabIndex = 5;
            this.sexeHomme.Text = "Homme";
            this.sexeHomme.UseSelectable = true;
            // 
            // sexeFemme
            // 
            this.sexeFemme.AutoSize = true;
            this.sexeFemme.Location = new System.Drawing.Point(287, 176);
            this.sexeFemme.Name = "sexeFemme";
            this.sexeFemme.Size = new System.Drawing.Size(63, 15);
            this.sexeFemme.TabIndex = 6;
            this.sexeFemme.Text = "Femme";
            this.sexeFemme.UseSelectable = true;
            // 
            // statut
            // 
            // 
            // 
            // 
            this.statut.CustomButton.Image = null;
            this.statut.CustomButton.Location = new System.Drawing.Point(122, 1);
            this.statut.CustomButton.Name = "";
            this.statut.CustomButton.Size = new System.Drawing.Size(16, 17);
            this.statut.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.statut.CustomButton.TabIndex = 1;
            this.statut.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.statut.CustomButton.UseSelectable = true;
            this.statut.CustomButton.Visible = false;
            this.statut.Lines = new string[0];
            this.statut.Location = new System.Drawing.Point(182, 198);
            this.statut.MaxLength = 32767;
            this.statut.Name = "statut";
            this.statut.PasswordChar = '\0';
            this.statut.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.statut.SelectedText = "";
            this.statut.SelectionLength = 0;
            this.statut.SelectionStart = 0;
            this.statut.ShortcutsEnabled = true;
            this.statut.Size = new System.Drawing.Size(184, 23);
            this.statut.TabIndex = 7;
            this.statut.UseSelectable = true;
            this.statut.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.statut.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Prenom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date de naissance :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sexe :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 198);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Statut : ";
            // 
            // valide
            // 
            this.valide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.valide.Location = new System.Drawing.Point(85, 386);
            this.valide.Name = "valide";
            this.valide.Size = new System.Drawing.Size(304, 31);
            this.valide.TabIndex = 9;
            this.valide.Text = "Valider";
            this.valide.UseSelectable = true;
            this.valide.Click += new System.EventHandler(this.valide_Click);
            // 
            // prisePhoto
            // 
            this.prisePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prisePhoto.Location = new System.Drawing.Point(85, 346);
            this.prisePhoto.Name = "prisePhoto";
            this.prisePhoto.Size = new System.Drawing.Size(304, 31);
            this.prisePhoto.TabIndex = 8;
            this.prisePhoto.Text = "Prendre une photo";
            this.prisePhoto.UseSelectable = true;
            this.prisePhoto.Click += new System.EventHandler(this.prisePhoto_Click);
            // 
            // saisieGroupbox
            // 
            this.saisieGroupbox.Controls.Add(this.nom);
            this.saisieGroupbox.Controls.Add(this.prenom);
            this.saisieGroupbox.Controls.Add(this.dateDeNaiss);
            this.saisieGroupbox.Controls.Add(this.label6);
            this.saisieGroupbox.Controls.Add(this.email);
            this.saisieGroupbox.Controls.Add(this.label5);
            this.saisieGroupbox.Controls.Add(this.sexeHomme);
            this.saisieGroupbox.Controls.Add(this.label4);
            this.saisieGroupbox.Controls.Add(this.sexeFemme);
            this.saisieGroupbox.Controls.Add(this.label3);
            this.saisieGroupbox.Controls.Add(this.statut);
            this.saisieGroupbox.Controls.Add(this.label2);
            this.saisieGroupbox.Controls.Add(this.label1);
            this.saisieGroupbox.Location = new System.Drawing.Point(23, 75);
            this.saisieGroupbox.Name = "saisieGroupbox";
            this.saisieGroupbox.Size = new System.Drawing.Size(692, 252);
            this.saisieGroupbox.TabIndex = 15;
            this.saisieGroupbox.TabStop = false;
            this.saisieGroupbox.Text = "Saisie";
            // 
            // erreur
            // 
            this.erreur.AutoSize = true;
            this.erreur.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.erreur.ForeColor = System.Drawing.Color.Red;
            this.erreur.Location = new System.Drawing.Point(284, 29);
            this.erreur.Name = "erreur";
            this.erreur.Size = new System.Drawing.Size(322, 20);
            this.erreur.TabIndex = 13;
            this.erreur.Text = "Les champs doivent tous être complets";
            this.erreur.Visible = false;
            // 
            // imgValide
            // 
            this.imgValide.Image = global::ProjetReconG1.Properties.Resources.check_oui;
            this.imgValide.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgValide.InitialImage")));
            this.imgValide.Location = new System.Drawing.Point(394, 346);
            this.imgValide.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.imgValide.Name = "imgValide";
            this.imgValide.Size = new System.Drawing.Size(29, 31);
            this.imgValide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgValide.TabIndex = 16;
            this.imgValide.TabStop = false;
            this.imgValide.Visible = false;
            // 
            // bVoirPhoto
            // 
            this.bVoirPhoto.Location = new System.Drawing.Point(85, 424);
            this.bVoirPhoto.Name = "bVoirPhoto";
            this.bVoirPhoto.Size = new System.Drawing.Size(304, 32);
            this.bVoirPhoto.TabIndex = 17;
            this.bVoirPhoto.Text = "Aperçu photo";
            this.bVoirPhoto.UseSelectable = true;
            this.bVoirPhoto.Click += new System.EventHandler(this.bVoirPhoto_Click);
            // 
            // Saisie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 470);
            this.Controls.Add(this.bVoirPhoto);
            this.Controls.Add(this.imgValide);
            this.Controls.Add(this.erreur);
            this.Controls.Add(this.saisieGroupbox);
            this.Controls.Add(this.prisePhoto);
            this.Controls.Add(this.valide);
            this.Name = "Saisie";
            this.Resizable = false;
            this.Text = "Formulaire d\'inscription";
            this.Activated += new System.EventHandler(this.Saisie_Activated);
            this.saisieGroupbox.ResumeLayout(false);
            this.saisieGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgValide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox prenom;
        private MetroFramework.Controls.MetroTextBox nom;
        private MetroFramework.Controls.MetroDateTime dateDeNaiss;
        private MetroFramework.Controls.MetroTextBox email;
        private MetroFramework.Controls.MetroRadioButton sexeHomme;
        private MetroFramework.Controls.MetroRadioButton sexeFemme;
        private MetroFramework.Controls.MetroTextBox statut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroButton valide;
        private MetroFramework.Controls.MetroButton prisePhoto;
        private System.Windows.Forms.GroupBox saisieGroupbox;
        private System.Windows.Forms.Label erreur;
        private System.Windows.Forms.PictureBox imgValide;
        private MetroFramework.Controls.MetroButton bVoirPhoto;
    }
}

