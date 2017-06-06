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
        public static Form1 formaintrare = null;
        public static string admin="0";
        SqlConnection conect = new SqlConnection(@"Data Source=pacienti.database.windows.net;Initial Catalog=database;Integrated Security=False;User ID=" + Properties.Resources.Cont.ToString() + ";Password=" + Properties.Resources.Parola.ToString() + ";Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public FormaLogare()
        {
            InitializeComponent();
        }

        private void FormaLogare_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            linkLabel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            linkLabel1.LinkColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            button3.Hide();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentException("Exceptie Date Gresite");
            }
            else
            {
                if (NetworkInterface.GetIsNetworkAvailable() == false)
                {
                    MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new ArgumentException("Exceptie Internet");
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
                        }
                        else
                        {
                            MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new ArgumentException("Exceptie Date Introduse Gresite");
                        }
                        comanda.Connection.Close();
                        formaintrare = new Form1();
                        formaintrare.Show();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new ArgumentException("Exceptie Date Gresite");
                    }
                }
                refreshtext();
            }
        }

        public void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show("Date introduse gresit !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new ArgumentException("Exceptie Date Gresite");
            }
            else
            {
                if (NetworkInterface.GetIsNetworkAvailable() == false)
                {
                    MessageBox.Show("Lipsa internet !", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw new ArgumentException("Exceptie Internet");
                }
                else
                {
                    try
                    {
                        SqlCommand comanda = new SqlCommand("insert into dbo.useri values('" + textBox1.Text + "','" + textBox2.Text + "', '"+admin+"')", new SqlConnection(conect.ConnectionString));
                        comanda.Connection.Open();
                        comanda.ExecuteNonQuery();
                        MessageBox.Show("Cont Introdus !", "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        comanda.Connection.Close();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw new ArgumentException("Exceptie");
                    }
                    button2.Show();
                    button3.Hide();
                    linkLabel1.Show();
                    refreshtext();
                }
            }
        }

        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.Hide();
            button3.Show();
            button2.Hide();
            refreshtext();
        }

        private void refreshtext()
        {
            textBox1.Text = null;
            textBox2.Text = null;
        }

        public void label1_DoubleClick(object sender, EventArgs e)
        {
            if (admin == "0") admin = "1";
            else admin = "0";
        }
    }
}
