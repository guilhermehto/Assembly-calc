using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoArqI.Helpers {
    /// <summary>
    /// Usada para identificar as operações na string do cálculo
    /// </summary>
    class Identificador {
        public string[] IdentificarOperandos(string calculo) {
            //calculo = calculo.Where(x => !String.IsNullOrWhiteSpace(x.ToString())).ToString();    
            string[] operandos = new string[calculo.Length];
            int i = 0;
            //TODO: Tratar erro caso um operador estiver no começo do cálculo
            foreach (char s in calculo) {
                switch (s.ToString()) {
                    case "+":
                        i++;
                        operandos[i] = s.ToString();
                        i++;
                        break;
                    case "-":
                        i++;
                        operandos[i] = s.ToString();
                        i++;
                        break;
                    case "*":
                        i++;
                        operandos[i] = s.ToString();
                        i++;
                        break;
                    case "/":
                        i++;
                        operandos[i] = s.ToString();
                        i++;
                        break;
                    default:
                        operandos[i] += s.ToString();
                        break;
                }
            }

            return operandos.Where(x => x != null).ToArray();
        }


        public string[] IdentificarSoma(string[] calculo) {
            string[] nums = new string[calculo.Length];
            int posNums = 0;
            for (int i = 0; i < calculo.Length; i++) {
                if (calculo[i] == "+") {
                    if (posNums != 0) {
                        nums[posNums] = calculo[i + 1];
                        posNums++;
                    }
                    else {
                        nums[posNums] = calculo[i - 1];
                        nums[posNums + 1] = calculo[i + 1];
                        posNums += 2;
                    }
                }
            }

            return nums.Where(x => x != null).ToArray();
        }
        public string[] IdentificarSubtracao(string[] calculo) {
            string[] nums = new string[calculo.Length];
            int posNums = 0;
            for (int i = 0; i < calculo.Length; i++) {
                if (calculo[i] == "-") {
                    if (posNums != 0) {
                        nums[posNums] = calculo[i + 1];
                        posNums++;
                    }
                    else {
                        nums[posNums] = calculo[i - 1];
                        nums[posNums + 1] = calculo[i + 1];
                        posNums += 2;
                    }
                }
            }

            return nums.Where(x => x != null).ToArray();
        }



        public void GerarCodigo(string[] operandos, Arquivo arquivo) {
            /*
             * 10 + 5 + 2 + 1
             * 5 + 2 + 1
             * 2 + 1 
             * 
             * */

            /*
             * ta dando pau nas ultimas contas, e também não está escrevendo o primeiro número da expressão
             * 
             * 
             */
            if (operandos.Length >= 5) {
                string[] operandosNovos = new string[operandos.Length];
                for (int i = 2; i < operandos.Length; i++) {
                    operandosNovos[i] = operandos[i];
                }
                //Array.Resize(ref operandosNovos, operandosNovos.Length - 3);
                operandosNovos = operandosNovos.Where(x => x != null).ToArray();
                GerarCodigo(operandosNovos, arquivo);
            }

            if (operandos.Length == 3) {
                switch (operandos[1]) {
                    case "+":
                        arquivo.EscreverSomaSimples(operandos[0], operandos[2], false);
                        break;
                    case "-":
                        arquivo.EscreverSubSimples(operandos[0], operandos[2], false);
                        break;
                    case "*":
                        arquivo.EscreverMultiplicacaoSimples(operandos[0], operandos[2], false);
                        break;
                }
            }
            else {
                switch (operandos[1]) {
                    case "+":
                        arquivo.EscreverSomaSimples(operandos[0], operandos[2], true);
                        break;
                    case "-":
                        arquivo.EscreverSubSimples(operandos[0], operandos[2], true);
                        break;
                    case "*":
                        arquivo.EscreverMultiplicacaoSimples(operandos[0], operandos[2], true);
                        break;
                }
            }

            /*
            int posOffset = 0;
            for (int i = 0; i < operandos.Length; i += 3) {
                switch (operandos[1 + posOffset]) {
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

        }
    }
}
