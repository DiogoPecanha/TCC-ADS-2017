using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades.View;

namespace TCC.Dados.Mapeamentos.View {
    public class ViewCidadeMap : ClassMap<ViewCidade> {
        public ViewCidadeMap() {
            Table("ViewCidade");
            Id(x => x.IdCidade).Column("IdCidade");
            Map(x => x.IdUf);
            Map(x => x.Nome);
            Map(x => x.NomeUf);
            Map(x => x.SiglaUf);
        }
    }
}