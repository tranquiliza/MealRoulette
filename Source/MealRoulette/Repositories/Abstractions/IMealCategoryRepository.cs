using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface IMealCategoryRepository : IBaseRepository<MealCategory>
    {
        MealCategory Get(string name);
    }
}
