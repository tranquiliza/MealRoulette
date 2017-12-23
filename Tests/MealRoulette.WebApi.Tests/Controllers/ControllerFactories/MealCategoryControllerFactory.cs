using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Controllers.Api;

namespace MealRoulette.WebApi.Tests.Controllers.ControllerFactories
{
    internal class MealCategoryControllerFactory
    {
        IMealCategoryService mealCategoryService;

        public MealCategoryControllerFactory()
        {
            mealCategoryService = null;
        }

        public MealCategoryControllerFactory WithMealCategoryService(IMealCategoryService mealCategoryService)
        {
            this.mealCategoryService = mealCategoryService;
            return this;
        }

        public MealCategoryController Build()
        {
            var controller = new MealCategoryController(mealCategoryService);
            return controller;
        }
    }
}
