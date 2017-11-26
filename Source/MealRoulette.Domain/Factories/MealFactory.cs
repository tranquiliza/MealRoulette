using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Factories
{
    static class MealFactory
    {
        public static Meal Create(string name, MealCategory mealCategory)
        {
            var meal = new Meal(name, mealCategory);
            return meal;
        }


        public static Meal Create(string name, MealCategory mealCategory, IEnumerable<MealIngredient> mealIngredients)
        {
            var meal = new Meal(name, mealCategory);
            foreach (MealIngredient ingredient in mealIngredients)
            {
                meal.AddIngredient(ingredient);
            }

            return meal;
        }
    }
}
