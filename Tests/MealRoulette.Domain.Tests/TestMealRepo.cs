using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using MealRoulette.Domain.Repositories.DataStructures;

namespace MealRoulette.Domain.Tests
{
    internal class TestMealRepo : IMealRepository
    {
        List<Meal> meals;

        public TestMealRepo()
        {
            meals = new List<Meal>();
        }

        public void Add(Meal meal)
        {
            meals.Add(meal);
        }

        public void Delete(Meal entity)
        {
            throw new NotImplementedException();
        }

        public Meal Get(string name)
        {
            var meal = meals.FirstOrDefault(m => m.Name == name);
            return meal;
        }

        public Meal Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meal> GetAll()
        {
            throw new NotImplementedException();
        }

        public IPage<Meal> GetPage(int index, int size)
        {
            throw new NotImplementedException();
        }
    }
}
