using System;
using Proiect;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestUser
{
    [TestClass]
    public class StergerePacient
    {
        [TestMethod]
        public void StergerePacient_Forma1()
        {
            Form1 FR1 = new Form1();
            object e = null;
            EventArgs x = null;
            FR1.textBoxNume.Text = "Maricela";
            FR1.textBoxPrenume.Text = "DinTest";
            FR1.textBoxVarsta.Text = "44";

            FR1.button4_Click(e, x);

        }
    }
}
