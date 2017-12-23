using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MealRoulette.Tests.Services
{
    [TestFixture]
    public class UnitOfMeasurementServiceShould
    {
        [Test]
        public void Return_Units_Of_Measurement()
        {
            //Arrange
            var repository = CreateRepositoryWithUnits();
            var service = new UnitOfMeasurementServiceFactory()
                .WithUnitOfMeasurementRepository(repository)
                .Build();

            //Act
            var sut = service.Get();

            //Assert 
            Assert.IsNotNull(sut);
        }

        private IUnitOfMeasurementRepository CreateRepositoryWithUnits()
        {
            var units = CreateUnitsOfMeasurement();
            var mock = new Mock<IUnitOfMeasurementRepository>();
            mock.Setup(x => x.Get()).Returns(units);
            return mock.Object;
        }

        private IEnumerable<UnitOfMeasurement> CreateUnitsOfMeasurement()
        {
            var list = new List<UnitOfMeasurement>()
            {
                new UnitOfMeasurement("Gram"),
                new UnitOfMeasurement("Kilo"),
                new UnitOfMeasurement("Water")
            };
            return list;
        }
    }
}
