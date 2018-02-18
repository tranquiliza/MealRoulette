using MealRoulette.DataAccess.Abstractions;
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
    public class MealRepository : IMealRepository
    {
        private readonly IMealRouletteContext mealRouletteContext;
        private readonly DbSet<Meal> meals;

        public MealRepository(IMealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            meals = mealRouletteContext.Meals;
        }

        void IBaseRepository<Meal>.Add(Meal entity)
        {
            meals.Add(entity);
        }

        void IBaseRepository<Meal>.Delete(int id)
        {
            var mealToDelete = meals.First(x => x.Id == id);
            meals.Remove(mealToDelete);
        }

        Meal IMealRepository.Get(string name)
        {
            var query = CreateBaseMealQuery();
            return query.FirstOrDefault(x => x.Name == name);
        }

        Meal IBaseRepository<Meal>.Get(int id)
        {
            var query = CreateBaseMealQuery();
            return query.First(x => x.Id == id);
        }

        IEnumerable<Meal> IBaseRepository<Meal>.Get()
        {
            var query = CreateBaseMealQuery();
            return query.ToList();
        }

        async Task<IEnumerable<Meal>> IBaseRepository<Meal>.GetAsync()
        {
            var query = CreateBaseMealQuery();
            return await query.ToListAsync();
        }

        private IQueryable<Meal> CreateBaseMealQuery()
        {
            return meals
                .Include(x => x.MealIngredients)
                .Include(x => x.CountryOfOrigin)
                .Include(x => x.HardwareCategory)
                .Include(x => x.MealIngredients.Select(c => c.UnitOfMeasurement))
                .Include(x => x.MealIngredients.Select(c => c.Ingredient))
                .Include(x => x.MealCategory)
                .Include(x => x.Holiday);
        }

        IPage<Meal> IBaseRepository<Meal>.Get(int pageIndex, int pageSize)
        {
            var totalCount = meals.Count();
            var page = CreateBaseMealQuery().OrderBy(meal => meal.Name).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<Meal>(page, pageIndex, pageSize, totalCount);
        }
    }
}
