using MealRoulette.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealRoulette.Domain.Models
{
    public class Meal : BaseEntity
    {
        private const string EmptyHardwareCategoryName = "None";
        private const string EmptyHolidayName = "Any";

        public string Name { get; private set; }
        public string Country { get; private set; } //Better name for "Italian Food"?
        public bool IsFastFood { get; set; }
        public bool IsVegetarianFriendly { get; private set; } //How do we check ?
        public string HardwareCategory { get; private set; }
        public Season Season { get; private set; } //Could one dish potentially be more Seasons?
        public string Holiday { get; private set; }
        public string Recipe { get; private set; }

        public MealCategory MealCategory { get; private set; }

        private List<Ingredient> _Ingredients { get; set; }
        public IEnumerable<Ingredient> GetIngredients
        {
            get
            {
                return _Ingredients;
            }
        }

        private Meal() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Cannot be NullOrEmpty</param>
        /// <param name="mealCategory">Cannot be Null</param>
        public Meal(string name, MealCategory mealCategory)
        {
            if (mealCategory == null) throw new ArgumentNullException(nameof(mealCategory));
            if (string.IsNullOrEmpty(name)) throw new ArgumentException(nameof(name));

            _Ingredients = new List<Ingredient>();
            Name = name;
            MealCategory = mealCategory;
            HardwareCategory = EmptyHardwareCategoryName;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            if (MealAlreadyHas(ingredient)) throw new DomainException($"This meal already contains {ingredient.Name}");

            _Ingredients.Add(ingredient);
        }

        private bool MealAlreadyHas(Ingredient ingredient)
        {
            return _Ingredients.FindAll(m => m.Name.ToLower() == ingredient.Name.ToLower()).Count > 0;
        }

        public void SetRecipe(string recipe)
        {
            if (string.IsNullOrWhiteSpace(recipe)) throw new ArgumentException(nameof(recipe));

            Recipe = recipe;
        }

        public void SetHoliday(string holiday)
        {
            if (string.IsNullOrWhiteSpace(holiday))
            {
                Holiday = EmptyHolidayName;
            }
            else
            {
                Holiday = holiday;
            }
        }

        public void SetHardwareCategory(string hardwareCategory)
        {
            if (string.IsNullOrWhiteSpace(hardwareCategory))
            {
                HardwareCategory = EmptyHardwareCategoryName;
            }
            else
            {
                HardwareCategory = hardwareCategory;
            }
        }
    }
}
