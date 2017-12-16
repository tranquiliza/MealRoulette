using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Domain.Services
{
    public class IngredientService : IIngredientService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IIngredientRepository ingredientRepository;

        public IngredientService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            ingredientRepository = unitOfWork.IngredientRepository;
        }

        void IIngredientService.Create(string name)
        {
            var duplicateCheck = ingredientRepository.Get(name);
            if (duplicateCheck != null) throw new DomainException($"Ingredient with {name}, already exists");

            var ingredient = new Ingredient(name);
            ingredientRepository.Add(ingredient);

            unitOfWork.SaveChanges();
        }

        void IBaseService<Ingredient>.Delete(int id)
        {
            ingredientRepository.Delete(id);

            unitOfWork.SaveChanges();
        }

        Ingredient IBaseService<Ingredient>.Get(int id)
        {
            var ingredient = ingredientRepository.Get(id);
            return ingredient;
        }

        IEnumerable<Ingredient> IBaseService<Ingredient>.Get()
        {
            var ingredients = ingredientRepository.Get();
            return ingredients;
        }

        IPage<Ingredient> IBaseService<Ingredient>.Get(int pageIndex, int pageSize)
        {
            var page = ingredientRepository.Get(pageIndex, pageSize);
            return page;
        }
    }
}
