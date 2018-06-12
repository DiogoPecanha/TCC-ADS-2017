using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Dtos {
    public class CursoDto : Dto {
        public string Nome { get; set; }
        public CursoCategoriaDto Categoria { get; set; }
    }
}
