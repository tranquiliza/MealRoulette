using System;

namespace MealRoulette.Domain.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; private set; }
        public string NameOfUnit { get; private set; }
        public int Amount { get; private set; }

        public Ingredient(string name, string nameOfUnit, int amount)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must be given", nameof(name));
            if (string.IsNullOrWhiteSpace(nameOfUnit)) throw new ArgumentException("Unit name must be given", nameof(name));
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount given must be higher than 0");

            Name = name;
            NameOfUnit = nameOfUnit;
            Amount = amount;
        }

        public void SetAmount(int amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount given must be higher than 0");

            Amount = amount;
        }

        public void SetNameOfUnit(string nameOfUnit)
        {
            if (string.IsNullOrWhiteSpace(nameOfUnit)) throw new ArgumentException("Name of the Unit must be given", nameof(nameOfUnit));
        }
    }
}
