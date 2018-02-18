using MealRoulette.DataAccess;
using MealRoulette.DataAccess.Abstractions;
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
            container.Register<IMealRouletteContext>(() =>
            {
                return new MealRouletteContextFactory().Create();
            });

            //Repositories
            container.Register<IUnitOfWork, UnitOfWork>();

            //Services
            container.Register<ICountryService, CountryService>();
            container.Register<IHardwareCategoryService, HardwareCategoryService>();
            container.Register<IHolidayService, HolidayService>();
            container.Register<IIngredientService, IngredientService>();
            container.Register<IMealCategoryService, MealCategoryService>();
            container.Register<IMealService, MealService>();
            container.Register<IMealRouletteService, MealRouletteService>();
            container.Register<IUnitOfMeasurementService, UnitOfMeasurementService>();
        }

        public static void RegisterEventHandlersToContainer(Container container)
        {
            var eventHandler = new EventHandler();
            container.RegisterCollection<IHandle<RandomMealWasChosenEvent>>(eventHandler);
        }
    }
}