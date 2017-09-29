using System;

namespace MealRoulette.Domain.Models
{
    public class Season : BaseEntity
    {
        public string Name { get; private set; }

        public Season(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must be given", nameof(name));

            Name = name;
        }
    }
}