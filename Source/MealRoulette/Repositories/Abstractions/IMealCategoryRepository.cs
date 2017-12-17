using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface IMealCategoryRepository : IBaseRepository<MealCategory>
    {
        MealCategory Get(string name);
    }
}
