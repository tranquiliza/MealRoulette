using MealRoulette.Domain.DataContracts;
using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IMealService : IBaseService<Meal>
    {
        void CreateMeal(string mealName, MealCategoryDto mealCategoryDto, IEnumerable<MealIngredientDto> enumerable);

        void CreateMeal(string mealName, MealCategoryDto mealCategory);
        
        void AddIngredient(int mealId, MealIngredientDto ingredientDto);

        void AddIngredients(int mealId, IEnumerable<MealIngredientDto> ingredientDtos);
    }
}
