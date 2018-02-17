using System;

namespace MealRoulette.Models
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public Country(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must be given", nameof(name));

            Name = name;
        }
    }
}