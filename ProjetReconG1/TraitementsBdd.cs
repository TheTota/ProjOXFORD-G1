//-----------------------------------------------------------------------
// <copyright file="RecupIdentifiants.cs" company="SIO">
//     Copyright (c) SIO. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;  // Librairie de connexion à MySQL ajoutée en référence.

namespace projetOxford
{
    /// <summary>
    /// Classe qui va permettre la récupération des identifiants liés à la photo prise.
    /// </summary>
    public class TraitementsBdd
    {
        /// <summary>
        /// Membre privé contenant les informations de connexion à la base de données.
        /// Le @ sert à prendre la chaîne de caractères telle quelle.
        /// </summary>
        private const string CNX = @"Server=127.0.0.1; Port=3306; Database=oxford; Uid=root; Pwd=;";     // LEO ! Ta bdd a un mdp! donc remplace "Pwd=;" par "Pwd='root'" !

        /// <summary>
        /// Déclaration d'un objet de la classe MysqlConnection.
        /// Va être utilisé pour gérer la connexion à la base de données MySQL.
        /// </summary>
        private static MySqlConnection _connexion;

        /// <summary>
        /// Méthode de connexion à la base de données.
        /// </summary>
        public static void OuvrirConnexion()
        {
            try
            {
                _connexion = new MySqlConnection(CNX);
                if (_connexion.State == ConnectionState.Closed)
                {
                    _connexion.Open();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur de connexion à la base de données MySQL.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Méthode publique de fermeture de la connexion à la base de données MySQL.
        /// Va permettre de libérer les ressources de la base de données après une requête.
        /// </summary>
        public static void FermerConnexion()
        {
            if (_connexion.State != ConnectionState.Closed)
            {
                _connexion.Dispose();
                _connexion.Close();
            }
        }

        /* Méthode DeletePhotoSiAnnulation()
        /// <summary>
        /// Méthode qui supprime la photo prise par l'utilisateur si il a annulé son inscription.
        /// </summary>
        public static void DeletePhotoSiAnnulation()
        {
            string requete = @"DELETE FROM photos WHERE id>(SELECT count(*) FROM users)";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, _connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                FermerConnexion();
            }
            catch (Exception ex)
            {
                FermerConnexion();
                throw new Exception("La requête n'a pu aboutir.\n" + ex.Message);
            }
        } */

        /// <summary>
        /// Enregistrement de la photo dans la bdd.
        /// </summary>
        /// <param name="adresse">Adresse pointant sur la photo.</param>
        public static void InsertPhoto(string adresse)
        {
            string requete = @"INSERT INTO photos(`date`,`value`, `faceid`) VALUES( @date, @adresse, @faceid)";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, _connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                cmd.Parameters.AddWithValue("@date", DateTimeToUnixTimestamp(DateTime.Now));
                cmd.Parameters.AddWithValue("@adresse", adresse);
                cmd.Parameters.AddWithValue("@faceid", null);
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


        public static void InsertUser(User userAPersister)
        {
            string requete = @"INSERT INTO users(prenom, nom, birth, email, sexe, status, photo, type, code) VALUES (@prenom, @nom, @dateDeNaiss, @email, @sexe, @statut, @nbUsers + 1, @statut, @code)";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, _connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                cmd.Parameters.AddWithValue("@prenom", userAPersister.Nom);
                cmd.Parameters.AddWithValue("@nom", userAPersister.Prenom);
                cmd.Parameters.AddWithValue("@dateDeNaiss", DateTimeToUnixTimestamp(userAPersister.DateDeNaissance));
                cmd.Parameters.AddWithValue("@email", userAPersister.Email);
                cmd.Parameters.AddWithValue("@sexe", userAPersister.Sexe);
                cmd.Parameters.AddWithValue("@nbUsers", GetNbUsers());
                cmd.Parameters.AddWithValue("@statut", userAPersister.Statut);
                cmd.Parameters.AddWithValue("@code", userAPersister.Code);
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

        /// <summary>
        /// Méthode qui retourne le nombre d'utilisateurs dans la bdd.
        /// </summary>
        private static int GetNbUsers()
        {
            string requete = @"SELECT count(*) FROM oxford.users";
            try
            {
                // Ouverture de la connexion à la BDD
                OuvrirConnexion();

                // Définition de la requête SQL
                MySqlCommand cmd = new MySqlCommand(requete, _connexion)
                {
                    CommandType = CommandType.Text
                };

                // Execution de la requête SQL
                int nbUsers = Convert.ToInt32(cmd.ExecuteScalar());

                // Fermeture de la connexion
                FermerConnexion();

                return nbUsers;
            }
            catch (Exception ex)
            {
                FermerConnexion();
                throw new Exception("La requête n'a pu aboutir.\n" + ex.Message);
            }
        }

        /// <summary>
        /// Méthode qui permet de convertir un DateTime en unix timestamp (format de dates dans la BDD)
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static double DateTimeToUnixTimestamp(DateTime dateTime)
        {
            return (TimeZoneInfo.ConvertTimeToUtc(dateTime) -
                   new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
