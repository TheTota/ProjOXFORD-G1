using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace ProjetReconFormulaire
{
    public partial class VuePhoto : MetroForm
    {
        /// <summary>
        /// Constructeur de la classe Vuephoto
        /// </summary>
        public VuePhoto()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evenement permettant de fermer le formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void metroButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
