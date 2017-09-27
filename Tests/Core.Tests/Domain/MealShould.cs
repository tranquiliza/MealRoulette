using NUnit.Framework;
using Core.Models;

namespace Core.Tests.Domain
{
    [TestFixture]
    public class MealShould
    {
        [Test]
        public void BeCreated()
        {
            //Arrange
            var mealCategory = new MealCategory("Dinner");
            var mealMeat = new Meat("Chicken");

            //Act
            const string mealName = "MyFirstMeal";
            var newMeal = new Meal(mealName, mealCategory, mealMeat);

            //Assert
            Assert.AreEqual(mealName, newMeal.Name);
        }

        [Test]
        public void ThrowExceptionIfAddingSameMeatTwice()
        {
            //Arrange
            var meal = CreateMealWithChicken();
            var chicken = new Meat("Chicken");

            //Act
            TestDelegate test = delegate { meal.AddMeat(chicken); };

            //Assert
            Assert.Throws(typeof(System.Exception), test);
        }

        private Meal CreateMealWithChicken()
        {
            var meat = new Meat("Chicken");
            var mealCategory = new MealCategory("Dinner");

            return new Meal("ThisHasChicken", mealCategory, meat);
        }
    }
}
