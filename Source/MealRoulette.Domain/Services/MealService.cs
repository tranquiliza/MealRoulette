using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Factories;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System.Collections.Generic;
using MealRoulette.Domain.DataStructures;

namespace MealRoulette.Domain.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository mealRepository;

        public MealService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new System.ArgumentNullException(nameof(unitOfWork));

            mealRepository = unitOfWork.MealRepository;
        }

        public void CreateMeal(string name)
        {
            throw new System.NotImplementedException();
        }

        public void CreateMeal(string name, MealCategory mealCategory)
        {
            var meal = MealFactory.Create(name, mealCategory);
            mealRepository.Add(meal);
        }

        public void CreateMeal(string name, MealCategory mealCategory, IEnumerable<MealIngredient> mealIngredients)
        {
            var meal = MealFactory.Create(name, mealCategory, mealIngredients);
            mealRepository.Add(meal);
        }

        public void AddIngredient(int id, MealIngredient mealIngredient)
        {
            var meal = mealRepository.Get(id);
            meal.AddIngredient(mealIngredient);
        }

        public void AddIngredients(int id, IEnumerable<MealIngredient> mealIngredients)
        {
            var meal = mealRepository.Get(id);

            foreach (var mealIngredient in mealIngredients)
            {
                meal.AddIngredient(mealIngredient);
            }
        }

        private bool MealAlreadyExists(string name)
        {
            return mealRepository.Get(name) != null;
        }

        public IEnumerable<Meal> GetAll()
        {
            return mealRepository.GetAll();
        }

        public Meal Get(int id)
        {
            return mealRepository.Get(id);
        }

        public void Delete(int Id)
        {
            mealRepository.Delete(Id);
        }

        public IPage<Meal> GetPage(int index, int pageSize)
        {
            var page = mealRepository.GetPage(index, pageSize);
            return page;
        }
    }
}
