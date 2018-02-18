using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class CountryServiceFactory
    {
        private ICountryRepository countryRepository;

        internal CountryServiceFactory()
        {
            countryRepository = null;
        }

        internal CountryServiceFactory WithHolidayRepository(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository ?? throw new System.ArgumentNullException(nameof(countryRepository));
            return this;
        }

        internal IHolidayService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.CountryRepository).Returns(countryRepository);

            var service = new HolidayService(unitOfWork.Object);
            return service;
        }
    }
}
