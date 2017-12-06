using System;
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
using Newtonsoft.Json.Linq;
using System.Net.Mail;
using MetroFramework;

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
        public static string faceIdTemp;
        private bool vraiMail;
        private bool traitementTermine;
        private Dictionary<int, String> dicoTypes;

        /// <summary>
        /// Constructeur de la classe Saisie
        /// </summary>
        public Saisie()
        {
            InitializeComponent();
            this.Show();

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
                if (prisEnPhoto)
                {
                    // Controles sur les champs du formulaire
                    if (!EmailEstBonne(email.Text))
                    {
                        vraiMail = false;
                        throw new Exception("Veuillez saisir une addresse email valide.");
                    }
                    else
                    {
                        vraiMail = true;
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
                                sexe = "F";
                            else
                                sexe = "H";

                            // On détermine le type d'utilisateur
                            int typeKey = cboStatut.SelectedIndex + 1;

                            // Création d'un objet utilisateur qui sera persisté plus tard dans la base
                            monUser = new User(prenom.Text, nom.Text, DateTime.Parse(dateDeNaiss.Text), email.Text, sexe, typeKey, GenCode()); // TODO: déterminer le int du statud en fct° de l'input
                            SendMail(email.Text, prenom.Text, nom.Text, photo);

                            if (erreur.Visible == false && vraiMail == true)
                            {
                                this.valide.Enabled = false;
                                this.metroProgressSpinner1.Visible = true;
                                // Persistance (insertion) de l'utilisateur dans la base
                                this.PersistUser(monUser);
                            }
                        }
                    }
                }
                else
                {
                    throw new Exception("Veuillez vous prendre en photo.");
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Fonction permettant de persister un utilisateur passé en paramètres dans la base 
        /// de données.
        /// </summary>
        /// <param name="user"></param>
        private void PersistUser(User user)
        {
            // Inscription de l'utilisateur dans la BDD MS
            this.traitementTermine = false;
            this.timer1.Enabled = true;
            InscrireDansBddMS(faceIdTemp);
        }

        /// <summary>
        /// Méthode permettant d'inscrire un utilisateur dans la BDD de Microsoft à partir d'un faceId temporaire
        /// </summary>
        /// <param name="faceIdTemp"></param>
        private async void InscrireDansBddMS(string faceIdTemp)
        {
            JObject jObjectPersistentFaceId = await ReconnaissanceFaciale.FaceRecFaceAddListAsync(photo);
            faceIdPersistent = jObjectPersistentFaceId.GetValue("persistedFaceId").ToString();
            this.traitementTermine = true;
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
            cboStatut.SelectedIndex = 0;
            prisePhoto.Enabled = true;
            valide.Enabled = true;
            timer1.Enabled = false;
            this.metroProgressSpinner1.Visible = false;
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
                this.maPhoto.Image = Image.FromFile(photo);
            }
        }

        /// <summary>
        /// Chaque 100ms et quand le timer est activé, on test si le traitement async est terminé.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            // L'ajout du faceid persistant dans la BDD est terminé
            if (this.traitementTermine)
            {
                // Remise à 0 du formulaire
                ResetForm();

                //Enregistrement de la photo dans la bdd
                TraitementsBdd.InsertPhoto(photo, faceIdPersistent);
                TraitementsBdd.InsertUser(monUser, TraitementsBdd.GetMaxPhotos());

                // Affichage du code généré 
                MetroMessageBox.Show(this, "Vous avez été enregistré avec succès !\nVotre code d'accès secret est : " + monUser.Code, "Succès de l'inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Envoi du mail
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

                message.From = new MailAddress("ultramegabidon@gmail.com");
                message.To.Add(new MailAddress(mail));
                message.Subject = "Inscription";
                Attachment Photo = new Attachment(photopath);
                message.Body = "Bonjour, " + nom + " " + prenom + "" +
                    "\n" +
                    "Merci d'être passé au stand du BTS SIO." +
                    "\n" +
                    "\n" + "Ce message fait suite à la réussite de votre inscription à travers notre application." +
                    "\n" +
                    "Pour plus d'informations sur le BTS vous pouvez vous rendre sur notre site web à l'adresse suivante : https://bts-sio.lyc-bonaparte.fr" +
                    "\n" +
                    "Bien à vous, l'équipe du BTS SIO SLAM.\n" +
                    "\n" +
                    "-------------------------------------------------------------------------------------------------\n" +
                    "Ceci est un message automatique.\n" +
                    "Merci de ne pas y répondre.\n";
                message.Attachments.Add(Photo);

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential("ultramegabidon@gmail.com", "Megabidon83");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch(Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

    }
}
