using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades {
    public class Auditoria : Entidade {
        public virtual string Entidade { get; set; }
        public virtual string Chave { get; set; }
        public virtual string Campo { get; set; }
        public virtual string ValorNovo { get; set; }
        public virtual string ValorAntigo { get; set; }
        public virtual string Login { get; set; }
        public virtual DateTime Data { get; set; }
    }
}
