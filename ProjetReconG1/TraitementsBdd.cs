// <copyright file="TraitementsBdd.cs" company="SIO">
// Copyright (c) SIO. All rights reserved.
// </copyright>

namespace ProjetOxford
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using MySql.Data.MySqlClient;  // Librairie de connexion à MySQL ajoutée en référence.

    /// <summary> Classe qui va permettre la récupération des identifiants liés à la photo prise. </summary>
    public class TraitementsBdd
    {
        /// <summary> Membre privé contenant les informations de connexion à la base de données. </summary>
        private const string CNX = @"Server=mysql-oxfordbonaparte.alwaysdata.net; Port=3306; Database=oxfordbonaparte_db; Uid=148178; Pwd=ToRYolOU;";

        /// <summary> Déclaration d'un objet de la classe MysqlConnection. Va être utilisé pour gérer la
        /// connexion à la base de données MySQL. </summary>
        private static MySqlConnection connexion;

        /// <summary> Méthode de connexion à la base de données. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        public static void OuvrirConnexion()
        {
            try
            {
                connexion = new MySqlConnection(CNX);
                if (connexion.State == ConnectionState.Closed)
                {
                    connexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur de connexion à la base de données MySQL.\n" + ex.Message);
            }
        }

        /// <summary> Méthode publique de fermeture de la connexion à la base de données MySQL. Va
        /// permettre de libérer les ressources de la base de données après une requête. </summary>
        public static void FermerConnexion()
        {
            if (connexion.State != ConnectionState.Closed)
            {
                connexion.Dispose();
                connexion.Close();
            }
        }

        /// <summary> Enregistrement de la photo dans la BDD. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <param name="adresse"> Adresse pointant sur la photo. </param>
        /// <param name="faceId">  Identifier for the face. </param>
        public static void InsertPhoto(string adresse, string faceId)
        {
            string requete = @"INSERT INTO photos(`date`,`value`, `faceid`) VALUES(@date, @adresse, @faceid)";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                cmd.Parameters.AddWithValue("@date", DateTimeToUnixTimestamp(DateTime.Now));
                cmd.Parameters.AddWithValue("@adresse", adresse);
                cmd.Parameters.AddWithValue("@faceid", faceId);
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                FermerConnexion();
            }
            catch (Exception ex)
            {
                FermerConnexion();
                throw new Exception("La requête n'a pu aboutir.\n" + ex.Message);
            }
        }

        /// <summary> Enregistrement de l'utilisateur dans la BDD. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <param name="userAPersister">Utilisateur à persister.</param>
        /// <param name="idPhoto">ID de la photo qui a été enregistrée.</param>
        public static void InsertUser(User userAPersister, int idPhoto)
        {
            string requete = @"INSERT INTO users(nom, prenom, birth, sexe, email, photo, code, type, status) VALUES (@nom, @prenom, @dateDeNaiss, @sexe, @email, @idPhoto, @code, @type, 1)";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                cmd.Parameters.AddWithValue("@nom", userAPersister.Prenom);
                cmd.Parameters.AddWithValue("@prenom", userAPersister.Nom);
                cmd.Parameters.AddWithValue("@dateDeNaiss", DateTimeToUnixTimestamp(userAPersister.DateDeNaissance));
                cmd.Parameters.AddWithValue("@sexe", userAPersister.Sexe);
                cmd.Parameters.AddWithValue("@email", userAPersister.Email);
                cmd.Parameters.AddWithValue("@idPhoto", idPhoto);
                cmd.Parameters.AddWithValue("@code", userAPersister.Code);
                cmd.Parameters.AddWithValue("@type", userAPersister.Type);
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                FermerConnexion();
            }
            catch (Exception ex)
            {
                FermerConnexion();
                throw new Exception("La requête n'a pu aboutir.\n" + ex.Message);
            }
        }

        /// <summary> Méthode qui retourne le nombre d'utilisateurs dans la bdd. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <returns> The maximum photos. </returns>
        public static int GetMaxPhotos()
        {
            string requete = @"SELECT max(id) FROM photos";
            try
            {
                ConnectionState initialCoState = connexion.State;

                // Ouverture de la connexion à la BDD
                if (initialCoState == ConnectionState.Closed)
                {
                    OuvrirConnexion();
                }

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                int maxIdPhotos = Convert.ToInt32(cmd.ExecuteScalar());

                // Fermeture de la connexion
                if (initialCoState == ConnectionState.Closed)
                {
                    FermerConnexion();
                }

                return maxIdPhotos;
            }
            catch (Exception ex)
            {
                FermerConnexion();
                throw new Exception("La requête n'a pu aboutir.\n" + ex.Message);
            }
        }

        /// <summary> Gets types users. </summary>
        /// <exception cref="Exception"> Thrown when an exception error condition occurs. </exception>
        /// <returns> Les types d'utilisateurs. </returns>
        public static List<string> GetTypesUsers()
        {
            string requete = @"SELECT value FROM types WHERE filter <> 'rssi'";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, connexion)
                {
                    CommandType = CommandType.Text
                };

                // Dictionnaire qui contiendra les valeurs des types liés aux id
                List<string> lesTypes = new List<string>();

                // Execution de la requête SQL
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    lesTypes.Add(dataReader.GetString(0));
                }

                // Fermeture de la connexion
                FermerConnexion();

                return lesTypes;
            }
            catch (Exception ex)
            {
                FermerConnexion();
                throw new Exception("La requête n'a pu aboutir.\n" + ex.Message);
            }
        }

        /// <summary> Méthode qui permet de convertir un DateTime en unix timestamp (format de dates dans
        /// la BDD) </summary>
        /// <param name="dateTime">Date à convertir en UnixTimestamp </param>
        /// <returns> La date convertie en UnixTimestamp. </returns>
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
