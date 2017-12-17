using MealRoulette.Models;

namespace MealRoulette.Repositories.Abstractions
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Ingredient Get(string name);
    }
}
