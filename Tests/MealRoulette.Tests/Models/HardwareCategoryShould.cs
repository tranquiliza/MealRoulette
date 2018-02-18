using MealRoulette.Exceptions;
using MealRoulette.Models;
using NUnit.Framework;

namespace MealRoulette.Tests.Models
{
    [TestFixture]
    public class HardwareCategoryShould
    {
        [Test]
        public void Construct_With_Given_Name()
        {
            //Arrange
            const string name = "None";

            //Act
            var hardwareCategory = new HardwareCategory(name);

            //Assert
            Assert.AreEqual(name, hardwareCategory.Name);
        }

        [Test]
        public void Throw_Domain_Exception_If_Trying_To_Set_Name_NullOrWhiteSpace()
        {
            //Arrange
            var hardwareCategory = new HardwareCategory("None");

            //Act
            var testDelegate = new TestDelegate(() => hardwareCategory.SetName(""));

            //Assert
            Assert.Throws<DomainException>(testDelegate);
        }
    }
}
