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
            arquivo = new Arquivo("C:/Codigo.txt");
        }

        private void btnGerarAssembly_Click(object sender, EventArgs e) {
            string calculo = txtCalculo.Text;
            var identificador = new Identificador();
            var operandos = identificador.IdentificarOperandos(calculo);
            var soma = identificador.IdentificarSoma(operandos);
            arquivo.EscreverSoma(soma);




        }
    }
}
