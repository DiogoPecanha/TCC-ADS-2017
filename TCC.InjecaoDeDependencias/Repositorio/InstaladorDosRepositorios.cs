using Castle.Core;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCC.Dados.Repositorio;
using TCC.Dominio.Interfaces.Repositorios;
using TCC.InjecaoDeDependencias.UnidadeDeTrabalho;

namespace TCC.InjecaoDeDependencias.Repositorio {
    public class InstaladorDosRepositorios : IWindsorInstaller {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {
            container.Kernel.ComponentRegistered += ComponenteRegistradoNoKernel;

            container.Register(Classes.FromAssembly(Assembly.GetAssembly(typeof(RepositorioBase)))
                .BasedOn(typeof(IRepositorioBase))
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }

        private void ComponenteRegistradoNoKernel(string chave, Castle.MicroKernel.IHandler handler) {
            if (UnidadeDeTrabalhoHelper.EhUmaClasseDeRepositorio(handler.ComponentModel.Implementation)) {
                handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(InterceptadorDosMetodosDoRepositorio)));
            }

            foreach (var metodo in handler.ComponentModel.Implementation.GetMethods()) {
                if (UnidadeDeTrabalhoHelper.PossuiAtributoTransacao(metodo)) {
                    handler.ComponentModel.Interceptors.Add(new InterceptorReference(typeof(InterceptadorDosMetodosDoRepositorio)));
                    return;
                }
            }
        }
    }
}