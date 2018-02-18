using MealRoulette.Models;

namespace MealRoulette.Services.Abstractions
{
    public interface ICountryService : IBaseService<Country>
    {
        Country Get(string name);
    }
}
