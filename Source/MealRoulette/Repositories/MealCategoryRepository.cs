using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            mealCategories.Add(entity);
        }

        void IBaseRepository<MealCategory>.Delete(int id)
        {
            var mealCategoryToDelete = mealCategories.First(x => x.Id == id);
            mealCategories.Remove(mealCategoryToDelete);
        }

        MealCategory IMealCategoryRepository.Get(string name)
        {
            return mealCategories.FirstOrDefault(x => x.Name == name);
        }

        MealCategory IBaseRepository<MealCategory>.Get(int id)
        {
            return mealCategories.First(x => x.Id == id);
        }

        IEnumerable<MealCategory> IBaseRepository<MealCategory>.Get()
        {
            return mealCategories.ToList();
        }

        IPage<MealCategory> IBaseRepository<MealCategory>.Get(int pageIndex, int pageSize)
        {
            var totalCount = mealCategories.Count();
            var page = mealCategories.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<MealCategory>(page, pageIndex, pageSize, totalCount);
        }
    }
}
