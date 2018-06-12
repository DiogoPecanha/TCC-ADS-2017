using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Aplicacao.Interfaces;
using TCC.Dominio;
using TCC.Dominio.Entidades;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Aplicacao.Servicos {
    public class UsuarioServicoAplicacao : ServicoAplicacao<UsuarioDto, Usuario>, IUsuarioServicoAplicacao {
        private readonly IUsuarioServico _servicoUsuario;
        private readonly IPerfilServico _servicoPerfil;

        public UsuarioServicoAplicacao(IUsuarioServico servicoUsuario, IPerfilServico servicoPerfil)
            : base(servicoUsuario) {
            _servicoUsuario = servicoUsuario;
            _servicoPerfil = servicoPerfil;
        }

        public override int Salvar(UsuarioDto dto) {
            Usuario usuario = new Usuario();
            usuario.Id = dto.Id;   
            usuario.Login = dto.Login;
            usuario.Aprovado = dto.Aprovado;
            usuario.Bloqueado = dto.Bloqueado;
            usuario.DataCriacao = dto.DataCriacao;
            usuario.DataUltimaAlteracaoSenha = dto.DataUltimaAlteracaoSenha;
            usuario.DataUltimaAtividade = dto.DataUltimaAtividade;
            usuario.DataUltimoBloqueio = dto.DataUltimoBloqueio;
            usuario.DataUltimoLogin = dto.DataUltimoLogin;
            usuario.NumeroTentativasLoginInvalido = dto.NumeroTentativasLoginInvalido;
            usuario.NumeroTentativasRespostaSenhaInvalida = dto.NumeroTentativasRespostaSenhaInvalida;
            usuario.Senha = dto.Senha;
            usuario.SenhaPergunta = dto.SenhaPergunta;
            usuario.SenhaResposta = dto.SenhaResposta;
            usuario.TentativaLoginInvalidoInicioJanela = dto.TentativaLoginInvalidoInicioJanela;
            usuario.TentativaRespostaSenhaInvalidaInicioJanela = dto.TentativaRespostaSenhaInvalidaInicioJanela;

            Perfil perfil = _servicoPerfil.PorId(dto.Perfil.Id);

            usuario.Perfis = new UsuarioPerfil[] {
                new UsuarioPerfil {
                    Perfil = perfil,
                    Usuario = usuario
                }
            };

            _servicoUsuario.Salvar(usuario);            
            return 1;
        }
    }
}