using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades.View;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.Dados.Repositorio {
    public class ViewCidadeRepositorio : Repositorio<ViewCidade>, IViewCidadeRepositorio {
        public ViewCidadeRepositorio(ISession sessao)
           : base(sessao) {

        }
    }
}

