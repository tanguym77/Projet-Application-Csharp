using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_TP.vue
{
    public partial class FormImport : Form
    {
        List<modele.User> listeAajouter = new List<modele.User>();
        List<modele.User> listeAsupprimer = new List<modele.User>();
        List<modele.User> listeAmodifier = new List<modele.User>();

        public FormImport()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 obj = new Form1();
            obj.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // vider la table import 
                modele.DbUsers.vider_userImport();

                //créer une instance de StreamReader pour lire à partir d'un fichier
                StreamReader sr = new StreamReader(textBox1.Text);
                string line;

                // lire les lignes du fichier
                while ((line = sr.ReadLine()) != null)
                {
                    string[] tab = line.Split(';');
                    dataGridView1.Rows.Add(tab[0], tab[1], tab[2], tab[3]);

                    modele.DbUsers.insert_userImport(tab[0], tab[1], tab[2], tab[3]);
                }
                MessageBox.Show("Import terminé !");
            } // fin try
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : "+ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // A ajouter
            MySqlDataReader resultat1 = modele.DbUsers.listeUsersAajouter();
            listBox1.Items.Clear();
            while (resultat1.Read())
            {
                listBox1.Items.Add(resultat1.GetValue(1));
                // Creation d'un objet à ajouter
                string nom = resultat1.GetValue(1).ToString();
                string prenom = resultat1.GetValue(2).ToString();
                string mail = resultat1.GetValue(3).ToString();
                string codebar = resultat1.GetValue(4).ToString();
                modele.User objUser = new modele.User(nom, prenom, mail, codebar);

                // ajouter l'objet dans la liste
                listeAajouter.Add(objUser);
            }
            resultat1.Close();

            // A supprimer
            MySqlDataReader resultat2 = modele.DbUsers.listeUsersAsupprimer(); // REVOIR CETTE FUNCTION

            listBox3.Items.Clear();
            while (resultat2.Read())
            {
                //creation d'un objet user à ajouter
                string nom = resultat2.GetValue(1).ToString();
                string prenom = resultat2.GetValue(2).ToString();
                string mail = resultat2.GetValue(3).ToString();
                string codebar = resultat2.GetValue(4).ToString();
                modele.User objUser = new modele.User(nom, prenom, mail, codebar);

                //ajouter l'objet dans la liste
                listeAsupprimer.Add(objUser);
                listBox3.Items.Add(resultat2.GetValue(1));

            }
            resultat2.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // validation de l'ajout
            foreach(modele.User unUser in listeAajouter)
            {
                string nom = unUser.GetName;
                string prenom = unUser.GetPrenom;
                string mail = unUser.GetMail;
                string codeBar = unUser.GetCodeBar;
                modele.DbUsers.valider_ajout_user(nom, prenom, mail, codeBar);
            }
            MessageBox.Show("La base est à jour !");
            listeAajouter.Clear();

            // validation de la suppression
            
            // validation de la mise à jour
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
        }
    }
}