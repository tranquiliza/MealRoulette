using MealRoulette.Models;
using System.Threading.Tasks;

namespace MealRoulette.Services.Abstractions
{
    public interface IMealRouletteService
    {
        Task<Meal> RollMealAsync();
    }
}
