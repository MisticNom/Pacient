using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{

    public partial class FormaLogare : Form
    {
        string admin;
        SqlConnection conect = new SqlConnection(@"Data Source=pacienti.database.windows.net;Initial Catalog=database;Integrated Security=False;User ID=" + Properties.Resources.Cont.ToString() + ";Password=" + Properties.Resources.Parola.ToString() + ";Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public FormaLogare()
        {
            InitializeComponent();
        }

        private void FormaLogare_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            button3.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            else
            {
                string parola = textBox2.Text;
                try
                {
                    SqlCommand comanda = new SqlCommand("select parola from dbo.useri where nume ='" + textBox1.Text + "'", new SqlConnection(conect.ConnectionString));
                    comanda.Connection.Open();
                    if (parola == comanda.ExecuteScalar().ToString())
                    {
                        SqlCommand comanda2 = new SqlCommand("select admin from dbo.useri where nume ='" + textBox1.Text + "'", new SqlConnection(conect.ConnectionString));
                        comanda2.Connection.Open();
                        admin = comanda2.ExecuteScalar().ToString();
                        comanda2.Connection.Close();
                        MessageBox.Show(admin.ToString(), "sad");
                    }
                    else
                    {
                        MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    comanda.Connection.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            refreshtext();

            Form1 formaintrare = new Form1();
            formaintrare.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NetworkInterface.GetIsNetworkAvailable() == false)
            {
                MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    SqlCommand comanda = new SqlCommand("insert into dbo.useri values('" + textBox1.Text + "','" + textBox2.Text + "', '0')", new SqlConnection(conect.ConnectionString));
                    comanda.Connection.Open();
                    comanda.ExecuteNonQuery();
                    MessageBox.Show("Cont Introdus !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    comanda.Connection.Close();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                button2.Show();
                button3.Hide();
                refreshtext();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            button3.Show();
            button2.Hide();
            refreshtext();
        }

        private void refreshtext()
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }
    }
}
