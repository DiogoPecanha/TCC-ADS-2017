using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCC.Aplicacao.Interfaces;

namespace TCC.InjecaoDeDependencias.Aplicacao {
    public class InstaladorDosServicosDaAplicacao : IWindsorInstaller {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {
            container.Register(Classes.FromAssemblyContaining(typeof(IServicoAplicacao))
                .BasedOn(typeof(IServicoAplicacao))
                .WithService.AllInterfaces()
                .LifestyleTransient()
                );
        }
    }
}
