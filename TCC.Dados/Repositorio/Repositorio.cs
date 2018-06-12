using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.Dados.Repositorio {
    public class Repositorio<TipoDaEntidade> : RepositorioBase, IRepositorioBase, IRepositorioBase<TipoDaEntidade> where TipoDaEntidade : class {

        private readonly ISession _sessao;

        public Repositorio(ISession sessao) {
            _sessao = sessao;
        }

        public IQueryable<TipoDaEntidade> Todos() {
            return _sessao.Query<TipoDaEntidade>();
        }

        public void Salvar(TipoDaEntidade entidade) {
            _sessao.SaveOrUpdate(entidade);
        }

        public void Excluir(TipoDaEntidade entidade) {
            _sessao.Delete(entidade);
        }

        public TipoDaEntidade PorId(string id) {
            return _sessao.Get<TipoDaEntidade>(id);
        }
    }
}
