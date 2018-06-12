using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Web.Models {
    public class AlunoModelView : PessoaModelView {
        public string Matricula { get; set; }
        public bool Ativo { get; set; }
    }
}