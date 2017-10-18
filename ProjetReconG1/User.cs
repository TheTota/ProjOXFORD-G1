using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projetOxford
{
    class User
    {
        private string prenom;
        private string nom;
        private int age;
        private DateTime dateDeNaissance;
        private string email;
        private string sexe;
        private string statut;

        public User(string prenom, string nom, int age, DateTime dateDeNaissance, string email, string sexe, string statut)
        {
            this.prenom = prenom;
            this.nom = nom;
            this.age = age;
            this.dateDeNaissance = dateDeNaissance;
            this.email = email;
            this.sexe = sexe;
            this.statut = statut;
        }

        public string Prenom { get => prenom; }
        public string Nom { get => nom;  }
        public int Age { get => age; }
        public DateTime DateDeNaissance { get => dateDeNaissance; }
        public string Email { get => email; }
        public string Sexe { get => sexe; }
        public string Statut { get => statut; }
    }
}
