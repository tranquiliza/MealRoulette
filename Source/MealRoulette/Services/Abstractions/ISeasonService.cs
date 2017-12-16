using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface ISeasonService : IBaseService<Season>
    {
        void Create(string name);
    }
}
