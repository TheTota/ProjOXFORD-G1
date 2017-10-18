using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
