using MealRoulette.Exceptions;
using System;

namespace MealRoulette.Models
{
    public class UnitOfMeasurement : BaseEntity
    {
        public string Name { get; set; }

        private UnitOfMeasurement() { }

        internal UnitOfMeasurement(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Name of the Unit must be given!");

            Name = name;
        }
    }
}