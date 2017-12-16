using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services.Abstractions;
using System;
using System.Linq;

namespace MealRoulette.Domain.Services
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
            var roll = random.Next(0, meals.Count);

            return meals[roll];
        }
    }
}
