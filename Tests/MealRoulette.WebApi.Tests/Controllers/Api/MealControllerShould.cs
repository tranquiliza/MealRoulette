﻿using MealRoulette.DataStructures;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.Meal;
using MealRoulette.WebApi.Models.MealCategory;
using MealRoulette.WebApi.Models.MealIngredient;
using MealRoulette.WebApi.Models.UnitOfMeasurement;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace MealRoulette.WebApi.Tests.Controllers.Api
{
    [TestFixture]
    public class MealControllerShould
    {
        [Test]
        public void Post_CreateMeal_Request()
        {
            //Arrange
            var service = CreateEmptyService();
            var controller = new MealControllerFactory()
                .WithMealService(service)
                .WithMapper()
                .Build();
            var request = NewCreateMealRequest(CreateIngredientsForRequest());

            //Act
            var sut = controller.Post(request) as OkResult;

            //Assert 
            Assert.IsNotNull(sut);
        }

        private static List<MealIngredientApiModel> CreateIngredientsForRequest()
        {
            var UnitOfMeasurementModel = new UnitOfMeasurementApiModel()
            {
                Id = 1,
                Name = "Gram"
            };
            return new List<MealIngredientApiModel>()
            {
                new MealIngredientApiModel() { IngredientId = 1, Amount = 20, UnitOfMeasurement = UnitOfMeasurementModel }
            };
        }

        private static CreateMealApiRequest NewCreateMealRequest(List<MealIngredientApiModel> ingredients)
        {
            return new CreateMealApiRequest()
            {
                Name = "My Meal!",
                MealCategory = new MealCategoryApiModel { Id = 1, Name = "SomeNameWeDontUseAnyways????" },
                Ingredients = ingredients
            };
        }

        private IMealService CreateEmptyService()
        {
            var mock = new Mock<IMealService>();
            return mock.Object;
        }

        [Test]
        public void Return_Meals()
        {
            //Arrange
            var service = CreateServiceWithMeals();
            var controller = new MealControllerFactory()
                .WithMealService(service)
                .Build();

            //Act
            var sut = controller.Get();

            //Assert
            Assert.AreEqual(6, sut.Count());
        }

        private IMealService CreateServiceWithMeals()
        {
            var meals = CreateMeals();
            var mock = new Mock<IMealService>();
            mock.Setup(x => x.Get()).Returns(meals);
            return mock.Object;
        }

        private IEnumerable<Meal> CreateMeals()
        {
            var mealCategory = new MealCategory("Dinner");
            var meals = new List<Meal>()
            {
                new Meal("Pizza With Pepperoni", mealCategory),
                new Meal("Pizza With Chicken", mealCategory),
                new Meal("Pizza With Ham", mealCategory),
                new Meal("Chicken Soup", mealCategory),
                new Meal("Pork", mealCategory),
                new Meal("Cheese Burger", mealCategory),
            };
            return meals;
        }

        [Test]
        public void Return_Meal_Page()
        {
            //Arrange
            var service = CreateServiceWithMealPage();
            var controller = new MealControllerFactory()
                .WithMealService(service)
                .Build();

            //Act
            var sut = controller.Get(0, 3);

            //Assert
            Assert.AreEqual(0, sut.PageIndex);
            Assert.AreEqual(3, sut.PageSize);
            Assert.AreEqual(sut.PageSize, sut.Count);
            Assert.AreEqual(6, sut.TotalCount);
            Assert.AreEqual(2, sut.TotalPageCount);
            Assert.IsTrue(sut.HasNextPage);
        }

        private IMealService CreateServiceWithMealPage()
        {
            var page = CreatePageWithMeals();
            var mock = new Mock<IMealService>();
            mock.Setup(x => x.Get(0, 3)).Returns(page);
            return mock.Object;
        }

        private IPage<Meal> CreatePageWithMeals()
        {
            var mealCategory = new MealCategory("Dinner");
            var meals = new List<Meal>()
            {
                new Meal("Pizza With Pepperoni", mealCategory),
                new Meal("Pizza With Chicken", mealCategory),
                new Meal("Pizza With Ham", mealCategory),
                new Meal("Chicken Soup", mealCategory),
                new Meal("Pork", mealCategory),
                new Meal("Cheese Burger", mealCategory),
            };

            var source = meals.OrderBy(x => x.Id).Skip(0 * 3).Take(3);
            var page = new Page<Meal>(source, 0, 3, meals.Count);
            return page;
        }

        [Test]
        public void Return_Meal_With_Given_ID()
        {
            //Arrange
            var service = CreateServiceWithMeal();
            var controller = new MealControllerFactory()
                .WithMealService(service)
                .Build();

            //Act
            var sut = controller.Get(1);

            //Assert 
            Assert.AreEqual(1, sut.Id);
        }

        private IMealService CreateServiceWithMeal()
        {
            var meal = CreateTestMeal();
            var mock = new Mock<IMealService>();
            mock.Setup(x => x.Get(1)).Returns(meal);
            return mock.Object;
        }

        private Meal CreateTestMeal()
        {
            var meal = new Meal("TestMeal", new MealCategory("SomeCategory"));
            typeof(BaseEntity).GetProperty("Id").SetValue(meal, 1);
            return meal;
        }
    }
}