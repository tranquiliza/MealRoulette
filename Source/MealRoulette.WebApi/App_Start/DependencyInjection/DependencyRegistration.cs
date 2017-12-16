using MealRoulette.DataAccess;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using SimpleInjector;

namespace MealRoulette.WebApi.App_Start.DependencyInjection
{
    public static class DependencyRegistration
    {
        public static void RegisterTypesToContainer(Container container)
        {
            //DataAccess
            var database = new MealRouletteContextFactory("DefaultConnection").Create();
            container.RegisterSingleton(database);

            //Repositories
            container.Register<IUnitOfWork, UnitOfWork>();

            //Services
            container.Register<IHolidayService, HolidayService>();
            container.Register<IMealCategoryService, MealCategoryService>();
            container.Register<IMealService, MealService>();
        }
    }
}