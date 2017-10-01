using System;

namespace MealRoulette.Domain.Models
{
    public class Holiday : BaseEntity
    {
        private string name { get; set; }

        public Holiday(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Give name is null or empty", nameof(name));

            this.name = name;
        }
    }
}
