using MealRoulette.Domain.DomainServices.Interfaces;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Factories;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories;
using System.Collections.Generic;

namespace MealRoulette.Domain.DomainServices
{
    public class MealService : IMealService
    {
        private readonly MealFactory _MealFactory;
        private readonly IngredientFactory _IngredientFactory;
        private readonly IUnitOfWork _UnitOfWork;

        public MealService(IUnitOfWork unitOfWork)
        {
            _MealFactory = new MealFactory();
            _IngredientFactory = new IngredientFactory();
            _UnitOfWork = unitOfWork;
        }

        public void CreateMeal(string name, int mealCategory)
        {
            if (MealAlreadyExists(name)) throw new DomainException($"Meal with given name: {name}, already exists");

            var category = _UnitOfWork.MealCategoryRepository.Get(mealCategory);
            var meal = _MealFactory.Create(name, category);

            _UnitOfWork.MealRepository.Add(meal);
        }

        public void CreateMeal(string name, int mealCategory, List<Ingredient> ingredients)
        {
            if (MealAlreadyExists(name)) throw new DomainException($"Meal with given name: {name}, already exists");

            var category = _UnitOfWork.MealCategoryRepository.Get(mealCategory);

            var meal = _MealFactory.Create(name, category, ingredients);

            _UnitOfWork.MealRepository.Add(meal);
        }

        private bool MealAlreadyExists(string name)
        {
            return _UnitOfWork.MealRepository.Get(name) != null;
        }

        public IEnumerable<Meal> GetAll()
        {
            return _UnitOfWork.MealRepository.GetAll();
        }
    }
}
