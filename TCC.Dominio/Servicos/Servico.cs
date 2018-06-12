using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.Dominio.Servicos {
    public class Servico<TipoDaEntidade> : IServico<TipoDaEntidade> where TipoDaEntidade : class {
        private readonly IRepositorioBase<TipoDaEntidade> _repositorio;

        public Servico(IRepositorioBase<TipoDaEntidade> repositorio) {
            _repositorio = repositorio;
        }

        public IQueryable<TipoDaEntidade> Todos() {
            return _repositorio.Todos();
        }

        public void Salvar(TipoDaEntidade entidade) {
            _repositorio.Salvar(entidade);
        }

        public void Excluir(TipoDaEntidade entidade) {
            _repositorio.Excluir(entidade);
        }

        public TipoDaEntidade PorId(string id) {
            return _repositorio.PorId(id);
        }
    }
}

