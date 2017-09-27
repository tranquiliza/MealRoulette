﻿namespace MealRoulette.Domain.Models
{
    public class MealCategory : BaseEntity
    {
        public string Name { get; private set; }

        public MealCategory(string name)
        {
            Name = name;
        }
    }
}