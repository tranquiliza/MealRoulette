using MealRoulette.Models;
using System.Collections.Generic;

namespace MealRoulette.Factories
{
    internal static class MealFactory
    {
        internal static Meal Create(string name, MealCategory mealCategory, HardwareCategory hardwareCategory)
        {
            var meal = new Meal(name, mealCategory, hardwareCategory);
            return meal;
        }

        internal static Meal Create(string name, MealCategory mealCategory, HardwareCategory hardwareCategory, IEnumerable<MealIngredient> mealIngredients)
        {
            var meal = new Meal(name, mealCategory, hardwareCategory);
            foreach (MealIngredient ingredient in mealIngredients)
            {
                meal.AddMealIngredient(ingredient);
            }

            return meal;
        }
    }
}
