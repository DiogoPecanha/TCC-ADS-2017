using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Dominio.Entidades.View;

namespace TCC.Aplicacao.Interfaces {
    public interface IViewUsuarioPerfilServicoAplicacao : IServicoAplicacao<ViewUsuarioPerfilDto, ViewUsuarioPerfil> {
        ViewUsuarioPerfilDto ValidaLogin(string usuario, string senha, string perfil);
    }
}
