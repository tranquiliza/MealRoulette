using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.DomainServices.Abstractions
{
    public interface IMealService
    {
        void CreateMeal(string name, int mealCategory);
        void CreateMeal(string name, int mealCategory, List<Ingredient> ingredientDtos);
        Meal Get(int id);
        IEnumerable<Meal> GetAll();
    }
}
