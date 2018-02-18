using MealRoulette.Models;

namespace MealRoulette.Services.Abstractions
{
    public interface IHardwareCategoryService : IBaseService<HardwareCategory>
    {
        HardwareCategory Get(string name);
    }
}
