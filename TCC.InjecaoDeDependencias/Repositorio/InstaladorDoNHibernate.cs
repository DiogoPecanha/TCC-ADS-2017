using Castle.MicroKernel.Registration;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TCC.InjecaoDeDependencias.Repositorio {
    public class InstaladorDoNHibernate : IWindsorInstaller {

        public void Install(Castle.Windsor.IWindsorContainer container, Castle.MicroKernel.SubSystems.Configuration.IConfigurationStore configurationStore) {
            container.Register(Component.For<ISessionFactory>()
                .UsingFactoryMethod(CriaFabricaDeSessaoDoNhibernate)
                .LifestyleSingleton());

            container.Register(Component.For<ISession>()
                .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenSession())
                .LifeStyle.PerWebRequest);

            container.Register(Component.For<IStatelessSession>()
                .UsingFactoryMethod(k => k.Resolve<ISessionFactory>().OpenStatelessSession())
                .LifestylePerWebRequest());
        }

        private static ISessionFactory CriaFabricaDeSessaoDoNhibernate() {
            System.Diagnostics.Debug.WriteLine("Carregando configurações do Nhibernate");
            var cfg = new Configuration().Configure();
            string assemblyComMapeamentos = "TCC.Dados";

            System.Diagnostics.Debug.WriteLine("Criando fábrica de sessão do Nhibernate");
            ISessionFactory fabrica = Fluently.Configure(cfg).Mappings(mapa => mapa.FluentMappings.AddFromAssembly(Assembly.Load(assemblyComMapeamentos))).BuildSessionFactory();

            return fabrica;
        }
    }
}
