using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;

namespace MealRoulette.Tests.Services
{
    [TestFixture]
    public class SeasonServiceShould
    {
        [Test]
        public void Create_Season()
        {
            //Arrange
            var repository = CreateEmptyRepostitory();
            var service = new SeasonServiceFactory()
                .WithSeasonRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create("Summer"));

            //Assert 
            Assert.DoesNotThrow(sut);
        }

        private ISeasonRepository CreateEmptyRepostitory()
        {
            var mock = new Mock<ISeasonRepository>();
            return mock.Object;
        }

        [Test]
        public void Throw_DomainException_When_Creating_Season_That_Already_Exists()
        {
            //Arrange
            var repository = CreateRepositoryWithSummer();
            var service = new SeasonServiceFactory()
                .WithSeasonRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create("Summer"));

            //Assert 
            Assert.Throws<DomainException>(sut);
        }

        private ISeasonRepository CreateRepositoryWithSummer()
        {
            var mock = new Mock<ISeasonRepository>();
            mock.Setup(x => x.Get("Summer")).Returns(new Season("Summer"));
            return mock.Object;
        }
    }
}
