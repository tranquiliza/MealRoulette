using MealRoulette.Models;

namespace MealRoulette.Services.Abstractions
{
    public interface IMealCategoryService : IBaseService<MealCategory>
    {
        void Create(string name);
    }
}
