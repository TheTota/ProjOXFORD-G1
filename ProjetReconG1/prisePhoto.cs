using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebEye.Controls.WinForms.WebCameraControl;

namespace ProjetReconFormulaire
{
    /// <summary>
    /// Formulaire de test.
    /// Le vrai formulaire permettra de prendre une photo à partir d'une caméra
    /// connectée à l'ordinateur.
    /// </summary>
    public partial class PrisePhoto : MetroFramework.Forms.MetroForm
    {
        // Webeye
        WebCameraControl webcamControl = new WebCameraControl();
        List<WebCameraId> listCams;

        public PrisePhoto()
        {
            InitializeComponent();
            
            // Récupération des caméras 
            listCams = webcamControl.GetVideoCaptureDevices().ToList<WebCameraId>();

            // Démarre la capture 
            webcamControl.StartCapture(listCams[0]);
        }

        /// <summary>
        /// Prise de photo lors du clic sur le bouton "Prendre la photo".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoto_onclick(object sender, EventArgs e)
        {
            // Si la webcam est bien active..
            if (webcamControl.IsCapturing)
            {
                // On prend une photo qu'on enregistre au path donné
                webcamControl.GetCurrentImage().Save(@"C:\Users\thoma\OneDrive\Documents\Photos Oxford\test.jpg", ImageFormat.Jpeg);

                // Fermeture du formulaire
                this.Close();
            }
        }

        /// <summary>
        /// Méthode se déclanchant à la fermeture du formulaire.
        /// Stop la capture vidéo (affichage en live à l'écran).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrisePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop la capture
            webcamControl.StopCapture();
        }
    }
}
