using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Models
{
    [TestFixture]
    public class MealShould
    {
        [Test]
        public void BeCreated()
        {
            //Arrange
            const string mealName = "MyFirstMeal";

            //Act
            var sut = new Meal(mealName, new MealCategory("Snack"));

            //Assert
            Assert.AreEqual(mealName, sut.Name);
        }

        [Test]
        public void ThrowExceptionIfAddingSameIngredientTwice()
        {
            //Arrange
            var meal = CreateMealWithChicken();
            var duplicateIngredient = new Ingredient("Chicken", "gram", 500);

            //Act
            TestDelegate sut = delegate { meal.AddIngredient(duplicateIngredient); };

            //Assert
            Assert.Throws(typeof(DomainException), sut);
        }

        private Meal CreateMealWithChicken()
        {
            var ingredient = new Ingredient("Chicken", "gram", 500);

            var meal = new Meal("ThisHasChicken", new MealCategory("Dinner"));
            meal.AddIngredient(ingredient);

            return meal;
        }
    }
}
