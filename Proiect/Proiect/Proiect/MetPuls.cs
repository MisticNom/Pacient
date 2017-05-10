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
    public partial class MetPuls : Form
    {
        public MetPuls()
        {
            InitializeComponent();
        }
        // + + CULORI
        private void MetPuls_Load(object sender, EventArgs e)
        {
            BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            panel1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            label1.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            label2.BackColor = System.Drawing.ColorTranslator.FromHtml("#424b70");
            label1.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            label2.ForeColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
            label3.BackColor = System.Drawing.ColorTranslator.FromHtml("#F7F5E6");
        }
    }
}
