using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades {
    public class Curso {
        public virtual string Id { get; set; }
        public virtual string Nome { get; set; }
        public virtual CursoCategoria Categoria { get; set; }
    }
}
