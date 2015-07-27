
using Microsoft.Practices.Unity;
using BusinessServices;
using Resolver;
using System.Web.Http;
using System.Web.Mvc;
namespace WEBAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            //var container = new UnityContainer();

            var container = BuildUnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            //System.Web.Mvc.DependencyResolver.SetResolver(new UnityDependencyResolver(container));


            //GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            System.Web.Mvc.DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();        
            //container.RegisterType<IProductServices, ProductServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            RegisterTypes(container);

            return container;
        }
        public static void RegisterTypes(IUnityContainer container)
        {
            ComponentLoader.LoadContainer(container, ".\\bin", "WEBAPI.dll");
            ComponentLoader.LoadContainer(container, ".\\bin", "BusinessServices.dll");
        }
    }
}