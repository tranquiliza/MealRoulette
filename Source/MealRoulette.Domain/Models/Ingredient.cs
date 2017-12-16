using System;

namespace MealRoulette.Domain.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; private set; }

        private Ingredient() { }

        internal Ingredient(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must be given", nameof(name));

            Name = name;
        }

        internal void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            Name = name;
        }
    }
}
