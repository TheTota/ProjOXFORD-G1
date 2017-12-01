using System;
using System.Drawing;
using System.Windows.Forms;
using projetOxford;
using MetroFramework.Forms;
using Newtonsoft.Json.Linq;
using System.Net.Mail;

namespace projetOxf
{

    /// <summary>
    /// Formulaire permettant l'inscription basique d'un nouvel utilisateur dans la base.
    /// Ce formulaire ne s'occupe pas de la prise de photo.
    /// </summary>
    public partial class Saisie : MetroForm
    {
        /// <summary>
        /// Utilisateur qui sera créé à partir des champs remplis du formulaire
        /// </summary>
        private User monUser;

        public static bool prisEnPhoto = false;
        public static string photo = "";
        public static string faceIdPersistent;
        public static string faceIdTemp;

        private bool vraiMail;
        private bool traitementTermine;

        /// <summary>
        /// Constructeur de la classe Saisie
        /// </summary>
        public Saisie()
        {
            InitializeComponent();

            // Récupération des types en BDD
            BindingSource bindingSource1 = new BindingSource
            {
                DataSource = TraitementsBdd.GetTypesUsers()
            };

            // Population de la combobox des types d'utilisateurs
            cboStatut.DataSource = bindingSource1.DataSource;
        }

        /// <summary>
        /// Fonction permettant de vérifier si une adresse email est valide.
        /// </summary>
        /// <param name="email">Adresse email à tester.</param>
        /// <returns>Vrai si l'email est valide, faux si il ne l'est pas.</returns>
        bool EmailValide(string email)
        {
            try
            {
                var addr = new MailAddress(email);
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
                // Si le formulaire est bien rempli, on procède à l'inscription de l'utilisateur
                if (FormulaireEstBienRempli())
                {
                    // On bloque une éventuelle "revalidation" de l'inscription pdt le traitement
                    this.valide.Enabled = false;
                    this.metroProgressSpinner1.Visible = true;

                    // Création d'un objet utilisateur qui sera persisté plus tard dans la base
                    monUser = new User(prenom.Text, nom.Text, DateTime.Parse(dateDeNaiss.Text), email.Text, GetSexe(), cboStatut.SelectedIndex + 1, GenCode());

                    // Envoi du mail de confirmation de l'inscription
                    SendMail(email.Text, prenom.Text, nom.Text, photo);

                    // Persistance de l'utilisateur dans notre BDD et dans la BDD MS
                    this.PersistUser(monUser);
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
            if (sexeFemme.Checked)
                sexe = "F";
            else
                sexe = "H";

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
                if (!string.IsNullOrWhiteSpace(nom.Text) && !string.IsNullOrWhiteSpace(prenom.Text) && !string.IsNullOrWhiteSpace(email.Text) && (sexeFemme.Checked || sexeHomme.Checked))
                {
                    // On test si l'email est valide
                    if (EmailValide(this.email.Text))
                    {
                        return true;
                    }
                    else
                    {
                        throw new Exception("Veuillez entrer une adresse email valide.");
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
            metroProgressSpinner1.Visible = false;
            maPhoto.Image = null;
        }

        /// <summary>
        /// Evenement qui se déclenche lorsque le formulaire prend le focus.
        /// Servira à afficher la validation de la prise de photo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Saisie_Activated(object sender, EventArgs e)
        {
            // Si une photo valide a été prise...
            if (prisEnPhoto)
            {
                // ... alors on affiche un icone indiquant le succès de la prise de photo
                imgValide.Visible = true;

                // Et on affiche désactive la prise d'une nouvelle photo, et on affiche la photo prise
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
                MessageBox.Show("Vous avez été enregistré avec succès !\nVotre code d'accès secret est : " + monUser.Code, "Succès de l'inscription", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
