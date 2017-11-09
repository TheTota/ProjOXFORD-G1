using System;

namespace projetOxford
{
    public class User
    {
        private string prenom;
        private string nom;
        private DateTime dateDeNaissance;
        private string email;
        private string sexe;
        private int statut;
        private int code;

        public User(string prenom, string nom, DateTime dateDeNaissance, string email, string sexe, int statut, int code)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.dateDeNaissance = dateDeNaissance;
            this.email = email;
            this.sexe = sexe;
            this.statut = statut;
            this.code = code;
        }

        public string Prenom { get => prenom; }
        public string Nom { get => nom;  }
        public DateTime DateDeNaissance { get => dateDeNaissance; }
        public string Email { get => email; }
        public string Sexe { get => sexe; }
        public int Statut { get => statut; }
        public int Code { get => code; }
    }
}
