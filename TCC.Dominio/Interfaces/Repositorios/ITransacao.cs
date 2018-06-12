using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Interfaces.Repositorios {
    public interface ITransacao {
        void IniciaTransacao();
        void DesfazTransacao();
        void FinalizaTransacao();
        bool TransacoEmAndamento();
    }
}
