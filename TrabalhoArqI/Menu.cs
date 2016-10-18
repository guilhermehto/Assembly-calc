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
        }

        private void btnGerarAssembly_Click(object sender, EventArgs e) {
            arquivo = new Arquivo("C:/CodigoNovoNovo.txt");

            string calculo = txtCalculo.Text;

            var identificador = new Identificador();

            //Coloca em um vetor todos os números separados das operações
            var operandos = identificador.IdentificarOperandos(calculo);
            
            identificador.EscreverCodigo(operandos, arquivo);
            
            arquivo.FecharArquivo();
        }
    }
}
