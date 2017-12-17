using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.Season;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace MealRoulette.WebApi.Tests.Controllers
{
    [TestFixture]
    public class SeasonControllerShould
    {
        [Test]
        public void Return_BadRequestErrorMessageResult_When_Posting_Already_Existing_Season()
        {
            //Arrange
            var service = CreateServiceThatThrows();
            var controller = new SeasonControllerFactory()
                .WithSeasonService(service)
                .Build();

            //Act
            var sut = controller.Post(new CreateSeasonApiRequest() { Name = "Summer" }) as BadRequestErrorMessageResult;

            //Assert 
            Assert.AreEqual("Season Summer, already exists", sut.Message);
        }

        private ISeasonService CreateServiceThatThrows()
        {
            var mock = new Mock<ISeasonService>();
            mock.Setup(x => x.Create("Summer")).Throws(new DomainException("Season Summer, already exists"));
            return mock.Object;
        }

        [Test]
        public void Return_BadRequest_When_Posting_Null()
        {
            //Arrange
            var controller = new SeasonControllerFactory()
                .Build();

            //Act
            var sut = controller.Post(null) as BadRequestResult;

            //Assert 
            Assert.IsNotNull(sut);
        }

        [Test]
        public void Return_Ok_When_Posting_New_Season()
        {
            //Arrange
            var service = CreateEmptyService();
            var controller = new SeasonControllerFactory()
                .WithSeasonService(service)
                .Build();

            //Act
            var sut = controller.Post(new CreateSeasonApiRequest() { Name = "Summer" }) as OkResult;

            //Assert 
            Assert.IsNotNull(sut);
        }

        private ISeasonService CreateEmptyService()
        {
            var mock = new Mock<ISeasonService>();
            return mock.Object;
        }

        [Test]
        public void Return_Seasons()
        {
            //Arrange
            var service = CreateServiceWithSeasons();
            var controller = new SeasonControllerFactory()
                .WithSeasonService(service)
                .Build();

            //Act
            var sut = controller.Get();

            //Assert
            Assert.AreEqual(4, sut.Count());
        }

        private ISeasonService CreateServiceWithSeasons()
        {
            var seasons = CreateSeasons();
            var mock = new Mock<ISeasonService>();
            mock.Setup(x => x.Get()).Returns(seasons);
            return mock.Object;
        }

        private IEnumerable<Season> CreateSeasons()
        {
            var seasons = new List<Season>()
            {
                new Season("Winter"),
                new Season("Spring"),
                new Season("Summer"),
                new Season("Fall")
            };
            return seasons;
        }
    }
}
