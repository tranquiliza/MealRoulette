using MealRoulette.Domain.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.Domain.Tests.Models
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
        public void ThrowExceptionWhenNameGivenIsNullOrWhiteSpace()
        {
            //Arrange

            //Act
            TestDelegate sut = new TestDelegate(() => new Holiday(""));

            //Assert 
            Assert.Throws<ArgumentException>(sut);
        }
    }
}
