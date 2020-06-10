using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace BioRicerchePatogeni
{
    public partial class Form4 : Form
    {
        string nomePatogeno;
        int idPatogeno = 0;

        string[] nuoviCaratteri = new string[96];

        public string percorsoDB = @"Patogeni.mdb"; //       si trova nella cartella "bin/debug" 
        public OleDbConnection connessione;

        public Form4()
        {
            InitializeComponent();
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            button2.Enabled = false;
            salvaModifiche.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            nomePatogeno = (string)textBox1.Text;
            dataGridView1.Rows.Clear();
            dataGridView1.Enabled = true;

            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");
                string query = "SELECT Patogeni.Id_Patogeno, Patogeni.Nome FROM Patogeni WHERE Patogeni.Nome = '" + nomePatogeno + "' ;";

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
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows[i].Cells[0].Value = Leggo[0].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = Leggo[1].ToString();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Cerca' permette di trovare i patogeni con il nome corrispondente a quello inserito.", "Informazioni tasto: Cerca", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Elimina Patogeno' permette di eliminare il patogeno selezionato, nella tabella dei risultati, dal sistema.", "Informazioni tasto: Elimina Patogeno", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Salva Modifice' permette di sovrascrivere i valori del patogeno selezioanto con i nuovi valori.", "Informazioni tasto: Salva Modifiche", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vuoi Eliminare il Patogeno dal sistema? ATTENZIONE: premendo 'SI' il patogeno verrà eliminato PERENNEMENTE dal sistema", "ATTENZIONE AZIONE INREVERSIBILE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                string query = "DELETE FROM Patogeni WHERE (Patogeni.ID_Patogeno = " + idPatogeno + " );";
                try
                {
                    connessione.Open();
                    // creazione connessione database


                    dataGridView1.Rows.Clear();


                    OleDbCommand Esegui;       //oggetto Command
                    Esegui = new OleDbCommand(query, connessione);

                    Esegui.ExecuteNonQuery();
                    Esegui = null;//Eseguiamo la query

                    connessione.Close();

                    MessageBox.Show("Il patogneo è stato eliminato perennemente ");


                }
                catch (Exception ex)
                {
                    connessione.Close(); // chiusura connessione in caso di errore
                    MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
                }

                try
                {
                    connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");
                    string query1 = "SELECT Patogeni.Id_Patogeno, Patogeni.Nome FROM Patogeni WHERE Patogeni.Nome = '" + nomePatogeno + "' ;";

                    connessione.Open();

                    OleDbDataReader Leggo;
                    OleDbCommand Comn;
                    Comn = new OleDbCommand(query1, connessione);
                    Leggo = Comn.ExecuteReader();

                    if (Leggo.HasRows)
                    {
                        int i = 0;

                        while (Leggo.Read())
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[i].Cells[0].Value = Leggo[0].ToString();
                            dataGridView1.Rows[i].Cells[1].Value = Leggo[1].ToString();
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
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void salvaModifiche_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vuoi salvare le modifiche al patogeno? ATTENZIONE: premendo 'SI' tutti i pozzetti verranno sovrascritti perennemente; Se si desidera inserire un nuovo patogeno usare la funzione 'nuovo patogeno' nella pagina principale del sistema", "ATTENZIONE AZIONE INREVERSIBILE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                getNewCaratteri();
                updateQuery();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void inizializeDGW()
        {
            dataGridView2.Enabled = true;
            dataGridView2.Rows.Clear();
            button2.Enabled = true;
            salvaModifiche.Enabled = true;

            int l;
            l = dataGridView1.CurrentRow.Index;

            idPatogeno = Convert.ToInt32(dataGridView1.Rows[l].Cells[0].Value);


            for (int q = 0; q < 7; q++)
            {
                dataGridView2.Rows.Add();
            }

            dataGridView2.Rows[0].Cells[0].Value = "A";
            dataGridView2.Rows[1].Cells[0].Value = "B";
            dataGridView2.Rows[2].Cells[0].Value = "C";
            dataGridView2.Rows[3].Cells[0].Value = "D";
            dataGridView2.Rows[4].Cells[0].Value = "E";
            dataGridView2.Rows[5].Cells[0].Value = "F";
            dataGridView2.Rows[6].Cells[0].Value = "G";
            dataGridView2.Rows[7].Cells[0].Value = "H";

            string[] caratteristiche = new string[96];

            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");
                string query = "SELECT * FROM Patogeni WHERE Patogeni.ID_Patogeno = " + idPatogeno + ";";

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
                        int n = 0;

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
            for (int h = 0; h < 8; h++)
            {
                for (int y = 1; y <= 12; y++)
                {
                    dataGridView2.Rows[h].Cells[y].Value = caratteristiche[u];
                    u++;
                }
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            inizializeDGW();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            inizializeDGW();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            inizializeDGW();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            inizializeDGW();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Tabella della composizione del patogeno: mostra il patogeno selezionato e permette di modificarlo inserendo - per negativo, + per positivo e / per neutro.", "Informazioni tasto: Salva Modifiche", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        int riga, colonna;

        string valoreCella;
        string nuovoValoreCella;
        private void changeCell()
        {
            colonna = dataGridView2.CurrentCell.ColumnIndex;
            riga = dataGridView2.CurrentCell.RowIndex;

            valoreCella = dataGridView2.CurrentCell.Value.ToString();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            changeCell();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            changeCell();
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeCell();
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            changeCell();
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            changeCell();
        }



        private void dataGridView2_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            changeCell();
        }

        private void dataGridView2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            nuovoValoreCella = dataGridView2.Rows[riga].Cells[colonna].Value.ToString();
            //|| nuovoValoreCella.Equals("+") == false || !nuovoValoreCella.Equals("/") == false
            if (colonna != 0)
            {
                if (nuovoValoreCella.Equals("-") == false)
                {
                    if (nuovoValoreCella.Equals("+") == false)
                    {
                        if (nuovoValoreCella.Equals("/") == false)
                        {
                            dataGridView2.Rows[riga].Cells[colonna].Value = valoreCella;
                            MessageBox.Show("Errore, carattere non valido, inserire + per positivo, - per negativo, / per neutro", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // MessageBox.Show("-" + nuovoValoreCella.Equals("-") +" "+ nuovoValoreCella + "+" + nuovoValoreCella.Equals("+") + " " + "/" + nuovoValoreCella.Equals("/") + " "  );
                }

            }
        }

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }

        void getNewCaratteri()
        {
            int u = 0;
            for (int h = 0; h < 8; h++)
            {
                for (int y = 1; y <= 12; y++)
                {
                    nuoviCaratteri[u] = " '"+ (string)dataGridView2.Rows[h].Cells[y].Value +"' ";
                    u++;
                }
            }
        }

        void updateQuery()
        {
            int n = 0;
            try
            {
                OleDbCommand Insert;

                String query;
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                //Patogeni.a1 = a1,Patogeni.a2=a2,Patogeni.a3=a3,Patogeni.a4=a4,Patogeni.a5=a5,Patogeni.a6=a6,Patogeni.a7=a7,Patogeni.a8=a8,Patogeni.a9=a9,Patogeni.a10=a10,Patogeni.a11=a11,Patogeni.a12=a12,Patogeni.b1=b1,Patogeni.b2=b2,Patogeni.b3=b3,Patogeni.b4=b4,Patogeni.b5=b5,Patogeni.b6=b6,Patogeni.b7=b7,Patogeni.b8=b8,b9,b10,b11,b12,c1
                OleDbParameter oleDbParameter;
                query = "UPDATE Patogeni SET a1= " + nuoviCaratteri[0] + ", a2= " + nuoviCaratteri[1] + ", a3= " + nuoviCaratteri[2] + ", a4= " + nuoviCaratteri[3] + ", a5= " + nuoviCaratteri[4] + ", a6= " + nuoviCaratteri[5] + ", a7= " + nuoviCaratteri[6] + ", a8= " + nuoviCaratteri[7] + ", a9= " + nuoviCaratteri[8] + ", a10= " + nuoviCaratteri[9] + ", a11= " + nuoviCaratteri[10] + ", a12= " + nuoviCaratteri[11] + ", b1= " + nuoviCaratteri[12] + ", b2= " + nuoviCaratteri[13] + ", b3= " + nuoviCaratteri[14] + ", b4= " + nuoviCaratteri[15] + ", b5= " + nuoviCaratteri[16] + ", b6= " + nuoviCaratteri[17] + ", b7= " + nuoviCaratteri[18] + ", b8= " + nuoviCaratteri[19] + ", b9= " + nuoviCaratteri[20] + ", b10= " + nuoviCaratteri[21] + ", b11= " + nuoviCaratteri[22] + ", b12= " + nuoviCaratteri[23] + ", c1= " + nuoviCaratteri[24] + ", c2= " + nuoviCaratteri[25] + ", c3= " + nuoviCaratteri[26] + ", c4= " + nuoviCaratteri[27] + ", c5= " + nuoviCaratteri[28] + ", c6= " + nuoviCaratteri[29] + ", c7= " + nuoviCaratteri[30] + ", c8= " + nuoviCaratteri[31] + ", c9= " + nuoviCaratteri[32] + ", c10= " + nuoviCaratteri[33] + ", c11= " + nuoviCaratteri[34] + ", c12= " + nuoviCaratteri[35] + ", d1= " + nuoviCaratteri[36] + ", d2= " + nuoviCaratteri[37] + ", d3= " + nuoviCaratteri[38] + ", d4= " + nuoviCaratteri[39] + ", d5= " + nuoviCaratteri[40] + ", d6= " + nuoviCaratteri[41] + ", d7= " + nuoviCaratteri[42] + ", d8= " + nuoviCaratteri[43] + ", d9= " + nuoviCaratteri[44] + ", d10= " + nuoviCaratteri[45] + ", d11= " + nuoviCaratteri[46] + ", d12= " + nuoviCaratteri[47] + ", e1= " + nuoviCaratteri[48] + ", e2= " + nuoviCaratteri[49] + ", e3= " + nuoviCaratteri[50] + ", e4= " + nuoviCaratteri[51] + ", e5= " + nuoviCaratteri[52] + ", e6= " + nuoviCaratteri[53] + ", e7= " + nuoviCaratteri[54] + ", e8= " + nuoviCaratteri[55] + ", e9= " + nuoviCaratteri[56] + ", e10= " + nuoviCaratteri[57] + ", e11= " + nuoviCaratteri[58] + ", e12= " + nuoviCaratteri[59] + ", f1= " + nuoviCaratteri[60] + ", f2= " + nuoviCaratteri[61] + ", f3= " + nuoviCaratteri[62] + ", f4= " + nuoviCaratteri[63] + ", f5= " + nuoviCaratteri[64] + ", f6= " + nuoviCaratteri[65] + ", f7= " + nuoviCaratteri[66] + ", f8= " + nuoviCaratteri[67] + ", f9= " + nuoviCaratteri[68] + ", f10= " + nuoviCaratteri[69] + ", f11= " + nuoviCaratteri[70] + ", f12= " + nuoviCaratteri[71] + ", g1= " + nuoviCaratteri[72] + ", g2= " + nuoviCaratteri[73] + ", g3= " + nuoviCaratteri[74] + ", g4= " + nuoviCaratteri[75] + ", g5= " + nuoviCaratteri[76] + ", g6= " + nuoviCaratteri[77] + ", g7= " + nuoviCaratteri[78] + ", g8= " + nuoviCaratteri[79] + ", g9= " + nuoviCaratteri[80] + ", g10= " + nuoviCaratteri[81] + ", g11= " + nuoviCaratteri[82] + ", g12= " + nuoviCaratteri[83] + ", h1= " + nuoviCaratteri[84] + ", h2= " + nuoviCaratteri[85] + ", h3= " + nuoviCaratteri[86] + ", h4= " + nuoviCaratteri[87] + ", h5= " + nuoviCaratteri[88] + ", h6= " + nuoviCaratteri[89] + ", h7= " + nuoviCaratteri[90] + ", h8= " + nuoviCaratteri[91] + ", h9= " + nuoviCaratteri[92] + ", h10= " + nuoviCaratteri[93] + ", h11= " + nuoviCaratteri[94] + ", h12 = " + nuoviCaratteri[95] + " WHERE Patogeni.ID_Patogeno = " + idPatogeno +"; ";
                connessione.Open();
                Insert = new OleDbCommand(query, connessione);

                Insert.ExecuteNonQuery();
                connessione.Close();

                MessageBox.Show("Cambiamento avvenuto con successo", "Successo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            catch (Exception ex)
            {
                connessione.Close(); // chiusura connessione in caso di errore
                MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
            }
        }
    }
}
