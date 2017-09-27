using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public class Meal
    {
        public string Name { get; private set; }
        public string Country { get; private set; } //Better name for "Italian Food"?
        public bool IsFastFood { get; private set; }
        public IEnumerable<string> Ingredients { get; private set; }
        public string HardwareCategory { get; private set; }
        public string Season { get; private set; }
        public string Holiday { get; private set; }
        public string Recipe { get; private set; }

        public MealCategory MealCategory { get; private set; }

        private List<Meat> _Meats { get; set; } //need a better way of "Adding Meats"
        public IEnumerable<Meat> GetMeats
        {
            get
            {
                return _Meats;
            }
        }

        private Meal() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">Name of the dish</param>
        /// <param name="mealCategory">Breakfast, Lunch, Dinner</param>
        /// <param name="meat">Per Default we cannot have a meal without a Meat / NoMeat involved</param>
        public Meal(string name, MealCategory mealCategory, Meat meat)
        {
            _Meats = new List<Meat>();
            Name = name;
            MealCategory = mealCategory;
            _Meats.Add(meat);
        }

        public void AddMeat(Meat meat)
        {
            if (_Meats.Select(m => m.Name == meat.Name).Count() != 0) throw new Exception();

            _Meats.Add(meat);
        }

        public void AddIngredient(string ingredient)
        {

        }
    }
}
