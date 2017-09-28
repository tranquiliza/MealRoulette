using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Factories
{
    class MealFactory
    {
        public Meal Create(string name, MealCategory mealCategory)
        {
            var meal = new Meal(name, mealCategory);
            return meal;
        }

        public Meal CreateWithIngredients(string name, MealCategory mealCategory, IEnumerable<Ingredient> ingredients)
        {
            var meal = new Meal(name, mealCategory);
            foreach (Ingredient ingredient in ingredients)
            {
                meal.AddIngredient(ingredient);
            }

            return meal;
        }
    }
}
