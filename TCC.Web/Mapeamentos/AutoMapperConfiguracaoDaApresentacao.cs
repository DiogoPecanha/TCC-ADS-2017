using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCC.Web.Mapeamentos {
    public class AutoMapperConfiguracaoDaApresentacao {
        public static void RegistrarMapeamentos() {
            Mapper.AddProfile<ViewModelsParaDtoMappingProfile>();
            Mapper.AddProfile<DtoParaViewModelsMappingProfile>();
            Mapper.AddProfile<ParametrosParaDtoMappingProfile>();
        }
    }
}