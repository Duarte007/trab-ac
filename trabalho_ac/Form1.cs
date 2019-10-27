using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho_ac
{
    public partial class binaryHandler : Form
    {
        public binaryHandler()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void convertNumber(object sender, EventArgs e) {
            IEEE754 patternIEEE = new IEEE754();
            valueOne.Text = !string.IsNullOrEmpty(valueOne.Text) ? valueOne.Text : "0";
            valueTwo.Text = !string.IsNullOrEmpty(valueTwo.Text) ? valueTwo.Text : "0";
            string nBin1 = patternIEEE.FloatToBinary(float.Parse(valueOne.Text));
            string nBin2 = patternIEEE.FloatToBinary(float.Parse(valueTwo.Text));
            string[] result1 = nBin1.Split(' ');
            signalBit1.Text = result1[0];
            expoente1.Text = result1[1];
            fracao1.Text = result1[2];
            string[] result2 = nBin2.Split(' ');
            signalBit2.Text = result2[0];
            expoente2.Text = result2[1];
            fracao2.Text = result2[2];
            // int integerPart1 = int.Parse(valueOne.Text.Split(',')[0]);
            // int integerPart2 = int.Parse(valueTwo.Text.Split(',')[0]);
            // string integerPart1Bin = Convert.ToString(integerPart1, 2);
            // string integerPart2Bin = Convert.ToString(integerPart2, 2);

            string n1Hex = patternIEEE.BinaryToHex(nBin1);
            string n2Hex = patternIEEE.BinaryToHex(nBin2);
            //dividir o numero de 24 bits em 6 partes e transformar cada grupo de 4 bits para hexa
            valueOneHex.Text = "0x"+n1Hex.ToUpper();
            valueTwoHex.Text = "0x"+n2Hex.ToUpper();
        }
    }
}
