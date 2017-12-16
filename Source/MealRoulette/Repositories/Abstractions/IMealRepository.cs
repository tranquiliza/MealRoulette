using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface IMealRepository : IBaseRepository<Meal>
    {
        Meal Get(string name);
    }
}
