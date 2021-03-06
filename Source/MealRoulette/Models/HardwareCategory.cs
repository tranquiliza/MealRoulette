﻿using MealRoulette.Exceptions;

namespace MealRoulette.Models
{
    public class HardwareCategory : BaseEntity
    {
        public string Name { get; private set; }

        private HardwareCategory() { }

        public HardwareCategory(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Hardware Category must have a name");

            Name = name;
        }
    }
}
