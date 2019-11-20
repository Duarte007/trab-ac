using System;
using POO_PortasLogicas;
using System.Collections.Generic;
using System.Linq;

namespace trabalho_ac {
    public class Ula24Bits {
        List<Ula8Bits> ulas8Bit = new List<Ula8Bits>();
        int[] saidas = new int[24];
        int[] currentNumsAUla = new int[8];
        int[] currentNumsBUla = new int[8];

        public Ula24Bits(int[] numA, int[] numB, int operacao, int carryIn){
            int start = 0;
            int end = 8;
            IEnumerable<int> numsAUla;
            IEnumerable<int> numsBUla;
            if(numA.Length == numB.Length && numA.Length == 24){
                for(int i = 2 ; i >= 0 ; i--){
                    numsAUla = numA.Skip(start).Take(end);
                    numsBUla = numB.Skip(start).Take(end);
                    int k = 0;
                    foreach (int numAUla in numsAUla) {
                        currentNumsAUla[k] = numAUla;
                        k++;
                    }
                    int l = 0;
                    foreach (int numBUla in numsBUla) {
                        currentNumsBUla[l] = numBUla;
                        l++;
                    }
                    int currentCarryIn = ulas8Bit.Count-1 != -1 ? 
                            ulas8Bit[ulas8Bit.Count-1].getCarryOut() : carryIn; 
                    ulas8Bit.Add(new Ula8Bits(currentNumsAUla, currentNumsBUla, operacao, currentCarryIn));
                    start+=8;
                }
            }
        }

        public int[] getSaidas(){
            int k = 0;
            for(int i = 0 ; i < ulas8Bit.Count ; i++) {
               foreach(int saida in ulas8Bit[i].getSaidas()){
                    saidas[k] = saida;
                    k++;
               }
            }
            return saidas;
        }

        public int getCarryOut(){
            return ulas8Bit[ulas8Bit.Count - 1].getCarryOut();
        }

    }
}
