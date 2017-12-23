using MealRoulette.Events.Abstractions;
using MealRoulette.Models;
using System;

namespace MealRoulette.Events
{
    public class RandomMealWasChosenEvent : IDomainEvent
    {
        public DateTimeOffset OccouredOn { get; private set; }

        public RandomMealWasChosenEvent(Meal meal)
        {
            Meal = meal;
            OccouredOn = DateTimeOffset.Now;
        }

        public Meal Meal { get; }

        DateTimeOffset IDomainEvent.OccouredOn => OccouredOn;
    }
}
