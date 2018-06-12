using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Interfaces.Servicos {
    public interface IServico<TipoDaEntidade> where TipoDaEntidade : class {
        TipoDaEntidade PorId(string id);
        IQueryable<TipoDaEntidade> Todos();
        void Salvar(TipoDaEntidade entidade);
        void Excluir(TipoDaEntidade entidade);

    }
}
