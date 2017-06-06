using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Proiect;
using System.Windows.Forms;

namespace TestUser
{
    [TestClass]
    public class TestAdmin
    {
        [TestMethod]
        public void TestCreare_Logare_admin()
        {
            FormaLogare FL = new FormaLogare();
            string nume = "admin";
            string password = "admin";
            LinkLabelLinkClickedEventArgs x = null;
            Object e = null;
            FL.label1_DoubleClick(e,x);
            FL.linkLabel1_LinkClicked(e, x);
            FL.textBox1.Text = nume;
            FL.textBox2.Text = password;
            FL.button3_Click(e, x);
            FL.label1_DoubleClick(e, x);
            
        }
    }
}
