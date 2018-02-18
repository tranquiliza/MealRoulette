using System;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using NUnit.Framework;

namespace MealRoulette.Tests.Models
{
    [TestFixture]
    public class MealShould
    {
        [Test]
        public void Add_Description_To_Meal()
        {
            //Arrange
            var meal = CreateMealWithChicken();

            //Act
            var sut = new TestDelegate(() => meal.SetDescription("Description goes here!"));

            //Assert 
            Assert.DoesNotThrow(sut);
            Assert.AreEqual("Description goes here!", meal.Description);
        }

        [Test]
        public void Set_Description_Null_When_Setting_Empty_Description()
        {
            //Arrange
            var meal = CreateMealWithChicken();

            //Act
            var sut = new TestDelegate(() => meal.SetDescription(""));

            //Assert 
            Assert.AreEqual(null, meal.Description);
        }

        [Test]
        public void Throw_ArgumentNullException_If_Giving_Null_Parameter()
        {
            //Arrange
            var meal = CreateMealWithChicken();

            //Act
            var sut = new TestDelegate(() => meal.SetCountryOfOrigin(null));

            //Assert 
            Assert.Throws<ArgumentNullException>(sut);
        }

        [Test]
        public void Set_Country_Of_Origin()
        {
            //Arrange
            var sut = CreateMealWithChicken();
            var country = new Country("Italy");

            //Act
            sut.SetCountryOfOrigin(country);

            //Assert 
            Assert.AreEqual(country, sut.CountryOfOrigin);
        }

        [Test]
        public void Create_With_Default_Values()
        {
            //Arrange
            const string mealName = "MyFirstMeal";

            //Act
            var sut = new Meal(mealName, new MealCategory("Snack"), new HardwareCategory("None"));

            //Assert
            Assert.AreEqual(mealName, sut.Name);
            Assert.AreEqual("None", sut.HardwareCategory.Name);
        }

        [Test]
        public void Add_Ingredient()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            var ingredient = new Ingredient("Chicken");
            var unitOfMasurement = new UnitOfMeasurement("Grams");
            var mealIngredient = new MealIngredient(ingredient, 10, unitOfMasurement);

            //Act
            sut.AddMealIngredient(mealIngredient);

            //Assert
            Assert.AreEqual(1, sut.MealIngredients.Count);
        }

        private Meal CreateMealWithoutIngredients()
        {
            var meal = new Meal("MyFirstMeal", new MealCategory("Snack"), new HardwareCategory("None"));
            return meal;
        }

        [Test]
        public void Throw_Exception_If_Adding_Same_Ingredient_Twice()
        {
            //Arrange
            var meal = CreateMealWithChicken();
            var duplicateIngredient = new Ingredient("Chicken");
            var unitOfMasurement = new UnitOfMeasurement("Grams");
            var mealIngredient = new MealIngredient(duplicateIngredient, 10, unitOfMasurement);

            //Act
            TestDelegate sut = delegate { meal.AddMealIngredient(mealIngredient); };

            //Assert
            Assert.Throws<DomainException>(sut);
        }

        private Meal CreateMealWithChicken()
        {
            var ingredient = new Ingredient("Chicken");
            var unitOfMasurement = new UnitOfMeasurement("Grams");
            var mealIngredient = new MealIngredient(ingredient, 10, unitOfMasurement);

            var meal = new Meal("ThisHasChicken", new MealCategory("Dinner"), new HardwareCategory("None"));

            meal.AddMealIngredient(mealIngredient);

            return meal;
        }

        [Test]
        public void Set_Recipe()
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
        public void Throws_ArgumentException_If_Setting_Empty_Recipe()
        {
            //Arrange
            var meal = CreateMealWithoutIngredients();

            //Act
            TestDelegate sut = new TestDelegate(() => meal.SetRecipe(""));

            //Assert
            Assert.Throws<ArgumentException>(sut);
        }

        [Test]
        public void Set_Holiday()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            var holiday = new Holiday("Christmas");

            //Act
            sut.SetHoliday(holiday);

            //Assert
            Assert.AreEqual(holiday, sut.Holiday);
        }

        [Test]
        public void Throw_ArgumentNullException_If_Empty_Holiday_Is_Given()
        {
            //Arrange
            var meal = CreateMealWithoutIngredients();

            //Act
            TestDelegate sut = new TestDelegate(() => meal.SetHoliday(null));

            //Assert
            Assert.Throws<ArgumentNullException>(sut);
        }

        [Test]
        public void Set_Hardware_Category()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            var HardwareCategory = new HardwareCategory("Grill");

            //Act
            sut.SetHardwareCategory(HardwareCategory);

            //Assert 
            Assert.AreEqual(HardwareCategory.Name, sut.HardwareCategory.Name);
        }

        [Test]
        public void Throw_Domain_Exception_If_Setting_Hardware_Category_To_Null()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();

            //Act
            var testDelegate = new TestDelegate(() => sut.SetHardwareCategory(null));

            //Assert 
            Assert.Throws<DomainException>(testDelegate);
        }
    }
}
