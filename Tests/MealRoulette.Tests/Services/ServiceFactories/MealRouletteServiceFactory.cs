using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class MealRouletteServiceFactory
    {
        IMealRepository mealRepository;

        public MealRouletteServiceFactory()
        {
            mealRepository = null;
        }

        public MealRouletteServiceFactory WithMealRepository(IMealRepository mealRepository)
        {
            this.mealRepository = mealRepository;
            return this;
        }

        public IMealRouletteService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.MealRepository).Returns(mealRepository);

            return new MealRouletteService(unitOfWork.Object);
        }
    }
}
