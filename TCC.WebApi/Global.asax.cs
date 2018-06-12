using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TCC.InjecaoDeDependencias.Aplicacao;
using TCC.InjecaoDeDependencias.Dominio;
using TCC.InjecaoDeDependencias.Log;
using TCC.InjecaoDeDependencias.Repositorio;
using TCC.InjecaoDeDependencias.UnidadeDeTrabalho;
using TCC.WebApi.InjecaoDeDependencias;

namespace TCC.WebApi {
    public class WebApiApplication : System.Web.HttpApplication {
        private WindsorContainer _windsorContainer;
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            InitializeWindsor();
        }

        private void InitializeWindsor() {
            _windsorContainer = new WindsorContainer();
            _windsorContainer.Install(new InstaladorDosServicosDaAplicacao());
            _windsorContainer.Install(new InstaladorDosServicosDoDominio());
            _windsorContainer.Install(new InstaladorDoLog());
            _windsorContainer.Install(new InstaladorDoNHibernate());
            _windsorContainer.Install(new InstaladorDosRepositorios());
            _windsorContainer.Install(new InstaladorDosRepositoriosSemEstado());
            _windsorContainer.Install(new InstaladorDosInterceptadoresDeTransacao());
            _windsorContainer.Install(new WebApiInstaller());

            // resolve references for API controllers
            // adding a collection sub-resolver resolves things like List when you've only mapped Type.
            // thismay not be needed, but you should test your code with and without it to be sure
            //_windsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(_windsorContainer.Kernel, true));
            // replace actual dependency resolver with our own
            var dependencyResolver = new WindsorDependencyResolver(_windsorContainer);
            //GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;            
            //DependencyResolver.SetResolver(new WindsorDependencyResolver(_windsorContainer));

            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(_windsorContainer));            
        }

        protected void Application_End(object sender, EventArgs e) {
            if (_windsorContainer != null)
                _windsorContainer.Dispose();
        }
    }
}
