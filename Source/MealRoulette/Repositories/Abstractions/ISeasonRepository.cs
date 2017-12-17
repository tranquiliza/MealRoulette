using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface ISeasonRepository : IBaseRepository<Season>
    {
        Season Get(string name);
    }
}
