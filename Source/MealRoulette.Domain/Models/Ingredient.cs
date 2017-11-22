using System;

namespace MealRoulette.Domain.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; private set; }

        public string UnitOfMeasurement { get; private set; }

        public int Amount { get; private set; }

        public Ingredient(string name, string unitOfMeasurement, int amount)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must be given", nameof(name));
            if (string.IsNullOrWhiteSpace(unitOfMeasurement)) throw new ArgumentException("Unit name must be given", nameof(name));
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount given must be higher than 0");

            Name = name;
            UnitOfMeasurement = unitOfMeasurement;
            Amount = amount;
        }

        public void SetAmount(int amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), amount, "Amount given must be higher than 0");

            Amount = amount;
        }

        public void SetUnitOfMeasurement(string unitOfMeasurement)
        {
            if (string.IsNullOrWhiteSpace(unitOfMeasurement)) throw new ArgumentException("Unit of Measurement must be given", nameof(unitOfMeasurement));
        }
    }
}
