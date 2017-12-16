using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Factories
{
    internal static class MealFactory
    {
        internal static Meal Create(string name, MealCategory mealCategory)
        {
            var meal = new Meal(name, mealCategory);
            return meal;
        }

        internal static Meal Create(string name, MealCategory mealCategory, IEnumerable<MealIngredient> mealIngredients)
        {
            var meal = new Meal(name, mealCategory);
            foreach (MealIngredient ingredient in mealIngredients)
            {
                meal.AddMealIngredient(ingredient);
            }

            return meal;
        }
    }
}
