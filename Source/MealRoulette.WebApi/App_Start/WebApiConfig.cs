using MealRoulette.Domain.DomainServices;
using MealRoulette.Domain.DomainServices.Abstractions;
using MealRoulette.Domain.Repositories;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.WebApi.DependencyInjection;
using SimpleInjector;
using System.Web.Http;
using MealRoulette.Domain.Models;

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
            container.Register<IIngredientService, IngredientService>();
            container.Register<IUnitOfWork, UnitOfWork>();

            var services = GlobalConfiguration.Configuration.Services;
            var controllerTypes = services.GetHttpControllerTypeResolver().GetControllerTypes(services.GetAssembliesResolver());

            container.RegisterWebApiControllers(config);
            
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
        }
    }


    #region .Temporary Test Implementations PLEASE DELETE BEFORE PRODUCTION!.
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

    internal class IngredientService : IIngredientService
    {
        public void CreateIngredient(string name, string unitOfMeasurement, int amount)
        {
            throw new System.NotImplementedException();
        }

        public Ingredient Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public void SetAmount(int amount, Ingredient ingredient)
        {
            throw new System.NotImplementedException();
        }

        public void SetUnitOfMeasurement(string unitOfMeasurement, Ingredient ingredient)
        {
            throw new System.NotImplementedException();
        }
    }
    #endregion
}
