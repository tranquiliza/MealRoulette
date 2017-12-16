using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MealRoulette.DataAccess.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly MealRouletteContext mealRouletteContext;
        private readonly DbSet<Meal> meals;

        public MealRepository(MealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            meals = mealRouletteContext.Meals;
        }

        void IBaseRepository<Meal>.Add(Meal entity)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<Meal>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Meal IMealRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        Meal IBaseRepository<Meal>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Meal> IBaseRepository<Meal>.Get()
        {
            throw new NotImplementedException();
        }

        IPage<Meal> IBaseRepository<Meal>.GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
