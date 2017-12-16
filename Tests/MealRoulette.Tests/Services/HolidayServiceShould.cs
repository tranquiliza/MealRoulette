using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Services
{
    [TestFixture]
    public class HolidayServiceShould
    {
        [Test]
        public void Create_Holiday()
        {
            //Arrange
            const string holidayName = "Christmas";
            var repository = CreateEmptyRepository();
            var service = new HolidayServiceFactory()
                .WithHolidayRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create(holidayName));

            //Assert
            Assert.DoesNotThrow(sut);
        }

        private IHolidayRepository CreateEmptyRepository()
        {
            var mock = new Mock<IHolidayRepository>();
            return mock.Object;
        }

        [Test]
        public void Throw_Exception_If_Holiday_With_Given_Name_Already_Exists()
        {
            //Arrange
            var repository = CreateRepositoryWithAlreadyExistingHoliday();
            var service = new HolidayServiceFactory()
                .WithHolidayRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create("Christmas"));

            //Assert
            Assert.Throws<DomainException>(sut);
        }

        private IHolidayRepository CreateRepositoryWithAlreadyExistingHoliday()
        {
            var mock = new Mock<IHolidayRepository>();
            var holiday = new Holiday("Christmas");
            mock.Setup(x => x.Get("Christmas")).Returns(holiday);
            return mock.Object;
        }
    }
}
