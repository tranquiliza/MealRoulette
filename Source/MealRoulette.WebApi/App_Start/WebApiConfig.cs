using MealRoulette.Domain.DomainServices;
using MealRoulette.Domain.DomainServices.Abstractions;
using MealRoulette.Domain.Repositories;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.WebApi.DependencyInjection;
using SimpleInjector;
using System.Web.Http;

namespace MealRoulette.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            ConfigureDependencyInjection(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureDependencyInjection(HttpConfiguration config)
        {
            var container = new Container();
            container.Register<IMealService, MealService>();
            container.Register<IUnitOfWork, UnitOfWork>();

            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver().GetControllerTypes(services.GetAssembliesResolver());

            container.RegisterWebApiControllers(config);
            
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
        }

        internal class UnitOfWork : IUnitOfWork
        {
            public IIngredientRepository IngredientRepository => throw new System.NotImplementedException();

            public IMealRepository MealRepository => throw new System.NotImplementedException();

            public IMealCategoryRepository MealCategoryRepository => throw new System.NotImplementedException();

            public void SaveChanges()
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
