using MealRoulette.Events;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MealRoulette.Services
{
    public class MealRouletteService : IMealRouletteService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMealRepository mealRepository;
        private readonly Random random;

        public MealRouletteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            mealRepository = unitOfWork.MealRepository;

            var randomSeed = DateTime.Now.Millisecond;
            random = new Random(randomSeed);
        }

        async Task<Meal> IMealRouletteService.RollMealAsync()
        {
            var meals = await mealRepository.GetAsync();
            if (meals.Count() == 0) throw new DomainException("There are no meals in the system");

            var roll = random.Next(0, meals.Count());

            var randomMeal = meals.ElementAt(roll);

            await DomainEvents.Raise(new RandomMealWasChosenEvent(randomMeal));

            return randomMeal;
        }
    }
}
