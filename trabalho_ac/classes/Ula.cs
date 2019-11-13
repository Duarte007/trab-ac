using System;
using POO_PortasLogicas;

namespace trabalho_ac {
    class Ula:Circuito {
        private int carryOut;
        private UnidadeLogica unidadeLogica;
        private Decodificador decodificador;
        private SomadorCompleto somadorCompleto;
        private int saidaUL1;
        private int saidaUL2;
        private int saidaUL3;
        private int saidaSC;
        private int saidaD1;
        private int saidaD2;
        private int saidaD3;
        private int saidaD4;
        private int saidaUla;

        public Ula(int entradaA, int entradaB, int operacao, int carryIn){
            this.decodificador = new Decodificador(operacao);
            this.decodificador.resolveCircuito();
            this.saidaD1 = this.decodificador.getSaidaDecod1();
            this.saidaD2 = this.decodificador.getSaidaDecod2();
            this.saidaD3 = this.decodificador.getSaidaDecod3();
            this.saidaD4 = this.decodificador.getSaidaDecod4();
            this.unidadeLogica = new UnidadeLogica(entradaA, entradaB, this.saidaD1, this.saidaD2, this.saidaD3);
            this.unidadeLogica.resolveCircuito();
            this.saidaUL1 = unidadeLogica.getSaidaUL1();
            this.saidaUL2 = unidadeLogica.getSaidaUL2();
            this.saidaUL3 = unidadeLogica.getSaidaUL3();
            this.somadorCompleto = new SomadorCompleto(entradaA, entradaB, this.saidaD4, carryIn);
            this.somadorCompleto.resolveCircuito();
            this.saidaSC = somadorCompleto.getSaidaSC();
            this.carryOut = somadorCompleto.getCarryOut();
            this.resolveCircuito();
        }

        public override void resolveCircuito(){
            POO_PortasLogicas.Or2 or1 = new POO_PortasLogicas.Or2(this.saidaUL1, this.saidaUL2);
            int resultOr1 = or1.result();
            POO_PortasLogicas.Or2 or2 = new POO_PortasLogicas.Or2(resultOr1, this.saidaUL3);
            int resultOr2 = or2.result();
            POO_PortasLogicas.Or2 or3 = new POO_PortasLogicas.Or2(resultOr2, this.saidaSC);
            
            this.saidaUla = or3.result();
        }

        public int getSaidaUla(){
            return this.saidaUla;
        }

        public int getCarryOut(){
            return this.carryOut;
        }

    }
}
