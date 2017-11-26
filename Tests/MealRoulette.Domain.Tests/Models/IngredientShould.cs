using MealRoulette.Domain.Models;
using NUnit.Framework;
using System;

namespace MealRoulette.Domain.Tests.Models
{
    [TestFixture]
    public class IngredientShould
    {
        [Test]
        public void Create()
        {
            //Arrange
            const string Name = "Chicken";

            //Act
            var sut = new Ingredient(Name);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ThrowArgumentExceptionOnMissingName()
        {
            //Arrange
            const string Name = "";

            //Act
            TestDelegate sut = new TestDelegate(() => new Ingredient(Name));

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
