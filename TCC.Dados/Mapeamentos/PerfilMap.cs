using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;

namespace TCC.Dados.Mapeamentos {
    public class PerfilMap : ClassMap<Perfil> {

        public PerfilMap() {
            //Schema("dbo");
            Table("Perfil");
            Id(x => x.Id).Column("IdPerfil");
            Map(x => x.Nome);
        }
    }
}
