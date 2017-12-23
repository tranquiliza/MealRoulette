using MealRoulette.DataAccess;
using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace MealRoulette.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly IMealRouletteContext context;

        private readonly DbSet<Ingredient> ingredients;

        public IngredientRepository(IMealRouletteContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            ingredients = context.Ingredients;
        }

        void IBaseRepository<Ingredient>.Add(Ingredient entity)
        {
            ingredients.Add(entity);
        }

        void IBaseRepository<Ingredient>.Delete(int id)
        {
            var ingredientToDelete = ingredients.First(x => x.Id == id);
            ingredients.Remove(ingredientToDelete);
        }

        Ingredient IBaseRepository<Ingredient>.Get(int id)
        {
            return ingredients.First(x => x.Id == id);
        }

        IEnumerable<Ingredient> IBaseRepository<Ingredient>.Get()
        {
            return ingredients.ToList();
        }

        Ingredient IIngredientRepository.Get(string name)
        {
            return ingredients.FirstOrDefault(x => x.Name == name);
        }

        IPage<Ingredient> IBaseRepository<Ingredient>.Get(int pageIndex, int pageSize)
        {
            var totalCount = ingredients.Count();
            var page = ingredients.OrderBy(x => x.Name).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<Ingredient>(page, pageIndex, pageSize, totalCount);
        }

        async Task<IEnumerable<Ingredient>> IBaseRepository<Ingredient>.GetAsync()
        {
            return await ingredients.ToListAsync();
        }
    }
}
