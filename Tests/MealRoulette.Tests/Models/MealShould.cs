﻿using System;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using NUnit.Framework;

namespace MealRoulette.Tests.Models
{
    [TestFixture]
    public class MealShould
    {
        private const string DefaultHardwareCategory = "None";

        [Test]
        public void Create_With_Default_Values()
        {
            //Arrange
            const string mealName = "MyFirstMeal";

            //Act
            var sut = new Meal(mealName, new MealCategory("Snack"));

            //Assert
            Assert.AreEqual(mealName, sut.Name);
            Assert.AreEqual(DefaultHardwareCategory, sut.HardwareCategory);
        }

        [Test]
        public void Add_Ingredient()
        {
            //Arrange
            var sut = CreateMealWithoutIngredients();
            var ingredient = new Ingredient("Chicken");
            var mealIngredient = new MealIngredient(ingredient, 10, "Grams");

            //Act
            sut.AddMealIngredient(mealIngredient);

            //Assert
            Assert.AreEqual(1, sut.Ingredients.Count);
        }

        private Meal CreateMealWithoutIngredients()
        {
            var meal = new Meal("MyFirstMeal", new MealCategory("Snack"));
            return meal;
        }

        [Test]
        public void Throw_Exception_If_Adding_Same_Ingredient_Twice()
        {
            //Arrange
            var meal = CreateMealWithChicken();
            var duplicateIngredient = new Ingredient("Chicken");
            var mealIngredient = new MealIngredient(duplicateIngredient, 10, "Gram");

            //Act
            TestDelegate sut = delegate { meal.AddMealIngredient(mealIngredient); };

            //Assert
            Assert.Throws<DomainException>(sut);
        }

        private Meal CreateMealWithChicken()
        {
            var ingredient = new Ingredient("Chicken");
            var mealIngredient = new MealIngredient(ingredient, 10, "Gram");
            var meal = new Meal("ThisHasChicken", new MealCategory("Dinner"));

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
            const string HardwareCategory = "Grill";

            //Act
            sut.SetHardwareCategory(HardwareCategory);

            //Assert 
            Assert.AreEqual(HardwareCategory, sut.HardwareCategory);
        }

        [Test]
        public void Set_Hardware_Category_To_Default_If_Empty_String_Is_Given()
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