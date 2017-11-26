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
            ConfigureDependencyInjectionForApi(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static void ConfigureDependencyInjectionForApi(HttpConfiguration config)
        {
            var container = new Container();
            DependencyRegistration.RegisterTypesToContainer(container);
            container.RegisterWebApiControllers(config);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorDependencyResolver(container);
        }
    }
}
