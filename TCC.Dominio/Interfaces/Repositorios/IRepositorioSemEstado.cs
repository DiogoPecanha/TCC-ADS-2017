using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Interfaces.Repositorios {
    public interface IRepositorioSemEstado {
    }

    public interface IRepositorioSemEstado<TipoDaEntidade> : IRepositorioSemEstado where TipoDaEntidade : class {
        TipoDaEntidade PorId(int id);
        IQueryable<TipoDaEntidade> Todos();
        void Salvar(TipoDaEntidade entidade);
        void Excluir(TipoDaEntidade entidade);
    }
}
