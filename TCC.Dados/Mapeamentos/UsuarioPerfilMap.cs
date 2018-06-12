using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;

namespace TCC.Dados.Mapeamentos {
    public class UsuarioPerfilMap : ClassMap<UsuarioPerfil> {

        public UsuarioPerfilMap() {
            //Schema("dbo");
            Table("UsuarioPerfil");
            CompositeId()
            .KeyReference(x => x.Usuario, "IdUsuario")
            .KeyReference(x => x.Perfil, "IdPerfil");
            References(x => x.Usuario)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("IdUsuario");
            References(x => x.Perfil)
                .Not.Nullable()
                .Cascade.SaveUpdate()
                .Column("IdPerfil");
        }


    }
}
