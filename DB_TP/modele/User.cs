using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_TP.modele
{
    class User
    {
        // déclaration des attributs
        private string nom;
        private string prenom;
        private string mail;
        private string codebar;

        // Constructeur
        public User(string Nom, string Prénom, string Email, string CodeBar)
        {
            this.nom = Nom;
            this.prenom = Prénom;
            this.mail = Email;
            this.codebar = CodeBar;
        }

        public string GetName
        {
            get { return nom; }
        }
        public string GetPrenom
        {
            get { return prenom; }
        }

        public string GetMail
        {
            get { return mail; }
        }

        public string GetCodeBar
        {
            get { return codebar; }
        }
    }
}
