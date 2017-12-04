//-----------------------------------------------------------------------
// <copyright file="PrisePhoto.cs" company="SIO">
//     Copyright (c) SIO. All rights reserved.
// </copyright>
// <author>Thomas Cianfarani</author>
// <author>Mehdi Ben Bahri</author>
// <author>Léo Espeu</author>
//-----------------------------------------------------------------------

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using projetOxford;
using WebEye.Controls.WinForms.WebCameraControl;

namespace ProjetOxf
{
    /// <summary>Formulaire de test. Le vrai formulaire permettra de prendre une photo à partir d'une
    /// caméra connectée à l'ordinateur.</summary>
    /// <remarks>Thomas CIANFARANI, 04/12/2017.</remarks>
    public partial class PrisePhoto : MetroFramework.Forms.MetroForm
    {
        /// <summary>Liste des caméras liées à l'ordinateur.</summary>
        private List<WebCameraId> listCams;

        /// <summary>Lieu où sera sauvegardée la photo.</summary>
        private string savePath = @"C:\Users\thoma\Desktop\oxfoto";

        /// <summary>Chemin pointant sur la photo prise.</summary>
        private string photo;

        /// <summary>Booléen définissant si le traitement Oxford est terminé.</summary>
        private bool traitementTermine;

        /// <summary>Initialise une nouvelle instance de la classe <see cref="PrisePhoto"/>.</summary>
        /// <remarks>Thomas CIANFARANI, 04/12/2017.</remarks>
        public PrisePhoto()
        {
            this.InitializeComponent();

            // Récupération des caméras 
            this.listCams = this.webcam.GetVideoCaptureDevices().ToList();

            // Démarre la capture 
            this.webcam.StartCapture(this.listCams[0]);

            this.traitementTermine = false;
        }

        /// <summary>Méthode qui permet de convertir un DateTime en unix timestamp.</summary>
        /// <remarks>Thomas CIANFARANI, 04/12/2017.</remarks>
        /// <param name="dateTime"> Date à convertir. </param>
        /// <returns> La date au format Unix Timestamp. </returns>
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>Fonction principale permettant d'inscrire un visage dans la BDD de microsoft après
        /// avoir vérifié qu'il n'était pas déjà inscrit.</summary>
        /// <remarks>Thomas CIANFARANI, 04/12/2017.</remarks>
        /// <exception cref="PersonneDejaInscriteException">
        ///     Thrown when a Personne Deja Inscrite error condition occurs.
        /// </exception>
        /// <param name="photo">Photo à traiter.</param>
        public async void TraiterImage(string photo)
        {
            try
            {
                // Création d'un faceid temporaire à partir de la photo donnée
                JObject jObjectFaceId = await ReconnaissanceFaciale.FaceRecCreateFaceIdTempAsync(photo);
                string faceIdTempo = jObjectFaceId.GetValue("faceId").ToString();

                // Comparaison du faceId à ceux existant dans la list en BDD microsoft
                JObject jObjectComparaison = await ReconnaissanceFaciale.FaceRecCompareFaceAsync(faceIdTempo);

                // Si jObectComparaison est égal à null, alors personne dans la BDD ressemble au visage.
                if (jObjectComparaison == null)
                {
                    Saisie.faceIdTemp = faceIdTempo;
                }
                else
                {
                    // Récupération du pourcentage de reconnaissance du visage
                    double confidence = Convert.ToDouble(jObjectComparaison.GetValue("confidence"));

                    // Si on a trouvé une personne qui ressemble mais la ressemblance n'est pas assez importante
                    // pour dire que la personne a été reconnue, on l'inscrit.
                    if (confidence < 0.7)
                    {
                        Saisie.faceIdTemp = faceIdTempo;
                    }
                    else
                    {
                        throw new PersonneDejaInscriteException("Inscription impossible : vous êtes déjà inscrits.");
                    }
                }

                // On déclare le traitement comme terminé ce qui permettra au timer de stopper l'attente
                this.traitementTermine = true;
            }
            catch (PersonneDejaInscriteException pex)
            {
                MessageBox.Show(pex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.metroProgressSpinner1.Visible = false;
                this.webcam.Visible = true;
                this.btnPrendrePhoto.Enabled = true;
            }
        }

        /// <summary>Chaque 100ms et quand le timer est activé, on test si le traitement async est
        /// terminé.</summary>
        /// <remarks>Thomas CIANFARANI, 04/12/2017.</remarks>
        /// <param name="sender">Sender. </param>
        /// <param name="e">EventArgs. </param>
        private void TimerTraitement_Tick(object sender, EventArgs e)
        {
            if (this.traitementTermine)
            {
                this.metroProgressSpinner1.Visible = false;

                // On confirme au form de saisie que la photo a été prise
                Saisie.prisEnPhoto = true;
                Saisie.photo = this.photo;

                // Fermeture du formulaire
                this.Close();
            }
        }

        /// <summary>Prise de photo lors du clic sur le bouton "Prendre la photo".</summary>
        /// <remarks>Thomas CIANFARANI, 04/12/2017.</remarks>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void BtnPhoto_onclick(object sender, EventArgs e)
        {
            try
            {
                // Si la webcam est bien active..
                if (this.webcam.IsCapturing)
                {
                    // On détermine le chemin complet final pointant vers la photo
                    this.photo = this.savePath + DateTimeToUnixTimestamp(DateTime.Now) + ".jpg";

                    // On prend une photo qu'on enregistre au path donné
                    this.webcam.GetCurrentImage().Save(this.photo, ImageFormat.Jpeg);

                    // Traitement de l'image avec la bdd oxford
                    this.timerTraitement.Enabled = true;
                    this.webcam.Visible = false;
                    this.metroProgressSpinner1.Visible = true;
                    this.btnPrendrePhoto.Enabled = false;

                    this.TraiterImage(this.photo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Méthode se déclanchant à la fermeture du formulaire. Stop la capture vidéo (affichage
        /// en live à l'écran).</summary>
        /// <remarks> Thomas CIANFARANI, 04/12/2017. </remarks>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void PrisePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop la capture
            this.webcam.StopCapture();
        }
    }
}