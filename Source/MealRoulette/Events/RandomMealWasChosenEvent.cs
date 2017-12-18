using System;
using MealRoulette.Events.Abstractions;
using MealRoulette.Models;

namespace MealRoulette.Events
{
    public class RandomMealWasChosenEvent : IDomainEvent
    {
        private readonly DateTimeOffset occouredOn;

        public RandomMealWasChosenEvent(Meal meal)
        {
            Meal = meal;
            occouredOn = DateTimeOffset.Now;
        }

        public Meal Meal { get; }

        DateTimeOffset IDomainEvent.OccouredOn => occouredOn;
    }
}
