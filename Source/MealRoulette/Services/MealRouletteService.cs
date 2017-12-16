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

        public MealRouletteService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

            mealRepository = unitOfWork.MealRepository;
        }

        Meal IMealRouletteService.RollMeal()
        {
            var meals = mealRepository.Get().ToList();


            var random = new Random();
            var roll = random.Next(0, meals.Count);

            return meals[roll];
        }
    }
}
