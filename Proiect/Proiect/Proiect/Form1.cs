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
                        // pentru forma 3
                        MetPuls MetPuls = new MetPuls();
                        MetPuls.label1.Text = textBoxNume.Text + " " + textBoxPrenume.Text;
                        MetPuls.label2.Text = "Puls: "+textBoxPuls.Text+"  Tensiune: "+textBoxTensiune.Text+"  Varsta: "+textBoxVarsta.Text;
                        int x = Convert.ToInt16(textBoxPuls.Text);
                        int y = Convert.ToInt16(textBoxTensiune.Text);
                        if(x<=60 && y <= 69)
                        {
                            MetPuls.label3.Text = "Eroare";
                            MetPuls.pictureBox1.Image = Properties.Resources.error;
                            MetPuls.sfat1.Text = "Valori prea mici";
                        }
                        if (x<=60 && (y >= 70 && y <=90))
                        {
                            MetPuls.label3.Text = "Sub Tensiune";
                            MetPuls.pictureBox1.Image = Properties.Resources.error;
                            MetPuls.sfat1.Text = "Adaugarea de sare in alimentatie";
                            MetPuls.sfat2.Text = "Consumul suficient de lichide";
                            MetPuls.sfat3.Text = "Purtarea ciorapilor elastici medicinali";
                            MetPuls.sfat4.Text ="Evitarea ridicarii bruste in picioare";
                            MetPuls.sfat5.Text ="Mese bogate in cereale integrale";
                        }
                        if ((x>=61 && x<=80)&&(y >= 91 && y <= 120))
                        {
                            MetPuls.label3.Text = "Tensiune normala";
                            MetPuls.pictureBox1.Image = Properties.Resources.success;
                            MetPuls.sfat1.Text = "Miscare moderata pe timpul zilei";
                            MetPuls.sfat2.Text = "Adoptarea meselor sanatoase";
                            MetPuls.sfat3.Text = "";
                            MetPuls.sfat4.Text = "";
                            MetPuls.sfat5.Text = "";
                        }
                        if ((x>=81 && x<=90)&&(y >= 121 && y <= 140))
                        {
                            MetPuls.label3.Text = "Pre-hipertensiune";
                            MetPuls.pictureBox1.Image = Properties.Resources.error;
                            MetPuls.sfat1.Text = "Miscare moderata pe timpul zilei";
                            MetPuls.sfat2.Text = "Micsorarea cantitatii sodiului din alimentatie";
                            MetPuls.sfat3.Text = "Mese bogate in legume si fructe";
                            MetPuls.sfat4.Text = "Micsoratea consumului de alcool";
                            MetPuls.sfat5.Text = "Micsorarea ingestiei de colesterol";
                        }
                        if (y >= 141)
                        {
                            MetPuls.label3.Text = "Hipertensiune";
                            MetPuls.pictureBox1.Image = Properties.Resources.error;
                            MetPuls.sfat1.Text = "Miscarea pe timpul zilei";
                            MetPuls.sfat2.Text = "Taierea sodiului din alimentatie";
                            MetPuls.sfat3.Text = "Mese bogate in legume si fructe";
                            MetPuls.sfat4.Text = "Oprirea consumului de alcool";
                            MetPuls.sfat5.Text = "Oprirea consumului de tigari";
                        }
                        MetPuls.Show();
                        //sfarsit forma 3
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
                    comanda.CommandText = "delete from dbo.pacienti where lower(nume)=lower('" + textBoxNume.Text + "') AND lower(prenume)=lower('" + textBoxPrenume.Text + "') AND lower(varsta)=lower('" + textBoxVarsta.Text + "')";
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
            butonInserare.TabStop = true;
            butonInserare.Visible = true;
            butonSterge.Visible=false;
            butonSterge.TabStop = false;

            textBoxInfo.Show();
            textBoxPuls.Show();
            textBoxTensiune.Show();

            labelPuls.Show();
            labelTensiune.Show();
            labelInfo.Show();
        }

        // BUTON MENIU STERGERE -------------------------------------------------------------------------------
        private void pictureBoxStergere_Click(object sender, EventArgs e)
        {
            butonInserare.TabStop = false;
            butonInserare.Visible = false;
            butonSterge.Visible = true;
            butonSterge.TabStop = true;

            textBoxInfo.Hide();
            textBoxPuls.Hide();
            textBoxTensiune.Hide();

            labelPuls.Hide();
            labelTensiune.Hide();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
