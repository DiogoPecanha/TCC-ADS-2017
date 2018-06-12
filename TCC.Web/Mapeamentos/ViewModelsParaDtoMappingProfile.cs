using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCC.Aplicacao.Dtos;
using TCC.Dominio.Entidades.View;
using TCC.Web.Models;

namespace TCC.Web.Mapeamentos {
    public class ViewModelsParaDtoMappingProfile : Profile {
        public override string ProfileName {
            get {
                return "MapeamentoDeViewModelsParaDto";
            }
        }

        protected override void Configure() {
            Mapper.CreateMap<AlunoModelView, ViewAlunoDto>();
        }
    }
}
