using MealRoulette.Models;
using NUnit.Framework;
using System;

namespace MealRoulette.Tests.Models
{
    [TestFixture]
    public class HolidayShould
    {
        [Test]
        public void Create()
        {
            //Arrange
            const string Name = "Christmas";

            //Act
            var sut = new Holiday(Name);

            //Assert
            Assert.IsNotNull(sut);
        }

        [Test]
        public void Throw_Exception_When_Name_Given_IsNullOrWhiteSpace()
        {
            //Arrange

            //Act
            TestDelegate sut = new TestDelegate(() => new Holiday(""));

            //Assert 
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
