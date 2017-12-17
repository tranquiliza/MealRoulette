using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface IMealRepository : IBaseRepository<Meal>
    {
        Meal Get(string name);
    }
}
