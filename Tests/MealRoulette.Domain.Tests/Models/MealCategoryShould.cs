using MealRoulette.Domain.Models;
using NUnit.Framework;
using System;

namespace MealRoulette.Domain.Tests.Models
{
    [TestFixture]
    public class MealCategoryShould
    {
        [Test]
        public void Create()
        {
            //Arrange
            const string CategoryName = "Dinner";

            //Act
            var sut = new MealCategory(CategoryName);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ThrowArgumentExceptionIfGivenNameIsEmpty()
        {
            //Arrange

            //Act
            TestDelegate sut = new TestDelegate(() => new MealCategory(""));

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
