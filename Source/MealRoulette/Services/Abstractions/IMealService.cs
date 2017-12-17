using MealRoulette.DataContracts;
using MealRoulette.Models;
using System.Collections.Generic;

namespace MealRoulette.Services.Abstractions
{
    public interface IMealService : IBaseService<Meal>
    {
        void Create(string mealName, MealCategoryDto mealCategory);

        void Create(string mealName, MealCategoryDto mealCategoryDto, IEnumerable<MealIngredientDto> mealIngredientDtos);
        
        void AddMealIngredient(int mealId, MealIngredientDto ingredientDto);

        void AddMealIngredients(int mealId, IEnumerable<MealIngredientDto> ingredientDtos);
    }
}
