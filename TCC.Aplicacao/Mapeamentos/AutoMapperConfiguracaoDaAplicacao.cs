using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Aplicacao.Mapeamentos {
    public class AutoMapperConfiguracaoDaAplicacao {
        public static void RegistrarMapeamentos() {
            Mapper.Initialize(cfg => {
                cfg.AddProfile(new DtoParaEntidadesDeDominioMappingProfile());
                cfg.AddProfile(new EntidadesDeDominioParaDtoMappingProfile());
            });
        }
    }
}
