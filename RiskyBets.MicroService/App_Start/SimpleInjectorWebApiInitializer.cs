using RiskyBets.MicroService.BLL;
using RiskyBets.MicroService.DAL;
using RiskyBets.MicroService.DAL.Entities;

[assembly: WebActivator.PostApplicationStartMethod(typeof(RiskyBets.MicroService.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace RiskyBets.MicroService.App_Start
{
    using System.Web.Http;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            container.Register<IRepository<SettledBet>, SettledBetCsvRepository>(Lifestyle.Scoped);
            container.Register<IRepository<UnSettledBet>, UnsettledBetCsvRepository>(Lifestyle.Scoped);
            container.Register<IRiskAnalyze<SettledBet>, SettledBetsRiskAnalyze>(Lifestyle.Scoped);
            container.Register<IRiskFactors, RiskFactors>(Lifestyle.Scoped);
        }
    }
}