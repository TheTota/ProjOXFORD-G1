// <copyright file="User.cs" company="SIO">
// Copyright (c) SIO. All rights reserved.
// </copyright>

namespace ProjetOxford
{
    using System;

    /// <summary>
    /// Classe Utilisateur qui sera liée en partie à la table Users de la BDD.
    /// </summary>
    public class User
    {
        private string prenom;
        private string nom;
        private DateTime dateDeNaissance;
        private string email;
        private string sexe;
        private int type;
        private int code;

        /// <summary>
        /// Initialise une instance de la classe User.
        /// </summary>
        /// <param name="prenom">Prénom de l'utilisateur.</param>
        /// <param name="nom">Nom de l'utilisateur</param>
        /// <param name="dateDeNaissance">Date de naissance de l'utilisateur.</param>
        /// <param name="email">Email de l'utilisateur.</param>
        /// <param name="sexe">Sexe de l'utilisateur ('H'/'F').</param>
        /// <param name="type">Type de l'utilisateur.</param>
        /// <param name="code">Code d'authentifaction lié à l'utilisateur.</param>
        public User(string prenom, string nom, DateTime dateDeNaissance, string email, string sexe, int type, int code)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.dateDeNaissance = dateDeNaissance;
            this.email = email;
            this.sexe = sexe;
            this.type = type;
            this.code = code;
        }

        /// <summary>
        /// Obtient le prénom de l'utilisateur.
        /// </summary>
        public string Prenom { get => this.prenom; }

        /// <summary>
        /// Obtient le nom de l'utilisateur.
        /// </summary>
        public string Nom { get => this.nom;  }

        /// <summary>
        /// Obtient la date de naissance de l'utilisateur.
        /// </summary>
        public DateTime DateDeNaissance { get => this.dateDeNaissance; }

        /// <summary>
        /// Obtient l'email de l'utilisateur.
        /// </summary>
        public string Email { get => this.email; }

        /// <summary>
        /// Obtient le sexe de l'utilisateur ('H'/'F')
        /// </summary>
        public string Sexe { get => this.sexe; }

        /// <summary>
        /// Obtient le type de l'utilisateur.
        /// </summary>
        public int Type { get => this.type; }

        /// <summary>
        /// Obtient le code d'authentification de l'utilisateur.
        /// </summary>
        public int Code { get => this.code; }
    }
}
