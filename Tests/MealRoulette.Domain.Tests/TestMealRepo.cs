using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using MealRoulette.Domain.DataStructures;

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

        public void Delete(int Id)
        {
            var mealToRemove = meals.Single(x => x.Id == Id);
            meals.Remove(mealToRemove);
        }

        public Meal Get(string name)
        {
            var meal = meals.FirstOrDefault(m => m.Name == name);
            return meal;
        }

        public Meal Get(int id)
        {
            var meal = meals.Single(m => m.Id == id);
            return meal;
        }

        public IEnumerable<Meal> GetAll()
        {
            return meals;
        }

        public IPage<Meal> GetPage(int index, int size)
        {
            var page = new Page<Meal>(meals, index, size, meals.Count);
            return page;
        }
    }
}
