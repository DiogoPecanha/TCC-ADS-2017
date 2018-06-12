using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades;

namespace TCC.Dados.Mapeamentos {

    public class UsuarioMap : ClassMap<Usuario> {

        public UsuarioMap() {
            //Schema("dbo");
            Table("Usuario");
            Id(x => x.Id).Column("IdUsuario");
            Map(x => x.Login);
            Map(x => x.Senha);
            Map(x => x.SenhaPergunta);
            Map(x => x.SenhaResposta);
            Map(x => x.Aprovado);
            Map(x => x.DataCriacao);
            Map(x => x.DataUltimoLogin);
            Map(x => x.DataUltimaAtividade);
            Map(x => x.DataUltimaAlteracaoSenha);
            Map(x => x.Bloqueado);
            Map(x => x.DataUltimoBloqueio);
            Map(x => x.NumeroTentativasLoginInvalido);
            Map(x => x.TentativaLoginInvalidoInicioJanela);
            Map(x => x.NumeroTentativasRespostaSenhaInvalida);
            Map(x => x.TentativaRespostaSenhaInvalidaInicioJanela);
            HasMany(x => x.Perfis)
                .Cascade.AllDeleteOrphan()
                .Fetch.Join()
                .Inverse().KeyColumn("IdUsuario");
        }
    }
}
