using MealRoulette.WebApi.Models.Ingredient;

namespace MealRoulette.WebApi.Models.MealIngredient
{
    public class MealIngredientApiModel
    {
        public int Amount { get; set; }

        public string UnitOfMeasurement { get; set; }

        public int IngredientId { get; set; }
    }
}