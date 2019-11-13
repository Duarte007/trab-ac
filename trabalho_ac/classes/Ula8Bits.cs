using System;
using POO_PortasLogicas;
using System.Collections.Generic;

namespace trabalho_ac {
    public class Ula8Bits {
        List<Ula> ulas1Bit = new List<Ula>();
        int[] saidas = new int[8];

        public Ula8Bits(int[] numA, int[] numB, int operacao, int carryIn){
            if(numA.Length == numB.Length && numA.Length == 8){
                for(int i = 7 ; i >= 0 ; i--){
                    int currentCarryIn = ulas1Bit.Count-1 != -1 ? 
                                    ulas1Bit[ulas1Bit.Count-1].getCarryOut() : carryIn; 
                    ulas1Bit.Add(new Ula(numA[i], numB[i], operacao, currentCarryIn));
                }
            }
        }

        public int[] getSaidas(){
            for(int i = ulas1Bit.Count -1, y = 0 ; i >= 0 ; i--, y++) {
                saidas[y] = ulas1Bit[i].getSaidaUla();
            }
            return saidas;
        }

        public int getCarryOut(){
            return ulas1Bit[ulas1Bit.Count - 1].getCarryOut();
        }

    }
}
