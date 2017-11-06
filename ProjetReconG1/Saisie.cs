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

namespace ProjetReconFormulaire
{
    /// <summary>
    /// Formulaire permettant l'inscription basique d'un nouvel utilisateur dans la base.
    /// Ce formulaire ne s'occupe pas de la prise de photo.
    /// </summary>
    public partial class Saisie : MetroForm
    {
        private User monUser;
        private bool prisEnPhoto = false;

        /// <summary>
        /// Constructeur de la classe Saisie
        /// </summary>
        public Saisie()
        {
            InitializeComponent();
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
                if (string.IsNullOrWhiteSpace(nom.Text) || string.IsNullOrWhiteSpace(prenom.Text) || string.IsNullOrWhiteSpace(email.Text) || string.IsNullOrWhiteSpace(statut.Text))
                {
                    erreur.Visible = true;
                }
                else
                {
                    erreur.Visible = false;
                    if (sexeFemme.Checked == false && sexeHomme.Checked == false)
                    {
                        erreur.Visible = true;
                    }
                    else
                    {
                        erreur.Visible = false;
                        // Si on a pas d'erreur, on détermine le sexe de la personne
                        string sexe;
                        if (sexeFemme.Checked == true)
                        {
                            sexe = "femme";
                        }
                        else
                        {
                            sexe = "homme";
                        }

                        // Inscription de l'utilisateur dans la base à partir des valeurs des champs du formulaire si il n'y a pas d'erreurs.
                        monUser = new User(prenom.Text, nom.Text, 00, DateTime.Parse(dateDeNaiss.Text), email.Text, sexe, statut.Text);
                        if (erreur.Visible == false)
                        {
                            this.PersistUser(monUser);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                //Valeur d'adresse et de la photo
                String photo = "adresse photo";

                //Vérifie que l'utilisateur n'a pas déja été pris en photos (la valeur sera mis à true quand la photo sera enregistré)
                if (prisEnPhoto==true)
                {
                    throw new Exception("L'utilisateur s'est déja pris en photos");
                }

                //Formulaire à supprimmer dés que la webcam sera operationnelle
                //PrisePhoto prisephoto = new PrisePhoto();
                //prisephoto.Show();

                // Connexion à la base de données
                string conStr = @"server=localhost;user=root;database=oxford;port=3306;password='root' ";
                MySqlConnection conn = new MySqlConnection(conStr);
                conn.Open();
                erreur.Visible = false;
                
                //Si l'utilisateur a pris une photo lors de l'utilisation précédente mais n'est pas allé au bout de l'opération ,celle-ci est supprimé de la bdd
                string requete = "delete from photos where id>(select count(*)from users)";
                MySqlCommand CmdEmploye = new MySqlCommand(requete, conn);
                CmdEmploye.ExecuteNonQuery();
                //Ouverture de la webcam de l'ordinateur (à condition quelle ensoit equipé) ,prise de la photo et enregistrement de celle-ci


                //Enregistrement de la photo dans la bdd et fermeture de la connexion
                string maRequete = "INSERT INTO photos(`id`,`date`,`value`) VALUES((select count(*)+1 from users),@date,@adresse)";
                MySqlCommand CmdEmploye2 = new MySqlCommand(maRequete, conn);
                CmdEmploye2.Parameters.AddWithValue("@date", DateTime.Now);
                CmdEmploye2.Parameters.AddWithValue("@adresse", photo);
                CmdEmploye2.ExecuteNonQuery();
                conn.Close();

                // Affichage du code généré et prend en compte le fait que l'utilisateur a pris une photo
                MessageBox.Show("Votre photo a été enregistré avec succès ");
                prisEnPhoto = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Fonction permettant de persister un utilisateur passé en paramètres dans la base 
        /// de données.
        /// </summary>
        /// <param name="user"></param>
        private void PersistUser(User user)
        {
            // Génération aléatoire du code/mdp de l'utilisateur
            Random generator = new Random();
            int code = generator.Next(1000, 9999);

            // Connexion à la base de données
            string conStr = @"server=localhost;user=root;database=oxford;port=3306;password='root' ";
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();

            //Verifie que l'utilisateur a bien pris et enregistré sa photo
            
            if (prisEnPhoto == false)
            {
                conn.Close();
                throw new Exception("Photo non enregistré");
            }

            // Création de la requête d'insertion du nouvel utilisateur dans la base (le mot de passe n'est pas pris en compte pour le moment et le status est prédefinie dans la requete)
            string requete = "insert into users(prenom,nom,birth,email,sexe,status,photo,type) values(@prenom,@nom,@dateDeNaiss,@email,@sexe,1,(select count(*) from photos),1)";
            MySqlCommand CmdEmploye = new MySqlCommand(requete, conn);
            CmdEmploye.Parameters.AddWithValue("@prenom", user.Nom);
            CmdEmploye.Parameters.AddWithValue("@nom", user.Prenom);
            CmdEmploye.Parameters.AddWithValue("@dateDeNaiss", user.DateDeNaissance);
            CmdEmploye.Parameters.AddWithValue("@email", user.Email);
            CmdEmploye.Parameters.AddWithValue("@sexe", user.Sexe);
            CmdEmploye.Parameters.AddWithValue("@code", code);

            // Exécution de la requête et fermeture de la connexion
            CmdEmploye.ExecuteNonQuery();
            conn.Close();

            // Affichage du code généré 
            MessageBox.Show("Vous avez été enregistré avec succès \n Votre Code d'accès secret est : " + code);
            
            //Remise à 0 du formulaire
            prisEnPhoto = false;
            prenom.Text = "";
            nom.Text = "";
            dateDeNaiss.Text = "";
            statut.Text = "";
            email.Text = "";
        }
    }
}