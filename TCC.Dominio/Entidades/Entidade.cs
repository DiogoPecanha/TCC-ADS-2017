using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Entidades;

namespace TCC.Dominio.Entidades {
    public class Entidade : IEntidade {
        public virtual string Id { get; set; }
        public virtual int Versao { get; protected set; }

        public virtual TipoDaEntidade Como<TipoDaEntidade>() where TipoDaEntidade : Entidade {

            return this as TipoDaEntidade;
        }

    }
}
