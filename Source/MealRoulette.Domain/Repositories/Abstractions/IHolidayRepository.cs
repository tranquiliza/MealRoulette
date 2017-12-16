using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface IHolidayRepository : IBaseRepository<Holiday>
    {
        Holiday Get(string name);
    }
}
