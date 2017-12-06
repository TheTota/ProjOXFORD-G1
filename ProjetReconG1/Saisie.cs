// <copyright file="Saisie.cs" company="SIO">
// Copyright (c) SIO. All rights reserved.
// </copyright>

namespace ProjetOxf
{
    using System;
    using System.Drawing;
    using System.Net.Mail;
    using System.Windows.Forms;
    using MetroFramework;
    using MetroFramework.Forms;
    using Newtonsoft.Json.Linq;
    using ProjetOxford;

    /// <summary>
    /// Formulaire permettant l'inscription basique d'un nouvel utilisateur dans la base.
    /// Ce formulaire ne s'occupe pas de la prise de photo.
    /// </summary>
    public partial class Saisie : MetroForm
    {
        // Variables statiques qui permettront la communication avec le formulaire de prise de photo
        private static bool prisEnPhoto = false;
        private static string photo = string.Empty;
        private static string faceIdPersistent;
        private static string faceIdTemp;

        /// <summary>
        /// Utilisateur qui sera créé à partir des champs remplis du formulaire.
        /// </summary>
        private User monUser;

        /// <summary>
        /// Booléen indiquant si le traitement oxford est terminé ou non.
        /// </summary>
        private bool traitementTermine;

        /// <summary>
        /// Initialise une nouvelle instande de la classe <see cref="Saisie"/>.
        /// </summary>
        public Saisie()
        {
            this.InitializeComponent();

            // Récupération des types en BDD
            BindingSource bindingSource1 = new BindingSource
            {
                DataSource = TraitementsBdd.GetTypesUsers()
            };

            // Population de la combobox des types d'utilisateurs
            this.cboStatut.DataSource = bindingSource1.DataSource;
        }

        /// <summary>
        /// Obtient ou modifie l'attribut photo.
        /// </summary>
        public static string Photo { get => photo; set => photo = value; }

        /// <summary>
        /// Obtient ou modifie l'attribut prisEnPhoto.
        /// </summary>
        public static bool PrisEnPhoto { get => prisEnPhoto; set => prisEnPhoto = value; }

        /// <summary>
        /// Obtient ou modifie l'attribut faceIdPersistent.
        /// </summary>
        public static string FaceIdPersistent { get => faceIdPersistent; set => faceIdPersistent = value; }

        /// <summary>
        /// Obtient ou modifie l'attribut faceIdTemp.
        /// </summary>
        public static string FaceIdTemp { get => faceIdTemp; set => faceIdTemp = value; }

        /// <summary>
        /// Correspond au clic sur le bouton "Valider".
        /// Procède à l'inscription d'un utilisateur en créant un enregistrement dans
        /// la base de données à partir des valeurs saisies dans le formulaire.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void Valide_Click(object sender, EventArgs e)
        {
            try
            {
                // Si le formulaire est bien rempli, on procède à l'inscription de l'utilisateur
                if (this.FormulaireEstBienRempli())
                {
                    // On bloque une éventuelle "revalidation" de l'inscription pdt le traitement
                    this.valide.Enabled = false;
                    this.traitementOxfordProgressSpinner.Visible = true;

                    // Création d'un objet utilisateur qui sera persisté plus tard dans la base
                    this.monUser = new User(this.prenom.Text, this.nom.Text, DateTime.Parse(this.dateDeNaiss.Text), this.email.Text, this.GetSexe(), this.cboStatut.SelectedIndex + 1, this.GenCode());

                    // Envoi du mail de confirmation de l'inscription
                    this.SendMail(this.email.Text, this.prenom.Text, this.nom.Text, photo);

                    // Persistance de l'utilisateur dans notre BDD et dans la BDD MS
                    this.PersistUser(this.monUser);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fonction déterminant le sexe choisi par l'utilisateur.
        /// </summary>
        /// <returns>Retourne 'H' si c'est un homme, 'F' si c'est une femme.</returns>
        private string GetSexe()
        {
            string sexe;
            if (this.sexeFemme.Checked)
            {
                sexe = "F";
            }
            else
            {
                sexe = "H";
            }

            return sexe;
        }

        /// <summary>
        /// Fonction permettant de tester si le formulaire a été rempli correctement.
        /// </summary>
        /// <returns>Retourne True si le formulaire a été bien rempli, et false si ce n'est pas le cas.</returns>
        private bool FormulaireEstBienRempli()
        {
            // On test si une photo a été prise
            if (prisEnPhoto)
            {
                // On test si tous les champs du formulaire ont été remplis
                if (!string.IsNullOrWhiteSpace(this.nom.Text) && !string.IsNullOrWhiteSpace(this.prenom.Text) && !string.IsNullOrWhiteSpace(this.email.Text) && (this.sexeFemme.Checked || this.sexeHomme.Checked))
                {
                    // On test si l'email est valide
                    if (System.Text.RegularExpressions.Regex.IsMatch(this.email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        // On test si le prénom est valide
                        if (System.Text.RegularExpressions.Regex.IsMatch(this.prenom.Text, "^[a-zA-Z]"))
                        {
                            // On test si le nom est valide
                            if (System.Text.RegularExpressions.Regex.IsMatch(this.nom.Text, "^[a-zA-Z]"))
                            {
                                return true;
                            }
                            else
                            {
                                throw new Exception("Veuillez saisir un nom ne comportant que des lettres.");
                            }
                        }
                        else
                        {
                            throw new Exception("Veuillez saisir un prénom ne comportant que des lettres.");
                        }
                    }
                    else
                    {
                        throw new Exception("Veuillez saisir une adresse email valide.");
                    }
                }
                else
                {
                    throw new Exception("Veuillez remplir tous les champs du formulaire.");
                }
            }
            else
            {
                throw new Exception("Veuillez vous prendre en photo.");
            }
        }

        /// <summary>
        /// Correspond au clic sur le bouton "Prendre une photo".
        /// Ouvre le formulaire de prise de photo.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void PrisePhoto_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciation du formulaire et ouverture
                PrisePhoto formPrisePhoto = new PrisePhoto();
                formPrisePhoto.ShowDialog();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fonction permettant de persister un utilisateur passé en paramètres dans les bases de données.
        /// </summary>
        /// <param name="user">Utilisateur à persister dans la BDD MS.</param>
        private void PersistUser(User user)
        {
            // Inscription de l'utilisateur dans la BDD MS
            this.traitementTermine = false;
            this.timer1.Enabled = true;
            this.InscrireDansBddMS();
        }

        /// <summary>
        /// Méthode permettant d'inscrire un utilisateur dans la BDD de Microsoft à partir d'un faceId temporaire
        /// </summary>
        private async void InscrireDansBddMS()
        {
            // Inscription du visage dans la liste de faceid oxford sur le serveur MS
            JObject jObjectPersistentFaceId = await ReconnaissanceFaciale.FaceRecFaceAddListAsync(photo);

            // Récupération du faceid persistant qui sera associé à l'utilisateur
            faceIdPersistent = jObjectPersistentFaceId.GetValue("persistedFaceId").ToString();

            // On signale que le traitement est terminé
            this.traitementTermine = true;
        }

        /// <summary>
        /// Méthode générant un code à 4 chiffres.
        /// </summary>
        /// <returns>Le code généré.</returns>
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
            this.prenom.Text = string.Empty;
            this.nom.Text = string.Empty;
            this.dateDeNaiss.Text = "01/01/2000";
            this.sexeFemme.Checked = false;
            this.sexeHomme.Checked = false;
            this.email.Text = string.Empty;
            this.imgValide.Visible = false;
            this.cboStatut.SelectedIndex = 0;
            this.prisePhoto.Enabled = true;
            this.valide.Enabled = true;
            this.timer1.Enabled = false;
            this.traitementOxfordProgressSpinner.Visible = false;
            this.maPhoto.Image = null;
        }

        /// <summary>
        /// Evenement qui se déclenche lorsque le formulaire prend le focus.
        /// Servira à afficher la validation de la prise de photo.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void Saisie_Activated(object sender, EventArgs e)
        {
            // Si une photo valide a été prise...
            if (prisEnPhoto)
            {
                // ... alors on affiche un icone indiquant le succès de la prise de photo
                this.imgValide.Visible = true;

                // Et on désactive la prise d'une nouvelle photo, et on affiche la photo prise
                this.prisePhoto.Enabled = false;
                this.maPhoto.Image = Image.FromFile(photo);
            }
        }

        /// <summary>
        /// Chaque 100ms et quand le timer est activé, on test si le traitement async est terminé.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            // L'ajout du faceid persistant dans la BDD est terminé
            if (this.traitementTermine)
            {
                // Remise à 0 du formulaire
                this.ResetForm();

                // Enregistrement de la photo dans la bdd
                TraitementsBdd.InsertPhoto(photo, faceIdPersistent);
                TraitementsBdd.InsertUser(this.monUser, TraitementsBdd.GetMaxPhotos());

                // Affichage du code généré
                MetroMessageBox.Show(this, "Vous avez été enregistré avec succès !\nVotre code d'accès secret est : " + this.monUser.Code, "Succès de l'inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Envoi du mail.
        /// </summary>
        /// <param name="mail">Mail destinataire</param>
        /// <param name="prenom">Prénom du destinataire</param>
        /// <param name="nom">Nom du destinataire</param>
        /// <param name="photopath">Chemin de la photo</param>
        private void SendMail(string mail, string prenom, string nom, string photopath)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();

                message.From = new MailAddress("bts-sio@lyc-bonaparte.fr");
                message.To.Add(new MailAddress(mail));
                message.CC.Add("bts-sio@lyc-bonaparte.fr");
                message.Subject = "Inscription";
                Attachment photo = new Attachment(photopath);
                message.Body = "Bonjour " + prenom + " " + nom + "," +
                    "\n" +
                    "Merci d'être passé au stand du BTS SIO." +
                    "\n" +
                    "\n" + "Ce message fait suite à la réussite de votre inscription à travers notre application" +
                    "\n" + "présentée au forum du numérique le Jeudi 07 decembre 2017." +
                    "\n" +
                    "\n" + "Vous pourrez rencontrer les étudiants du BTS SIO aux dates suivantes :" +
                    "\n" + "- Salon du lycéen et de l'étudiant (Zénith Omega) : Samedi 13 Janvier 2018" +
                    "\n" + "- Journée portes ouvertes (Lycée Bonaparte) : Mercredi 7 février 2018 13h-16h45" +
                    "\n" + "- Journée portes ouvertes (Lycée Bonaparte) : Samedi 24 Mars 2018 9h-13h" + "\n" +
                    "\n" + "Pour plus d'informations sur le BTS vous pouvez vous rendre sur notre site web à l'adresse suivante : http://bit.ly/jnum2btssio" +
                    "\n" +
                    "\n" +
                    "Bien à vous, les étudiants et professeurs du BTS SIO SLAM.\n" +
                    "\n" +
                    "-------------------------------------------------------------------------------------------------\n" +
                    "Ceci est un message automatique.\n" +
                    "Merci de ne pas y répondre.\n";
                message.Attachments.Add(photo);

                smtp.Port = 587;
                smtp.Host = "SSL0.OVH.NET";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("bts-sio@lyc-bonaparte.fr", "M@il0xford2017");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
