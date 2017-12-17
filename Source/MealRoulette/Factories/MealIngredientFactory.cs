using MealRoulette.Models;

namespace MealRoulette.Factories
{
    internal static class MealIngredientFactory
    {
        internal static MealIngredient Create(Ingredient ingredient, int amount, string unitOfMeasurement)
        {
            return new MealIngredient(ingredient, amount, unitOfMeasurement);
        }
    }
}
