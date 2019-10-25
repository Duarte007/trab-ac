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
    public partial class Form1 : Form
    {
        public Form1()
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
            int n1 = int.Parse(valueOne.Text);
            int n2 = int.Parse(valueTwo.Text);
            string n1Bin = Convert.ToString(n1, 2);
            string n2Bin = Convert.ToString(n2, 2);
            valueOneHex.Text = n1Bin.PadLeft(24, '0');
            valueTwoHex.Text = n2Bin.PadLeft(24, '0');
        }
    }
}
