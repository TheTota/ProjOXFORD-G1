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

namespace ProjetReconFormulaire
{
    public partial class dateNaiss : MetroFramework.Forms.MetroForm
    {
        public dateNaiss()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void valide_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(nom.Text) && string.IsNullOrWhiteSpace(prenom.Text) && string.IsNullOrWhiteSpace(email.Text) && string.IsNullOrWhiteSpace(statut.Text))
            {

                
                erreur.Visible = true;


            }
            if (sexeFemme.Checked==false && sexeHomme.Checked==false)
            {
                erreur.Visible = true;
            }
            else
            {
                string sexe="";
               

                if (sexeFemme.Checked == true)
                {
                    sexe = "femme";
                }
                if (sexeHomme.Checked == true)
                {
                    sexe = "homme";
                }
                //suite du Formulaire
                this.PersistUser(new User(prenom.Text, nom.Text, 00, DateTime.Parse(dateDeNaiss.Text), email.Text, sexe, statut.Text));
            }

        }

        private void prisePhoto_Click(object sender, EventArgs e)
        {
            
                prisePhoto prisephoto = new prisePhoto();
                prisephoto.Show();
                erreur.Visible = false;
            
        }

        private void erreur_Click(object sender, EventArgs e)
        {
        }

        private void PersistUser(User user)
        {
            try
            {
                Random code = new Random();
                int gen = code.Next(1000, 9999);

                string conStr = @"server=localhost;user=root;database=oxford;port=3306;password=''";
                MySqlConnection conn = new MySqlConnection(conStr);
                conn.Open();
                string requete = "insert into user values(@id,@prenom,@nom,@dateDeNaiss,@email,@sexe,@statut,@code)";
                MySqlCommand CmdEmploye = new MySqlCommand(requete, conn);
                CmdEmploye.Parameters.AddWithValue("@id", 0);
                CmdEmploye.Parameters.AddWithValue("@prenom", user.Nom);
                CmdEmploye.Parameters.AddWithValue("@nom", user.Prenom);
                CmdEmploye.Parameters.AddWithValue("@dateDeNaiss", user.DateDeNaissance);
                CmdEmploye.Parameters.AddWithValue("@email", user.Email);
                CmdEmploye.Parameters.AddWithValue("@sexe", user.Sexe);
                CmdEmploye.Parameters.AddWithValue("@statut", user.Statut);
                CmdEmploye.Parameters.AddWithValue("@code", gen);
                
                CmdEmploye.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Vous avez été enregistré avec succès \n Votre Code d'accès secret est : " + gen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
