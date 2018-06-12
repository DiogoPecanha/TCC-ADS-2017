using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio {
    [AttributeUsage(AttributeTargets.Method)]
    public class TransacaoAtomicaAttribute : Attribute {
    }
}
