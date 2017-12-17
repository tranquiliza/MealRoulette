using MealRoulette.Models;
using NUnit.Framework;
using System;

namespace MealRoulette.Tests.Models
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
        public void Throw_Argument_Exception_When_Empty_Name_Is_Given()
        {
            //Arrange

            //Act
            TestDelegate sut = new TestDelegate(() => new Season(""));

            //Assert 
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
