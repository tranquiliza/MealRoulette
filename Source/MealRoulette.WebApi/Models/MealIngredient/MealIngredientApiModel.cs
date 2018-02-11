using MealRoulette.WebApi.Models.Ingredient;
using MealRoulette.WebApi.Models.UnitOfMeasurement;

namespace MealRoulette.WebApi.Models.MealIngredient
{
    public class MealIngredientApiModel
    {
        public int Amount { get; set; }

        public UnitOfMeasurementApiModel UnitOfMeasurement { get; set; }

        public IngredientApiModel Ingredient { get; set; }
    }
}