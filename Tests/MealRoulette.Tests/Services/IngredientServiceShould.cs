using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Services
{
    [TestFixture]
    public class IngredientServiceShould
    {
        [Test]
        public void Create_Ingredient()
        {
            //Arrange
            var repository = CreateEmptyRepository();
            var service = new IngredientServiceFactory()
                .WithIngredientRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create("Cheese"));

            //Assert
            Assert.DoesNotThrow(sut);
        }

        private IIngredientRepository CreateEmptyRepository()
        {
            var mock = new Mock<IIngredientRepository>();
            return mock.Object;
        }

        [Test]
        public void Throw_DomainException_If_Creating_Already_Existing_Ingredient()
        {
            //Arrange
            var repository = CreateRepositoryWithCheese();
            var service = new IngredientServiceFactory()
                .WithIngredientRepository(repository)
                .Build();

            //Act
            var sut = new TestDelegate(() => service.Create("Cheese"));

            //Assert 
            Assert.Throws<DomainException>(sut);
        }

        private IIngredientRepository CreateRepositoryWithCheese()
        {
            var cheese = new Ingredient("Cheese");
            var mock = new Mock<IIngredientRepository>();
            mock.Setup(x => x.Get("Cheese")).Returns(cheese);
            return mock.Object;
        }
    }
}
