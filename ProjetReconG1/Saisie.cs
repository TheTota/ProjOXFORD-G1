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
            else
            {
                //suite du Formulaire
                this.PersistUser(new User("Léo", "ESPEU", 20, new DateTime(2017, 11, 16), "btssioleo.espeu@gmail.com", "homme", "étudiant"));
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
                string conStr = @"server=localhost;user=root;database=user;port=3306;password=''";
                MySqlConnection conn = new MySqlConnection(conStr);
                conn.Open();
                string requete = "insert into user values(@nom,@prenom,@age,@date,@mail,@sexe,@statut)";
                MySqlCommand CmdEmploye = new MySqlCommand(requete, conn);
                CmdEmploye.Parameters.AddWithValue("@nom", user.Nom);
                CmdEmploye.Parameters.AddWithValue("@prenom", user.Prenom);
                CmdEmploye.Parameters.AddWithValue("@age", user.Age);
                CmdEmploye.Parameters.AddWithValue("@date", user.DateDeNaissance);
                CmdEmploye.Parameters.AddWithValue("@mail", user.Email);
                CmdEmploye.Parameters.AddWithValue("@sexe", user.Sexe);
                CmdEmploye.Parameters.AddWithValue("@statut", user.Statut);
                CmdEmploye.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Enregistré");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
