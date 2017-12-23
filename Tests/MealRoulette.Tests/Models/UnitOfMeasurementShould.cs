using MealRoulette.Exceptions;
using MealRoulette.Models;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Models
{
    [TestFixture]
    public class UnitOfMeasurementShould
    {
        [Test]
        public void Construct()
        {
            //Act
            var sut = new UnitOfMeasurement("Gram");

            //Assert 
            Assert.IsNotNull(sut);
        }

        [Test]
        public void Throw_DomainException_If_Name_Given_Is_Empty()
        {
            //Act
            var sut = new TestDelegate(() => new UnitOfMeasurement(string.Empty));

            //Assert 
            Assert.Throws<DomainException>(sut);
        }
    }
}
