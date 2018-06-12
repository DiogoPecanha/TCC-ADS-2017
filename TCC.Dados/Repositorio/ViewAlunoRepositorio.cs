using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades.View;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.Dados.Repositorio {
    public class ViewAlunoRepositorio : Repositorio<ViewAluno>, IViewAlunoRepositorio {
        public ViewAlunoRepositorio(ISession sessao)
           : base(sessao) {

        }
    }
}