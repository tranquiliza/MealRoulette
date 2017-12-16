using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MealRoulette.Domain.Tests.Services
{
    [TestFixture]
    public class MealRouletteServiceShould
    {
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

            //Assert.AreNotEqual(sut.Name, sut2.Name);
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