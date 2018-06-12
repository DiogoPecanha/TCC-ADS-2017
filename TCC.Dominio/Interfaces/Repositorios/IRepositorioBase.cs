using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Interfaces.Repositorios {
    public interface IRepositorioBase {
    }

    public interface IRepositorioBase<TipoDaEntidade> : IRepositorioBase where TipoDaEntidade : class {
        TipoDaEntidade PorId(string id);
        IQueryable<TipoDaEntidade> Todos();
        void Salvar(TipoDaEntidade entidade);
        void Excluir(TipoDaEntidade entidade);
    }
}
