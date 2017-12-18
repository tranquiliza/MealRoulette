using MealRoulette.DataAccess;
using MealRoulette.Events;
using MealRoulette.Events.Abstractions;
using MealRoulette.Repositories;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using SimpleInjector;

namespace MealRoulette.WebApi.App_Start.DependencyInjection
{
    public static class DependencyRegistration
    {
        public static void RegisterTypesToContainer(Container container)
        {
            //DataAccess
            var context = new MealRouletteContextFactory("DefaultConnection").Create();
            container.RegisterSingleton<IMealRouletteContext>(context);

            //Repositories
            container.Register<IUnitOfWork, UnitOfWork>();

            //Services
            container.Register<IHolidayService, HolidayService>();
            container.Register<ISeasonService, SeasonService>();
            container.Register<IIngredientService, IngredientService>();
            container.Register<IMealCategoryService, MealCategoryService>();
            container.Register<IMealService, MealService>();
            container.Register<IMealRouletteService, MealRouletteService>();
        }

        public static void RegisterEventHandlersToContainer(Container container)
        {
            var eventHandler = new EventHandler();
            container.RegisterCollection<IHandle<RandomMealWasChosenEvent>>(eventHandler);
        }
    }
}