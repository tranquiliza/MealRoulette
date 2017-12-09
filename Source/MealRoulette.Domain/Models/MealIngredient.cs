using System;

namespace MealRoulette.Domain.Models
{
    public class MealIngredient
    {
        public Ingredient Ingredient { get; set; }

        public int Amount { get; private set; }

        public string UnitOfMeasurement { get; private set; }

        internal MealIngredient(Ingredient ingredient, int amount, string unitOfMeasurement)
        {
            if (ingredient == null) throw new ArgumentNullException(nameof(ingredient));
            if (amount <= 0) throw new ArgumentException(nameof(amount));
            if (string.IsNullOrWhiteSpace(unitOfMeasurement)) throw new ArgumentNullException(nameof(unitOfMeasurement));

            Ingredient = ingredient;
            Amount = amount;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
