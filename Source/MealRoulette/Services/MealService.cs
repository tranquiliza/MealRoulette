﻿using MealRoulette.DataContracts;
using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Factories;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Services
{
    public class MealService : IMealService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMealRepository mealRepository;
        private readonly IMealCategoryRepository mealCategoryRepository;
        private readonly IIngredientRepository ingredientRepository;
        private readonly IUnitOfMeasurementRepository unitOfMeasurementRepository;
        private readonly IHardwareCategoryRepository hardwareCategoryRepository;

        public MealService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            mealRepository = unitOfWork.MealRepository;
            mealCategoryRepository = unitOfWork.MealCategoryRepository;
            ingredientRepository = unitOfWork.IngredientRepository;
            unitOfMeasurementRepository = unitOfWork.UnitOfMeasurementRepository;
            hardwareCategoryRepository = unitOfWork.HardwareRepository;
        }

        public void Create(string mealName, MealCategoryDto mealCategoryDto)
        {
            if (mealCategoryDto == null) throw new ArgumentNullException(nameof(mealCategoryDto));

            var mealCategory = mealCategoryRepository.Get(mealCategoryDto.Id);
            var defaultHardwareCategory = hardwareCategoryRepository.Get("None");

            var meal = MealFactory.Create(mealName, mealCategory, defaultHardwareCategory);
            mealRepository.Add(meal);

            unitOfWork.SaveChanges();
        }

        public void Create(string mealName, MealCategoryDto mealCategoryDto, IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            if (mealCategoryDto == null) throw new ArgumentNullException(nameof(mealCategoryDto));
            if (mealIngredientDtos == null) throw new ArgumentNullException(nameof(mealIngredientDtos));

            var mealCategory = mealCategoryRepository.Get(mealCategoryDto.Id);
            var mealIngredients = RetrieveMealIngredients(mealIngredientDtos);
            var defaultHardwareCategory = hardwareCategoryRepository.Get("None");

            var meal = MealFactory.Create(mealName, mealCategory, defaultHardwareCategory, mealIngredients);

            mealRepository.Add(meal);

            unitOfWork.SaveChanges();
        }

        private IEnumerable<MealIngredient> RetrieveMealIngredients(IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            var mealIngredients = new List<MealIngredient>();
            foreach (var mealIngredientDto in mealIngredientDtos)
            {
                var ingredient = ingredientRepository.Get(mealIngredientDto.IngredientId);
                var unitOfMeasurement = unitOfMeasurementRepository.Get(mealIngredientDto.UnitOfMeasurement.Id);

                mealIngredients.Add(MealIngredientFactory.Create(ingredient, mealIngredientDto.Amount, unitOfMeasurement));
            }

            return mealIngredients;
        }

        public void AddMealIngredient(int mealId, MealIngredientDto mealIngredientDto)
        {
            var meal = mealRepository.Get(mealId);
            if (meal == null) throw new DomainException($"Meal with id {mealId}, does not exist");

            var ingredient = ingredientRepository.Get(mealIngredientDto.IngredientId);
            var unitOfMeasurement = unitOfMeasurementRepository.Get(mealIngredientDto.UnitOfMeasurement.Id);

            meal.AddMealIngredient(MealIngredientFactory.Create(ingredient, mealIngredientDto.Amount, unitOfMeasurement));

            unitOfWork.SaveChanges();
        }

        public void AddMealIngredients(int mealId, IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            var meal = mealRepository.Get(mealId);

            foreach (var mealIngredientDto in mealIngredientDtos)
            {
                var ingredient = ingredientRepository.Get(mealIngredientDto.IngredientId);
                var unitOfMeasurement = unitOfMeasurementRepository.Get(mealIngredientDto.UnitOfMeasurement.Id);

                meal.AddMealIngredient(MealIngredientFactory.Create(ingredient, mealIngredientDto.Amount, unitOfMeasurement));
            }

            unitOfWork.SaveChanges();
        }

        private bool MealAlreadyExists(string name)
        {
            return mealRepository.Get(name) != null;
        }

        public IEnumerable<Meal> Get()
        {
            return mealRepository.Get();
        }

        public Meal Get(int id)
        {
            return mealRepository.Get(id);
        }

        public IPage<Meal> Get(int index, int pageSize)
        {
            var page = mealRepository.Get(index, pageSize);
            return page;
        }

        public void Delete(int id)
        {
            mealRepository.Delete(id);

            unitOfWork.SaveChanges();
        }

    }
}
