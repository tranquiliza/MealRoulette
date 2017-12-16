using MealRoulette.Domain.DataContracts;
using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Factories;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services
{
    public class MealService : IMealService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMealRepository mealRepository;
        private readonly IMealCategoryRepository mealCategoryRepository;
        private readonly IIngredientRepository ingredientRepository;

        public MealService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            mealRepository = unitOfWork.MealRepository;
            mealCategoryRepository = unitOfWork.MealCategoryRepository;
            ingredientRepository = unitOfWork.IngredientRepository;
        }

        public void Create(string mealName, MealCategoryDto mealCategoryDto)
        {
            if (mealCategoryDto == null) throw new ArgumentNullException(nameof(mealCategoryDto));

            var mealCategory = mealCategoryRepository.Get(mealCategoryDto.Id);

            var meal = MealFactory.Create(mealName, mealCategory);
            mealRepository.Add(meal);

            unitOfWork.SaveChanges();
        }

        public void Create(string mealName, MealCategoryDto mealCategoryDto, IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            if (mealCategoryDto == null) throw new ArgumentNullException(nameof(mealCategoryDto));
            if (mealIngredientDtos == null) throw new ArgumentNullException(nameof(mealIngredientDtos));

            var mealCategory = mealCategoryRepository.Get(mealCategoryDto.Id);
            var mealIngredients = RetrieveMealIngredients(mealIngredientDtos);

            var meal = MealFactory.Create(mealName, mealCategory, mealIngredients);
            mealRepository.Add(meal);

            unitOfWork.SaveChanges();
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

        public void AddMealIngredient(int mealId, MealIngredientDto mealIngredientDto)
        {
            var meal = mealRepository.Get(mealId);
            if (meal == null) throw new DomainException($"Meal with id {mealId}, does not exist");

            var ingredient = ingredientRepository.Get(mealIngredientDto.IngredientId);
            if (ingredient == null) throw new DomainException($"ingredient with id {mealIngredientDto.IngredientId}, does not exist");

            meal.AddMealIngredient(MealIngredientFactory.Create(ingredient, mealIngredientDto.Amount, mealIngredientDto.UnitOfMeasurement));

            unitOfWork.SaveChanges();
        }

        public void AddMealIngredients(int mealId, IEnumerable<MealIngredientDto> mealIngredientDtos)
        {
            var meal = mealRepository.Get(mealId);

            foreach (var mealIngredientdto in mealIngredientDtos)
            {
                var ingredient = ingredientRepository.Get(mealIngredientdto.IngredientId);

                meal.AddMealIngredient(MealIngredientFactory.Create(ingredient, mealIngredientdto.Amount, mealIngredientdto.UnitOfMeasurement));
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

        public void Delete(int Id)
        {
            mealRepository.Delete(Id);

            unitOfWork.SaveChanges();
        }

        public IPage<Meal> Get(int index, int pageSize)
        {
            var page = mealRepository.Get(index, pageSize);
            return page;
        }
    }
}
