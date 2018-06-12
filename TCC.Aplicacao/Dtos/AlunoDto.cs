using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Dtos {
    public class AlunoDto : Dto {
        public  string Matricula { get; set; }
        public  bool Ativo { get; set; }
    }
}
