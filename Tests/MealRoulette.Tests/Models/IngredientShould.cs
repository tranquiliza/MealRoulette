using MealRoulette.Models;
using NUnit.Framework;
using System;

namespace MealRoulette.Tests.Models
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
        public void Throw_ArgumentException_On_Missing_Name()
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
