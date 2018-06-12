using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Dominio;
using TCC.Dominio.Entidades.View;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Aplicacao.Servicos {
    public class ViewUsuarioPerfilServicoAplicacao : ServicoAplicacao<ViewUsuarioPerfilDto, ViewUsuarioPerfil>, IViewUsuarioPerfilServicoAplicacao {
        private readonly IViewUsuarioPerfilServico _servicoViewUsuarioPerfil;

        public ViewUsuarioPerfilServicoAplicacao(IViewUsuarioPerfilServico servicoViewUsuarioPerfil)
            : base(servicoViewUsuarioPerfil) {
            _servicoViewUsuarioPerfil = servicoViewUsuarioPerfil;
        }

        public override int Salvar(ViewUsuarioPerfilDto dto) {
            return 0;
        }

        public ViewUsuarioPerfilDto ValidaLogin(string usuario, string senha, string perfil) {
            var user = new ViewUsuarioPerfilDto();
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(senha) || string.IsNullOrEmpty(perfil)) {
                throw new Exception("Dados informados inválidos");
            }

            var registros = _servicoViewUsuarioPerfil.Todos().Where(x => x.Login.ToLower() == usuario.ToLower() && x.Senha == senha);
            if (registros == null) {
                throw new Exception("Usuário ou senha inválidos");
            }

            var userTemp = registros.Where(x => x.IdPerfil == perfil).FirstOrDefault();
            if (userTemp == null) throw new Exception("Usuário não possui acesso ao perfil selecionado");

            if (userTemp != null) AutoMapper.Mapper.Map(userTemp, user);            

            return user;
        }
    }
}