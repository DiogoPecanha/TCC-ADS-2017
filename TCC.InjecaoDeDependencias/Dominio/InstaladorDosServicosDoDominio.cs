using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Dominio.Interfaces.Servicos;

namespace TCC.InjecaoDeDependencias.Dominio {
    public class InstaladorDosServicosDoDominio : IWindsorInstaller {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {
            container.Register(Classes.FromAssemblyContaining(typeof(IServico<>))
                .BasedOn(typeof(IServico<>))
                .WithService.AllInterfaces()
                .LifestyleTransient());
        }
    }
}