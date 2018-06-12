using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades {
    public class Pessoa : Entidade {
        public virtual string IdPessoa { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Foto { get; set; }
        public virtual string DtNasc { get; set; }
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
        public virtual Usuario Usuario { get; set; }
    }
}
