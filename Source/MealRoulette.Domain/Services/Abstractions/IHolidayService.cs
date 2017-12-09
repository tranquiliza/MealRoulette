using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IHolidayService : IBaseService<Holiday>
    {
        void Create(string name);
    }
}
