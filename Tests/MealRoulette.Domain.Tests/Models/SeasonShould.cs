using MealRoulette.Domain.Models;
using NUnit.Framework;
using System;

namespace MealRoulette.Domain.Tests.Models
{
    [TestFixture]
    public class SeasonShould
    {
        [Test]
        public void Create()
        {
            //Arrange
            const string SeasonName = "Summer";

            //Act
            var sut = new Season(SeasonName);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void ThrowArgumentExceptionWhenEmptyNameIsGiven()
        {
            //Arrange

            //Act
            TestDelegate sut = new TestDelegate(() => new Season(""));

            //Assert 
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
