using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCC.Aplicacao.Dtos;
using TCC.Web.Models;

namespace TCC.Web.Mapeamentos {
    public class DtoParaViewModelsMappingProfile : Profile {
        public override string ProfileName {
            get {
                return "MapeamentoDeDtoParaViewModelsMappingProfile";
            }
        }

        protected override void Configure() {
            Mapper.CreateMap<ViewAlunoDto, AlunoModelView>();
        }
    }
}