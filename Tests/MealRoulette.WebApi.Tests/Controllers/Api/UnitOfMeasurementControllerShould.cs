using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.WebApi.Tests.Controllers.Api
{
    [TestFixture]
    public class UnitOfMeasurementControllerShould
    {
        [Test]
        public void Return_Collection_Of_UnitsOfMeasurement()
        {
            //Arrange
            var service = CreateServiceWithUnits();
            var controller = new UnitOfMesurementControllerFactory()
                .WithUnitOfMeasurementService(service)
                .Build();

            //Act
            var sut = controller.Get();

            //Assert 
            Assert.AreEqual(4, sut.Count());
        }

        private IUnitOfMeasurementService CreateServiceWithUnits()
        {
            var units = CreateUnitsOfMeasurement();
            var mock = new Mock<IUnitOfMeasurementService>();
            mock.Setup(x => x.Get()).Returns(units);
            return mock.Object;
        }

        private IEnumerable<UnitOfMeasurement> CreateUnitsOfMeasurement()
        {
            return new List<UnitOfMeasurement>()
            {
                new UnitOfMeasurement("Gram"),
                new UnitOfMeasurement("Kilo"),
                new UnitOfMeasurement("Litre"),
                new UnitOfMeasurement("Tonne")
            };
        }
    }
}
