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

        // Identifica e separa os operandos e os operadores
        public string[] IdentificarOperandos(string calculo) {
            
            string[] operandos = new string[calculo.Length];
            int i = 0;
            
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


        public void EscreverCodigo(string[] operandos, Arquivo arquivo) {
            var dicionario = GetDicionario(operandos); // Dicionário que é utilizado para relacionar a posição do operando com sua prioridade (Chave-Valor)
            bool escreverEmResultado = false;
            var ultOpPos = 0; // A posição da ultima operação
            for (int i = Prioridade.PrioridadeFunc; i >= 0; i--) { // Para cada prioridade
                foreach (var dic in dicionario) { // Para cada relação no dicionário
                    if (dic.Value == i) { // Se o valor for igual à prioridade em questão
                        var pos1 = dic.Key - 1; // operando à esquerda
                        var pos2 = dic.Key + 1; // operando à direita
                        switch (operandos[dic.Key]) {
                            case "+": 
                                // Soma
                                arquivo.EscreverSomaSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                            case "-": 
                                // Subtração
                                arquivo.EscreverSubSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                            case "*":
                                //Multiplicação
                                arquivo.EscreverMultiplicacaoSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                            case "/":
                                //Divisão
                                arquivo.EscreverDivSimples(operandos[pos1], operandos[pos2], escreverEmResultado);
                                escreverEmResultado = true;
                                ultOpPos = dic.Key;
                                break;
                        }
                    }
                }
            }
        }

        //Método que cria o dicionário e de acordo com a operação, associa uma prioridade
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
