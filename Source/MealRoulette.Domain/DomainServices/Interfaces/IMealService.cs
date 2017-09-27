using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.DomainServices.Interfaces
{
    public interface IMealService
    {
        void CreateMeal(string name, int mealCategory, List<int> ingredients);
    }
}
