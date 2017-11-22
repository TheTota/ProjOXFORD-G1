﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using projetOxford;
using WebEye.Controls.WinForms.WebCameraControl;
using Newtonsoft.Json.Linq;

namespace projetOxf
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
        // ATTENTION : le chemin vers le bureau par exemple sera:
        //C:\Users\LENOMDETONPC\Desktop\tuMetLeNomDeLimage
        //ce qui sera après le dernier slash c'est le NOMDU FICHIER
        //ici on veut que l'image s'appelle oxfoto8454.jpg (8454 sera le mdp généré pas la peine de le mettre)
        //donc le chemin sera: C:\Users\LENOMDETONPC\Desktop\oxfoto
        string savePath = @"C:\Users\thoma\Desktop\oxfoto";

        string photo;
        bool traitementTermine;

        /// <summary>
        /// Constructeur de la classe PrisePhoto.
        /// </summary>
        public PrisePhoto()
        {
            InitializeComponent();

            // Récupération des caméras 
            listCams = webcam.GetVideoCaptureDevices().ToList();

            // Démarre la capture 
            webcam.StartCapture(listCams[0]);

            this.traitementTermine = false;
        }

        /// <summary>
        /// Prise de photo lors du clic sur le bouton "Prendre la photo".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPhoto_onclick(object sender, EventArgs e)
        {
            try
            {
                // Si la webcam est bien active..
                if (webcam.IsCapturing)
                {
                    // On détermine le chemin complet final pointant vers la photo
                    this.photo = savePath + GenCode() + ".jpg";

                    // On prend une photo qu'on enregistre au path donné
                    webcam.GetCurrentImage().Save(this.photo, ImageFormat.Jpeg);

                    // Traitement de l'image avec la bdd oxford
                    this.timerTraitement.Enabled = true;
                    this.webcam.Visible = false;
                    this.metroProgressSpinner1.Visible = true;
                    TraiterImage(this.photo);
                    //TraiterImage(@"C:\Users\thoma\Desktop\oxfoto1285.jpg");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public async void TraiterImage(string photo)
        {
            try
            {
                // Création d'un faceid temporaire à partir de la photo donnée
                JObject jObjectFaceId = await ReconnaissanceFaciale.FaceRecCreateFaceIdTempAsync(photo);
                string faceIdTempo = jObjectFaceId.GetValue("faceId").ToString();

                // Comparaison du faceId à ceux existant dans la list en BDD microsoft
                JObject jObjectComparaison = await ReconnaissanceFaciale.FaceRecCompareFaceAsync(faceIdTempo); ;

                if (jObjectComparaison == null)
                {
                    JObject jObjectPersistentFaceId = await ReconnaissanceFaciale.FaceRecFaceAddListAsync(photo);
                    Saisie.faceIdPersistent = jObjectPersistentFaceId.GetValue("persistedFaceId").ToString();
                }
                else
                {
                    double confidence = Convert.ToDouble(jObjectComparaison.GetValue("confidence"));

                    if (confidence < 0.5)
                    {
                        JObject jObjectPersistentFaceId = await ReconnaissanceFaciale.FaceRecFaceAddListAsync(photo);
                        Saisie.faceIdPersistent = jObjectPersistentFaceId.GetValue("persistedFaceId").ToString();
                    }
                    else
                    {
                        throw new PersonneDejaInscriteException("Inscription impossible : vous êtes déjà inscrits.");
                    }
                }
                this.traitementTermine = true;
            }
            catch (PersonneDejaInscriteException pex)
            {
                MessageBox.Show(pex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.metroProgressSpinner1.Visible = false;
                this.webcam.Visible = true;
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

        /// <summary>
        /// Chaque 100ms et quand le timer est activé, on test si le traitement async est terminé.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerTraitement_Tick(object sender, EventArgs e)
        {
            if (this.traitementTermine)
            {
                this.metroProgressSpinner1.Visible = false;

                // On confirme au form de saisie que la photo a été prise
                Saisie.prisEnPhoto = true;
                Saisie.photo = photo;

                // Fermeture du formulaire
                this.Close();
            }
        }
    }
}
