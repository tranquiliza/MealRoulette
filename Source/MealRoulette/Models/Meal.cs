﻿using MealRoulette.Exceptions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Models
{
    public class Meal : BaseEntity
    {
        private const string DefaultHardwareCategory = "None";

        public string Name { get; private set; }

        public string Country { get; private set; } //Better name for "Italian Food"?

        public bool IsFastFood { get; set; }

        public bool IsVegetarianFriendly { get; private set; } //How do we check ?

        public string HardwareCategory { get; private set; }

        public Season Season { get; private set; } //Could one dish potentially be more Seasons?

        public Holiday Holiday { get; private set; }

        public string Recipe { get; private set; }

        public MealCategory MealCategory { get; private set; }

        public List<MealIngredient> Ingredients { get; private set; }

        private Meal() { }

        internal Meal(string name, MealCategory mealCategory)
        {
            if (mealCategory == null) throw new ArgumentNullException(nameof(mealCategory));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

            Ingredients = new List<MealIngredient>();
            Name = name;
            MealCategory = mealCategory;
            HardwareCategory = DefaultHardwareCategory;
        }

        internal void AddMealIngredient(MealIngredient mealIngredient)
        {
            if (mealIngredient == null) throw new ArgumentNullException(nameof(mealIngredient));
            if (MealAlreadyHas(mealIngredient)) throw new DomainException($"This meal already contains {mealIngredient.Ingredient.Name}");

            Ingredients.Add(mealIngredient);
        }

        private bool MealAlreadyHas(MealIngredient mealIngredient)
        {
            return Ingredients.FindAll(m => m.Ingredient.Id == mealIngredient.Ingredient.Id).Count > 0;
        }

        internal void SetRecipe(string recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe)) throw new ArgumentException(nameof(recipe));

            Recipe = recipe;
        }

        internal void SetHoliday(Holiday holiday)
        {
            if (holiday == null) throw new ArgumentNullException(nameof(holiday));

            Holiday = holiday;
        }

        internal void SetHardwareCategory(string hardwareCategory)
        {
            if (string.IsNullOrWhiteSpace(hardwareCategory))
            {
                HardwareCategory = DefaultHardwareCategory;
            }
            else
            {
                HardwareCategory = hardwareCategory;
            }
        }
    }
}