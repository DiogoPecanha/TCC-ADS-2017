using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Http.Controllers;
using System.IO;

namespace TCC.InjecaoDeDependencias.Apresentacao {
    public class InstaladorDosControllersDoAspNetWebApi : IWindsorInstaller {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {

            string assemblyQueContemControllers = "TCC.WebApi";
            container.Register(Classes
            //.FromAssemblyContaining(typeof(ApiController))
            .FromAssemblyNamed(assemblyQueContemControllers)
            .BasedOn<ApiController>()            
            .LifestyleTransient());


            //container.Register(Classes.FromAssemblyNamed(assemblyQueContemControllers)
            //        .BasedOn<IHttpController>(). //Web API
            //        If(c => c.Name.EndsWith("Controller")).
            //        LifestyleTransient());


            ////container.Register(Classes.FromAssemblyContaining(typeof(IHttpController))
            ////.BasedOn<IHttpController>()
            ////.WithService.AllInterfaces()
            ////.LifestyleTransient());
        }
    }
}
