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
    public partial class Form1 : Form
    {
        
        int[] nClick = new int[96];
        string[] GetD = new string[96];

        public string percorsoDB = @"Patogeni.mdb"; //       si trova nella cartella "bin/debug" 
        public OleDbConnection connessione;

        //anagrafica
        string azienda, località, tecnico, data, campione, incubazione,s, ParogenoFine, Percentuale;
        string n_piastra;

        string temp;
        string lastIdPi;
        int lastIdPa;

        string patogeno;


        public Form1()
        {
            InitializeComponent();
            //panels
            panel2.Visible = true;
            panel2.Enabled = false;
            panel3.Enabled = false;
            panel4.Visible = true;
            panel4.Enabled = false;
            panel6.Visible = false;
            panel6.Enabled = false;
            panel8.Visible = false;
            panel8.Enabled = false;
            panel9.Enabled = false;
            panel9.Visible = false;
            panel10.Enabled = false;
            panel10.Visible = true;

            //labels
            label33.Visible = false;
            label35.Visible = false;
            label38.Visible = false;
            label39.Visible = false;


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel2.Enabled = true;
            panel4.Visible = true;
            panel4.Enabled = true;

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {

        }

        private void button93_Click(object sender, EventArgs e)
        {

        }

        public void changeButton(int i, Button b)
        {
            nClick[i]++;
            if (nClick[i] == 1)
            {
                b.Text = "/";
                b.BackColor = Color.LightPink;
            }
            if (nClick[i] == 2)
            {
                b.Text = "+";
                b.BackColor = Color.Violet;

            }
            if (nClick[i] > 2)
            {
                b.Text = "-";
                nClick[i] = 0;
                b.BackColor = Color.White;
            }
        }

        private void B_a1_Click(object sender, EventArgs e)
        {
            Button b = B_a1;
            changeButton(1, b);

        }
           
        private void B_a2_Click(object sender, EventArgs e)
        {
            Button b = B_a2;
            changeButton(2, b);
        }

        private void B_a3_Click(object sender, EventArgs e)
        {
            Button b = B_a3;
            changeButton(3, b);
        }

        private void B_a4_Click(object sender, EventArgs e)
        {
            Button b = B_a4;
            changeButton(4, b);
        }

        private void B_a5_Click(object sender, EventArgs e)
        {
            Button b = B_a5;
            changeButton(5, b);
        }

        private void B_a6_Click(object sender, EventArgs e)
        {
            Button b = B_a6;
            changeButton(6, b);
        }

        private void B_a7_Click(object sender, EventArgs e)
        {
            Button b = B_a7;
            changeButton(7, b);
        }

        private void B_a8_Click(object sender, EventArgs e)
        {
            Button b = B_a8;
            changeButton(8, b);
        }

        private void B_a9_Click(object sender, EventArgs e)
        {
            Button b = B_a9;
            changeButton(9, b);
        }

        private void B_a10_Click(object sender, EventArgs e)
        {
            Button b = B_a10;
            changeButton(10, b);
        }

        private void B_a11_Click(object sender, EventArgs e)
        {
            Button b = B_a11;
            changeButton(11, b);
        }

        private void B_a12_Click(object sender, EventArgs e)
        {
            Button b = B_a12;
            changeButton(12, b);
        }

        private void B_b1_Click(object sender, EventArgs e)
        {
            Button b = B_b1;
            changeButton(13, b);
        }

        private void B_b2_Click(object sender, EventArgs e)
        {
            Button b = B_b2;
            changeButton(14, b);
        }

        private void B_b3_Click(object sender, EventArgs e)
        {
            Button b = B_b3;
            changeButton(15, b);
        }

        private void B_b4_Click(object sender, EventArgs e)
        {
            Button b = B_b4;
            changeButton(16, b);
        }

        private void B_b5_Click(object sender, EventArgs e)
        {
            Button b = B_b5;
            changeButton(17, b);
        }

        private void B_b6_Click(object sender, EventArgs e)
        {
            Button b = B_b6;
            changeButton(18, b);
        }

        private void B_b17_Click(object sender, EventArgs e)
        {
            Button b = B_b17;
            changeButton(19, b);
        }

        private void B_b18_Click(object sender, EventArgs e)
        {
            Button b = B_b18;
            changeButton(20, b);
        }

        private void B_b9_Click(object sender, EventArgs e)
        {
            Button b = B_b9;
            changeButton(21, b);
        }

        private void B_b10_Click(object sender, EventArgs e)
        {
            Button b = B_b10;
            changeButton(22, b);
        }

        private void B_b11_Click(object sender, EventArgs e)
        {
            Button b = B_b11;
            changeButton(23, b);
        }

        private void B_b12_Click(object sender, EventArgs e)
        {
            Button b = B_b12;
            changeButton(24, b);
        }

        private void B_c1_Click(object sender, EventArgs e)
        {
            Button b = B_c1;
            changeButton(25, b);
        }

        private void B_c2_Click(object sender, EventArgs e)
        {
            Button b = B_c2;
            changeButton(26, b);
        }

        private void B_c3_Click(object sender, EventArgs e)
        {
            Button b = B_c3;
            changeButton(27, b);
        }

        private void B_c4_Click(object sender, EventArgs e)
        {
            Button b = B_c4;
            changeButton(28, b);
        }

        private void B_c5_Click(object sender, EventArgs e)
        {
            Button b = B_c5;
            changeButton(29, b);
        }

        private void B_c6_Click(object sender, EventArgs e)
        {
            Button b = B_c6;
            changeButton(30, b);
        }

        private void B_c7_Click(object sender, EventArgs e)
        {
            Button b = B_c7;
            changeButton(31, b);
        }

        private void B_c8_Click(object sender, EventArgs e)
        {
            Button b = B_c8;
            changeButton(32, b);
        }

        private void B_c9_Click(object sender, EventArgs e)
        {
            Button b = B_c9;
            changeButton(33, b);
        }

        private void B_c10_Click(object sender, EventArgs e)
        {
            Button b = B_c10;
            changeButton(34, b);
        }

        private void B_c11_Click(object sender, EventArgs e)
        {
            Button b = B_c11;
            changeButton(35, b);
        }

        private void B_c12_Click(object sender, EventArgs e)
        {
            Button b = B_c12;
            changeButton(36, b);
        }

        private void B_d1_Click(object sender, EventArgs e)
        {
            Button b = B_d1;
            changeButton(37, b);
        }

        private void B_d2_Click(object sender, EventArgs e)
        {
            Button b = B_d2;
            changeButton(38, b);
        }

        private void B_d3_Click(object sender, EventArgs e)
        {
            Button b = B_d3;
            changeButton(39, b);
        }

        private void B_d4_Click(object sender, EventArgs e)
        {
            Button b = B_d4;
            changeButton(40, b);
        }

        private void B_d5_Click(object sender, EventArgs e)
        {
            Button b = B_d5;
            changeButton(41, b);
        }

        private void B_d6_Click(object sender, EventArgs e)
        {
            Button b = B_d6;
            changeButton(42, b);
        }

        private void B_d7_Click(object sender, EventArgs e)
        {
            Button b = B_d7;
            changeButton(43, b);
        }

        private void B_d8_Click(object sender, EventArgs e)
        {
            Button b = B_d8;
            changeButton(44, b);
        }

        private void B_d9_Click(object sender, EventArgs e)
        {
            Button b = B_d9;
            changeButton(45, b);
        }

        private void B_d10_Click(object sender, EventArgs e)
        {
            Button b = B_d10;
            changeButton(46, b);
        }

        private void B_d11_Click(object sender, EventArgs e)
        {
            Button b = B_d11;
            changeButton(47, b);
        }

        private void B_d12_Click(object sender, EventArgs e)
        {
            Button b = B_d12;
            changeButton(48, b);
        }

        private void B_e1_Click(object sender, EventArgs e)
        {
            Button b = B_e1;
            changeButton(49, b);
        }

        private void B_e2_Click(object sender, EventArgs e)
        {
            Button b = B_e2;
            changeButton(50, b);
        }

        private void B_e3_Click(object sender, EventArgs e)
        {
            Button b = B_e3;
            changeButton(51, b);
        }

        private void B_e4_Click(object sender, EventArgs e)
        {
            Button b = B_e4;
            changeButton(52, b);
        }

        private void B_e5_Click(object sender, EventArgs e)
        {
            Button b = B_e5;
            changeButton(53, b);
        }

        private void B_e6_Click(object sender, EventArgs e)
        {
            Button b = B_e6;
            changeButton(54, b);
        }

        private void B_e7_Click(object sender, EventArgs e)
        {
            Button b = B_e7;
            changeButton(55, b);
        }

        private void B_e8_Click(object sender, EventArgs e)
        {
            Button b = B_e8;
            changeButton(56, b);
        }

        private void B_e9_Click(object sender, EventArgs e)
        {
            Button b = B_e9;
            changeButton(57, b);
        }

        private void B_e10_Click(object sender, EventArgs e)
        {
            Button b = B_e10;
            changeButton(58, b);
        }

        private void B_e11_Click(object sender, EventArgs e)
        {
            Button b = B_e11;
            changeButton(59, b);
        }

        private void B_e12_Click(object sender, EventArgs e)
        {
            Button b = B_e12;
            changeButton(60, b);
        }

        private void B_f1_Click(object sender, EventArgs e)
        {
            Button b = B_f1;
            changeButton(61, b);
        }

        private void B_f2_Click(object sender, EventArgs e)
        {
            Button b = B_f2;
            changeButton(62, b);
        }

        private void B_f3_Click(object sender, EventArgs e)
        {
            Button b = B_f3;
            changeButton(63, b);
        }

        private void B_f4_Click(object sender, EventArgs e)
        {
            Button b = B_f4;
            changeButton(64, b);
        }

        private void B_f5_Click(object sender, EventArgs e)
        {
            Button b = B_f5;
            changeButton(65, b);
        }

        private void B_f6_Click(object sender, EventArgs e)
        {
            Button b = B_f6;
            changeButton(66, b);
        }

        private void B_f7_Click(object sender, EventArgs e)
        {
            Button b = B_f7;
            changeButton(67, b);
        }

        private void B_f8_Click(object sender, EventArgs e)
        {
            Button b = B_f8;
            changeButton(68, b);
        }

        private void B_f9_Click(object sender, EventArgs e)
        {
            Button b = B_f9;
            changeButton(69, b);
        }

        private void B_f10_Click(object sender, EventArgs e)
        {
            Button b = B_f10;
            changeButton(70, b);
        }

        private void B_f11_Click(object sender, EventArgs e)
        {
            Button b = B_f11;
            changeButton(71, b);
        }

        private void B_f12_Click(object sender, EventArgs e)
        {
            Button b = B_f12;
            changeButton(72, b);
        }

        private void B_g1_Click(object sender, EventArgs e)
        {
            Button b = B_g1;
            changeButton(73, b);
        }

        private void B_g2_Click(object sender, EventArgs e)
        {
            Button b = B_g2;
            changeButton(74, b);
        }

        private void B_g3_Click(object sender, EventArgs e)
        {
            Button b = B_g3;
            changeButton(75, b);
        }

        private void B_g4_Click(object sender, EventArgs e)
        {
            Button b = B_g4;
            changeButton(76, b);
        }

        private void B_g5_Click(object sender, EventArgs e)
        {
            Button b = B_g5;
            changeButton(77, b);
        }

        private void B_g6_Click(object sender, EventArgs e)
        {
            Button b = B_g6;
            changeButton(78, b);
        }

        private void B_g7_Click(object sender, EventArgs e)
        {
            Button b = B_g7;
            changeButton(79, b);
        }

        private void B_g8_Click(object sender, EventArgs e)
        {
            Button b = B_g8;
            changeButton(80, b);
        }

        private void B_g9_Click(object sender, EventArgs e)
        {
            Button b = B_g9;
            changeButton(81, b);
        }

        private void B_g10_Click(object sender, EventArgs e)
        {
            Button b = B_g10;
            changeButton(82, b);
        }

        private void B_g11_Click(object sender, EventArgs e)
        {
            Button b = B_g11;
            changeButton(83, b);
        }

        private void B_g12_Click(object sender, EventArgs e)
        {
            Button b = B_g12;
            changeButton(84, b);
        }

        private void B_h1_Click(object sender, EventArgs e)
        {
            Button b = B_h1;
            changeButton(85, b);
        }

        private void B_h2_Click(object sender, EventArgs e)
        {
            Button b = B_h2;
            changeButton(86, b);
        }

        private void B_h3_Click(object sender, EventArgs e)
        {
            Button b = B_h3;
            changeButton(87, b);
        }

        private void B_h4_Click(object sender, EventArgs e)
        {
            Button b = B_h4;
            changeButton(88, b);
        }

        private void B_h5_Click(object sender, EventArgs e)
        {
            Button b = B_h5;
            changeButton(89, b);
        }

        private void B_h6_Click(object sender, EventArgs e)
        {
            Button b = B_h6;
            changeButton(90, b);
        }

        private void B_h7_Click(object sender, EventArgs e)
        {
            Button b = B_h7;
            changeButton(91, b);
        }

        private void B_h8_Click(object sender, EventArgs e)
        {
            Button b = B_h8;
            changeButton(92, b);
        }

        private void B_h9_Click(object sender, EventArgs e)
        {
            Button b = B_h9;
            changeButton(93, b);
        }

        private void B_h10_Click(object sender, EventArgs e)
        {
            Button b = B_h10;
            changeButton(94, b);
        }

        private void B_h11_Click(object sender, EventArgs e)
        {
            Button b = B_h11;
            changeButton(95, b);
        }

        private void B_h12_Click(object sender, EventArgs e)
        {
            Button b = B_h12;
            changeButton(96, b);
        }

        private void Cerca_P_Click(object sender, EventArgs e)
        {
            if (B_a1.Text != "-")
            {
                panel6.Visible = true;
                panel6.Enabled = true;
                panel7.Enabled = false;
            }
            else
            {
                panel7.Enabled = false;
                panel3.Enabled = true;
                Cerca_Patogeno_db();
                Cerca_P.Enabled = false;

            }

        }

        private void Mod_Piastra_Click(object sender, EventArgs e)
        {
            panel7.Enabled = true;
            panel6.Enabled = false;
            panel6.Visible = false;
        }

        private void Reset_function()
        {
            //a
            B_a1.Text = "-";
            B_a2.Text = "-";
            B_a3.Text = "-";
            B_a4.Text = "-";
            B_a5.Text = "-";
            B_a6.Text = "-";
            B_a7.Text = "-";
            B_a8.Text = "-";
            B_a9.Text = "-";
            B_a10.Text = "-";
            B_a11.Text = "-";
            B_a12.Text = "-";

            B_a1.BackColor = Color.White;
            B_a2.BackColor = Color.White;
            B_a3.BackColor = Color.White;
            B_a4.BackColor = Color.White;
            B_a5.BackColor = Color.White;
            B_a6.BackColor = Color.White;
            B_a7.BackColor = Color.White;
            B_a8.BackColor = Color.White;
            B_a9.BackColor = Color.White;
            B_a10.BackColor = Color.White;
            B_a11.BackColor = Color.White;
            B_a12.BackColor = Color.White;
            //b
            B_b1.Text = "-";
            B_b2.Text = "-";
            B_b3.Text = "-";
            B_b4.Text = "-";
            B_b5.Text = "-";
            B_b6.Text = "-";
            B_b17.Text = "-";
            B_b18.Text = "-";
            B_b9.Text = "-";
            B_b10.Text = "-";
            B_b11.Text = "-";
            B_b12.Text = "-";

            B_b1.BackColor = Color.White;
            B_b2.BackColor = Color.White;
            B_b3.BackColor = Color.White;
            B_b4.BackColor = Color.White;
            B_b5.BackColor = Color.White;
            B_b6.BackColor = Color.White;
            B_b17.BackColor = Color.White;
            B_b18.BackColor = Color.White;
            B_b9.BackColor = Color.White;
            B_b10.BackColor = Color.White;
            B_b11.BackColor = Color.White;
            B_b12.BackColor = Color.White;

            //c
            B_c1.Text = "-";
            B_c2.Text = "-";
            B_c3.Text = "-";
            B_c4.Text = "-";
            B_c5.Text = "-";
            B_c6.Text = "-";
            B_c7.Text = "-";
            B_c8.Text = "-";
            B_c9.Text = "-";
            B_c10.Text = "-";
            B_c11.Text = "-";
            B_c12.Text = "-";

            B_c1.BackColor = Color.White;
            B_c2.BackColor = Color.White;
            B_c3.BackColor = Color.White;
            B_c4.BackColor = Color.White;
            B_c5.BackColor = Color.White;
            B_c6.BackColor = Color.White;
            B_c7.BackColor = Color.White;
            B_c8.BackColor = Color.White;
            B_c9.BackColor = Color.White;
            B_c10.BackColor = Color.White;
            B_c11.BackColor = Color.White;
            B_c12.BackColor = Color.White;

            //d
            B_d1.Text = "-";
            B_d2.Text = "-";
            B_d3.Text = "-";
            B_d4.Text = "-";
            B_d5.Text = "-";
            B_d6.Text = "-";
            B_d7.Text = "-";
            B_d8.Text = "-";
            B_d9.Text = "-";
            B_d10.Text = "-";
            B_d11.Text = "-";
            B_d12.Text = "-";

            B_d1.BackColor = Color.White;
            B_d2.BackColor = Color.White;
            B_d3.BackColor = Color.White;
            B_d4.BackColor = Color.White;
            B_d5.BackColor = Color.White;
            B_d6.BackColor = Color.White;
            B_d7.BackColor = Color.White;
            B_d8.BackColor = Color.White;
            B_d9.BackColor = Color.White;
            B_d10.BackColor = Color.White;
            B_d11.BackColor = Color.White;
            B_d12.BackColor = Color.White;

            //e
            B_e1.Text = "-";
            B_e2.Text = "-";
            B_e3.Text = "-";
            B_e4.Text = "-";
            B_e5.Text = "-";
            B_e6.Text = "-";
            B_e7.Text = "-";
            B_e8.Text = "-";
            B_e9.Text = "-";
            B_e10.Text = "-";
            B_e11.Text = "-";
            B_e12.Text = "-";

            B_e1.BackColor = Color.White;
            B_e2.BackColor = Color.White;
            B_e3.BackColor = Color.White;
            B_e4.BackColor = Color.White;
            B_e5.BackColor = Color.White;
            B_e6.BackColor = Color.White;
            B_e7.BackColor = Color.White;
            B_e8.BackColor = Color.White;
            B_e9.BackColor = Color.White;
            B_e10.BackColor = Color.White;
            B_e11.BackColor = Color.White;
            B_e12.BackColor = Color.White;

            //f
            B_f1.Text = "-";
            B_f2.Text = "-";
            B_f3.Text = "-";
            B_f4.Text = "-";
            B_f5.Text = "-";
            B_f6.Text = "-";
            B_f7.Text = "-";
            B_f8.Text = "-";
            B_f9.Text = "-";
            B_f10.Text = "-";
            B_f11.Text = "-";
            B_f12.Text = "-";

            B_f1.BackColor = Color.White;
            B_f2.BackColor = Color.White;
            B_f3.BackColor = Color.White;
            B_f4.BackColor = Color.White;
            B_f5.BackColor = Color.White;
            B_f6.BackColor = Color.White;
            B_f7.BackColor = Color.White;
            B_f8.BackColor = Color.White;
            B_f9.BackColor = Color.White;
            B_f10.BackColor = Color.White;
            B_f11.BackColor = Color.White;
            B_f12.BackColor = Color.White;

            //g
            B_g1.Text = "-";
            B_g2.Text = "-";
            B_g3.Text = "-";
            B_g4.Text = "-";
            B_g5.Text = "-";
            B_g6.Text = "-";
            B_g7.Text = "-";
            B_g8.Text = "-";
            B_g9.Text = "-";
            B_g10.Text = "-";
            B_g11.Text = "-";
            B_g12.Text = "-";

            B_g1.BackColor = Color.White;
            B_g2.BackColor = Color.White;
            B_g3.BackColor = Color.White;
            B_g4.BackColor = Color.White;
            B_g5.BackColor = Color.White;
            B_g6.BackColor = Color.White;
            B_g7.BackColor = Color.White;
            B_g8.BackColor = Color.White;
            B_g9.BackColor = Color.White;
            B_g10.BackColor = Color.White;
            B_g11.BackColor = Color.White;
            B_g12.BackColor = Color.White;

            //h
            B_h1.Text = "-";
            B_h2.Text = "-";
            B_h3.Text = "-";
            B_h4.Text = "-";
            B_h5.Text = "-";
            B_h6.Text = "-";
            B_h7.Text = "-";
            B_h8.Text = "-";
            B_h9.Text = "-";
            B_h10.Text = "-";
            B_h11.Text = "-";
            B_h12.Text = "-";

            B_h1.BackColor = Color.White;
            B_h2.BackColor = Color.White;
            B_h3.BackColor = Color.White;
            B_h4.BackColor = Color.White;
            B_h5.BackColor = Color.White;
            B_h6.BackColor = Color.White;
            B_h7.BackColor = Color.White;
            B_h8.BackColor = Color.White;
            B_h9.BackColor = Color.White;
            B_h10.BackColor = Color.White;
            B_h11.BackColor = Color.White;
            B_h12.BackColor = Color.White;

            //panel
            panel3.Enabled = false;
            panel6.Visible = false;
            panel6.Enabled = false;
            panel8.Visible = false;
            panel8.Enabled = false;
            panel9.Enabled = false;
            panel9.Visible = false;
            panel10.Enabled = false;
            panel10.Visible = false;

            //labels
            label33.Visible = false;
            label35.Visible = false;
            label38.Visible = false;
            label39.Visible = false;

            //button
            Cerca_P.Enabled = true;

        }

        private void Reset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Vuoi resettare la piastra? ATTENZIONE: premendo 'SI' tutti i pozzetti verranno riportati a -", "ATTENZIONE AZIONE INREVERSIBILE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                Reset_function();
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
            
        }

        private void Reset_2_Click(object sender, EventArgs e)
        {
            Reset_function();
            panel7.Enabled = true;
            panel6.Enabled = false;
            panel6.Visible = false;
        }

        int Controllo()
        {
            return 1;
        }

        private void Restt50_Click(object sender, EventArgs e)
        {
            panel9.Enabled = false;
            panel9.Visible = false;
            Reset_function();
        }

        private void Ins_new_Click(object sender, EventArgs e)
        {
            panel9.Enabled = false;
            panel9.Visible = false;
            if (B_a1.Text != "-")
            {
                panel6.Visible = true;
                panel6.Enabled = true;
                panel7.Enabled = false;
            }
            else
            {
                panel7.Enabled = false;
                panel8.Visible = true;
                panel8.Enabled = true;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel7.Enabled = true;
            panel6.Enabled = false;
            panel6.Visible = false;
            panel9.Enabled = false;
            panel9.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Anagrafica();
            InDb();
            MessageBox.Show("Salvataggio Avvenuto correttamente");
        }

        private void InDb()
        {
            
            try
            {
                OleDbCommand Insert;

                String query;
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");


                OleDbParameter oleDbParameter;
                //query = "INSERT INTO Libro (Titolo, Autore, Prezzo, Anno, Editore, Collana, Sconto) VALUES(?,?,?,?,?,?,?);";

                query = "INSERT INTO Piastra (N_Piastra,Data,Tecnico,C_Vegetale,T_Incubazione,Nome_Azienda,Località,Percentuale,Patogeno) VALUES(?,?,?,?,?,?,?,?,?);";
                connessione.Open();
                Insert = new OleDbCommand(query, connessione);               
                             
                oleDbParameter = Insert.Parameters.Add("@Nome_Azienda", OleDbType.Char);
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Nome Azienda!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox1.Clear();
                    textBox1.Focus();
                    return;
                }
                oleDbParameter.Value = azienda;

                oleDbParameter = Insert.Parameters.Add("@Località", OleDbType.Char);
                if (textBox2.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Nome Località!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox2.Clear();
                    textBox2.Focus();
                    return;
                }
                oleDbParameter.Value = località;

                oleDbParameter = Insert.Parameters.Add("@N_Piastra", OleDbType.Char);
                if (textBox3.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Numero Piastra!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox3.Clear();
                    textBox3.Focus();
                    return;
                }
                oleDbParameter.Value = n_piastra;

                oleDbParameter = Insert.Parameters.Add("@C_Vegetale", OleDbType.Char);
                if (textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Campione Vegetale!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox4.Clear();
                    textBox4.Focus();
                    return;
                }
                oleDbParameter.Value = campione;

                oleDbParameter = Insert.Parameters.Add("@T_Incubazione", OleDbType.Char);
                if (textBox5.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Numero Piastra!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox5.Clear();
                    textBox5.Focus();
                    return;
                }
                oleDbParameter.Value = incubazione;

                oleDbParameter = Insert.Parameters.Add("@Data", OleDbType.Char);
                if (textBox6.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Data!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox6.Clear();
                    textBox6.Focus();
                    return;
                }
                oleDbParameter.Value = data;

                oleDbParameter = Insert.Parameters.Add("@Tecnico", OleDbType.Char);
                if (textBox7.Text.Trim() == "")
                {
                    MessageBox.Show("Errore nel campo Tecnico!", "ERRORE", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox7.Clear();
                    textBox7.Focus();
                    return;
                }
                oleDbParameter.Value = tecnico;

                oleDbParameter = Insert.Parameters.Add("@Percentuale", OleDbType.Char);
                oleDbParameter.Value = Percentuale;

                oleDbParameter = Insert.Parameters.Add("@Patogeno", OleDbType.Char);
                oleDbParameter.Value = patogeno;

                Insert.ExecuteNonQuery();

                connessione.Close();
            }

            catch (Exception ex)
            {
                connessione.Close(); // chiusura connessione in caso di errore
                MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
            }

            int z = 0;

            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                string query = "SELECT LAST (Piastra.ID_Piastra) FROM Piastra;";
                connessione.Open();

                OleDbDataReader Leggo;
                OleDbCommand Comn;
                Comn = new OleDbCommand(query, connessione);
                Leggo = Comn.ExecuteReader();

                if (Leggo.HasRows)
                {                   

                    while (Leggo.Read())
                    {
                        lastIdPi = Leggo[0].ToString();
                        z = Convert.ToInt32(lastIdPi);
                    }
                    Leggo.Close();
                    connessione.Close();

                    OleDbCommand ins;
                    OleDbParameter oleDbParameter;
                    //query = "INSERT INTO Libro (Titolo, Autore, Prezzo, Anno, Editore, Collana, Sconto) VALUES(?,?,?,?,?,?,?);";
                    query = "INSERT INTO PatToPias (ID_Piastra,ID_Patogeno) VALUES(?,?);";

                    ins = new OleDbCommand(query, connessione);
                    connessione.Open();


                    oleDbParameter = ins.Parameters.Add("@ID_Piastra", OleDbType.Numeric);
                    oleDbParameter.Value = z;


                    oleDbParameter = ins.Parameters.Add("@ID_Patogeno", OleDbType.Numeric);
                    oleDbParameter.Value = lastIdPa;

                    ins.ExecuteNonQuery();

                    connessione.Close();
                }
            }

            catch (Exception ex)
            {
                connessione.Close(); // chiusura connessione in caso di errore
                MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
            }

        }

        private void dgwDati()
        {
            int l;
            l = dgw_Out.CurrentRow.Index;
            string lbl33 = Convert.ToString(dgw_Out.Rows[l].Cells[1].Value);
            string lbl35 = Convert.ToString(dgw_Out.Rows[l].Cells[3].Value);
            lastIdPa = Convert.ToInt32(dgw_Out.Rows[l].Cells[0].Value);

            patogeno = Convert.ToString(dgw_Out.Rows[l].Cells[1].Value);

            label33.Text = (lbl33);
            label35.Text = (lbl35 + "%");

            label38.Visible = true;
            label38.Text = (lbl33);

            label39.Visible = true;
            label39.Text = (lbl35 + "%");
        }

        private void dgw_Out_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void dgw_Out_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void dgw_Out_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void dgw_Out_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgwDati();
        }

        private void dgw_Out_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwDati();
        }

        private void dgw_Out_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgwDati();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GestisciP_Click(object sender, EventArgs e)
        {
            Form frm4 = new Form4();
            frm4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Nuova Lettura' permette di abilitare la piastra per l'inserimento dei pozzetti.", "Informazioni tasto: Nuova Lettura", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Gestione Patogeni' permette di abilitare la sezione del programma per la modifica ed eliminazione dei patogeni dal sistema.", "Informazioni tasto: Gestione Patogeni", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Stampa referto Precedente' permette di abilitare la sezione del programma per la ricerca, visualizzazione e stampa di referti precedentemente salvati.", "Informazioni tasto: Stampa Referto Precedente", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Cerca' permette di cercare nel sistema corrispondenze tra la piastra ed i patogeni.", "Informazioni tasto: Cerca", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Inserisci nuovo patogeno' permette di inserire la piastra come un nuovo patogeno salvandola con un nome scelto dal utente.", "Informazioni tasto: Inserisci Nuovo Patogeno", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Reset' permette di pulire la piastra per portarla allo stato iniziale.", "Informazioni tasto: Reset", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Salva' permette di salvare i dati che sono stati inseriti negli appositi campi sopra il tasto, compreso il patogeno e la percentuale di similitudine.", "Informazioni tasto: Salva", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Il tasto 'Stampa' permette di stampare i dati che sono stati inseriti negli appositi campi sopra il tasto, compreso il patogeno e la percentuale di similitudine.", "Informazioni tasto: Stampa", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show("La tabella dei risultati mostra tutti i risultati corrispondenti ai parametri inseriti; Per selezionare un patogeno come il risultato adeguato, cliccare una qualsiasi delle caselle sulla riga corrispondente.", "Informazioni: Tabella dei risultati", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ogniuno dei tasti della tabella rappresenta un pozzetto identificato da una lettera ed un numero che corrispondono alla controparte reale. Ad ogni click il valore del singolo pozzetto verra modificato da -(negativo)  a /(neutro) e da /(neutro) a +(positivo), da +(positivo) a -(negativo).", "Informazioni: Piastra", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            Anagrafica();

            Form2 frm2 = new Form2(lastIdPa,  azienda, località, tecnico, data, campione, incubazione,  ParogenoFine, Percentuale, n_piastra);
            frm2.Show();

            //lastIdPa

            panel10.Enabled = true;
            panel10.Visible = true;

            label38.Text = (label33.Text);
            label39.Text = (label35.Text);

            label38.Visible = true;
            label39.Visible = true;

            //this.Size = new Size(595, 842);

            
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (B_a1.Text != "-")
            {
                panel6.Visible = true;
                panel6.Enabled = true;
                panel7.Enabled = false;
            }
            else
            {
                panel7.Enabled = false;               
                panel8.Visible = true;
                panel8.Enabled = true;
                
            }
        }

        private void Data_In()
        {
            int n = 0;
            //a
            GetD[n] =Convert.ToString(B_a1.Text);
            n++;
            GetD[n] = Convert.ToString(B_a2.Text);
            n++;
            GetD[n] = Convert.ToString(B_a3.Text);
            n++;
            GetD[n] = Convert.ToString(B_a4.Text);
            n++;
            GetD[n] = Convert.ToString(B_a5.Text);
            n++;
            GetD[n] = Convert.ToString(B_a6.Text);
            n++;
            GetD[n] = Convert.ToString(B_a7.Text);
            n++;
            GetD[n] = Convert.ToString(B_a8.Text);
            n++;
            GetD[n] = Convert.ToString(B_a9.Text);
            n++;
            GetD[n] = Convert.ToString(B_a10.Text);
            n++;
            GetD[n] = Convert.ToString(B_a11.Text);
            n++;
            GetD[n] = Convert.ToString(B_a12.Text);
            n++;

            //b
            GetD[n] = Convert.ToString(B_b1.Text);
            n++;
            GetD[n] = Convert.ToString(B_b2.Text);
            n++;
            GetD[n] = Convert.ToString(B_b3.Text);
            n++;
            GetD[n] = Convert.ToString(B_b4.Text);
            n++;
            GetD[n] = Convert.ToString(B_b5.Text);
            n++;
            GetD[n] = Convert.ToString(B_b6.Text);
            n++;
            GetD[n] = Convert.ToString(B_b17.Text);
            n++;
            GetD[n] = Convert.ToString(B_b18.Text);
            n++;
            GetD[n] = Convert.ToString(B_b9.Text);
            n++;
            GetD[n] = Convert.ToString(B_b10.Text);
            n++;
            GetD[n] = Convert.ToString(B_b11.Text);
            n++;
            GetD[n] = Convert.ToString(B_b12.Text);
            n++;

            //c
            GetD[n] = Convert.ToString(B_c1.Text);
            n++;
            GetD[n] = Convert.ToString(B_c2.Text);
            n++;
            GetD[n] = Convert.ToString(B_c3.Text);
            n++;
            GetD[n] = Convert.ToString(B_c4.Text);
            n++;
            GetD[n] = Convert.ToString(B_c5.Text);
            n++;
            GetD[n] = Convert.ToString(B_c6.Text);
            n++;
            GetD[n] = Convert.ToString(B_c7.Text);
            n++;
            GetD[n] = Convert.ToString(B_c8.Text);
            n++;
            GetD[n] = Convert.ToString(B_c9.Text);
            n++;
            GetD[n] = Convert.ToString(B_c10.Text);
            n++;
            GetD[n] = Convert.ToString(B_c11.Text);
            n++;
            GetD[n] = Convert.ToString(B_c12.Text);
            n++;

            //d
            GetD[n] = Convert.ToString(B_d1.Text);
            n++;
            GetD[n] = Convert.ToString(B_d2.Text);
            n++;
            GetD[n] = Convert.ToString(B_d3.Text);
            n++;
            GetD[n] = Convert.ToString(B_d4.Text);
            n++;
            GetD[n] = Convert.ToString(B_d5.Text);
            n++;
            GetD[n] = Convert.ToString(B_d6.Text);
            n++;
            GetD[n] = Convert.ToString(B_d7.Text);
            n++;
            GetD[n] = Convert.ToString(B_d8.Text);
            n++;
            GetD[n] = Convert.ToString(B_d9.Text);
            n++;
            GetD[n] = Convert.ToString(B_d10.Text);
            n++;
            GetD[n] = Convert.ToString(B_d11.Text);
            n++;
            GetD[n] = Convert.ToString(B_d12.Text);
            n++;

            //e
            GetD[n] = Convert.ToString(B_e1.Text);
            n++;
            GetD[n] = Convert.ToString(B_e2.Text);
            n++;
            GetD[n] = Convert.ToString(B_e3.Text);
            n++;
            GetD[n] = Convert.ToString(B_e4.Text);
            n++;
            GetD[n] = Convert.ToString(B_e5.Text);
            n++;
            GetD[n] = Convert.ToString(B_e6.Text);
            n++;
            GetD[n] = Convert.ToString(B_e7.Text);
            n++;
            GetD[n] = Convert.ToString(B_e8.Text);
            n++;
            GetD[n] = Convert.ToString(B_e9.Text);
            n++;
            GetD[n] = Convert.ToString(B_e10.Text);
            n++;
            GetD[n] = Convert.ToString(B_e11.Text);
            n++;
            GetD[n] = Convert.ToString(B_e12.Text);
            n++;

            //f
            GetD[n] = Convert.ToString(B_f1.Text);
            n++;
            GetD[n] = Convert.ToString(B_f2.Text);
            n++;
            GetD[n] = Convert.ToString(B_f3.Text);
            n++;
            GetD[n] = Convert.ToString(B_f4.Text);
            n++;
            GetD[n] = Convert.ToString(B_f5.Text);
            n++;
            GetD[n] = Convert.ToString(B_f6.Text);
            n++;
            GetD[n] = Convert.ToString(B_f7.Text);
            n++;
            GetD[n] = Convert.ToString(B_f8.Text);
            n++;
            GetD[n] = Convert.ToString(B_f9.Text);
            n++;
            GetD[n] = Convert.ToString(B_f10.Text);
            n++;
            GetD[n] = Convert.ToString(B_f11.Text);
            n++;
            GetD[n] = Convert.ToString(B_f12.Text);
            n++;

            //g
            GetD[n] = Convert.ToString(B_g1.Text);
            n++;
            GetD[n] = Convert.ToString(B_g2.Text);
            n++;
            GetD[n] = Convert.ToString(B_g3.Text);
            n++;
            GetD[n] = Convert.ToString(B_g4.Text);
            n++;
            GetD[n] = Convert.ToString(B_g5.Text);
            n++;
            GetD[n] = Convert.ToString(B_g6.Text);
            n++;
            GetD[n] = Convert.ToString(B_g7.Text);
            n++;
            GetD[n] = Convert.ToString(B_g8.Text);
            n++;
            GetD[n] = Convert.ToString(B_g9.Text);
            n++;
            GetD[n] = Convert.ToString(B_g10.Text);
            n++;
            GetD[n] = Convert.ToString(B_g11.Text);
            n++;
            GetD[n] = Convert.ToString(B_g12.Text);
            n++;

            //h
            GetD[n] = Convert.ToString(B_h1.Text);
            n++;
            GetD[n] = Convert.ToString(B_h2.Text);
            n++;
            GetD[n] = Convert.ToString(B_h3.Text);
            n++;
            GetD[n] = Convert.ToString(B_h4.Text);
            n++;
            GetD[n] = Convert.ToString(B_h5.Text);
            n++;
            GetD[n] = Convert.ToString(B_h6.Text);
            n++;
            GetD[n] = Convert.ToString(B_h7.Text);
            n++;
            GetD[n] = Convert.ToString(B_h8.Text);
            n++;
            GetD[n] = Convert.ToString(B_h9.Text);
            n++;
            GetD[n] = Convert.ToString(B_h10.Text);
            n++;
            GetD[n] = Convert.ToString(B_h11.Text);
            n++;
            GetD[n] = Convert.ToString(B_h12.Text);
            n++;
        }

        private void Anagrafica()
        {
            azienda = Convert.ToString(textBox1.Text);
            località = Convert.ToString(textBox2.Text);
            n_piastra = Convert.ToString(textBox3.Text);
            campione = Convert.ToString(textBox4.Text);
            incubazione = Convert.ToString(textBox5.Text);
            data = Convert.ToString(textBox6.Text);
            tecnico = Convert.ToString(textBox7.Text);
            ParogenoFine = Convert.ToString(label33.Text);
            Percentuale = Convert.ToString(label35.Text); 
        }

        private void Inserisci_in_db(string nome)
        {            
            Data_In();
            int n = 0;

            try
            {
                OleDbCommand Insert;

                String query;
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");


                OleDbParameter oleDbParameter;
                query = "INSERT INTO Patogeni (Nome,a1,a2,a3,a4,a5,a6,a7,a8,a9,a10,a11,a12,b1,b2,b3,b4,b5,b6,b7,b8,b9,b10,b11,b12,c1,c2,c3,c4,c5,c6,c7,c8,c9,c10,c11,c12,d1,d2,d3,d4,d5,d6,d7,d8,d9,d10,d11,d12,e1,e2,e3,e4,e5,e6,e7,e8,e9,e10,e11,e12,f1,f2,f3,f4,f5,f6,f7,f8,f9,f10,f11,f12,g1,g2,g3,g4,g5,g6,g7,g8,g9,g10,g11,g12,h1,h2,h3,h4,h5,h6,h7,h8,h9,h10,h11,h12) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?);";
                connessione.Open();
                Insert = new OleDbCommand(query, connessione);


                oleDbParameter = Insert.Parameters.Add("@Nome", OleDbType.Char);
                oleDbParameter.Value = nome;

                //a
                oleDbParameter = Insert.Parameters.Add("@a1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@a12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //b
                oleDbParameter = Insert.Parameters.Add("@b1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@b12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //c
                oleDbParameter = Insert.Parameters.Add("@c1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@c12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //d
                oleDbParameter = Insert.Parameters.Add("@d1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@d12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //e
                oleDbParameter = Insert.Parameters.Add("@e1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@e12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //f
                oleDbParameter = Insert.Parameters.Add("@f1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@f12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //g
                oleDbParameter = Insert.Parameters.Add("@g1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@g12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;

                //h
                oleDbParameter = Insert.Parameters.Add("@h1", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h2", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h3", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h4", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h5", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h6", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h7", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h8", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h9", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h10", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h11", OleDbType.Char);
                oleDbParameter.Value = GetD[n];
                n++;
                oleDbParameter = Insert.Parameters.Add("@h12", OleDbType.Char);
                oleDbParameter.Value = GetD[n];               

                Insert.ExecuteNonQuery();

                connessione.Close();
            }

            catch (Exception ex)
            {
                connessione.Close(); // chiusura connessione in caso di errore
                MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
            }
        }

        private void Cerca_Patogeno_db()
        {
            int j = 0;
            int z = 0;
            int p = 0;
            

            double[] ordine = new double[3];
            

            Data_In();
            try
            {
                connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                string query = "SELECT LAST (Patogeni.ID_Patogeno) FROM Patogeni;";
                connessione.Open();

                OleDbDataReader Leggo;
                OleDbCommand Comn;
                Comn = new OleDbCommand(query, connessione);
                Leggo = Comn.ExecuteReader();

                if (Leggo.HasRows)  
                {                    
                    string ID;
                    
                    while (Leggo.Read())  
                    {
                        ID = Leggo[0].ToString();
                        j = Convert.ToInt32(ID);
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

            for(int i=1; i<=j; i++)
               {
                int x = 96;
                string ID;
                
                try
                {
                    connessione = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; " + "Data Source=" + percorsoDB + ";");

                    string query = "SELECT * FROM Patogeni WHERE Patogeni.ID_Patogeno = " + i + ";";
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
                            string[] caratteristiche = new string[96];

                            ID = Leggo[0].ToString();
                            s = Leggo[1].ToString();

                             for (int c=2; n<96; c++)
                            {
                             caratteristiche[n] = Leggo[c].ToString();
                                string f, v;
                                f = caratteristiche[n];
                                v = GetD[n];
                                if (f!=v)
                                {
                                    
                                    x--;
                                    if (x < 48)
                                    {
                                        n = 97;
                                    }
                                }

                                n++;
                             }
                                                                                                                                   
                        }
                        Leggo.Close();
                        connessione.Close();
                    }
                    else
                    {
                        x = 0;
                    }
                }

                catch (Exception ex)
                {
                    connessione.Close(); // chiusura connessione in caso di errore
                    MessageBox.Show(ex.StackTrace + "..." + ex.Message, "Errore apertura database");
                }
                
               if (x > 48)
                {
                    z++;
                    double flag = Convert.ToDouble(x);
                    double perc = (flag*100/ 96) ;
                    ordine[1] = perc;
                    dgw_Out.Rows.Add();
                    dgw_Out.Rows[p].Cells[0].Value = i;
                    dgw_Out.Rows[p].Cells[1].Value = s;
                    dgw_Out.Rows[p].Cells[2].Value = perc;
                    dgw_Out.Rows[p].Cells[3].Value = x;
                    p++;

                    if (ordine[1]>ordine[2])
                    {
                        ordine[2] = ordine[1];
                        temp = s;
                        lastIdPa = i;
                    }
               }

                         

            }

            label33.Text = ""+temp;
            label35.Text =""+Convert.ToString(ordine[2])+"%";
            label33.Visible = true;
            label35.Visible = true;
            
            if (z == 0)
            {
                panel9.Enabled = true;
                panel9.Visible = true;
            }

        }       

        private void addInDb_Click(object sender, EventArgs e)
        {
            string nome;
            nome = Convert.ToString(txb_nome_p.Text);
            Inserisci_in_db(nome);

            panel8.Enabled = false;
            panel8.Visible = false;

            MessageBox.Show("Patogeno inserito correttamente");
        }
    }
}
