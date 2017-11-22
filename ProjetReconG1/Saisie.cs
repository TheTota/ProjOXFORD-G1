﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using projetOxford;
using MetroFramework.Forms;
using WebEye.Controls.WinForms.WebCameraControl;


namespace projetOxf
{

    /// <summary>
    /// Formulaire permettant l'inscription basique d'un nouvel utilisateur dans la base.
    /// Ce formulaire ne s'occupe pas de la prise de photo.
    /// </summary>
    public partial class Saisie : MetroForm
    {
        private User monUser;
        public static bool prisEnPhoto = false;
        public static string photo = "";
        public static string faceIdPersistent;
        private bool vraimail;
        private Dictionary<int, String> dicoTypes;

        /// <summary>
        /// Constructeur de la classe Saisie
        /// </summary>
        public Saisie()
        {
            InitializeComponent();

            // Récupération des types en BDD
            this.dicoTypes = TraitementsBdd.GetTypesUsers();
            // Création d'une liste de chaines à partir du dico de types récupéré
            foreach (var type in this.dicoTypes)
            {
                // Attribution du contenu de la liste des noms des types à la comboBox
                cboStatut.Items.Add(type.Value);
            }
            cboStatut.SelectedItem = cboStatut.Items[0];
        }
        //Fonction pour vérifier si une email est valide
        //Retourne: true si elle est valide
        //Retourne: false si elle n'est pas valide
        bool EmailEstBonne(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Correspond au clic sur le bouton "Valider".
        /// Procède à l'inscription d'un utilisateur en créant un enregistrement dans 
        /// la base de données à partir des valeurs saisies dans le formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void valide_Click(object sender, EventArgs e)
        {
            try
            {
                // Controles sur les champs du formulaire
                if (!EmailEstBonne(email.Text))
                {
                    MessageBox.Show("Veuillez Saisir une email valide", "Erreur - Email Invalide", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    vraimail = false;
                }
                else
                {
                    vraimail = true;
                }

                if (string.IsNullOrWhiteSpace(nom.Text) || string.IsNullOrWhiteSpace(prenom.Text) || string.IsNullOrWhiteSpace(email.Text))
                {
                    erreur.Visible = true;
                }
                else
                {
                    erreur.Visible = false;
                    if (!sexeFemme.Checked && !sexeHomme.Checked)
                    {
                        erreur.Visible = true;
                    }
                    else
                    {
                        erreur.Visible = false;

                        // Si on a pas d'erreur, on détermine le sexe de la personne
                        string sexe;
                        if (sexeFemme.Checked)
                            sexe = "femme";
                        else
                            sexe = "homme";

                        // On détermine le type d'utilisateur
                        int typeKey = cboStatut.SelectedIndex + 1;

                        // Création d'un objet utilisateur qui sera persisté plus tard dans la base
                        monUser = new User(prenom.Text, nom.Text, DateTime.Parse(dateDeNaiss.Text), email.Text, sexe, typeKey, GenCode()); // TODO: déterminer le int du statud en fct° de l'input

                        if (erreur.Visible == false && vraimail == true)
                        {
                            // Persistance (insertion) de l'utilisateur dans la base
                            this.PersistUser(monUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Correspond au clic sur le bouton "Prendre une photo".
        /// Ouvre le formulaire de prise de photo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prisePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciation du formulaire et ouverture
                PrisePhoto formPrisePhoto = new PrisePhoto();
                formPrisePhoto.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fonction permettant de persister un utilisateur passé en paramètres dans la base 
        /// de données.
        /// </summary>
        /// <param name="user"></param>
        private void PersistUser(User user)
        {
            //Verifie que l'utilisateur a bien pris et enregistré sa photo            
            if (!prisEnPhoto)
            {
                throw new Exception("Photo non enregistrée.\nVeuillez vous prendre en photo.");
            }

            // Création de la requête d'insertion du nouvel utilisateur dans la base (le mot de passe n'est pas pris en compte pour le moment et le status est prédefinie dans la requete)
            TraitementsBdd.InsertUser(user);
            //Enregistrement de la photo dans la bdd
            TraitementsBdd.InsertPhoto(photo, faceIdPersistent);

            // Affichage du code généré 
            MessageBox.Show("Vous avez été enregistré avec succès !\nVotre code d'accès secret est : " + user.Code, "Succès de l'inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Remise à 0 du formulaire
            ResetForm();
        }

        /// <summary>
        /// Méthode générant un code à 4 chiffres.
        /// </summary>
        /// <returns></returns>
        private int GenCode()
        {
            // Génération aléatoire du code/mdp de l'utilisateur
            Random generator = new Random();
            return generator.Next(1000, 9999);
        }

        /// <summary>
        /// Méthode permettant de remettre à 0 le formulaire.
        /// </summary>
        private void ResetForm()
        {
            prisEnPhoto = false;
            prenom.Text = "";
            nom.Text = "";
            dateDeNaiss.Text = "01/01/2000";
            sexeFemme.Checked = false;
            sexeHomme.Checked = false;
            email.Text = "";
            imgValide.Visible = false;
        }

        /// <summary>
        /// Evenement qui se déclenche lorsque le formulaire prend le focus.
        /// Servira à afficher la validation de la prise de photo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Saisie_Activated(object sender, EventArgs e)
        {
            if (prisEnPhoto)
            {
                imgValide.Visible = true;
                this.prisePhoto.Enabled = false;
            }
        }
    }
}