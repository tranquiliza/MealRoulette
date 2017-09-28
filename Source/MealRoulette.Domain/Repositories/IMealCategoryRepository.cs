using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories
{
    public interface IMealCategoryRepository
    {
        MealCategory Get(string name);
        MealCategory Get(int id);
    }
}
