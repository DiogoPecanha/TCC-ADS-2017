using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Dominio.Entidades.View;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Aplicacao.Servicos {
    public class ViewCidadeServicoAplicacao : ServicoAplicacao<ViewCidadeDto, ViewCidade>, IViewCidadeServicoAplicacao {
        private readonly IViewCidadeServico _servicoViewCidade;

        public ViewCidadeServicoAplicacao(IViewCidadeServico servicoViewCidade)
            : base(servicoViewCidade) {
            _servicoViewCidade = servicoViewCidade;
        }

        public override int Salvar(ViewCidadeDto dto) {
            return 0;
        }
    }
}