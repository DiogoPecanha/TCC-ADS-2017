using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Entidades;

namespace TCC.Dominio.Entidades {
    public class Aluno : Entidade {
        public virtual string Matricula { get; set; }
        public virtual bool Ativo { get; set; }
    }
}
