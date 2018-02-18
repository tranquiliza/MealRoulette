using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface IHardwareCategoryRepository : IBaseRepository<HardwareCategory>
    {
        HardwareCategory Get(string name);
    }
}
