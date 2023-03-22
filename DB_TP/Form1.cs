using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace DB_TP
{
    public partial class Form1 : Form
    {
        public static MySqlConnection objconnect;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string host = "localhost";
            string db = "DB_TP";
            string user = "root";
            string mdp = "";

            string connstring = "Server=" + host + ";Database=" + db + ";User Id=" + user + ";password=" + mdp;
            try{ 
                objconnect = new MySqlConnection(connstring);
                objconnect.Open();
                label2.Enabled = true;
                label2.Text = "Connexion OK !";
            }
            catch(Exception ex) {
                MessageBox.Show("Pb d'accès à la DB" + ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            vue.FormImport obj = new vue.FormImport();
            obj.ShowDialog();
            this.Close();
        }
    }
}
