using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TCC.Dados.Repositorio;
using TCC.Dominio.Interfaces.Repositorios;

namespace TCC.InjecaoDeDependencias.Repositorio {
    public class InstaladorDosRepositoriosSemEstado : IWindsorInstaller {
        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {
            container.Register(Classes.FromAssembly(Assembly.GetAssembly(typeof(RepositorioSemEstado<>)))
                .BasedOn(typeof(IRepositorioSemEstado))
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }
    }
}
