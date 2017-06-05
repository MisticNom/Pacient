using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect
{
    public partial class FormaLogare : Form
    {

        public FormaLogare()
        {
            InitializeComponent();
        }

        private void FormaLogare_Load(object sender, EventArgs e)
        {
            BackColor= System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 formaintrare = new Form1();
            formaintrare.Show();
            Hide();
        }
    }
}
