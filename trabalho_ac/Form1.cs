﻿using System;
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

        //private void subtract(object sender, EventArgs e)
        //{
        //    MessageBox.Show("Não implementado");
        //}


        private void subtract(object sender, EventArgs e)
        {

            IEEE754 patternIEEE = new IEEE754();

            double v1 = !string.IsNullOrEmpty(valueOne.Text) ? double.Parse(valueOne.Text.Replace(".", ",")) : 0d;
            double v2 = !string.IsNullOrEmpty(valueTwo.Text) ? double.Parse(valueTwo.Text.Replace(".", ",")) : 0d;

            string nBin1 = patternIEEE.FloatToBinary(float.Parse(valueOne.Text)).Replace(" ", "");
            string nBin2 = patternIEEE.FloatToBinary(float.Parse(valueTwo.Text)).Replace(" ", "");
            string mantissaBit1 = "", mantissaBit2 = "";
            Ula24Bits ula24Bits;
            if (v1 < 0) {
                nBin1 = nBin1[0] + nBin1.Substring(1, 8) + nBin1.Substring(9, 23).Replace('0', 'x');
                nBin1 = nBin1[0] + nBin1.Substring(1, 8) + nBin1.Substring(9, 23).Replace('1', '0');
                nBin1 = nBin1[0] + nBin1.Substring(1, 8) + nBin1.Substring(9, 23).Replace('x', '1');
                ula24Bits = new Ula24Bits(arrayParse(nBin1.Substring(9, 23), 24), arrayParse("1".PadLeft(24, '0'), 24), 3, 0);
                mantissaBit1 = string.Join(string.Empty, ula24Bits.getSaidas());
                mantissaBit1 = nBin1[0] + nBin1.Substring(1, 8) + mantissaBit1.Substring(0, 23);
            }
            
                nBin2 = nBin2[0] + nBin2.Substring(1, 8) + nBin2.Substring(9, 23).Replace('0', 'x');
                nBin2 = nBin2[0] + nBin2.Substring(1, 8) + nBin2.Substring(9, 23).Replace('1', '0');
                nBin2 = nBin2[0] + nBin2.Substring(1, 8) + nBin2.Substring(9, 23).Replace('x', '1');
                ula24Bits = new Ula24Bits(arrayParse(nBin2.Substring(9, 23), 24), arrayParse("1".PadLeft(24, '0'), 24), 3, 0);
                mantissaBit2 = string.Join(string.Empty, ula24Bits.getSaidas());
                mantissaBit2 = nBin2[0] + nBin2.Substring(1, 8) + mantissaBit2.Substring(0, 23);
           
           
            if (mantissaBit1 == "") mantissaBit1 = nBin1;
            string result = this.operation(mantissaBit1, mantissaBit2);
            this.setResultFields(result);

        }

        private void add(object sender, EventArgs e) {

            IEEE754 patternIEEE = new IEEE754();
            
            valueOne.Text = !string.IsNullOrEmpty(valueOne.Text) ? valueOne.Text.Replace(".", ",") : "0";
            valueTwo.Text = !string.IsNullOrEmpty(valueTwo.Text) ? valueTwo.Text.Replace(".", ",") : "0";

            string nBin1 = patternIEEE.FloatToBinary(float.Parse(valueOne.Text)).Replace(" ", "");
            string nBin2 = patternIEEE.FloatToBinary(float.Parse(valueTwo.Text)).Replace(" ", "");

            string result = this.operation(nBin1, nBin2);
            this.setResultFields(result);
        }

        private string operation(string nBin1, string nBin2) {

            int signal1 = int.Parse(nBin1[0].ToString());
            int signal2 = int.Parse(nBin2[0].ToString());

            double v1 = !string.IsNullOrEmpty(valueOne.Text) ? double.Parse(valueOne.Text.Replace(".", ",")) : 0d;
            double v2 = !string.IsNullOrEmpty(valueTwo.Text) ? double.Parse(valueTwo.Text.Replace(".", ",")) : 0d;


            string signalBitBin1 = nBin1.Substring(0, 1);
            string exponentBin1 = nBin1.Substring(1, 8);
            int expoBin1 = Convert.ToInt32(exponentBin1, 2);
            int lengthBin1 = expoBin1 - 127;
            string fractionBin1 = "1" + nBin1.Substring(9, 23);

            string signalBitBin2 = nBin2.Substring(0, 1);
            string exponentBin2 = nBin2.Substring(1, 8);
            int expoBin2 = Convert.ToInt32(exponentBin2, 2);
            int lengthBin2 = expoBin2 - 127;
            string fractionBin2 = "1" + nBin2.Substring(9, 23);

            this.currentExpo = exponentBin1;
            if (v1 != 0 && v2 == 0){
                return string.Join(string.Empty, new Ula(signal1, signal2, 3, 0).getSaidaUla()) + exponentBin1 + nBin1.Substring(9, 23);
            } else if(v2 != 0 && v1 == 0){
                return string.Join(string.Empty, new Ula(signal1, signal2, 3, 0).getSaidaUla()) + exponentBin2 + nBin2.Substring(9, 23);
            } else if (lengthBin1 > lengthBin2) {
                int diff = lengthBin1 - lengthBin2;
                int[] result = new Ula8Bits(arrayParse(exponentBin1, 8), arrayParse(diff.ToString("2"), 8), 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, result);
                string zeros = "".PadLeft(diff, '0');
                fractionBin2 = zeros + fractionBin2.Substring(0, (24 - zeros.Length));
            } else if (lengthBin1 < lengthBin2) {
                int diff = lengthBin2 - lengthBin1;
                int[] result = new Ula8Bits(arrayParse(exponentBin2, 8), arrayParse(diff.ToString("2"), 8), 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, result);
                string zeros = "".PadLeft(diff, '0');
                fractionBin1 = zeros + fractionBin1.Substring(0, (24 - zeros.Length));
            }
            Ula24Bits ula24Bits = new Ula24Bits(arrayParse(fractionBin1, 24), arrayParse(fractionBin2, 24), 3, 0);
            string mantissa = string.Join(string.Empty, ula24Bits.getSaidas());

            if (ula24Bits.getCarryOut() == 1) {
                int[] bitToNormalize = new int[8] { 0, 0, 0, 0, 0, 0, 0, 1 };
                int[] finalResult = new Ula8Bits(arrayParse(this.currentExpo, 8), bitToNormalize, 3, 0).getSaidas();
                this.currentExpo = string.Join(string.Empty, finalResult);
                mantissa = mantissa.Substring(0, 23);
            } else {
                mantissa = mantissa.Substring(1, 23);
            }

            return string.Join(string.Empty, new Ula(signal1, signal2, 3, 0).getSaidaUla()) + this.currentExpo + mantissa.Substring(0, 23);


        }

        private void multiply(object sender, EventArgs e) {
            IEEE754 patternIEEE = new IEEE754();

            double v1 = !string.IsNullOrEmpty(valueOne.Text) ? double.Parse(valueOne.Text.Replace(".", ",")) : 0d;
            double v2 = !string.IsNullOrEmpty(valueTwo.Text) ? double.Parse(valueTwo.Text.Replace(".", ",")) : 0d;
            double count;
            if (float.Parse(valueOne.Text.Replace(".", ",")) != 0 && float.Parse(valueTwo.Text.Replace(".", ",")) != 0) {

                string nBin1 = patternIEEE.FloatToBinary(float.Parse(valueOne.Text.Replace(".", ","))).Replace(" ", "");
                string nBin2 = patternIEEE.FloatToBinary(float.Parse(valueTwo.Text.Replace(".", ","))).Replace(" ", "");
                string mult, result = "0", numToSumBin = "";

                if (IsInteger(v1))
                {
                    if (v1 < 0)
                    {
                        count = v1 * (-1) - 1;
                        nBin2 = nBin2[0] == '1' && nBin1[0] == '1' ? '0' + nBin2.Substring(1, 31) : '1'+nBin2.Substring(1, 31);
                        mult = nBin2;
                        result = nBin2;
                    }
                    else {
                        count = v1 - 1;
                        mult = nBin2;
                        result = nBin2;
                    }
                }
                else if (IsInteger(v2))
                {
                    if (v1 < 0)
                    {
                        count = v2 * (-1) - 1;
                        nBin1 = nBin1[0] == '1' && nBin2[0] == '1' ? '0' + nBin1.Substring(1, 31) : '1' + nBin1.Substring(1, 31);
                        mult = nBin1;
                        result = nBin1;
                    }
                    else
                    {
                        count = v2 - 1;
                        mult = nBin1;
                        result = nBin1;
                    }
                }
                else
                {
                    double num = double.Parse(valueTwo.Text.Replace(".", ","));
                    count = Math.Floor(num) - 1;
                    double numToSum = v1 * (num - Math.Floor(num));
                    numToSumBin = patternIEEE.FloatToBinary(float.Parse(numToSum.ToString())).Replace(" ", "");
                    double n = double.Parse(valueTwo.Text.Replace(".", ",")) - (count + 1);
                    mult = nBin1;
                    result = nBin1;
                }

                for (int i = 0; i < count; i++)
                {
                    result = this.operation(result, mult);
                }
                if (numToSumBin != "")
                    result = this.operation(result, numToSumBin);

                this.setResultFields(result);
            }
            else {
                this.setResultFields(patternIEEE.FloatToBinary(0));
            }

        }

        public bool IsInteger(double d)
        {
            if (d == (int)d) return true;
            else return false;
        }

        private void setResultFields(string binResult) {
            IEEE754 patternIEEE = new IEEE754();
            signalResult.Text = binResult.Substring(0, 1);
            expoentResult.Text = binResult.Substring(1, 8);
            fracaoResult.Text = binResult.Substring(9, 23);
            string n1Hex = patternIEEE.BinaryToHex(binResult);
            hexResult.Text = "0x" + n1Hex.ToUpper();
            floatResult.Text = patternIEEE.hexToFloat(n1Hex).ToString();
        }

        private void divide(object sender, EventArgs e) {
            MessageBox.Show("Não implementado");
        }
    }
}
