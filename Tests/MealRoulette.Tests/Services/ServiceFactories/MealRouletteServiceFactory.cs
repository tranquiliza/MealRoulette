using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.Domain.Tests.Services.ServiceFactories
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
