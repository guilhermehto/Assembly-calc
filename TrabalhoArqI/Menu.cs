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
            arquivo = new Arquivo("C:/CodigoNovoNovo.txt");
        }

        private void btnGerarAssembly_Click(object sender, EventArgs e) {
            string calculo = txtCalculo.Text;
            var identificador = new Identificador();
            //Coloca em um vetor todos os números separados das operações
            //TODO: Identificar operações fib, etc..
            var operandos = identificador.IdentificarOperandos(calculo);
            int posOffset = 0;
            for (int i = 0; i < operandos.Length; i+=3) {

                switch (operandos[1+posOffset]) {
                    case "+":
                        arquivo.EscreverSomaSimples(operandos[0 + posOffset], operandos[2 + posOffset], posOffset != 0);
                        break;
                    case "-":
                        arquivo.EscreverSubSimples(operandos[0 + posOffset], operandos[2 + posOffset], posOffset != 0);
                        break;
                }

                posOffset += 2;
            }

            arquivo.FecharArquivo();

            /*var soma = identificador.IdentificarSoma(operandos);
            var subtracao = identificador.IdentificarSubtracao(operandos);
            arquivo.EscreverSoma(soma);
            arquivo.EscreverSubtracao(subtracao);
            */
            Debug.WriteLine("");


        }
    }
}
