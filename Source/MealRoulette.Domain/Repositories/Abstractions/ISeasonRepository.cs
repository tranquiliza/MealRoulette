using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface ISeasonRepository : IBaseRepository<Season>
    {
        Season Get(string name);
    }
}
