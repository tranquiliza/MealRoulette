using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Factories
{
    class IngredientFactory
    {
        public Ingredient Create(string name, string unitOfMeasurement, int amount)
        {
            var ingredient = new Ingredient(name, unitOfMeasurement, amount);
            return ingredient;
        }
    }
}
