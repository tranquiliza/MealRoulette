using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Country Get(string name);
    }
}
