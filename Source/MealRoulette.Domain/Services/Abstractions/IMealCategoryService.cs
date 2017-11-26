using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IMealCategoryService : IBaseService<MealCategory>
    {
        void Create(string name);
    }
}
