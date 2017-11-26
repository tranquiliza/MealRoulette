using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IMealService : IBaseService<Meal>
    {
        void CreateMeal(string name);

        void CreateMeal(string name, MealCategory mealCategory);

        void CreateMeal(string name, MealCategory mealCategory, IEnumerable<MealIngredient> ingredient);

        void AddIngredient(int id, MealIngredient ingredient);

        void AddIngredients(int id, IEnumerable<MealIngredient> ingredient);
    }
}
