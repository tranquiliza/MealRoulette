﻿using System;

namespace MealRoulette.Models
{
    public class MealIngredient : BaseEntity
    {
        public Ingredient Ingredient { get; set; }

        public int Amount { get; private set; }

        public UnitOfMeasurement UnitOfMeasurement { get; private set; }

        private MealIngredient() { }

        internal MealIngredient(Ingredient ingredient, int amount, UnitOfMeasurement unitOfMeasurement)
        {
            if (ingredient == null) throw new ArgumentNullException(nameof(ingredient));
            if (amount <= 0) throw new ArgumentException(nameof(amount));
            if (unitOfMeasurement == null) throw new ArgumentNullException(nameof(unitOfMeasurement));

            Ingredient = ingredient;
            Amount = amount;
            UnitOfMeasurement = unitOfMeasurement;
        }
    }
}
