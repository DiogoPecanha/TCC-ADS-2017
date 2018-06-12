using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Dominio.Servicos {
    public class PerfilServico : Servico<Perfil>, IPerfilServico {

        public PerfilServico(IPerfilRepositorio repositorio)
            : base(repositorio) {
        }
    }
}
