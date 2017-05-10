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
    public partial class Form2 : Form
    {
        //----------------------- INITIALIZARE INTERNET SI BAZA DATE   -----------------------------------------------------------------------------------------------------
       
        // SqlConnection conect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mihai\Desktop\Proiect\Proiect\Database1.mdf;Integrated Security=True");
        SqlConnection conect = new SqlConnection(@"Data Source=pacienti.database.windows.net;Initial Catalog=database;Integrated Security=False;User ID=" + Properties.Resources.Cont.ToString() + ";Password=" + Properties.Resources.Parola.ToString() + ";Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        
        public Form2()
        {
            InitializeComponent();
        }

        //----------------------- FUNCTIE AFISARE TOATE   -----------------------------------------------------------------------------------------------------

        private void afisaredate()
        {

            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                conect.Open();
                SqlCommand comanda = conect.CreateCommand();
                comanda.CommandType = CommandType.Text;
                comanda.CommandText = "select * from dbo.pacienti";
                try
                {
                    comanda.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString(), "Eroare");
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comanda);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conect.Close();
            }
        }

        //----------------------- FORM 2 LOAD   -----------------------------------------------------------------------------------------------------
        //++ CULORI
        private void Form2_Load(object sender, EventArgs e)
        {
            panel1.BackColor= panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            dataGridView1.BackgroundColor=System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            dataGridView1.DefaultCellStyle.BackColor= System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            dataGridView1.GridColor= System.Drawing.ColorTranslator.FromHtml("#424b70");
            afisaredate();
            textBox1.Text = "Cautare dupa Nume";
        }

        //----------------------- TIMER   -----------------------------------------------------------------------------------------------------------

        //buton refresh si inchide
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "Cautare dupa Nume";
            afisaredate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        // pentru textBox
        private void TextInBox(object sender, EventArgs e)
        {
            if(textBox1.Text== "Cautare dupa Nume") textBox1.Text = "";
        }

        private void TextOutBox(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox1.Text==" ")
            {
                textBox1.Text = "Cautare dupa Nume";
            }
        }

        //cautare dupa nume
        private void button3_Click(object sender, EventArgs e)
        {
            string numefull = textBox1.Text;
            string nume = null;
            string prenume = null;
            int ok = 1;
            for(int i = 0; i < numefull.Length; i++)
            {
                if (numefull[i] != ' ' && ok == 1) nume += Char.ToLower(numefull[i]);
                else if(numefull[i] == ' ' && ok == 1)
                {
                    ok = 0;
                }
                else if (ok == 0)
                {
                    prenume += Char.ToLower(numefull[i]);
                }
            }
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                conect.Open();
                SqlCommand comanda = conect.CreateCommand();
                comanda.CommandType = CommandType.Text;
                comanda.CommandText = "select * from dbo.pacienti where (lower(nume)='"+nume+"' and lower(prenume)='"+prenume+ "') or (lower(nume)='"+nume+"') or (lower(prenume)='"+nume+"')";
                try
                {
                    comanda.ExecuteNonQuery();
                }
                catch (Exception p)
                {
                    MessageBox.Show(p.ToString(), "Eroare");
                }
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(comanda);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conect.Close();
            }          
        }
    }
}
