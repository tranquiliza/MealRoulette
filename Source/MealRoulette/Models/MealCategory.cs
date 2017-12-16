using System;

namespace MealRoulette.Domain.Models
{
    public class MealCategory : BaseEntity
    {
        public string Name { get; private set; }

        private MealCategory() { }

        internal MealCategory(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must be given", nameof(name));

            Name = name;
        }
    }
}