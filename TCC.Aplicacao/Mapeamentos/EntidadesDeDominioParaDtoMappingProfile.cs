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
    public class EntidadesDeDominioParaDtoMappingProfile : Profile {
        public override string ProfileName {
            get {
                return "MapeamentoDeEntidadeDeDominioParaDto";
            }
        }

        protected override void Configure() {
            Mapper.CreateMap<Aluno, AlunoDto>();
            Mapper.CreateMap<Curso, CursoDto>();
            Mapper.CreateMap<CursoCategoria, CursoCategoriaDto>();
            Mapper.CreateMap<Perfil, PerfilDto>();
            Mapper.CreateMap<Usuario, UsuarioDto>();
            Mapper.CreateMap<ViewUsuarioPerfil, ViewUsuarioPerfilDto>();
            Mapper.CreateMap<ViewCidade, ViewCidadeDto>();
            Mapper.CreateMap<ViewAluno, ViewAlunoDto>();
        }
    }


    public class ProxyConverter<TSource, TDestination> : ITypeConverter<TSource, TDestination>
        where TSource : class
        where TDestination : class {
        public TDestination Convert(ResolutionContext context) {
            // Get dynamic proxy base type
            var baseType = context.SourceValue.GetType().BaseType;

            // Return regular map if base type == Abstract base type
            if (baseType == typeof(TSource))
                baseType = context.SourceValue.GetType();

            // Look up map for base type
            var destType = (from maps in Mapper.GetAllTypeMaps()
                            where maps.SourceType == baseType
                            select maps).FirstOrDefault().DestinationType;

            return Mapper.DynamicMap(context.SourceValue, baseType, destType) as TDestination;
        }
    }
}
