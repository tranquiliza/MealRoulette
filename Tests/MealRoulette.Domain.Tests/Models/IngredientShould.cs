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
            const string NameOfUnit = "Gram";
            const int Amount = 400;

            //Act
            var sut = new Ingredient(Name, NameOfUnit, Amount);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ThrowArgumentExceptionOnMissingName()
        {
            //Arrange
            const string Name = "";
            const string NameOfUnit = "Gram";
            const int Amount = 400;

            //Act
            TestDelegate sut = new TestDelegate(() => new Ingredient(Name, NameOfUnit, Amount));

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Test]
        public void ThrowArgumentExceptionOnMissingNameOfUnit()
        {
            //Arrange
            const string Name = "Chicken";
            const string NameOfUnit = "";
            const int Amount = 400;

            //Act
            TestDelegate sut = new TestDelegate(() => new Ingredient(Name, NameOfUnit, Amount));

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Test]
        public void ThrowArgumentOutOfRangeExceptionOnAmountLessThanOrEqualToZero()
        {
            //Arrange
            const string Name = "Chicken";
            const string NameOfUnit = "Gram";
            const int Amount = 0;

            //Act
            TestDelegate sut = new TestDelegate(() => new Ingredient(Name, NameOfUnit, Amount));

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(sut);
        }
    }
}
