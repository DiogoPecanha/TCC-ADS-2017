using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades.View {
    public class ViewCidade : Entidade{
        public virtual int IdCidade { get; set; }
        public virtual string Nome { get; set; }
        public virtual int IdUf { get; set; }
        public virtual string SiglaUf { get; set; }
        public virtual string NomeUf { get; set; }
    }
}
