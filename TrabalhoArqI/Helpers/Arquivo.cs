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

        public Arquivo(string caminho) {
            ArquivoCodigo = new StreamWriter(caminho);
            /*using (ArquivoCodigo) {
                ArquivoCodigo.WriteLine("main:");
            }*/
        }

      

        public void EscreverSoma(string[] operandos) {
            using (ArquivoCodigo) {
                
                ArquivoCodigo.WriteLine("main:");
                ArquivoCodigo.WriteLine("li " + Contrato.Resultado + ",0");
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
        }
    }
}
