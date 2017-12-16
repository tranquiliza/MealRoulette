using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace MealRoulette.DataAccess.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly MealRouletteContext context;
        private readonly DbSet<Ingredient> ingredients;

        public IngredientRepository(MealRouletteContext context)
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

        }

        Ingredient IBaseRepository<Ingredient>.Get(int id)
        {
            return ingredients.First(x => x.Id == id);
        }

        IEnumerable<Ingredient> IBaseRepository<Ingredient>.Get()
        {
            throw new NotImplementedException();
        }

        Ingredient IIngredientRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        IPage<Ingredient> IBaseRepository<Ingredient>.GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
