using System;
using POO_PortasLogicas;

namespace trabalho_ac {
    class SomadorCompleto:Circuito {
        private int entradaA;
        private int entradaB;
        private int saidaD4;
        private int saidaSC;
        private int carryIn;
        private int carryOut;

        public SomadorCompleto(int entradaA, int entradaB, int saidaD4, int carryIn){
            this.entradaA = entradaA;
            this.entradaB = entradaB;
            this.saidaD4 = saidaD4;
            this.carryIn = carryIn;
        }

        public override void resolveCircuito(){
            POO_PortasLogicas.And2 and1 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and2 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and3 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and4 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and5 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.Xor2 xor1 = new POO_PortasLogicas.Xor2();
            POO_PortasLogicas.Xor2 xor2 = new POO_PortasLogicas.Xor2();
            POO_PortasLogicas.Or2 or = new POO_PortasLogicas.Or2();

            /* PARTE DO CIRCUITO PARA SAIDA DO SOMADOR COMPLETO */

            xor1.setBit1(this.entradaB);
            xor1.setBit2(this.entradaA);
            int resultXor1 = xor1.result();

            xor2.setBit1(resultXor1);
            xor2.setBit2(this.carryIn);
            int resultXor2 = xor2.result();

            and5.setBit1(resultXor2);
            and5.setBit2(this.saidaD4);
            this.saidaSC = and5.result();

            /* PARTE DO CIRCUITO PARA O CARRY OUT */

            //and1 e and2 formam uma and de 3 entradas
            and1.setBit1(this.saidaD4);
            and1.setBit2(this.entradaA);
            int resultAnd1Aux = and1.result();

            and2.setBit1(resultAnd1Aux);
            and2.setBit2(this.entradaB);
            int resultAnd2 = and2.result();

            //and3 e and4 formam uma and de 3 entradas
            and3.setBit1(this.saidaD4);
            and3.setBit2(resultXor1);
            int resultAnd3Aux = and3.result();

            and4.setBit1(resultAnd3Aux);
            and4.setBit2(this.carryIn);
            int resultAnd4 = and4.result();

            //carryOut
            or.setBit1(resultAnd2);
            or.setBit2(resultAnd4);
            this.carryOut = or.result();
        }

        public int getSaidaSC(){
            return this.saidaSC;
        }

        public int getCarryOut(){
            return this.carryOut;
        }
    }
}
