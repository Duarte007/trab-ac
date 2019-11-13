using System;
using POO_PortasLogicas;

namespace trabalho_ac {
    class Decodificador:Circuito {
        private int f0;
        private int f1;
        private int saidaD1, saidaD2, saidaD3, saidaD4;

        public Decodificador(int operacao){
            this.defineEntradas(operacao);
        }

        public void defineEntradas(int operacao){
            switch(operacao){
                case 0: //and
                    this.f0 = 0;
                    this.f1 = 0;
                break;
                case 1: //or
                    this.f0 = 0;
                    this.f1 = 1;
                break;
                case 2: //not
                    this.f0 = 1;
                    this.f1 = 0;
                break;
                case 3: //soma
                    this.f0 = 1;
                    this.f1 = 1;
                break;
            }
        }

        public override void resolveCircuito(){
            POO_PortasLogicas.And2 and1 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and2 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and3 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.And2 and4 = new POO_PortasLogicas.And2();
            POO_PortasLogicas.Not notF0 = new POO_PortasLogicas.Not();
            POO_PortasLogicas.Not notF1 = new POO_PortasLogicas.Not();

            notF0.setBit1(f0);
            notF1.setBit1(f1);
            
            and1.setBit1(notF0.result());
            and1.setBit2(notF1.result());
            this.saidaD1 = and1.result();

            and2.setBit1(notF0.result());
            and2.setBit2(f1);
            this.saidaD2 = and2.result();

            and3.setBit1(f0);
            and3.setBit2(notF1.result());
            this.saidaD3 = and3.result();

            and4.setBit1(f0);
            and4.setBit2(f1);
            this.saidaD4 = and4.result();
        }

        public int getSaidaDecod1(){
            return this.saidaD1;
        }

        public int getSaidaDecod2(){
            return this.saidaD2;
        }

        public int getSaidaDecod3(){
            return this.saidaD3;
        }

        public int getSaidaDecod4(){
            return this.saidaD4;
        }

    }
}
