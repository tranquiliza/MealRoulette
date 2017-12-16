using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MealRoulette.DataAccess.Repository
{
    public class MealCategoryRepository : IMealCategoryRepository
    {
        private readonly MealRouletteContext mealRouletteContext;
        private readonly DbSet<MealCategory> mealCategories;

        public MealCategoryRepository(MealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            mealCategories = mealRouletteContext.MealCategories;
        }

        void IBaseRepository<MealCategory>.Add(MealCategory entity)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<MealCategory>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        MealCategory IMealCategoryRepository.Find(string name)
        {
            throw new NotImplementedException();
        }

        MealCategory IBaseRepository<MealCategory>.Get(int id)
        {
            return null;
        }

        IEnumerable<MealCategory> IBaseRepository<MealCategory>.Get()
        {
            throw new NotImplementedException();
        }

        IPage<MealCategory> IBaseRepository<MealCategory>.GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
