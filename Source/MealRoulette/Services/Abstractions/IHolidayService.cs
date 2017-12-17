using MealRoulette.Models;

namespace MealRoulette.Services.Abstractions
{
    public interface IHolidayService : IBaseService<Holiday>
    {
        void Create(string name);
    }
}
