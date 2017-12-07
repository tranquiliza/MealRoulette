using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Controllers;
using Moq;

namespace MealRoulette.WebApi.Tests.Controllers.Helpers
{
    internal static class MealCategoryControllerHelper
    {
        internal static IMealCategoryService CreateMealCategoryService()
        {
            var mock = new Mock<IMealCategoryService>();
            return mock.Object;
        }

        public static MealCategoryController CreateController()
        {
            var service = CreateMealCategoryService();
            var controller = new MealCategoryController(service);
            return controller;
        }
    }
}
