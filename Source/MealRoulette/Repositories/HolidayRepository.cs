using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace MealRoulette.DataAccess.Repository
{
    public class HolidayRepository : IHolidayRepository
    {
        private readonly MealRouletteContext mealRouletteContext;
        private readonly DbSet<Holiday> holidays;

        public HolidayRepository(MealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            holidays = mealRouletteContext.Holidays;
        }

        void IBaseRepository<Holiday>.Add(Holiday entity)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<Holiday>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        Holiday IHolidayRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        Holiday IBaseRepository<Holiday>.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Holiday> IBaseRepository<Holiday>.Get()
        {
            throw new NotImplementedException();
        }

        IPage<Holiday> IBaseRepository<Holiday>.GetPage(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
