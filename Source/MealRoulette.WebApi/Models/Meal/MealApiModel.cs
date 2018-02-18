using MealRoulette.WebApi.Models.Country;
using MealRoulette.WebApi.Models.HardwareCategory;
using MealRoulette.WebApi.Models.Holiday;
using MealRoulette.WebApi.Models.MealCategory;
using MealRoulette.WebApi.Models.MealIngredient;
using System.Collections.Generic;

namespace MealRoulette.WebApi.Models.Meal
{
    public class MealApiModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CountryApiModel CountryOfOrigin { get; set; }

        public bool IsFastFood { get; set; }

        public bool IsVegetarianFriendly { get; set; }

        public HardwareCategoryApiModel HardwareCategory { get; set; }

        public HolidayApiModel Holiday { get; set; }

        public string Recipe { get; set; }

        public string Description { get; set; }

        public MealCategoryApiModel MealCategory { get; set; }

        public IEnumerable<MealIngredientApiModel> MealIngredients { get; set; }
    }
}