using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories
{
    public interface IMealRepository
    {
        Meal Get(string name);

        Meal Get(int id);

        void Add(Meal meal);
    }
}
