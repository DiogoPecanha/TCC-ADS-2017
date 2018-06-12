using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Web.Models {
    public class CursoModelView {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string IdAreaConhecimento { get; set; }
        public string AreaConhecimento { get; set; }
        public string Sigla { get; set; }
        public string CargaHoraria { get; set; }
        public string NivelEnsino { get; set; }
        public string IdNivelEnsino { get; set; }
        public string IdTipoCurso { get; set; }
        public string TipoCurso { get; set; }
        public string IdModalidade { get; set; }
        public string Modalidade { get; set; }
        public string NumeroPeriodos { get; set; }
        public string Periodicidade { get; set; }
        public string IdPeriodicidade { get; set; }

        public CursoModelView() {

        }
    }
}