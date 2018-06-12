using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC.Dominio.Entidades {
    public class UsuarioPerfil  {
        public virtual Usuario Usuario { get; set; }
        public virtual Perfil Perfil { get; set; }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return base.ToString();
        }
    }
}
