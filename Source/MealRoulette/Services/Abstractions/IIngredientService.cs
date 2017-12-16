using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IIngredientService : IBaseService<Ingredient>
    {
        void Create(string name);
    }
}
