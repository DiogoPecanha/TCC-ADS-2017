using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Dtos {
    public class UsuarioDto :Dto {
        public string Login { get; set; }
        public string Senha { get; set; }
        public string SenhaPergunta { get; set; }
        public string SenhaResposta { get; set; }
        public bool Aprovado { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public DateTime? DataUltimaAtividade { get; set; }
        public DateTime? DataUltimaAlteracaoSenha { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? DataUltimoBloqueio { get; set; }
        public int NumeroTentativasLoginInvalido { get; set; }
        public int TentativaLoginInvalidoInicioJanela { get; set; }
        public int NumeroTentativasRespostaSenhaInvalida { get; set; }
        public int TentativaRespostaSenhaInvalidaInicioJanela { get; set; }
        public PerfilDto Perfil { get; set; }
    }
}
