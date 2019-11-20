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
    public partial class binaryHandler : Form {

        public string currentExpo = "";
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

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void convertNumber(object sender, EventArgs e) {
            IEEE754 patternIEEE = new IEEE754();
            valueOne.Text = !string.IsNullOrEmpty(valueOne.Text) ? valueOne.Text.Replace(".", ",") : "0";
            valueTwo.Text = !string.IsNullOrEmpty(valueTwo.Text) ? valueTwo.Text.Replace(".", ",") : "0";
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

        public string[] normalizeBin(string nBin1, string nBin2) {
            string signalBitBin1 = nBin1.Substring(0, 1);
            string exponentBin1 = nBin1.Substring(1, 8);
            int expoBin1 = Convert.ToInt32(exponentBin1, 2);
            int lengthBin1 = expoBin1 - 127;
            string fractionBin1 = "1"+nBin1.Substring(9, 23);

            string signalBitBin2 = nBin2.Substring(0, 1);
            string exponentBin2 = nBin2.Substring(1, 8);
            int expoBin2 = Convert.ToInt32(exponentBin2, 2);
            int lengthBin2 = expoBin2 - 127;
            string fractionBin2 = "1"+nBin2.Substring(9, 23);

            this.currentExpo = exponentBin1;
            if (lengthBin1 > lengthBin2) {
                int diff = lengthBin1 - lengthBin2;
                int[] result = new Ula8Bits(arrayParse(exponentBin1, 8), arrayParse(diff.ToString("2"), 8), 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, result);
                fractionBin2 = "0".fractionBin2.Substring(9, 23);
            } else if (lengthBin1 < lengthBin2) {
                int diff = lengthBin2 - lengthBin1;
                int[] result = new Ula8Bits(arrayParse(exponentBin2, 8), arrayParse(diff.ToString("2"), 8), 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, result);
                fractionBin1 = "0".fractionBin1.Substring(9, 23);
            } else {
                int[] bit = new int[8] { 0, 0, 0, 0, 0, 0, 0, 1 };
                int[] result = new Ula8Bits(arrayParse(exponentBin1, 8), bit, 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, result);
            }
            Ula24Bits ula24Bits = new Ula24Bits(arrayParse(fractionBin1, 24), arrayParse(fractionBin2, 24), 3, 0);
            string mantissa = string.Join(string.Empty, ula24Bits.getSaidas());
            if(ula24Bits.getCarryOut() == 1){
                int[] bitToNormalize = new int[8] { 0, 0, 0, 0, 0, 0, 0, 1 };
                int[] finalResult = new Ula8Bits(arrayParse(this.currentExpo, 8), bitToNormalize, 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, finalResult);
            }
            // fractionBin1 = fractionBin1.PadLeft(24, '1');
            // fractionBin2 = fractionBin2.PadLeft(24, '1');
            return new string [2] {fractionBin1, fractionBin2};
        }

        private void Button2_Click(object sender, EventArgs e) {

        }

        private int[] arrayParse(string bin, int length){
            int[] arr = new int[length];
            int i = 0;
            foreach (char number in bin) {
                arr[i] = int.Parse(number.ToString());
                i++;
            }
            return arr;
        }

        private void subtract(object sender, EventArgs e) {

        }

        // private void add(object sender, EventArgs e)
        // {
        //     IEEE754 patternIEEE = new IEEE754();
        //     valueOne.Text = !string.IsNullOrEmpty(valueOne.Text) ? valueOne.Text : "0";
        //     valueTwo.Text = !string.IsNullOrEmpty(valueTwo.Text) ? valueTwo.Text : "0";
        //     string nBin1 = Convert.ToString(int.Parse(valueOne.Text), 2).PadLeft(24, '0');
        //     string nBin2 = Convert.ToString(int.Parse(valueTwo.Text), 2).PadLeft(24, '0');
        //     int[] arrBin1 = array24BitsParse(nBin1);
        //     int[] arrBin2 = array24BitsParse(nBin2);
        //     Ula32Bits ula = new Ula32Bits(arrBin1, arrBin2, 3, 0);
        //     int[] saidas = ula.getSaidas();
        //     string result = string.Join(string.Empty, saidas);

        //     signalBit1.Text = result.Substring(0, 1);
        //     expoente1.Text = result.Substring(1, 8);
        //     fracao1.Text = result.Substring(8, 23);
        // }

        private void add(object sender, EventArgs e) {
            IEEE754 patternIEEE = new IEEE754();
            valueOne.Text = !string.IsNullOrEmpty(valueOne.Text) ? valueOne.Text.Replace(".", ",") : "0";
            valueTwo.Text = !string.IsNullOrEmpty(valueTwo.Text) ? valueTwo.Text.Replace(".", ",") : "0";
            string nBin1 = patternIEEE.FloatToBinary(float.Parse(valueOne.Text)).Replace(" ", "");
            string nBin2 = patternIEEE.FloatToBinary(float.Parse(valueTwo.Text)).Replace(" ", "");
            int signal1 = int.Parse(nBin1[0].ToString());
            int signal2 = int.Parse(nBin2[0].ToString());
            string[] resultP = normalizeBin(nBin1, nBin2);
            int[] arrBin1 = arrayParse(resultP[0], 32);
            int[] arrBin2 = arrayParse(resultP[1], 32);
            Ula32Bits ula = new Ula32Bits(arrBin1, arrBin2, 3, 0);
            int[] saidas = ula.getSaidas();
            string result = string.Join(string.Empty, saidas);
            signalResult.Text = new Ula(signal1, signal2, 3, 0).getSaidaUla().ToString();
            expoentResult.Text = this.currentExpo;
            fracaoResult.Text = result.Substring(9, 23);
        }

        private void multiply(object sender, EventArgs e) {
            IEEE754 patternIEEE = new IEEE754();
            valueOne.Text = !string.IsNullOrEmpty(valueOne.Text) ? valueOne.Text : "0";
            valueTwo.Text = !string.IsNullOrEmpty(valueTwo.Text) ? valueTwo.Text : "0";
            // for( int i = 0; i < int.Parse())
        }

        private void divide(object sender, EventArgs e) {

        }
    }
}
