using MealRoulette.Models;

namespace MealRoulette.Factories
{
    internal static class MealIngredientFactory
    {
        internal static MealIngredient Create(Ingredient ingredient, int amount, UnitOfMeasurement unitOfMeasurement)
        {
            return new MealIngredient(ingredient, amount, unitOfMeasurement);
        }
    }
}
