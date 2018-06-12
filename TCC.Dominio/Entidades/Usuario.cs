using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades {
    public class Usuario : Entidade {
        public virtual string Login { get; set; }
        public virtual string Senha { get; set; }
        public virtual string SenhaPergunta { get; set; }
        public virtual string SenhaResposta { get; set; }
        public virtual bool Aprovado { get; set; }
        public virtual DateTime DataCriacao { get; set; }
        public virtual DateTime? DataUltimoLogin { get; set; }
        public virtual DateTime? DataUltimaAtividade { get; set; }
        public virtual DateTime? DataUltimaAlteracaoSenha { get; set; }
        public virtual bool Bloqueado { get; set; }
        public virtual DateTime? DataUltimoBloqueio { get; set; }
        public virtual int NumeroTentativasLoginInvalido { get; set; }
        public virtual int TentativaLoginInvalidoInicioJanela { get; set; }
        public virtual int NumeroTentativasRespostaSenhaInvalida { get; set; }
        public virtual int TentativaRespostaSenhaInvalidaInicioJanela { get; set; }
        virtual public IList<UsuarioPerfil> Perfis { get; set; }

    }
}
