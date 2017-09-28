using MealRoulette.Domain.DomainServices.DataContracts;
using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.DomainServices.Interfaces
{
    public interface IMealService
    {
        void CreateMeal(string name, int mealCategory);
        void CreateMeal(string name, int mealCategory, List<IngredientType> ingredientDtos);
        IEnumerable<Meal> GetAll();
    }
}
