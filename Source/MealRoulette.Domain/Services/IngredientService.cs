using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MealRoulette.Domain.DataStructures;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;

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

        public void CreateIngredient(string name)
        {
            var ingredient = new Ingredient(name);
            ingredientRepository.Add(ingredient);
        }

        public void Delete(int id)
        {
            ingredientRepository.Delete(id);
        }

        public Ingredient Get(int id)
        {
            var ingredient = ingredientRepository.Get(id);
            return ingredient;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            var ingredients = ingredientRepository.GetAll();
            return ingredients;
        }

        public IPage<Ingredient> GetPage(int pageIndex, int pageSize)
        {
            var page = ingredientRepository.GetPage(pageIndex, pageSize);
            return page;
        }
    }
}
