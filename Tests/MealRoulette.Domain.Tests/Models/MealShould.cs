using System;
using MealRoulette.Domain.Exceptions;
using MealRoulette.Domain.Models;
using NUnit.Framework;

namespace MealRoulette.Domain.Tests.Models
{
    [TestFixture]
    public class MealShould
    {
        private const string DefaultHardwareCategory = "None";
        private const string DefaultHolidayValue = "Any";

        [Test]
        public void CreateWithDefaultValues()
        {
            //Arrange
            const string mealName = "MyFirstMeal";

            //Act
            var sut = new Meal(mealName, new MealCategory("Snack"));

            //Assert
            Assert.AreEqual(mealName, sut.Name);
            Assert.AreEqual(DefaultHolidayValue, sut.Holiday);
            Assert.AreEqual(DefaultHardwareCategory, sut.HardwareCategory);
        }

        [Test]
        public void AddIngredient()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            var ingredient = new Ingredient("Chicken", "Grams", 400);

            //Act
            sut.AddIngredient(ingredient);

            //Assert
            Assert.AreEqual(1, sut.Ingredients.Count);
        }

        private Meal CreateMealWithoutIngredients()
        {
            var meal = new Meal("MyFirstMeal", new MealCategory("Snack"));
            return meal;
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
            Assert.Throws<DomainException>(sut);
        }

        private Meal CreateMealWithChicken()
        {
            var ingredient = new Ingredient("Chicken", "gram", 500);

            var meal = new Meal("ThisHasChicken", new MealCategory("Dinner"));
            meal.AddIngredient(ingredient);

            return meal;
        }

        [Test]
        public void SetRecipe()
        {
            //Arrange
            var meal = CreateMealWithoutIngredients();
            const string recipe = "Very long recipe containing many different types of letters, ÆØÅæøåõ ö ";

            //Act
            meal.SetRecipe(recipe);

            //Assert 
            Assert.AreEqual(recipe, meal.Recipe);
        }

        [Test]
        public void ThrowsArgumentExceptionIfSettingEmptyRecipe()
        {
            //Arrange
            var meal = CreateMealWithoutIngredients();

            //Act
            TestDelegate sut = new TestDelegate(() => meal.SetRecipe(""));

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Test]
        public void SetHoliday()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            const string holiday = "Christmas";

            //Act
            sut.SetHoliday(holiday);

            //Assert
            Assert.AreEqual(holiday, sut.Holiday);
        }

        [Test]
        public void SetHolidayToDefaultIfEmptyHolidayIsGiven()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();

            //Act
            sut.SetHoliday("");

            //Assert
            Assert.AreEqual(DefaultHolidayValue, sut.Holiday);
        }

        [Test]
        public void SetHardwareCategory()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            const string HardwareCategory = "Grill";

            //Act
            sut.SetHardwareCategory(HardwareCategory);

            //Assert 
            Assert.AreEqual(HardwareCategory, sut.HardwareCategory);
        }

        [Test]
        public void SetHardwareCategoryToDefaultIfEmptyStringIsGiven()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();

            //Act
            sut.SetHardwareCategory("");

            //Assert 
            Assert.AreEqual(DefaultHardwareCategory, sut.HardwareCategory);
        }
    }
}
