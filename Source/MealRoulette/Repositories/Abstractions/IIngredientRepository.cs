using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Repositories.Abstractions
{
    public interface IIngredientRepository : IBaseRepository<Ingredient>
    {
        Ingredient Get(string name);
    }
}
