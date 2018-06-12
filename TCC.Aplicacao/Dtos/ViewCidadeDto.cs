using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Dtos {
    public class ViewCidadeDto : Dto {
        public int IdCidade { get; set; }
        public string Nome { get; set; }
        public int IdUf { get; set; }
        public string SiglaUf { get; set; }
        public string NomeUf { get; set; }
    }
}
