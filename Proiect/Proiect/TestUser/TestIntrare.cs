using System;
using Proiect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUser
{
    [TestClass]
    public class TestIntrare
    {
        [TestMethod]
        public void Logare_in_aplicatie()
        {
            FormaLogare FL = new FormaLogare();
            string nume = "mercur3";
            string password = "mercur3";
            EventArgs x = null;
            Object e = null;
            FL.textBox1.Text = nume;
            FL.textBox2.Text = password;
            FL.button2_Click(e, x);
        }
    }
}
