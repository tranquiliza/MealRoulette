using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface IHolidayRepository : IBaseRepository<Holiday>
    {
        Holiday Get(string name);
    }
}
