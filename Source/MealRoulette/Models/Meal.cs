using MealRoulette.Exceptions;
using System;
using System.Collections.Generic;

namespace MealRoulette.Models
{
    public class Meal : BaseEntity
    {
        public string Name { get; private set; }

        public Country CountryOfOrigin { get; private set; }

        public bool IsFastFood { get; set; }

        public bool IsVegetarianFriendly { get; private set; }

        public HardwareCategory HardwareCategory { get; private set; }

        public Holiday Holiday { get; private set; }

        public string Recipe { get; private set; }

        public string Description { get; private set; }

        public MealCategory MealCategory { get; private set; }

        public List<MealIngredient> MealIngredients { get; private set; }

        private Meal() { }

        internal Meal(string name, MealCategory mealCategory, HardwareCategory hardwareCategory)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));
            if (mealCategory == null) throw new ArgumentNullException(nameof(mealCategory));
            if (hardwareCategory == null) throw new ArgumentNullException(nameof(hardwareCategory));

            MealIngredients = new List<MealIngredient>();
            Name = name;
            MealCategory = mealCategory;
            HardwareCategory = hardwareCategory;
        }

        internal void SetCountryOfOrigin(Country countryOfOrigin)
        {
            if (countryOfOrigin == null) throw new ArgumentNullException("Country cannot be empty!", nameof(countryOfOrigin));

            CountryOfOrigin = countryOfOrigin;
        }

        internal void SetDescription(string description)
        {
            Description = description;
        }

        internal void AddMealIngredient(MealIngredient mealIngredient)
        {
            if (mealIngredient == null) throw new ArgumentNullException(nameof(mealIngredient));
            if (MealAlreadyHas(mealIngredient)) throw new DomainException($"This meal already contains {mealIngredient.Ingredient.Name}");

            MealIngredients.Add(mealIngredient);
        }

        private bool MealAlreadyHas(MealIngredient mealIngredient)
        {
            return MealIngredients.FindAll(m => m.Ingredient.Id == mealIngredient.Ingredient.Id).Count > 0;
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

        internal void SetHardwareCategory(HardwareCategory hardwareCategory)
        {
            if (hardwareCategory == null) throw new DomainException("Hardware Category cannot be empty");

            HardwareCategory = hardwareCategory;
        }
    }
}
