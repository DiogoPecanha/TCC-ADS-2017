using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Web.Mapeamentos {
    public class ParametrosParaDtoMappingProfile : Profile {
        public override string ProfileName {
            get {
                return "MapeamentoDeParametroParaDto";
            }
        }

        protected override void Configure() {
        }
    }
}