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
    public class CountryRepository : ICountryRepository
    {
        private readonly IMealRouletteContext _MealRouletteContext;
        private readonly DbSet<Country> _Countries;

        public CountryRepository(IMealRouletteContext mealRouletteContext)
        {
            this._MealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            _Countries = mealRouletteContext.Countries;
        }

        void IBaseRepository<Country>.Add(Country entity)
        {
            _Countries.Add(entity);
        }

        void IBaseRepository<Country>.Delete(int id)
        {
            var hardwareCategoryToDelete = _Countries.First(x => x.Id == id);
            _Countries.Remove(hardwareCategoryToDelete);
        }

        Country ICountryRepository.Get(string name)
        {
            return _Countries.FirstOrDefault(x => x.Name == name);
        }

        Country IBaseRepository<Country>.Get(int id)
        {
            return _Countries.First(x => x.Id == id);
        }

        IEnumerable<Country> IBaseRepository<Country>.Get()
        {
            return _Countries.OrderBy(x => x.Name).ToList();
        }

        IPage<Country> IBaseRepository<Country>.Get(int pageIndex, int pageSize)
        {
            var totalCount = _Countries.Count();
            var page = _Countries.OrderBy(x => x.Name).Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<Country>(page, pageIndex, pageSize, totalCount);
        }

        async Task<IEnumerable<Country>> IBaseRepository<Country>.GetAsync()
        {
            return await _Countries.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
