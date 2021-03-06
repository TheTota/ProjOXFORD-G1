﻿//-----------------------------------------------------------------------
// <copyright file="PrisePhoto.cs" company="SIO">
//     Copyright (c) SIO. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ProjetOxf
{
    using System;
    using System.Collections.Generic;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Windows.Forms;
    using MetroFramework;
    using Newtonsoft.Json.Linq;
    using ProjetOxford;
    using WebEye.Controls.WinForms.WebCameraControl;

    /// <summary>Formulaire de test. Le vrai formulaire permettra de prendre une photo à partir d'une
    /// caméra connectée à l'ordinateur.</summary>
    public partial class PrisePhoto : MetroFramework.Forms.MetroForm
    {
        /// <summary>Liste des caméras liées à l'ordinateur.</summary>
        private List<WebCameraId> listCams;

        /// <summary>Lieu où sera sauvegardée la photo.</summary>
        private string savePath = "oxfoto";

        /// <summary>Chemin pointant sur la photo prise.</summary>
        private string photo;

        /// <summary>Booléen définissant si le traitement Oxford est terminé.</summary>
        private bool traitementTermine;

        /// <summary>Initialise une nouvelle instance de la classe <see cref="PrisePhoto"/>.</summary>
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
        /// <param name="dateTime"> Date à convertir. </param>
        /// <returns> La date au format Unix Timestamp. </returns>
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        /// <summary>Fonction principale permettant d'inscrire un visage dans la BDD de microsoft après
        /// avoir vérifié qu'il n'était pas déjà inscrit.</summary>
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
                    Saisie.FaceIdTemp = faceIdTempo;
                }
                else
                {
                    // Récupération du pourcentage de reconnaissance du visage
                    double confidence = Convert.ToDouble(jObjectComparaison.GetValue("confidence"));

                    // Si on a trouvé une personne qui ressemble mais la ressemblance n'est pas assez importante
                    // pour dire que la personne a été reconnue, on l'inscrit.
                    if (confidence < 0.7)
                    {
                        Saisie.FaceIdTemp = faceIdTempo;
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
                MetroMessageBox.Show(this, pex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.traitementOxfordProgressSpinner.Visible = false;
                this.webcam.Visible = true;
                this.btnPrendrePhoto.Enabled = true;
            }
        }

        /// <summary>Chaque 100ms et quand le timer est activé, on test si le traitement async est
        /// terminé.</summary>
        /// <param name="sender">Sender. </param>
        /// <param name="e">EventArgs. </param>
        private void TimerTraitement_Tick(object sender, EventArgs e)
        {
            if (this.traitementTermine)
            {
                this.traitementOxfordProgressSpinner.Visible = false;

                // On confirme au form de saisie que la photo a été prise
                Saisie.PrisEnPhoto = true;
                Saisie.Photo = this.photo;

                // Fermeture du formulaire
                this.Close();
            }
        }

        /// <summary>Prise de photo lors du clic sur le bouton "Prendre la photo".</summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void BtnPhoto_onclick(object sender, EventArgs e)
        {
            try
            {
                // Si la webcam est bien active..
                if (this.webcam.IsCapturing)
                {
                    this.webcam.Visible = false;
                    this.traitementOxfordProgressSpinner.Visible = true;
                    this.btnPrendrePhoto.Enabled = false;
                    this.timerTraitement.Enabled = true;

                    // On détermine le chemin complet final pointant vers la photo
                    this.photo = this.savePath + DateTimeToUnixTimestamp(DateTime.Now) + ".jpg";

                    // On prend une photo qu'on enregistre au path donné
                    this.webcam.GetCurrentImage().Save(this.photo, ImageFormat.Jpeg);

                    // On l'enregistre dans le fichier du serveur alwaysdata
                    this.UpLoadImage(this.photo);

                    // Traitement de l'image avec la bdd oxford
                    this.TraiterImage(this.photo);
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Méthode permettant d'enregistrer la photo prise vers le serveur alwaysdata
        /// </summary>
        /// <param name="target">Image à uploader.</param>
        private void UpLoadImage(string target)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://ftp-oxfordbonaparte.alwaysdata.net/www/public/photos/" + target);
            req.UseBinary = true;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential("oxfordbonaparte", "ToRYolOU");
            byte[] fileData = File.ReadAllBytes(target);
            req.ContentLength = fileData.Length;
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(fileData, 0, fileData.Length);
            reqStream.Close();
        }

        /// <summary>Méthode se déclanchant à la fermeture du formulaire. Stop la capture vidéo (affichage
        /// en live à l'écran).</summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">EventArgs.</param>
        private void PrisePhoto_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop la capture
            this.webcam.StopCapture();
        }
    }
}