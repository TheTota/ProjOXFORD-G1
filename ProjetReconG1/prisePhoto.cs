using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
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
        string savePath = @"oxfoto";

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
                    //this.photo = @"C:\Users\thoma\Desktop\usa-today-9765113.0.jpg";

                    // On prend une photo qu'on enregistre au path donné
                    webcam.GetCurrentImage().Save(this.photo, ImageFormat.Jpeg);

                    //On l'enregistre dans le fichier du serveur alwaysdata
                    this.UpLoadImage(this.photo);

                    // Traitement de l'image avec la bdd oxford
                    this.timerTraitement.Enabled = true;
                    this.webcam.Visible = false;
                    this.metroProgressSpinner1.Visible = true;
                    this.btnPrendrePhoto.Enabled = false;

                    //TraiterImage(this.photo);
                    TraiterImage(this.photo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Fonction principale permettant d'inscrire un visage dans la BDD de microsoft après
        /// avoir vérifié qu'il n'était pas déjà inscrit.
        /// </summary>
        /// <param name="photo">Photo param>
        public async void TraiterImage(string photo)
        {
            try
            {
                // Création d'un faceid temporaire à partir de la photo donnée
                JObject jObjectFaceId = await ReconnaissanceFaciale.FaceRecCreateFaceIdTempAsync(photo);
                string faceIdTempo = jObjectFaceId.GetValue("faceId").ToString();

                // Comparaison du faceId à ceux existant dans la list en BDD microsoft
                JObject jObjectComparaison = await ReconnaissanceFaciale.FaceRecCompareFaceAsync(faceIdTempo); ;

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

        /// <summary>
        /// Méthode permettant d'enregistrer la photo prise vers le serveur alwaysdata
        /// </summary>
        /// <param name="target"></param>
        private void UpLoadImage(string target)
        {
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create("ftp://ftp-oxfordbonaparte.alwaysdata.net/www/public/photos/" + target);
            req.UseBinary = true;
            req.Method = WebRequestMethods.Ftp.UploadFile;
            req.Credentials = new NetworkCredential("oxfordbonaparte", "ToRYolOU");
            byte[] fileData = File.ReadAllBytes(this.photo);
            req.ContentLength = fileData.Length;
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(fileData, 0, fileData.Length);
            reqStream.Close();
        }
    }
}
