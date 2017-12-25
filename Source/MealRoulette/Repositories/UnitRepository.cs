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
    public class UnitOfMeasurementRepository : IUnitOfMeasurementRepository
    {
        private readonly IMealRouletteContext mealRouletteContext;
        private readonly DbSet<UnitOfMeasurement> UnitsOfMeasurement;

        public UnitOfMeasurementRepository(IMealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            UnitsOfMeasurement = mealRouletteContext.UnitsOfMeasurement;
        }

        void IBaseRepository<UnitOfMeasurement>.Add(UnitOfMeasurement entity)
        {
            UnitsOfMeasurement.Add(entity);
        }

        void IBaseRepository<UnitOfMeasurement>.Delete(int id)
        {
            var unitToRemove = UnitsOfMeasurement.First(x => x.Id == id);
            UnitsOfMeasurement.Remove(unitToRemove);
        }

        UnitOfMeasurement IBaseRepository<UnitOfMeasurement>.Get(int id)
        {
            return UnitsOfMeasurement.First(x => x.Id == id);
        }

        IEnumerable<UnitOfMeasurement> IBaseRepository<UnitOfMeasurement>.Get()
        {
            return UnitsOfMeasurement.ToList();
        }

        IPage<UnitOfMeasurement> IBaseRepository<UnitOfMeasurement>.Get(int pageIndex, int pageSize)
        {
            var totalCount = UnitsOfMeasurement.Count();
            var page = UnitsOfMeasurement.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<UnitOfMeasurement>(page, pageIndex, pageSize, totalCount);
        }

        async Task<IEnumerable<UnitOfMeasurement>> IBaseRepository<UnitOfMeasurement>.GetAsync()
        {
            return await UnitsOfMeasurement.ToListAsync();
        }
    }
}
