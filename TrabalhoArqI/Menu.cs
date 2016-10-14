using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabalhoArqI.Helpers;

namespace TrabalhoArqI {
    public partial class Menu : Form {
        private Arquivo arquivo;
        public Menu() {
            InitializeComponent();
            //arquivo = new Arquivo("C:/Users/renan/Desktop/Aulas/Arquitetura de Computadores I/CodigoNovo.asm");
        }

        private void btnGerarAssembly_Click(object sender, EventArgs e) {
            arquivo = new Arquivo("C:/CodigoNovoNovo.txt");


            string calculo = txtCalculo.Text;
            var identificador = new Identificador();
            //Coloca em um vetor todos os números separados das operações
            //TODO: Identificar operações fib, etc..
            var operandos = identificador.IdentificarOperandos(calculo);
            //operandos = operandos.Reverse().ToArray();

            /*var operandosEmOrdem = new string[operandos.Length];
            var indexSig = 0;
            var indexMenos = operandos.Length-1;
            for (int i = 0; i < operandos.Length; i++) {
                switch (operandos[i + 1]) {
                    case "+":
                        operandosEmOrdem[indexMenos] = operandos[i];
                        operandosEmOrdem[indexMenos] = "+";
                        operandosEmOrdem[indexMenos] = operandos[i + 2];

                        indexMenos -= 3;
                        break;

                    case "-":
                        operandosEmOrdem[indexMenos] = operandos[i];
                        operandosEmOrdem[indexMenos] = "";
                        operandosEmOrdem[indexMenos] = operandos[i + 2];

                        indexMenos -= 3;
                        break;

                    case "*":
                        operandosEmOrdem[indexSig] = operandos[i];
                        operandosEmOrdem[indexSig + 1] = "*";
                        operandosEmOrdem[indexSig +2] = operandos[i+2];

                        indexSig += 3;
                        break;

                    case "/":
                        operandosEmOrdem[indexSig] = operandos[i];
                        operandosEmOrdem[indexSig + 1] = "/";
                        operandosEmOrdem[indexSig + 2] = operandos[i + 2];

                        indexSig += 3;
                        break;
                }
            }
            Debug.Write(operandosEmOrdem);

            */

            identificador.EscreverCodigoRenan(operandos, arquivo);






            /*
            int posOffset = 0;
            for (int i = 0; i < operandos.Length; i+=3) {

                switch (operandos[1+posOffset]) {
                    case "+":
                        arquivo.EscreverSomaSimples(operandos[0 + posOffset], operandos[2 + posOffset], posOffset != 0);
                        break;
                    case "-":
                        arquivo.EscreverSubSimples(operandos[0 + posOffset], operandos[2 + posOffset], posOffset != 0);
                        break;
                    case "*":
                        arquivo.EscreverMultiplicacaoSimples(operandos[0 + posOffset], operandos[2 + posOffset], posOffset != 0);
                        break;
                }

                posOffset += 2;
            }
            */
            arquivo.FecharArquivo();

            /*var soma = identificador.IdentificarSoma(operandos);
            var subtracao = identificador.IdentificarSubtracao(operandos);
            arquivo.EscreverSoma(soma);
            arquivo.EscreverSubtracao(subtracao);
            */


        }
    }
}
