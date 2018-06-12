using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Entidades.View;

namespace TCC.Dados.Mapeamentos.View {
    public class ViewAlunoMap : ClassMap<ViewAluno> {
        public ViewAlunoMap() {
            Table("ViewAluno");
            Id(x => x.Id).Column("IdAluno");
            Map(x => x.Ativo);
            Map(x => x.Matricula);
            Map(x => x.Nome);
            Map(x => x.Foto);
            Map(x => x.DtNasc);
            Map(x => x.EmailInstitucional);
            Map(x => x.Sexo);
            Map(x => x.NaturalidadeCidade);
            Map(x => x.NaturalidadeUF);
            Map(x => x.Nacionalidade);
            Map(x => x.EstCivil);
            Map(x => x.IdNum);
            Map(x => x.IdExp);
            Map(x => x.IdUF);
            Map(x => x.IdDataEmissao);
            Map(x => x.CPF);
            Map(x => x.ResEndereco);
            Map(x => x.ResBairro);
            Map(x => x.ResCidade);
            Map(x => x.ResEstado);
            Map(x => x.ResUF);
            Map(x => x.ResCEP);
            Map(x => x.ResTel);
            Map(x => x.EMailPessoal);
            Map(x => x.TelCelular);
            Map(x => x.NomePai);
            Map(x => x.NomeMae);
            Map(x => x.TelTrabalho);
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
        }
    }
}