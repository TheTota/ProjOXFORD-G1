﻿namespace ProjetOxf
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saisie));
            this.prenom = new MetroFramework.Controls.MetroTextBox();
            this.nom = new MetroFramework.Controls.MetroTextBox();
            this.dateDeNaiss = new MetroFramework.Controls.MetroDateTime();
            this.email = new MetroFramework.Controls.MetroTextBox();
            this.sexeHomme = new MetroFramework.Controls.MetroRadioButton();
            this.sexeFemme = new MetroFramework.Controls.MetroRadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.valide = new MetroFramework.Controls.MetroButton();
            this.prisePhoto = new MetroFramework.Controls.MetroButton();
            this.saisieGroupbox = new System.Windows.Forms.GroupBox();
            this.maPhoto = new System.Windows.Forms.PictureBox();
            this.cboStatut = new System.Windows.Forms.ComboBox();
            this.imgValide = new System.Windows.Forms.PictureBox();
            this.traitementOxfordProgressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saisieGroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgValide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // prenom
            // 
            // 
            // 
            // 
            this.prenom.CustomButton.Image = null;
            this.prenom.CustomButton.Location = new System.Drawing.Point(224, 2);
            this.prenom.CustomButton.Name = "";
            this.prenom.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.prenom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.prenom.CustomButton.TabIndex = 1;
            this.prenom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.prenom.CustomButton.UseSelectable = true;
            this.prenom.CustomButton.Visible = false;
            this.prenom.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.prenom.Lines = new string[0];
            this.prenom.Location = new System.Drawing.Point(373, 134);
            this.prenom.MaxLength = 32767;
            this.prenom.Name = "prenom";
            this.prenom.PasswordChar = '\0';
            this.prenom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.prenom.SelectedText = "";
            this.prenom.SelectionLength = 0;
            this.prenom.SelectionStart = 0;
            this.prenom.ShortcutsEnabled = true;
            this.prenom.Size = new System.Drawing.Size(262, 40);
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
            this.nom.CustomButton.Location = new System.Drawing.Point(224, 2);
            this.nom.CustomButton.Name = "";
            this.nom.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.nom.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.nom.CustomButton.TabIndex = 1;
            this.nom.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.nom.CustomButton.UseSelectable = true;
            this.nom.CustomButton.Visible = false;
            this.nom.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.nom.Lines = new string[0];
            this.nom.Location = new System.Drawing.Point(373, 72);
            this.nom.MaxLength = 32767;
            this.nom.Name = "nom";
            this.nom.PasswordChar = '\0';
            this.nom.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.nom.SelectedText = "";
            this.nom.SelectionLength = 0;
            this.nom.SelectionStart = 0;
            this.nom.ShortcutsEnabled = true;
            this.nom.Size = new System.Drawing.Size(262, 40);
            this.nom.TabIndex = 1;
            this.nom.UseSelectable = true;
            this.nom.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.nom.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // dateDeNaiss
            // 
            this.dateDeNaiss.FontSize = MetroFramework.MetroDateTimeSize.Tall;
            this.dateDeNaiss.Location = new System.Drawing.Point(373, 200);
            this.dateDeNaiss.MaximumSize = new System.Drawing.Size(400, 40);
            this.dateDeNaiss.MinimumSize = new System.Drawing.Size(0, 35);
            this.dateDeNaiss.Name = "dateDeNaiss";
            this.dateDeNaiss.Size = new System.Drawing.Size(221, 35);
            this.dateDeNaiss.TabIndex = 3;
            this.dateDeNaiss.Value = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            // 
            // email
            // 
            // 
            // 
            // 
            this.email.CustomButton.Image = null;
            this.email.CustomButton.Location = new System.Drawing.Point(287, 2);
            this.email.CustomButton.Name = "";
            this.email.CustomButton.Size = new System.Drawing.Size(35, 35);
            this.email.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.email.CustomButton.TabIndex = 1;
            this.email.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.email.CustomButton.UseSelectable = true;
            this.email.CustomButton.Visible = false;
            this.email.FontSize = MetroFramework.MetroTextBoxSize.Tall;
            this.email.Lines = new string[0];
            this.email.Location = new System.Drawing.Point(373, 256);
            this.email.MaxLength = 32767;
            this.email.Name = "email";
            this.email.PasswordChar = '\0';
            this.email.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.email.SelectedText = "";
            this.email.SelectionLength = 0;
            this.email.SelectionStart = 0;
            this.email.ShortcutsEnabled = true;
            this.email.Size = new System.Drawing.Size(325, 40);
            this.email.TabIndex = 4;
            this.email.UseSelectable = true;
            this.email.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.email.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // sexeHomme
            // 
            this.sexeHomme.AutoSize = true;
            this.sexeHomme.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.sexeHomme.Location = new System.Drawing.Point(373, 318);
            this.sexeHomme.Name = "sexeHomme";
            this.sexeHomme.Size = new System.Drawing.Size(93, 25);
            this.sexeHomme.TabIndex = 5;
            this.sexeHomme.TabStop = true;
            this.sexeHomme.Text = "Homme";
            this.sexeHomme.UseSelectable = true;
            // 
            // sexeFemme
            // 
            this.sexeFemme.AutoSize = true;
            this.sexeFemme.FontSize = MetroFramework.MetroCheckBoxSize.Tall;
            this.sexeFemme.Location = new System.Drawing.Point(507, 318);
            this.sexeFemme.Name = "sexeFemme";
            this.sexeFemme.Size = new System.Drawing.Size(87, 25);
            this.sexeFemme.TabIndex = 6;
            this.sexeFemme.TabStop = true;
            this.sexeFemme.Text = "Femme";
            this.sexeFemme.UseSelectable = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(62, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "Nom :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(62, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 31);
            this.label2.TabIndex = 8;
            this.label2.Text = "Prenom :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 31);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date de naissance :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(62, 256);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 31);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 318);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 31);
            this.label5.TabIndex = 11;
            this.label5.Text = "Sexe :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 387);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 31);
            this.label6.TabIndex = 12;
            this.label6.Text = "Statut : ";
            // 
            // valide
            // 
            this.valide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.valide.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.valide.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.valide.Location = new System.Drawing.Point(1001, 821);
            this.valide.Name = "valide";
            this.valide.Size = new System.Drawing.Size(304, 40);
            this.valide.TabIndex = 9;
            this.valide.Text = "Valider";
            this.valide.UseCustomForeColor = true;
            this.valide.UseSelectable = true;
            this.valide.Click += new System.EventHandler(this.Valide_Click);
            // 
            // prisePhoto
            // 
            this.prisePhoto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prisePhoto.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.prisePhoto.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.prisePhoto.Location = new System.Drawing.Point(628, 821);
            this.prisePhoto.Name = "prisePhoto";
            this.prisePhoto.Size = new System.Drawing.Size(304, 40);
            this.prisePhoto.TabIndex = 8;
            this.prisePhoto.Text = "Prendre une photo";
            this.prisePhoto.UseCustomForeColor = true;
            this.prisePhoto.UseSelectable = true;
            this.prisePhoto.Click += new System.EventHandler(this.PrisePhoto_Click);
            // 
            // saisieGroupbox
            // 
            this.saisieGroupbox.Controls.Add(this.maPhoto);
            this.saisieGroupbox.Controls.Add(this.cboStatut);
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
            this.saisieGroupbox.Controls.Add(this.label2);
            this.saisieGroupbox.Controls.Add(this.label1);
            this.saisieGroupbox.Location = new System.Drawing.Point(266, 219);
            this.saisieGroupbox.Name = "saisieGroupbox";
            this.saisieGroupbox.Size = new System.Drawing.Size(1389, 576);
            this.saisieGroupbox.TabIndex = 15;
            this.saisieGroupbox.TabStop = false;
            // 
            // maPhoto
            // 
            this.maPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.maPhoto.Location = new System.Drawing.Point(765, 72);
            this.maPhoto.Margin = new System.Windows.Forms.Padding(2);
            this.maPhoto.Name = "maPhoto";
            this.maPhoto.Size = new System.Drawing.Size(558, 390);
            this.maPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.maPhoto.TabIndex = 14;
            this.maPhoto.TabStop = false;
            // 
            // cboStatut
            // 
            this.cboStatut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatut.FormattingEnabled = true;
            this.cboStatut.Location = new System.Drawing.Point(373, 387);
            this.cboStatut.Margin = new System.Windows.Forms.Padding(2);
            this.cboStatut.MaximumSize = new System.Drawing.Size(400, 0);
            this.cboStatut.Name = "cboStatut";
            this.cboStatut.Size = new System.Drawing.Size(184, 21);
            this.cboStatut.TabIndex = 13;
            // 
            // imgValide
            // 
            this.imgValide.Image = global::ProjetReconG1.Properties.Resources.check_oui;
            this.imgValide.InitialImage = ((System.Drawing.Image)(resources.GetObject("imgValide.InitialImage")));
            this.imgValide.Location = new System.Drawing.Point(937, 821);
            this.imgValide.Margin = new System.Windows.Forms.Padding(2);
            this.imgValide.Name = "imgValide";
            this.imgValide.Size = new System.Drawing.Size(40, 40);
            this.imgValide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgValide.TabIndex = 16;
            this.imgValide.TabStop = false;
            this.imgValide.Visible = false;
            // 
            // traitementOxfordProgressSpinner
            // 
            this.traitementOxfordProgressSpinner.Location = new System.Drawing.Point(1313, 821);
            this.traitementOxfordProgressSpinner.Margin = new System.Windows.Forms.Padding(2);
            this.traitementOxfordProgressSpinner.Maximum = 100;
            this.traitementOxfordProgressSpinner.Name = "traitementOxfordProgressSpinner";
            this.traitementOxfordProgressSpinner.Size = new System.Drawing.Size(40, 40);
            this.traitementOxfordProgressSpinner.TabIndex = 17;
            this.traitementOxfordProgressSpinner.UseSelectable = true;
            this.traitementOxfordProgressSpinner.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(195, 195);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.label7.Location = new System.Drawing.Point(756, 60);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(409, 64);
            this.label7.TabIndex = 19;
            this.label7.Text = "Enregistrement";
            // 
            // Saisie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.traitementOxfordProgressSpinner);
            this.Controls.Add(this.imgValide);
            this.Controls.Add(this.saisieGroupbox);
            this.Controls.Add(this.prisePhoto);
            this.Controls.Add(this.valide);
            this.Name = "Saisie";
            this.Activated += new System.EventHandler(this.Saisie_Activated);
            this.saisieGroupbox.ResumeLayout(false);
            this.saisieGroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgValide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroButton valide;
        private MetroFramework.Controls.MetroButton prisePhoto;
        private System.Windows.Forms.GroupBox saisieGroupbox;
        private System.Windows.Forms.PictureBox imgValide;
        private System.Windows.Forms.ComboBox cboStatut;
        private MetroFramework.Controls.MetroProgressSpinner traitementOxfordProgressSpinner;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox maPhoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label7;
    }
}

