using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;

namespace TCC.Dados.Mapeamentos {
    public class AlunoMap : ClassMap<Aluno> {

        public AlunoMap() {
            //Schema("dbo");
            Table("Aluno");
            Id(x => x.Id).Column("IdAluno");
            Map(x => x.Ativo);
            Map(x => x.Matricula);
        }
    }
}