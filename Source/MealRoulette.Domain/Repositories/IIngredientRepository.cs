using MealRoulette.Domain.Models;
using System.Collections.Generic;

namespace MealRoulette.Domain.Repositories
{
    public interface IIngredientRepository
    {
        IEnumerable<Ingredient> GetAll();

        Ingredient Get(string name);

        Ingredient Get(int id);
    }
}
