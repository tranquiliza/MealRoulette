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
    public class HardwareCategoryRepository : IHardwareCategoryRepository
    {
        private readonly IMealRouletteContext mealRouletteContext;

        private readonly DbSet<HardwareCategory> hardwareCategories;

        public HardwareCategoryRepository(IMealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            hardwareCategories = mealRouletteContext.HardwareCategories;
        }

        void IBaseRepository<HardwareCategory>.Add(HardwareCategory entity)
        {
            hardwareCategories.Add(entity);
        }

        void IBaseRepository<HardwareCategory>.Delete(int id)
        {
            var hardwareCategoryToDelete = hardwareCategories.First(x => x.Id == id);
            hardwareCategories.Remove(hardwareCategoryToDelete);
        }

        HardwareCategory IBaseRepository<HardwareCategory>.Get(int id)
        {
            return hardwareCategories.First(x => x.Id == id);
        }

        IEnumerable<HardwareCategory> IBaseRepository<HardwareCategory>.Get()
        {
            return hardwareCategories.ToList();
        }

        IPage<HardwareCategory> IBaseRepository<HardwareCategory>.Get(int pageIndex, int pageSize)
        {
            var totalCount = hardwareCategories.Count();
            var page = hardwareCategories.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<HardwareCategory>(page, pageIndex, pageSize, totalCount);
        }

        HardwareCategory IHardwareCategoryRepository.Get(string name)
        {
            return hardwareCategories.FirstOrDefault(x => x.Name == name);
        }

        async Task<IEnumerable<HardwareCategory>> IBaseRepository<HardwareCategory>.GetAsync()
        {
            return await hardwareCategories.ToListAsync();
        }
    }
}
