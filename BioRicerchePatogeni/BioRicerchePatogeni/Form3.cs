using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BioRicerchePatogeni
{
    public partial class Form3 : Form
    {

        //anagrafica
        string azienda, località, tecnico, data, campione, incubazione, s, ParogenoFine, Percentuale;

        private void button2_Click(object sender, EventArgs e)
        {

        }

        string n_piastra;
        string patogeno;

        public string percorsoDB = @"Patogeni.mdb"; //       si trova nella cartella "bin/debug" 
        public OleDbConnection connessione;

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //WHERE CustomerName LIKE '%or%'	Finds any values that have "or" in any position
            n_piastra = (string)textBox1.Text;
            azienda = (string)textBox2.Text;
            campione = (string)textBox3.Text;            
            patogeno = (string)textBox5.Text;
           

            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                string query = "SELECT * FROM Piastra WHERE Piastra.N_Pastra = " + n_piastra + "Or Piastra.Tecnico = "+tecnico+ "Or Piastra.C_Vegetale = "+campione+" Or Piastra.Nome_Azienda = "+azienda+";";
                connessione.Open();

                OleDbDataReader Leggo;
                OleDbCommand Comn;
                Comn = new OleDbCommand(query, connessione);
                Leggo = Comn.ExecuteReader();

                if (Leggo.HasRows)
                {


                    while (Leggo.Read())
                    {
                        //riempimento dataGrid

                    }
                    Leggo.Close();
                    connessione.Close();
                }

            }

            catch (Exception ex)
            {
                connessione.Close(); // chiusura connessione in caso di errore
                MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
            }
        }
    }
}
