using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using TCC.InjecaoDeDependencias.Aplicacao;
using TCC.InjecaoDeDependencias.Dominio;
using TCC.InjecaoDeDependencias.Log;
using TCC.InjecaoDeDependencias.Repositorio;
using TCC.InjecaoDeDependencias.UnidadeDeTrabalho;

namespace TCC.WebApi.InjecaoDeDependencias {
    public static class CastleHelper {
        public static WindsorContainer Container { get; private set; }
        private static WindsorHttpDependencyResolver _resolver;
        private static bool _initialized;

        static CastleHelper() {
            Container = new WindsorContainer();
            _initialized = false;
        }

        public static WindsorHttpDependencyResolver GetDependencyResolver() {
            if (_initialized)
                return _resolver;

            _initialized = true;
            Container.Install(FromAssembly.This());
            Container.Install(new InstaladorDosServicosDaAplicacao());
            Container.Install(new InstaladorDosServicosDoDominio());
            Container.Install(new InstaladorDoLog());
            Container.Install(new InstaladorDoNHibernate());
            Container.Install(new InstaladorDosRepositorios());
            Container.Install(new InstaladorDosRepositoriosSemEstado());
            Container.Install(new InstaladorDosInterceptadoresDeTransacao());
            Container.Install(new WebApiInstaller());

            //var assemblyQueContemInstallers = "TCC.InjecaoDeDependencias";
            //Container.Install(FromAssembly.Named(assemblyQueContemInstallers));

            _resolver = new WindsorHttpDependencyResolver(Container);            
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), new WindsorHttpControllerActivator(Container));
            //DependencyResolver.SetResolver(new WindsorDependencyResolver(Container));
            return _resolver;
        }
    }
}