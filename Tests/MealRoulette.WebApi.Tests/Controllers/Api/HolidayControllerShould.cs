using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.Holiday;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace MealRoulette.WebApi.Tests.Controllers.Api
{
    [TestFixture]
    public class HolidayControllerShould
    {
        [Test]
        public void Return_BadRequestResult_When_Posting_NullArgument()
        {
            //Arrange
            var service = CreateEmptyService();
            var controller = new HolidayControllerFactory()
                .WithHolidayService(service)
                .Build();

            //Act
            var sut = controller.Create(null) as BadRequestResult;

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void Return_BadRequestErrorMessageResult_When_Posting_Already_Existing_Holiday()
        {
            //Arrange
            var service = CreateHolidayServiceThatThrows();
            var controller = new HolidayControllerFactory()
                .WithHolidayService(service)
                .Build();

            //Act
            var request = new CreateHolidayApiRequest()
            {
                Name = "Christmas"
            };
            var sut = controller.Create(request) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(sut);
        }

        private IHolidayService CreateHolidayServiceThatThrows()
        {
            var mock = new Mock<IHolidayService>();
            mock.Setup(x => x.Create(It.IsAny<string>())).Throws<DomainException>();
            return mock.Object;
        }

        [Test]
        public void Post_Holiday()
        {
            //Arrange
            var service = CreateEmptyService();
            var controller = new HolidayControllerFactory()
                .WithHolidayService(service)
                .Build();

            //Act
            var createHolidayRequest = new CreateHolidayApiRequest
            {
                Name = "Christmas"
            };
            var sut = controller.Create(createHolidayRequest) as OkResult;

            //Assert 
            Assert.IsNotNull(sut);
        }

        private IHolidayService CreateEmptyService()
        {
            var mock = new Mock<IHolidayService>();
            return mock.Object;
        }

        [Test]
        public void Return_Holidays()
        {
            //Arrange
            var service = CreateHolidayServiceWithFiveHolidays();
            var controller = new HolidayControllerFactory()
                .WithHolidayService(service)
                .Build();

            //Act
            var sut = controller.Get() as OkNegotiatedContentResult<IEnumerable<Holiday>>;

            //Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual(5, sut.Content.Count());
        }

        [Test]
        public void Return_Holiday_With_Given_Id()
        {
            //Arrange
            var service = CreateHolidayServiceWithFiveHolidays();
            var controller = new HolidayControllerFactory()
                .WithHolidayService(service)
                .Build();

            //Act
            var sut = controller.Get(2) as OkNegotiatedContentResult<Holiday>;

            //Assert 
            Assert.IsNotNull(sut);
            Assert.AreEqual(2, sut.Content.Id);
        }

        private IHolidayService CreateHolidayServiceWithFiveHolidays()
        {
            var holidays = CreateHolidays();
            var mock = new Mock<IHolidayService>();
            mock.Setup(x => x.Get()).Returns(holidays);
            mock.Setup(x => x.Get(2)).Returns(holidays.FirstOrDefault(x => x.Id == 2));
            return mock.Object;
        }

        private IEnumerable<Holiday> CreateHolidays()
        {
            var holidays = new List<Holiday>()
            {
                new Holiday("Christmas"),
                new Holiday("Halloween"),
                new Holiday("Thanksgiving"),
                new Holiday("Easter"),
                new Holiday("New Years")
            };

            var holidaysWithIds = AssignIds(holidays);
            return holidaysWithIds;
        }

        private IEnumerable<Holiday> AssignIds(List<Holiday> holidays)
        {
            var counter = 0;
            foreach (var holiday in holidays)
            {
                counter++;
                typeof(BaseEntity).GetProperty("Id").SetValue(holiday, counter);
            }

            return holidays;
        }
    }
}
