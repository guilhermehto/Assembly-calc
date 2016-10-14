using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoArqI.Helpers {
    /// <summary>
    /// Usada para definir o nome de registradores utilizados pelo programa assembly
    /// </summary>
    public static class Contrato {
        public const string Resultado = "$a0";
        public const string ResultadoMultiplicacao = "$a1";
    }

    public static class Prioridade {
        public const int PrioridadeFunc = 2;
        public const int PrioridadeMult = 1;
        public const int PrioridadeAdicao = 0;
    }
}
