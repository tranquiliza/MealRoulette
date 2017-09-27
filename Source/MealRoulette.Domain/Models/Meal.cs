using MealRoulette.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealRoulette.Domain.Models
{
    public class Meal : BaseEntity
    {
        public string Name { get; private set; }
        public string Country { get; private set; } //Better name for "Italian Food"?
        public bool IsFastFood { get; private set; }
        public bool IsVegetarianFriendly { get; private set; }
        public string HardwareCategory { get; private set; }
        public Season Season { get; private set; } //Could one dish potentially be more Seasons?
        public string Holiday { get; private set; }
        public string Recipe { get; private set; }

        public MealCategory MealCategory { get; private set; }

        private List<Ingredient> _Ingredients { get; set; }
        public List<Ingredient> GetIngredients
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
        /// <param name="name">Name of the dish</param>
        /// <param name="mealCategory">Breakfast, Lunch, Dinner</param>
        /// <param name="meat">Per Default we cannot have a meal without a Meat / NoMeat involved</param>
        public Meal(string name, MealCategory mealCategory)
        {
            if (MealCategory == null) throw new ArgumentNullException(nameof(mealCategory));

            _Ingredients = new List<Ingredient>();
            Name = name;
            MealCategory = mealCategory;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            if (_Ingredients.Select(m => m.Name == ingredient.Name).Count() > 0) throw new DomainException($"This meal already contains {ingredient.Name}");

            _Ingredients.Add(ingredient);
        }
    }
}
