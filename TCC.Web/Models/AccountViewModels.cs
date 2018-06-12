using System;
using System.Collections.Generic;

namespace TCC.Web.Models
{
    // Models returned by AccountController actions.

    public class LoginViewModel {
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public bool LembrarDados { get; set; }
        public string MensagemLogin { get; set; }
    }

    public class ExternalLoginViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }

    public class ManageInfoViewModel
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfoViewModel> Logins { get; set; }

        public IEnumerable<ExternalLoginViewModel> ExternalLoginProviders { get; set; }
    }

    public class UserInfoViewModel
    {
        public string Email { get; set; }

        public bool HasRegistered { get; set; }

        public string LoginProvider { get; set; }
    }

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

    public class CredecialModelView {
        public UsuarioModelView Usuario { get; set; }
        //public configuraco[] Configuracoes { get; set; }
    }

    public class UsuarioModelView {
        public  string Id { get; set; }
        public  string Login { get; set; }
        public  string Senha { get; set; }
        public  string SenhaPergunta { get; set; }
        public  string SenhaResposta { get; set; }
        public  bool Aprovado { get; set; }
        public  DateTime DataCriacao { get; set; }
        public  DateTime? DataUltimoLogin { get; set; }
        public  DateTime? DataUltimaAtividade { get; set; }
        public  DateTime? DataUltimaAlteracaoSenha { get; set; }
        public bool Bloqueado { get; set; }
        public  DateTime? DataUltimoBloqueio { get; set; }
        public  int NumeroTentativasLoginInvalido { get; set; }
        public  int TentativaLoginInvalidoInicioJanela { get; set; }
        public  int NumeroTentativasRespostaSenhaInvalida { get; set; }
        public  int TentativaRespostaSenhaInvalidaInicioJanela { get; set; }
        public bool Ativo { get; set; }
        public string IdPerfil  { get; set; }
        public string PerfilNome { get; set; }
        public PerfilModel[] Perfil { get; set; }
        public PerfisModel PerfisDisponiveis { get; set; }
        public UsuarioModelView() {
            PerfisDisponiveis = new Models.PerfisModel();
        }
    }

    public class UsuarioPerfilViewModel {
        public string Id { get; set; }
        public string Nome { get; set; }
    }
}
