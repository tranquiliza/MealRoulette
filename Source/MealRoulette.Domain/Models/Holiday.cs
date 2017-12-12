using System;

namespace MealRoulette.Domain.Models
{
    public class Holiday : BaseEntity
    {
        public string Name { get; private set; }

        internal Holiday(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Give name is null or empty", nameof(name));

            Name = name;
        }
    }
}
