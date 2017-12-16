using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Controllers;

namespace MealRoulette.WebApi.Tests.Controllers.ControllerFactories
{
    internal class IngredientControllerFactory
    {
        private IIngredientService ingredientService;

        internal IngredientControllerFactory()
        {
            ingredientService = null;
        }
                
        internal IngredientControllerFactory WithIngredientService(IIngredientService service)
        {
            ingredientService = service;
            return this;
        }

        internal IngredientController Build()
        {
            var controller = new IngredientController(ingredientService);
            return controller;
        }
    }
}
