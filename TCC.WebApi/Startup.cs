using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Security.OAuth;
using Castle.Windsor;
using TCC.InjecaoDeDependencias.Aplicacao;
using TCC.InjecaoDeDependencias.Dominio;
using TCC.InjecaoDeDependencias.Log;
using TCC.InjecaoDeDependencias.Repositorio;
using TCC.InjecaoDeDependencias.UnidadeDeTrabalho;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using TCC.WebApi.InjecaoDeDependencias;
using System.Web.Mvc;
using Castle.Windsor.Installer;

[assembly: OwinStartup(typeof(TCC.WebApi.Startup))]

namespace TCC.WebApi {    
    public partial class Startup {
        //private WindsorContainer _windsorContainer;
        private HttpConfiguration config;
        public void Configuration(IAppBuilder app)
        {
            // configuracao WebApi
            config = new HttpConfiguration();
            // configurando rotas
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
             );

            
            // ativando cors
            app.UseCors(CorsOptions.AllowAll);
            // ativando a geração do token
            AtivarGeracaoTokenAcesso(app);
            // ativando configuração WebApi
            app.UseWebApi(config);

            //InitializeWindsor();
        }



        //private void InitializeWindsor() {
        //    _windsorContainer = new WindsorContainer();
        //    _windsorContainer.Install(new InstaladorDosServicosDaAplicacao());
        //    _windsorContainer.Install(new InstaladorDosServicosDoDominio());
        //    _windsorContainer.Install(new InstaladorDoLog());
        //    _windsorContainer.Install(new InstaladorDoNHibernate());
        //    _windsorContainer.Install(new InstaladorDosRepositorios());
        //    _windsorContainer.Install(new InstaladorDosRepositoriosSemEstado());
        //    _windsorContainer.Install(new InstaladorDosInterceptadoresDeTransacao());
        //    _windsorContainer.Install(FromAssembly.This());

        //    // resolve references for API controllers
        //    // adding a collection sub-resolver resolves things like List when you've only mapped Type.
        //    // thismay not be needed, but you should test your code with and without it to be sure
        //    //_windsorContainer.Kernel.Resolver.AddSubResolver(new CollectionResolver(_windsorContainer.Kernel, true));
        //    // replace actual dependency resolver with our own
        //    var dependencyResolver = new WindsorDependencyResolver(_windsorContainer);            
        //    config.DependencyResolver = dependencyResolver;            
        //    // use new controller factory
        //    //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(Container));

        //    //ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(_windsorContainer.Kernel));
        //}

        private void AtivarGeracaoTokenAcesso(IAppBuilder app) {
            var opcoesConfiguracaoToken = new OAuthAuthorizationServerOptions() {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),
                Provider = new ProviderDeTokensDeAcesso()
            };
            app.UseOAuthAuthorizationServer(opcoesConfiguracaoToken);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
