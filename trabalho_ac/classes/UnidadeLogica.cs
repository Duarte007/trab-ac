using System;
using POO_PortasLogicas;

namespace trabalho_ac {

    class UnidadeLogica:Circuito {
        private int entradaA;
        private int entradaB;
        private int saidaD1;
        private int saidaD2;
        private int saidaD3;

        private int saidaUL1, saidaUL2, saidaUL3;
        

        public UnidadeLogica(int entradaA, int entradaB, int saidaD1, int saidaD2, int saidaD3){
            this.entradaA = entradaA;
            this.entradaB = entradaB;
            this.saidaD1 = saidaD1;
            this.saidaD2 = saidaD2;
            this.saidaD3 = saidaD3;
        }

        public override void resolveCircuito(){
            POO_PortasLogicas.And2 and1 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and2 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and3 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and4 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.Not notB = new POO_PortasLogicas.Not();
            POO_PortasLogicas.Or2 or = new POO_PortasLogicas.Or2();

            and1.setBit1(this.entradaA);
            and1.setBit2(this.entradaB);
            int resultAnd1 = and1.result();

            or.setBit1(this.entradaA);
            or.setBit2(this.entradaB);
            int resultOr = or.result();

            and2.setBit1(resultAnd1);
            and2.setBit2(this.saidaD1);
            this.saidaUL1 = and2.result();

            and3.setBit1(resultOr);
            and3.setBit2(this.saidaD2);
            this.saidaUL2 = and3.result();

            notB.setBit1(this.entradaB);
            and4.setBit1(notB.result());
            and4.setBit2(this.saidaD3);
            this.saidaUL3 = and4.result();
        }

        public int getSaidaUL1(){
            return this.saidaUL1;
        }

        public int getSaidaUL2(){
            return this.saidaUL2;
        }

        public int getSaidaUL3(){
            return this.saidaUL3;
        }
    }
}
