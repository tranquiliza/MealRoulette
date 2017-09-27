using MealRoulette.Domain.DomainServices.Interfaces;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Factories;
using MealRoulette.Domain.Repositories;
using System.Collections.Generic;

namespace MealRoulette.Domain.DomainServices
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _MealRepository;
        private readonly IMealCategoryRepository _mealCategoryRepository;
        private readonly IIngredientRepository _ingredientRepository;

        public MealService(IMealRepository mealRepository, IMealCategoryRepository mealCategoryRepository, IIngredientRepository ingredientRepository)
        {
            _MealRepository = mealRepository;
            _mealCategoryRepository = mealCategoryRepository;
            _ingredientRepository = ingredientRepository;
        }

        public void CreateMeal(string name, int mealCategory, List<int> ingredients)
        {
            var duplicateCheck = _MealRepository.Get(name);
            if (duplicateCheck != null) throw new DomainException("Meal with given name already exists");

            var category = _mealCategoryRepository.Get(mealCategory);

            var factory = MealFactory.Create(name, category);

            var meal = factory.CreateMeal();

            _MealRepository.Add(meal);
        }
    }
}
