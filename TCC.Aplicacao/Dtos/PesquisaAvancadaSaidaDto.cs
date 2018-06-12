using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Dtos {
    public class PesquisaAvancadaSaidaDto<TipoDoDto> {
        public TipoDoDto[] Resultado { get; set; }
        public int TotalDeRegistrosSemPaginar { get; set; }
    }
}
