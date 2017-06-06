using System;
using Proiect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUser
{
    [TestClass]
    public class IntroducerePacient
    {
        [TestMethod]
        public void IntroducerePacient_Forma1()
        {
            Form1 FR1 = new Form1();
            object e = null;
            EventArgs x = null;
            FR1.textBoxNume.Text = "Maricica";
            FR1.textBoxPrenume.Text = "DinTest";
            FR1.textBoxVarsta.Text = "44";
            FR1.textBoxPuls.Text = "62";
            FR1.textBoxTensiune.Text = "93";
            FR1.textBoxInfo.Text = "Sistem TEST DO NOT REPLY";
            FR1.button1_Click(e,x);
        }
    }
}
