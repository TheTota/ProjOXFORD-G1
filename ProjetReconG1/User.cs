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
        private int type;
        private int code;

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

        public string Prenom { get => prenom; }
        public string Nom { get => nom;  }
        public DateTime DateDeNaissance { get => dateDeNaissance; }
        public string Email { get => email; }
        public string Sexe { get => sexe; }
        public int Type { get => type; }
        public int Code { get => code; }
    }
}
