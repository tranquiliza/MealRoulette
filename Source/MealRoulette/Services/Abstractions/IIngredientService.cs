using MealRoulette.Models;

namespace MealRoulette.Services.Abstractions
{
    public interface IIngredientService : IBaseService<Ingredient>
    {
        void Create(string name);
    }
}
