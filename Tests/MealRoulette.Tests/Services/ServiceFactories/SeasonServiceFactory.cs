using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;
using System;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class SeasonServiceFactory
    {
        private ISeasonRepository seasonRepository;

        internal SeasonServiceFactory()
        {
            seasonRepository = null;
        }

        internal SeasonServiceFactory WithSeasonRepository(ISeasonRepository seasonRepository)
        {
            this.seasonRepository = seasonRepository ?? throw new ArgumentNullException(nameof(seasonRepository));
            return this;
        }

        internal ISeasonService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.SeasonRepository).Returns(seasonRepository);

            var service = new SeasonService(unitOfWork.Object);
            return service;
        }
    }
}
