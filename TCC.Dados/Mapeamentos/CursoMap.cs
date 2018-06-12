using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;

namespace TCC.Dados.Mapeamentos {
    public class CursoMap : ClassMap<Curso> {

        public CursoMap() {
            //Schema("dbo");
            Table("Curso");
            Id(x => x.Id).Column("IdCurso");
            Map(x => x.Nome);            
        }
    }
}
