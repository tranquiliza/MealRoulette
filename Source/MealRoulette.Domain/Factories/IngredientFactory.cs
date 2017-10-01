using System;
using System.Collections.Generic;
using MealRoulette.Domain.DomainServices.DataContracts;
using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Factories
{
    class IngredientFactory
    {
        public Ingredient Create(string name, string unitOfMeasurement, int amount)
        {
            var ingredient = new Ingredient(name, unitOfMeasurement, amount);
            return ingredient;
        }

        public IEnumerable<Ingredient> CreateMany(List<IngredientType> ingredientDtos)
        {
            if (ingredientDtos == null) throw new ArgumentNullException(nameof(ingredientDtos));

            var ingredients = new List<Ingredient>();

            foreach (var ingredient in ingredientDtos)
            {
                ingredients.Add(Create(ingredient.Name, ingredient.UnitOfMeasurement, ingredient.Amount));
            }
            return ingredients;
        }
    }
}
