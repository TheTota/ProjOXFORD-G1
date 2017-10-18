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

namespace ProjetReconFormulaire
{
    /// <summary>
    /// Formulaire permettant l'inscription basique d'un nouvel utilisateur dans la base.
    /// Ce formulaire ne s'occupe pas de la prise de photo.
    /// </summary>
    public partial class Saisie : MetroForm
    {
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
                if (string.IsNullOrWhiteSpace(nom.Text) && string.IsNullOrWhiteSpace(prenom.Text) && string.IsNullOrWhiteSpace(email.Text) && string.IsNullOrWhiteSpace(statut.Text))
                {
                    erreur.Visible = true;
                }
                if (sexeFemme.Checked == false && sexeHomme.Checked == false)
                {
                    erreur.Visible = true;
                }
                else
                {
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

                    // Inscription de l'utilisateur dans la base à partir des valeurs des champs du formulaire.
                    this.PersistUser(new User(prenom.Text, nom.Text, 00, DateTime.Parse(dateDeNaiss.Text), email.Text, sexe, statut.Text));
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
            PrisePhoto prisephoto = new PrisePhoto();
            prisephoto.Show();
            erreur.Visible = false;
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
            string conStr = @"server=localhost;user=root;database=oxford;port=3306;password=''";
            MySqlConnection conn = new MySqlConnection(conStr);
            conn.Open();

            // Création de la requête d'insertion du nouvel utilisateur dans la base
            string requete = "insert into user values(@id,@prenom,@nom,@dateDeNaiss,@email,@sexe,@statut,@code)";
            MySqlCommand CmdEmploye = new MySqlCommand(requete, conn);
            CmdEmploye.Parameters.AddWithValue("@id", 0);
            CmdEmploye.Parameters.AddWithValue("@prenom", user.Nom);
            CmdEmploye.Parameters.AddWithValue("@nom", user.Prenom);
            CmdEmploye.Parameters.AddWithValue("@dateDeNaiss", user.DateDeNaissance);
            CmdEmploye.Parameters.AddWithValue("@email", user.Email);
            CmdEmploye.Parameters.AddWithValue("@sexe", user.Sexe);
            CmdEmploye.Parameters.AddWithValue("@statut", user.Statut);
            CmdEmploye.Parameters.AddWithValue("@code", code);

            // Exécution de la requête et fermeture de la connexion
            CmdEmploye.ExecuteNonQuery();
            conn.Close();

            // Affichage du code généré
            MessageBox.Show("Vous avez été enregistré avec succès \n Votre Code d'accès secret est : " + code);
        }
    }
}