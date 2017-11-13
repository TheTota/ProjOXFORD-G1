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
        List<WebCameraId> listCams;

        // Lieu où sera sauvegardée la photo
        string savePath = @"D:\Users\ludo\Documents\";

        /// <summary>
        /// Constructeur de la classe PrisePhoto.
        /// </summary>
        public PrisePhoto()
        {
            InitializeComponent();
            
            // Récupération des caméras 
            listCams = webcam.GetVideoCaptureDevices().ToList<WebCameraId>();

            // Démarre la capture 
            webcam.StartCapture(listCams[0]);
        }

        /// <summary>
        /// Prise de photo lors du clic sur le bouton "Prendre la photo".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoto_onclick(object sender, EventArgs e)
        {
            // Si la webcam est bien active..
            if (webcam.IsCapturing)
            {
                // On détermine le chemin complet final pointant vers la photo
                string photo = savePath + "oxfoto" + GenCode() + ".jpg";

                // On prend une photo qu'on enregistre au path donné
                webcam.GetCurrentImage().Save(photo, ImageFormat.Jpeg);

                // On confirme au form de saisie que la photo a été prise
                Saisie.prisEnPhoto = true;
                Saisie.photo = photo;
                
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
            webcam.StopCapture();
        }

        /// <summary>
        /// Méthode générant un code à 4 chiffres. 
        /// Solution PROVISOIRE pour le nom des photos à enregistrer.
        /// </summary>
        /// <returns></returns>
        private int GenCode()
        {
            // Génération aléatoire du code/mdp de l'utilisateur
            Random generator = new Random();
            return generator.Next(1000, 9999);
        }
    }
}
