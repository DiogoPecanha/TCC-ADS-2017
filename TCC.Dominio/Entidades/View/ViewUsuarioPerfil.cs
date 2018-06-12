using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades.View {
    public class ViewUsuarioPerfil : Entidade {
        public virtual string IdUsuario { get; set; }
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
        public virtual string IdPerfil { get; set; }
        public virtual string NomePerfil { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Foto { get; set; }
        public virtual DateTime? DtNasc { get; set; }
        public virtual string EmailInstitucional { get; set; }
        public virtual string Sexo { get; set; }
        public virtual string NaturalidadeCidade { get; set; }
        public virtual string NaturalidadeUF { get; set; }
        public virtual string Nacionalidade { get; set; }
        public virtual string EstCivil { get; set; }
        public virtual string IdNum { get; set; }
        public virtual string IdExp { get; set; }
        public virtual string IdUF { get; set; }
        public virtual string IdDataEmissao { get; set; }
        public virtual string CPF { get; set; }
        public virtual string ResEndereco { get; set; }
        public virtual string ResBairro { get; set; }
        public virtual string ResCidade { get; set; }
        public virtual string ResEstado { get; set; }
        public virtual string ResUF { get; set; }
        public virtual string ResCEP { get; set; }
        public virtual string ResTel { get; set; }
        public virtual string EMailPessoal { get; set; }
        public virtual string TelCelular { get; set; }
        public virtual string NomePai { get; set; }
        public virtual string NomeMae { get; set; }
        public virtual string TelTrabalho { get; set; }
    }
}
