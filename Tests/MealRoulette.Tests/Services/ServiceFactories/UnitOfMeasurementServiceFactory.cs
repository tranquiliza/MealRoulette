using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class UnitOfMeasurementServiceFactory
    {
        private IUnitOfMeasurementRepository UnitOfMeasurementRepository;

        internal UnitOfMeasurementServiceFactory()
        {
            UnitOfMeasurementRepository = null;
        }

        internal UnitOfMeasurementServiceFactory WithUnitOfMeasurementRepository(IUnitOfMeasurementRepository unitOfMeasurementRepository)
        {
            UnitOfMeasurementRepository = unitOfMeasurementRepository ?? throw new System.ArgumentNullException(nameof(unitOfMeasurementRepository));
            return this;
        }

        internal IUnitOfMeasurementService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.UnitOfMeasurementRepository).Returns(UnitOfMeasurementRepository);

            var service = new UnitOfMeasurementService(unitOfWork.Object);
            return service;
        }
    }
}
