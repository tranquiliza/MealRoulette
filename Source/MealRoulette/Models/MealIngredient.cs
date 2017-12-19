using System;

namespace MealRoulette.Models
{
    public class MealIngredient : BaseEntity
    {
        public Ingredient Ingredient { get; set; }

        public int Amount { get; private set; }

        public string UnitOfMeasurement { get; private set; }

        private MealIngredient() { }

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
