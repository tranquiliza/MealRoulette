using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Tests.Services.Helpers;
using Moq;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Services
{
    [TestFixture]
    public class MealCategoryServiceShould
    {
        [Test]
        public void Create_MealCategory()
        {
            //Arrange
            var repository = CreateEmptyRepository();

            var service = new MealCategoryServiceFactory()
                .WithMealCategoryRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create("Dinner"));

            //Assert
            Assert.DoesNotThrow(sut);
        }

        private IMealCategoryRepository CreateEmptyRepository()
        {
            var mock = new Mock<IMealCategoryRepository>();
            return mock.Object;
        }

        [Test]
        public void Throws_DomainException_If_Mealcategory_Already_Exists()
        {
            //Arrange
            const string categoryName = "Dinner";
            var repository = CreateRepositoryWithAlreadyExisting(categoryName);
            var service = new MealCategoryServiceFactory()
                .WithMealCategoryRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create(categoryName));

            //Assert
            Assert.Throws<DomainException>(sut);
        }

        private IMealCategoryRepository CreateRepositoryWithAlreadyExisting(string categoryName)
        {
            var mock = new Mock<IMealCategoryRepository>();
            mock.Setup(x => x.Get(categoryName)).Returns(CreateMealCategory(categoryName));
            return mock.Object;
        }

        private MealCategory CreateMealCategory(string categoryName)
        {
            return new MealCategory(categoryName);
        }
    }
}
