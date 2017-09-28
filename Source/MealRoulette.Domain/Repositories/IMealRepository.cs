using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Repositories
{
    public interface IMealRepository
    {
        Meal Get(string name);
        Meal Get(int id);
        void Add(Meal meal);
        IEnumerable<Meal> GetAll();
    }
}
