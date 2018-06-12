using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades.View;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.Dominio.Interfaces.Servicos;
using TCC.Dominio.Servicos;

namespace TCC.Dominio.Servicos {
    public class ViewUsuarioPerfilServico : Servico<ViewUsuarioPerfil>, IViewUsuarioPerfilServico {

        public ViewUsuarioPerfilServico(IViewUsuarioPerfilRepositorio repositorio)
            : base(repositorio) {
        }
    }
}
