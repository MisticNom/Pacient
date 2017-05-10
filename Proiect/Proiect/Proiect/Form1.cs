using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace Proiect
{


    public partial class Form1 : Form
    {
        // -------------- INIT. INTERNET SI BAZA DATE ---------------------------------------------------------------------------------------------------

        SqlConnection conect = new SqlConnection(@"Data Source=pacienti.database.windows.net;Initial Catalog=database;Integrated Security=False;User ID=" + Properties.Resources.Cont.ToString() + ";Password=" + Properties.Resources.Parola.ToString() + ";Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        int x = 0;
        // -------------------- FUNCTIE RESET TEXT BOX  --------------------------------------------------------------------------------------------------

        private void resetbox()
        {
            textBoxNume.ResetText();
            textBoxPrenume.ResetText();
            textBoxPuls.ResetText();
            textBoxTensiune.ResetText();
            textBoxInfo.ResetText();
            textBoxVarsta.ResetText();
        }

        public Form1()
        {
            InitializeComponent();
        }

        //-----------------------  ADAUGA PACIENT   ----------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNume.Text != "" && textBoxPrenume.Text != "" && textBoxPuls.Text != "" && textBoxTensiune.Text != "" && textBoxVarsta.Text != "")
            {
                if (NetworkInterface.GetIsNetworkAvailable() == false)
                {
                    MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    conect.Open();
                    SqlCommand comanda = conect.CreateCommand();
                    comanda.CommandType = CommandType.Text;
                    comanda.CommandText = "insert into dbo.pacienti values('" + textBoxNume.Text + "','" + textBoxPrenume.Text + "','" + textBoxPuls.Text + "','" + textBoxTensiune.Text + "','" + textBoxVarsta.Text + "','" + textBoxInfo.Text + "')";
                    try
                    {
                        comanda.ExecuteNonQuery();
                        MetPuls MetPuls = new MetPuls();
                        MetPuls.label1.Text = textBoxNume.Text + " " + textBoxPrenume.Text;
                        MetPuls.label2.Text = "Puls:"; 
                        MetPuls.label6.Text= textBoxPuls.Text;
                        MetPuls.label4.Text = "Tensiune:";
                            MetPuls.label7.Text=textBoxTensiune.Text;
                        MetPuls.label5.Text = "Varsta:";
                        MetPuls.label8.Text= textBoxVarsta.Text;
                        MetPuls.Show();
                        resetbox();
                    }
                    catch
                    {
                        MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conect.Close();
                }
            }
            else
            {
                MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //---------------------- STERGE PACIENT --------------------------------------------------------------------------------------------------

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxNume.Text != "" && textBoxPrenume.Text != "")
            {
                if (NetworkInterface.GetIsNetworkAvailable() == false)
                {
                    MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    conect.Open();
                    SqlCommand comanda = conect.CreateCommand();
                    comanda.CommandType = CommandType.Text;
                    comanda.CommandText = "delete from dbo.pacienti where lower(nume)=lower('" + textBoxNume.Text + "') AND lower(prenume)=lower('" + textBoxPrenume.Text + "')";
                    try
                    {
                        comanda.ExecuteNonQuery();
                        MessageBox.Show("Sters cu succes !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        resetbox();
                    }
                    catch
                    {
                        MessageBox.Show("Eroare !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conect.Close();
                }
            }
            else
            {
                MessageBox.Show("Eroare Nume Pacient !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //----------------------  FORM LOAD    --------------------------------------------------------------------------------------------------------
        // + + CULORI
        private void Form1_Load(object sender, EventArgs e)
        {
            butonSterge.Visible = false;
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#EFEFEF");
            panel2.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            label1.ForeColor= System.Drawing.ColorTranslator.FromHtml("#F7F5E6"); 
            label2.ForeColor= System.Drawing.ColorTranslator.FromHtml("#F7F5E6"); 
            label3.ForeColor= System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            label4.ForeColor= System.Drawing.ColorTranslator.FromHtml("#F7F5E6"); 
        }

        // ANIMATII MENIU ------------------------------------------------------------------------
        private void pictureBoxInserare_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxInserare.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
        }
        private void pictureBoxInserare_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxInserare.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
        }
        private void pictureBoxStergere_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxStergere.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
        }
        private void pictureBoxStergere_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxStergere.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
        }
        private void pictureBoxAfisare_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAfisare.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
        }
        private void pictureBoxAfisare_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAfisare.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
        }
        private void pictureBoxIesire_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxIesire.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
        }
        private void pictureBoxIesire_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxIesire.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
        }


        // BUTON MENIU INCHIDERE ---------------------------------------------------
        private void pictureBoxIesire_Click(object sender, EventArgs e)
        {
            Close();
        }
        // BUTON MENIU INSERARE ----------------------------------------------------
        private void pictureBoxInserare_Click(object sender, EventArgs e)
        {
            butonInserare.Visible = true;
            butonSterge.Visible=false;

            textBoxInfo.Show();
            textBoxPuls.Show();
            textBoxTensiune.Show();
            textBoxVarsta.Show();

            labelPuls.Show();
            labelTensiune.Show();
            labelVarsta.Show();
            labelInfo.Show();
        }

        // BUTON MENIU STERGERE -------------------------------------------------------------------------------
        private void pictureBoxStergere_Click(object sender, EventArgs e)
        {
            butonInserare.Visible = false;
            butonSterge.Visible = true;

            textBoxInfo.Hide();
            textBoxPuls.Hide();
            textBoxTensiune.Hide();
            textBoxVarsta.Hide();

            labelPuls.Hide();
            labelTensiune.Hide();
            labelVarsta.Hide();
            labelInfo.Hide();
        }

        // BUTON MENIU AFISARE --------------------------------------------------------
        private void pictureBoxAfisare_Click(object sender, EventArgs e)
        {
            Form2 forma2 = new Form2();
            forma2.Show();
        }

        // PORNIRE ANIMATIE MENIU
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            if (x == 0) { x += 1; pictureBox1.Image = Properties.Resources.menuverde; }
            else
            { x -= 1; pictureBox1.Image = Properties.Resources.menu2; }
        }


        // ANIMATIE MENIU ----------------------------------
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (x) {
                case 0:
                    if (panel1.Location.X > -140)
                    {
                        panel1.Location = new Point(panel1.Location.X - 14, panel1.Location.Y);
                        panel2.Location = new Point(panel2.Location.X - 14, panel2.Location.Y);
                        Refresh();
                    }
                    break;
                case 1:
                    if (panel1.Location.X < 0)
                    {
                        panel1.Location = new Point(panel1.Location.X + 14, panel1.Location.Y);
                        panel2.Location = new Point(panel2.Location.X + 14, panel2.Location.Y);
                        Refresh();
                    }
                    break;
            }
        }
    }
}
