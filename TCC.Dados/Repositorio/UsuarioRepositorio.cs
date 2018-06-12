using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.Dados.Repositorio {
     public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio {
        public UsuarioRepositorio(ISession sessao)
           : base(sessao) {

        }
    }
}