using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class HardwareCategoryServiceFactory
    {
        private IHardwareCategoryRepository hardwareCategoryRepository;

        internal HardwareCategoryServiceFactory()
        {
            hardwareCategoryRepository = null;
        }

        internal HardwareCategoryServiceFactory WithHolidayRepository(IHardwareCategoryRepository hardwareCategoryRepository)
        {
            this.hardwareCategoryRepository = hardwareCategoryRepository ?? throw new System.ArgumentNullException(nameof(hardwareCategoryRepository));
            return this;
        }

        internal IHolidayService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.HardwareRepository).Returns(hardwareCategoryRepository);

            var service = new HolidayService(unitOfWork.Object);
            return service;
        }
    }
}
