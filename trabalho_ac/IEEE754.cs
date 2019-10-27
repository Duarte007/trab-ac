using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trabalho_ac
{

    internal class IEEE754 {

        public IEEE754() {

        }

        public string FloatToBinary(float f) {
            StringBuilder sb = new StringBuilder();
            Byte[] ba = BitConverter.GetBytes(f);
            foreach (Byte b in ba){
                for (int i = 0; i < 8; i++) {
                    sb.Insert(0,((b>>i) & 1) == 1 ? "1" : "0");
                }
            }
            string s = sb.ToString();
            string r = s.Substring(0, 1) + " " + s.Substring(1, 8) + " " + s.Substring(9);
            return r;
        }

       public string BinaryToHex(string bin) {
           string result = "";
            if (string.IsNullOrEmpty(bin))
                return bin;
            bin = bin.Replace(" ", "");
            
            result +=Convert.ToInt32(bin, 2).ToString("X");
           
            return result;
        }
    }
}
