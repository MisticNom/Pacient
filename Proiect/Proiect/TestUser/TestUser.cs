using System;
using Proiect;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;

namespace TestUser
{
    [TestClass]
    
    public class TestUser
    {
        [TestMethod]
        public void Vedem_daca_incarca_user_nou()
        {
            FormaLogare FL = new FormaLogare();
            string nume = "mercur3";
            string password = "mercur3";
            LinkLabelLinkClickedEventArgs x = null;
            Object e = null;
            FL.linkLabel1_LinkClicked(e,x);
            FL.textBox1.Text = nume;
            FL.textBox2.Text = password;
            FL.button3_Click(e,x);
        }
    }
}
