using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Factories;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using System.Collections.Generic;
using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.DataContracts;
using System;

namespace MealRoulette.Domain.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository mealRepository;
        private readonly IMealCategoryRepository mealCategoryRepository;
        private readonly IIngredientRepository ingredientRepository;

        public MealService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null) throw new ArgumentNullException(nameof(unitOfWork));

            mealRepository = unitOfWork.MealRepository;
            mealCategoryRepository = unitOfWork.MealCategoryRepository;
            ingredientRepository = unitOfWork.IngredientRepository;
        }

        public void CreateMeal(string mealName, MealCategoryDto mealCategoryDto)
        {
            if (string.IsNullOrWhiteSpace(mealName)) throw new ArgumentException("Meal name cannot be empty", nameof(mealName));
            if (mealCategoryDto == null) throw new ArgumentNullException(nameof(mealCategoryDto));

            var mealCategory = mealCategoryRepository.Get(mealCategoryDto.Id);

            var meal = MealFactory.Create(mealName, mealCategory);
            mealRepository.Add(meal);
        }

        public void CreateMeal(string mealName, MealCategoryDto mealCategoryDto, IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            if (string.IsNullOrEmpty(mealName)) throw new ArgumentException("Meal name cannot be empty", nameof(mealName));
            if (mealCategoryDto == null) throw new ArgumentNullException(nameof(mealCategoryDto));
            if (mealIngredientDtos == null) throw new ArgumentNullException(nameof(mealIngredientDtos));

            var mealCategory = mealCategoryRepository.Get(mealCategoryDto.Id);
            var mealIngredients = RetrieveMealIngredients(mealIngredientDtos);

            var meal = MealFactory.Create(mealName, mealCategory, mealIngredients);
            mealRepository.Add(meal);
        }

        private IEnumerable<MealIngredient> RetrieveMealIngredients(IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            var mealIngredients = new List<MealIngredient>();
            foreach (var mealIngredientDto in mealIngredientDtos)
            {
                var ingredient = ingredientRepository.Get(mealIngredientDto.IngredientId);

                mealIngredients.Add(MealIngredientFactory.Create(ingredient, mealIngredientDto.Amount, mealIngredientDto.UnitOfMeasurement));
            }

            return mealIngredients;
        }

        public void AddIngredient(int mealId, MealIngredientDto mealIngredientDto)
        {
            var meal = mealRepository.Get(mealId);
            var ingredient = ingredientRepository.Get(mealIngredientDto.IngredientId);

            meal.AddIngredient(MealIngredientFactory.Create(ingredient, mealIngredientDto.Amount, mealIngredientDto.UnitOfMeasurement));
        }

        public void AddIngredients(int mealId, IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            var meal = mealRepository.Get(mealId);

            foreach (var mealIngredientdto in mealIngredientDtos)
            {
                var ingredient = ingredientRepository.Get(mealIngredientdto.IngredientId);

                meal.AddIngredient(MealIngredientFactory.Create(ingredient, mealIngredientdto.Amount, mealIngredientdto.UnitOfMeasurement));
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
