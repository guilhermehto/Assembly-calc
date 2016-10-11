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
    }
}
