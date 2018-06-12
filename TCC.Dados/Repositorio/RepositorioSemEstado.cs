using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.Dados.Repositorio {
    public class RepositorioSemEstado<TipoDaEntidade> : IRepositorioSemEstado<TipoDaEntidade> where TipoDaEntidade : class {
        private readonly IStatelessSession _sessao;

        public RepositorioSemEstado(IStatelessSession sessao) {
            _sessao = sessao;
        }

        protected IStatelessSession Sessao {
            get {
                return _sessao;
            }
        }

        public TipoDaEntidade PorId(int id) {
            return Sessao.Get<TipoDaEntidade>(id);
        }

        public IQueryable<TipoDaEntidade> Todos() {
            return Sessao.Query<TipoDaEntidade>();
        }

        public void Salvar(TipoDaEntidade entidade) {
            throw new NotImplementedException();
        }

        public void Excluir(TipoDaEntidade entidade) {
            _sessao.Delete(entidade);
        }
    }
}
