using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TCC.Aplicacao.Mapeamentos;
using TCC.Web.InjecaoDeDependencias;
using TCC.Web.Mapeamentos;

namespace TCC.Web {
    public class WebApiApplication : System.Web.HttpApplication {
        private WindsorContainer _windsorContainer;
        protected void Application_Start() {
            InitializeWindsor();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfiguracaoDaAplicacao.RegistrarMapeamentos();
            AutoMapperConfiguracaoDaApresentacao.RegistrarMapeamentos();
        }

        private void InitializeWindsor() {
            var assemblyQueContemInstallers = "TCC.InjecaoDeDependencias";

            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(FromAssembly.Named(assemblyQueContemInstallers));

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
        }
    }
}
