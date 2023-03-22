using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB_TP.modele
{
    class DbUsers
    {
        public static MySqlDataReader getListUsers()
        {
            string sql = "select * from users";
            MySqlCommand cmd = new MySqlCommand(sql, Form1.objconnect);
            MySqlDataReader result = cmd.ExecuteReader();
            return result;
        }

        // fonction pour ajouter un enregistrement dans la table users_import
        public static void insert_userImport(string nom, string prenom, string mail, string codeb)
        {
            string sql = "insert into usertemp values(NULL, '" + nom + "','" + prenom + "','" + mail + "','" + codeb + "')";
            MySqlCommand cmd = new MySqlCommand(sql, Form1.objconnect);
            cmd.ExecuteNonQuery();
        }

        public static void valider_ajout_user(string nom, string prenom, string mail, string codeb) // MODIFIER LA FONCTION
        {
            string sql = "insert into users values(NULL, '" + nom + "','" + prenom + "','" + mail + "','" + codeb + "')";
            MySqlCommand cmd = new MySqlCommand(sql, Form1.objconnect);
            cmd.ExecuteNonQuery();
        }

        //vider table import
        public static void vider_userImport()
        {
            string sql = "delete from usertemp";
            MySqlCommand cmd = new MySqlCommand(sql, Form1.objconnect);
            cmd.ExecuteNonQuery();
        }

        // A ajouter import
        public static MySqlDataReader listeUsersAajouter()
        {
            string sql = "select * from usertemp where Codeb not in(select Codeb from users)";
            MySqlCommand cmd = new MySqlCommand(sql, Form1.objconnect);
            MySqlDataReader result = cmd.ExecuteReader();
            return result;
        }

        public static MySqlDataReader listeUsersAsupprimer() // FONCTION A MODIFIER
        {
            string sql = "select * from usertemp where Codeb in(select Codeb from users)";
            MySqlCommand cmd = new MySqlCommand(sql, Form1.objconnect);
            MySqlDataReader result = cmd.ExecuteReader();
            return result;
        }
    }
    
}
