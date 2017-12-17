using MealRoulette.Events;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MealRoulette.Tests.Services
{
    [TestFixture]
    public class MealRouletteServiceShould
    {
        [Test]
        public void Cause_Meal_Selected_Event()
        {
            //Arrange
            var repository = CreateMealRepositoryWithMeals();
            var service = new MealRouletteServiceFactory()
                .WithMealRepository(repository)
                .Build();

            var domainEventHandler = new DomainEventHandler(service);

            //Act
            var sut = service.RollMeal();

            //Assert

        }

        [Test]
        public void Return_A_Random_Meal()
        {
            //Arrange
            var repository = CreateMealRepositoryWithMeals();
            var service = new MealRouletteServiceFactory()
                .WithMealRepository(repository)
                .Build();
            var service2 = new MealRouletteServiceFactory()
                 .WithMealRepository(repository)
                 .Build();

            //Act
            var sut = service.RollMeal();
            var sut2 = service2.RollMeal();

            //Assert
            Assert.IsNotNull(sut);
            Assert.IsNotNull(sut2);
        }

        private IMealRepository CreateMealRepositoryWithMeals()
        {
            var meals = CreateMeals();
            var mock = new Mock<IMealRepository>();
            mock.Setup(x => x.Get()).Returns(meals);
            return mock.Object;
        }

        private IEnumerable<Meal> CreateMeals()
        {
            var dinnerCategory = new MealCategory("Dinner");
            var desertCategory = new MealCategory("Dessert");

            var meals = new List<Meal>()
            {
                new Meal("Pizza", dinnerCategory),
                new Meal("IceCream", desertCategory),
                new Meal("Pasta", dinnerCategory),
                new Meal("Apple Pie", desertCategory)
            };

            return meals;
        }
    }
}