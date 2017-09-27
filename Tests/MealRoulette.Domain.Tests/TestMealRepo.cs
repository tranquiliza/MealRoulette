using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Meal Get(string name)
        {
            var meal = meals.FirstOrDefault(m => m.Name == name);
            return meal;
        }

        public Meal Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
