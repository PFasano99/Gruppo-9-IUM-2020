using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace BioRicerchePatogeni
{
    public partial class Form2 : Form
    {
        int did = 0;
        public string percorsoDB = @"Patogeni.mdb"; //       si trova nella cartella "bin/debug" 
        public OleDbConnection connessione;
        public Form2(int dgwid, string azienda,string località, string tecnico, string data, string campione, string incubazione, string ParogenoFine, string Percentuale, string npiastra)
        {
            InitializeComponent();
            did = dgwid;
            inizializzo();
            label19.Text = "" + azienda;
            label18.Text = "" + località;
            label17.Text = "" + npiastra;
            label16.Text = "" + campione;
            label14.Text = "" + incubazione;
            label15.Text = "" + data;
            label13.Text = "" + tecnico;
            label12.Text = "" + ParogenoFine;
            label11.Text = "" + Percentuale;
        }

        

        private void inizializzo()
        {
            for(int q=0; q<=8; q++)
            {
                dataGridView1.Rows.Add();
            }

            dataGridView1.Rows[1].Cells[0].Value = "A";
            dataGridView1.Rows[2].Cells[0].Value = "B";
            dataGridView1.Rows[3].Cells[0].Value = "C";
            dataGridView1.Rows[4].Cells[0].Value = "D";
            dataGridView1.Rows[5].Cells[0].Value = "E";
            dataGridView1.Rows[6].Cells[0].Value = "F";
            dataGridView1.Rows[7].Cells[0].Value = "G";
            dataGridView1.Rows[8].Cells[0].Value = "H";

            string[] caratteristiche = new string[96];

            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                string query = "SELECT * FROM Patogeni WHERE Patogeni.ID_Patogeno = " + did + ";";
                connessione.Open();

                OleDbDataReader Leggo;
                OleDbCommand Comn;
                Comn = new OleDbCommand(query, connessione);
                Leggo = Comn.ExecuteReader();

                if (Leggo.HasRows)
                {


                    while (Leggo.Read())
                    {
                        int n = 0;
                       
                        string ID, s;

                        ID = Leggo[0].ToString();
                        s = Leggo[1].ToString();

                        for (int c = 2; n < 96; c++)
                        {
                            caratteristiche[n] = Leggo[c].ToString();
                            string f, v;
                            f = caratteristiche[n];                                                      
                            n++;
                        }

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

            int u = 0;
            for(int h=1; h<=8; h++)
            {
                for(int y=1; y<=12; y++)
                {
                    dataGridView1.Rows[h].Cells[y].Value = caratteristiche[u];
                    u++;
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        Bitmap btm;

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            btnPrint.Visible = false;
            Graphics g = this.CreateGraphics();
            btm = new Bitmap(this.Size.Height, this.Size.Width, g);
            Graphics mg = Graphics.FromImage(btm);
            mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
            printDialog1.ShowDialog();
           
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(btm,0,0);
        }
    }
}
