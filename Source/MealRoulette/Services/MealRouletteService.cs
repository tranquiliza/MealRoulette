using MealRoulette.Events;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services.Abstractions;
using System;
using System.Linq;

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

        Meal IMealRouletteService.RollMeal()
        {
            var meals = mealRepository.Get().ToList();
            if (meals.Count == 0) throw new DomainException("There are no meals in your query");

            var roll = random.Next(0, meals.Count);

            var randomMeal = meals[roll];

            DomainEvents.Raise(new RandomMealWasChosenEvent(randomMeal));

            return randomMeal;
        }
    }
}
