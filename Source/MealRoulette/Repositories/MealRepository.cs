﻿using MealRoulette.DataAccess;
using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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
            return meals.FirstOrDefault(x => x.Name == name);
        }

        Meal IBaseRepository<Meal>.Get(int id)
        {
            return meals.First(x => x.Id == id);
        }

        IEnumerable<Meal> IBaseRepository<Meal>.Get()
        {
            return meals.ToList();
        }

        IPage<Meal> IBaseRepository<Meal>.Get(int pageIndex, int pageSize)
        {
            var totalCount = meals.Count();
            var page = meals.Skip(pageIndex * pageSize).Take(pageSize).ToList();

            return new Page<Meal>(page, pageIndex, pageSize, totalCount);
        }
    }
}