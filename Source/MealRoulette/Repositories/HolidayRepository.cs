﻿using MealRoulette.DataAccess.Abstractions;
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
    public class HolidayRepository : IHolidayRepository
    {
        private readonly IMealRouletteContext mealRouletteContext;

        private readonly DbSet<Holiday> holidays;

        public HolidayRepository(IMealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext ?? throw new ArgumentNullException(nameof(mealRouletteContext));
            holidays = mealRouletteContext.Holidays;
        }

        void IBaseRepository<Holiday>.Add(Holiday entity)
        {
            holidays.Add(entity);
        }

        void IBaseRepository<Holiday>.Delete(int id)
        {
            var holidayToDelete = holidays.First(x => x.Id == id);
            holidays.Remove(holidayToDelete);
        }

        Holiday IHolidayRepository.Get(string name)
        {
            return holidays.FirstOrDefault(x => x.Name == name);
        }

        Holiday IBaseRepository<Holiday>.Get(int id)
        {
            return holidays.First(x => x.Id == id);
        }

        IEnumerable<Holiday> IBaseRepository<Holiday>.Get()
        {
            return holidays.ToList();
        }

        async Task<IEnumerable<Holiday>> IBaseRepository<Holiday>.GetAsync()
        {
            return await holidays.ToListAsync();
        }

        IPage<Holiday> IBaseRepository<Holiday>.Get(int pageIndex, int pageSize)
        {
            var totalCount = holidays.Count();
            var page = holidays.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<Holiday>(page, pageIndex, pageSize, totalCount);
        }
    }
}
