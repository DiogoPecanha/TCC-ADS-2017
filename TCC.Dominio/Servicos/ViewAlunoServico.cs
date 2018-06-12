using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades.View;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Dominio.Servicos {
    public class ViewAlunoServico : Servico<ViewAluno>, IViewAlunoServico {

        public ViewAlunoServico(IViewAlunoRepositorio repositorio)
            : base(repositorio) {
        }
    }
}
