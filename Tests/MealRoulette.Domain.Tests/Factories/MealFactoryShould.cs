using MealRoulette.Domain.Factories;
using MealRoulette.Domain.Models;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Factories
{
    [TestFixture]
    public class MealFactoryShould
    {
        [Test]
        public void CreateMealFromFactory()
        {
            //Arrange
            var factory = MealFactory.Create("TestMeal", new MealCategory("Name"));
            factory.AddIngredient("Chicken", "Grams", 100);

            //Act
            var sut = factory.CreateMeal();

            //Assert
            Assert.IsNotNull(sut);
        }
    }
}
