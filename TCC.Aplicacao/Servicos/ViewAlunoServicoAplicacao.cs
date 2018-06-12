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
    public class ViewAlunoServicoAplicacao : ServicoAplicacao<ViewAlunoDto, ViewAluno>, IViewAlunoServicoAplicacao {
        private readonly IViewAlunoServico _servicoViewAluno;
        private readonly IPessoaServico _servicoPessoa;
        private readonly IAlunoServico _servicoAluno;
        private readonly IUsuarioServico _servicoUsuario;

        public ViewAlunoServicoAplicacao(IViewAlunoServico servicoViewAluno, IPessoaServico servicoPessoa, IAlunoServico servicoAluno, IUsuarioServico servicoUsuario)
            : base(servicoViewAluno) {
            _servicoViewAluno = servicoViewAluno;
            _servicoPessoa = servicoPessoa;
            _servicoAluno = servicoAluno;
            _servicoUsuario = servicoUsuario;
        }

        public override int Salvar(ViewAlunoDto dto) {
            return 0;
        }
    }
}