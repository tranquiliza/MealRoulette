using MealRoulette.Events;
using MealRoulette.Models;
using System;

namespace MealRoulette.Services.Abstractions
{
    public interface IMealRouletteService
    {
        event EventHandler<DomainEventArgs> MealSelectedEvent;

        Meal RollMeal();
    }
}
