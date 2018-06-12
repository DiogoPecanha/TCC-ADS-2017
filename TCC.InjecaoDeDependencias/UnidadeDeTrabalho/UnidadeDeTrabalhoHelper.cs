using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.InjecaoDeDependencias.UnidadeDeTrabalho {
    public static class UnidadeDeTrabalhoHelper {

        public static bool EhUmMetodoDoRepositorio(MethodInfo metodo) {
            return EhUmaClasseDeRepositorio(metodo.DeclaringType);
        }

        public static bool EhUmaClasseDeRepositorio(Type tipo) {
            return typeof(IRepositorioBase).IsAssignableFrom(tipo);
        }

        public static bool PossuiAtributoTransacao(MethodInfo metodo) {
            return metodo.IsDefined(typeof(TransacaoAtomicaAttribute), true);
        }
    }
}