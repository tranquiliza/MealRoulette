using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Services.Abstractions
{
    public interface IMealRouletteService
    {
        Meal RollMeal();
    }
}
