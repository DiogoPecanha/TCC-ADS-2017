using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Web.Models {
    public class PessoaModelView : UsuarioModelView {
        public  string IdPessoa { get; set; }
        public  string Nome { get; set; }
        public  string Foto { get; set; }
        public  DateTime? DtNasc { get; set; }
        public  string EmailInstitucional { get; set; }
        public  string Sexo { get; set; }
        public  string NaturalidadeCidade { get; set; }
        public  string NaturalidadeUF { get; set; }
        public  string Nacionalidade { get; set; }
        public  string EstCivil { get; set; }
        public  string IdNum { get; set; }
        public  string IdExp { get; set; }
        public  string IdUF { get; set; }
        public  string IdDataEmissao { get; set; }
        public  string CPF { get; set; }
        public  string ResEndereco { get; set; }
        public  string ResBairro { get; set; }
        public  string ResCidade { get; set; }
        public  string ResEstado { get; set; }
        public  string ResUF { get; set; }
        public  string ResCEP { get; set; }
        public  string ResTel { get; set; }
        public  string EMailPessoal { get; set; }
        public  string TelCelular { get; set; }
        public  string NomePai { get; set; }
        public  string NomeMae { get; set; }
        public  string TelTrabalho { get; set; }
    }
}