using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace TCC.InjecaoDeDependencias.Apresentacao {
    public class InstaladorDosControllersDoAspNetMvc : IWindsorInstaller {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {

            string assemblyQueContemControllers = "TCC.Web";

            container.Register(Classes
                .FromAssemblyNamed(assemblyQueContemControllers)
                .BasedOn<IController>()
                .LifestyleTransient());
        }
    }
}
