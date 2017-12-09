using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using Moq;

namespace MealRoulette.Domain.Tests.Services.ServiceFactories
{
    internal class HolidayServiceFactory
    {
        private IHolidayRepository holidayRepository;

        internal HolidayServiceFactory()
        {
            holidayRepository = null;
        }

        internal HolidayServiceFactory WithHolidayRepository(IHolidayRepository holidayRepository)
        {
            this.holidayRepository = holidayRepository ?? throw new System.ArgumentNullException(nameof(holidayRepository));
            return this;
        }

        internal IHolidayService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.HolidayRepository).Returns(holidayRepository);

            var service = new HolidayService(unitOfWork.Object);
            return service;
        }
    }
}
