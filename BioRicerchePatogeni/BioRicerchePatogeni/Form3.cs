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
        string azienda, località, tecnico, data, campione, incubazione, Percentuale;

        int idPatogeno;

        Boolean isSelected = false;
        int idReferto;

        string n_piastra;
        string patogeno;

        public string percorsoDB = @"Patogeni.mdb"; //       si trova nella cartella "bin/debug" 
        public OleDbConnection connessione;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Cerca' serve a trovare un referto in base ai dati inseriti negli appositi spazi a sinistra del tasto.", "Informazioni tasto: Cerca", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Stampa referto' permette di stampare un referto precedentemente selezionato dalla tabella dei risultati.", "Informazioni tasto: Stampa Referto", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La tabella dei risultati mostra tutti i risultati corrispondenti ai parametri inseriti; Per selezionare un referto da stampare, cliccare una qualsiasi delle caselle sulla riga corrispondente.", "Informazioni: Tabella Risultati", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void dgwDati()
        {
            isSelected = true;
            button2.Enabled = true;

            int l;
            l = dataGridView1.CurrentRow.Index;
                  
            idReferto = Convert.ToInt32(dataGridView1.Rows[l].Cells[0].Value);
            n_piastra = Convert.ToString(dataGridView1.Rows[l].Cells[1].Value);
            patogeno = Convert.ToString(dataGridView1.Rows[l].Cells[2].Value);
            tecnico = Convert.ToString(dataGridView1.Rows[l].Cells[3].Value);
            data = Convert.ToString(dataGridView1.Rows[l].Cells[4].Value);
            incubazione = Convert.ToString(dataGridView1.Rows[l].Cells[5].Value);
            campione = Convert.ToString(dataGridView1.Rows[l].Cells[6].Value);
            azienda = Convert.ToString(dataGridView1.Rows[l].Cells[7].Value);
            località = Convert.ToString(dataGridView1.Rows[l].Cells[8].Value);
            Percentuale = Convert.ToString(dataGridView1.Rows[l].Cells[9].Value);


            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                string query = "SELECT PatToPias.ID_Patogeno FROM PatToPias WHERE PatToPias.ID_Piastra = " + idReferto + " ;";
                connessione.Open();

                OleDbDataReader Leggo;
                OleDbCommand Comn;
                Comn = new OleDbCommand(query, connessione);
                Leggo = Comn.ExecuteReader();

                if (Leggo.HasRows)
                {
                    int i = 0;

                    while (Leggo.Read())
                    {
                        idPatogeno = Convert.ToInt32(Leggo[0].ToString());
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            isSelected = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isSelected)
            {             
                Form2 frm2 = new Form2(idPatogeno, azienda, località, tecnico, data, campione, incubazione, patogeno, Percentuale, n_piastra);
                frm2.Show();
            }
            else
                MessageBox.Show("Selezionare un riultato da stampare");
            
        }

        

        public Form3()
        {
            InitializeComponent();
            dataGridView1.Enabled = false;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Enabled = true;

            //WHERE CustomerName LIKE '%or%'	Finds any values that have "or" in any position
            n_piastra = (string)textBox1.Text;
            azienda = (string)textBox2.Text;
            campione = (string)textBox3.Text;            
            patogeno = (string)textBox5.Text;
           tecnico = (string)textBox4.Text;

            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                //" Or Piastra.Tecnico = '"+tecnico+ "' Or Piastra.C_Vegetale = '"+campione+"' Or Piastra.Nome_Azienda = '"+azienda+ "' Or Piastra.Patogeno = '" + patogeno + 

                string query = "SELECT * FROM Piastra WHERE (Piastra.N_Piastra = '" + n_piastra + "' Or Piastra.Tecnico = '" + tecnico + "' Or Piastra.C_Vegetale = '" + campione + "' Or Piastra.Nome_Azienda = '" + azienda + "' Or Piastra.Patogeno = '" + patogeno + "');";
                connessione.Open();

                OleDbDataReader Leggo;
                OleDbCommand Comn;
                Comn = new OleDbCommand(query, connessione);
                Leggo = Comn.ExecuteReader();

                if (Leggo.HasRows)
                {
                    int i = 0;

                    while (Leggo.Read())
                    {
                        //riempimento dataGrid
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = Leggo[0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = Leggo[1].ToString();
                        dataGridView1.Rows[i].Cells[2].Value = Leggo[9].ToString();
                        dataGridView1.Rows[i].Cells[3].Value = Leggo[3].ToString();
                        dataGridView1.Rows[i].Cells[4].Value = Leggo[2].ToString();
                        dataGridView1.Rows[i].Cells[5].Value = Leggo[5].ToString();
                        dataGridView1.Rows[i].Cells[6].Value = Leggo[4].ToString();
                        dataGridView1.Rows[i].Cells[7].Value = Leggo[6].ToString();
                        dataGridView1.Rows[i].Cells[8].Value = Leggo[7].ToString();
                        dataGridView1.Rows[i].Cells[9].Value = Leggo[8].ToString();
                        i++;



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
