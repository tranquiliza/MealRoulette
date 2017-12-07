using MealRoulette.WebApi.Models.MealCategory;
using MealRoulette.WebApi.Models.MealIngredient;
using System.Collections.Generic;

namespace MealRoulette.WebApi.Models.Meal
{
    public class CreateMealApiRequest
    {
        public string Name { get; set; }

        public MealCategoryApiModel MealCategory { get; set; }

        public IEnumerable<MealIngredientApiModel> Ingredients { get; set; }
    }
}