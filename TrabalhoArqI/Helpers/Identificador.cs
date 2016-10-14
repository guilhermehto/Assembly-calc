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
            /*ResultadoMultiplicacao -> mult
             * ResultadoDiv -> div
             * 
             * Escreve todas as div;
             * Escreve todas as mult;
             * Escreve todas as somas/sub;
             * Soma div e mult no resultado;
             * 
             * 10 + 5 + 2 + 1
             * 5 + 2 + 1
             * 2 + 1 
             * 
             * 10 + 6 / 2 * 3 - 7
             * 
             * [1] 0
             * [3] 1
             * [5] 1
             * [7] 0
             * 
             * 
             * 
             * 
             * [3] 1
             * Escreve 6/2 - EscreverDivSimples(false)
             * 
             * [1] 0
             * [5] 1
             * [7] 0
             * 
             * 
             * [5] 1
             * Escrever Resultado * 3 - EscreverMultSimples(true)
             * 
             * [1] 0
             * [7] 0 
             * 
             * [1] 0
             * Escrever 10 + Resultado - EscreverSomaSimples(true)
             * 
             * 
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
                    case "/":
                        arquivo.EscreverDivSimples(operandos[0], operandos[2], false);
                        break;
                }
            }
            else {
                switch (operandos[1]) {
                    case "+":
                        arquivo.EscreverSomaSimples(operandos[0], operandos[0], true);
                        break;
                    case "-":
                        arquivo.EscreverSubSimples(operandos[0], operandos[0], true);
                        break;
                    case "*":
                        arquivo.EscreverMultiplicacaoSimples(operandos[0], operandos[0], true);
                        break;
                    case "/":
                        arquivo.EscreverDivSimples(operandos[0], operandos[0], true);
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

        /*
         10 + |6 / 2| * 3| - |8 / 2| - |10 / 2| + |4 / 4|
         Quando identificar um parenteses, incrementar a prioridade de cada operando dentro dele em 1(para cada parenteses) ex: ((2+2) * 1) * 3
             
             */

        public void EscreverCodigoRenan(string[] operandos, Arquivo arquivo) {
            var dicionario = GetDicionario(operandos);
            bool escreverEmResultado = false;
            var ultOpPos = 0;
            for (int i = Prioridade.PrioridadeFunc; i >= 0; i--) {
                foreach (var dic in dicionario) {
                    if (dic.Value == i) {
                        var pos1 = dic.Key - 1;
                        var pos2 = dic.Key + 1;
                        switch (operandos[dic.Key]) {
                            case "+":
                                if (ultOpPos < dic.Key) {
                                    arquivo.EscreverSomaSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                } else {
                                    arquivo.EscreverSomaSimples(operandos[pos2], operandos[pos1], escreverEmResultado);
                                }
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                            case "-":
                                if (ultOpPos < dic.Key) {
                                    arquivo.EscreverSubSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                } else {
                                    arquivo.EscreverSubSimples(operandos[pos2], operandos[pos1], escreverEmResultado);
                                }
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                            case "*":
                                if (ultOpPos < dic.Key) {
                                    arquivo.EscreverMultiplicacaoSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                } else {
                                    arquivo.EscreverMultiplicacaoSimples(operandos[pos2], operandos[pos1], escreverEmResultado);
                                }
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                            case "/":
                                if (ultOpPos > dic.Key) {
                                    arquivo.EscreverDivSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                }
                                else {
                                    arquivo.EscreverDivSimples(operandos[pos2], operandos[pos1], escreverEmResultado);
                                }
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                        }
                    }
                }
            }



        }


        private Dictionary<int, int> GetDicionario(string[] operandos) {
            Dictionary<int,int> dicionario = new Dictionary<int, int>();

            for (int i = 1; i < operandos.Length; i += 2) {
                switch (operandos[i]) {
                    case "+":
                        dicionario.Add(i, Prioridade.PrioridadeAdicao);
                        break;
                    case "-":
                        dicionario.Add(i, Prioridade.PrioridadeAdicao);
                        break;
                    case "*":
                        dicionario.Add(i, Prioridade.PrioridadeMult);
                        break;
                    case "/":
                        dicionario.Add(i, Prioridade.PrioridadeMult);
                        break;
                }
            }

            return dicionario;

        }

    }
}
