using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoArqI.Helpers {
    class Arquivo {
        /// <summary>
        /// Usada para facilitar a realização de operações sobre um determinado arquivo
        /// </summary>

        private StreamWriter ArquivoCodigo;

        private string Caminho;

        private void AbrirArquivo() {
            ArquivoCodigo = new StreamWriter(Caminho);
        }
        public void FecharArquivo() {
            ArquivoCodigo.Close();
        }

        public Arquivo(string caminho) {
            Caminho = caminho;
            AbrirArquivo();
            ArquivoCodigo.WriteLine("main:");
            ArquivoCodigo.WriteLine("li " + Contrato.Resultado + ",0");
        }

      

        public void EscreverSoma(string[] operandos) {

            int i = 0;
            foreach (string s in operandos) {
                ArquivoCodigo.WriteLine("li " + "$s" + i + "," + s);
                i++;
            }
            i = 0;
            foreach (var operando in operandos) {
                ArquivoCodigo.WriteLine("add " + Contrato.Resultado + "," + Contrato.Resultado + ",$s" + i);
                i++;
            }
            
        }

        public void EscreverSubtracao(string[] operandos) {

            int i = 0;
            foreach (string s in operandos) {
                ArquivoCodigo.WriteLine("li " + "$s" + i + "," + s);
                i++;
            }

            int pos = 0;
            for (i = 1; i < operandos.Length; i++) {
                if (i == 1) {
                    ArquivoCodigo.WriteLine("sub " + Contrato.Resultado + "," + "$s" + pos + ",$s" + (pos+1));
                    pos++;
                }
                else {
                    ArquivoCodigo.WriteLine("sub " + Contrato.Resultado + "," + Contrato.Resultado + ",$s" + pos);
                }

                pos++;
            }


            /*i = 1;
            foreach (var operando in operandos) {
                ArquivoCodigo.WriteLine("sub " + Contrato.Resultado + "," + Contrato.Resultado + ",$s" + i);
                i++;
            }*/

        }

        //A Bool resultado é usada para saber se devemos aplicar a operação ao resultado geral da expressão
        public void EscreverSomaSimples(string s, string s1, bool resultado) {
            if (!resultado) {
                ArquivoCodigo.WriteLine("li $s0," + s);
                ArquivoCodigo.WriteLine("li $s1," + s1);
                ArquivoCodigo.WriteLine("add $s3 $s0,$s1");
                ArquivoCodigo.WriteLine("add " + Contrato.Resultado + "," + Contrato.Resultado + ",$s3");
            } else {
                ArquivoCodigo.WriteLine("li $s1," + s1);
                ArquivoCodigo.WriteLine("add " + Contrato.Resultado + "," + Contrato.Resultado + ",$s1");
            }
        }

        //A Bool resultado é usada para saber se devemos aplicar a operação ao resultado geral da expressão
        public void EscreverSubSimples(string s, string s1, bool resultado) {
            if (!resultado) {
                ArquivoCodigo.WriteLine("li $s0," + s);
                ArquivoCodigo.WriteLine("li $s1," + s1);
                ArquivoCodigo.WriteLine("sub $s3 $s0,$s1");
                ArquivoCodigo.WriteLine("sub " + Contrato.Resultado + "," + Contrato.Resultado + ",$s3");
            }
            else {
                ArquivoCodigo.WriteLine("li $s1," + s1);
                ArquivoCodigo.WriteLine("sub " + Contrato.Resultado + "," + Contrato.Resultado + ",$s1");
            }
        }


        public void EscreverMultiplicacaoSimples(string esquerda, string direita, bool resultado) {
            //10*10
            if (!resultado) {
                ArquivoCodigo.WriteLine("#parte da multiplicacao");
                ArquivoCodigo.WriteLine("li $s5," + esquerda);
                ArquivoCodigo.WriteLine("li $s4,0");
                //ArquivoCodigo.WriteLine("li $s6," + direita);
                for (int i = 0; i < int.Parse(direita); i++) {
                    ArquivoCodigo.WriteLine("add $s4,$s4,$s5");
                    //ArquivoCodigo.WriteLine("add " + Contrato.Resultado + "," + Contrato.Resultado + ",$s3");
                }
                ArquivoCodigo.WriteLine();
                ArquivoCodigo.WriteLine("add " + Contrato.Resultado + "," + Contrato.Resultado + ",$s4");
                ArquivoCodigo.WriteLine("#fim da multiplicacao");
            }
            //(10*10) -> Resultado *10
            else {
                for (int i = 1; i < int.Parse(direita); i++) {
                    ArquivoCodigo.WriteLine("add $s4," + "$s4," + Contrato.Resultado);
                }
                ArquivoCodigo.WriteLine("move " + Contrato.Resultado + ",$s4");
            }
        }
    }
}
