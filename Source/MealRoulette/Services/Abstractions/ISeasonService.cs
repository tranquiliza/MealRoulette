using MealRoulette.Models;

namespace MealRoulette.Services.Abstractions
{
    public interface ISeasonService : IBaseService<Season>
    {
        void Create(string name);
    }
}
