using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;

namespace TCC.Dados.Mapeamentos {
    public class CursoCategoriaMap : ClassMap<CursoCategoria> {

        public CursoCategoriaMap() {
            //Schema("dbo");
            Table("CursoCategoria");
            Id(x => x.Id).Column("IdCursoCategoria");
            Map(x => x.Nome);
            //References(x => x.SecaoBloqueio).Column("IdSecaoBloqueio");
        }
    }
}
