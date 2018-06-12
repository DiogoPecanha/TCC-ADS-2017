using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Dtos;
using TCC.Dominio.Entidades;
using TCC.Dominio.Entidades.View;

namespace TCC.Aplicacao.Mapeamentos {
    public class DtoParaEntidadesDeDominioMappingProfile : Profile {
        public override string ProfileName {
            get {
                return "MapeamentoDeDtoParaEntidadeDeDominio";
            }
        }

        protected override void Configure() {
            Mapper.CreateMap<AlunoDto,Aluno>();
            Mapper.CreateMap<CursoDto,Curso>();
            Mapper.CreateMap<CursoCategoriaDto,CursoCategoria > ();
            Mapper.CreateMap<PerfilDto, Perfil>();
            Mapper.CreateMap<UsuarioDto,Usuario>();
            Mapper.CreateMap<ViewUsuarioPerfilDto, ViewUsuarioPerfil>();
            Mapper.CreateMap<ViewCidadeDto, ViewCidade>();
            Mapper.CreateMap<ViewAlunoDto, ViewAluno>();
        }
    }
}
