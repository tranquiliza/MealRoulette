using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //Act
            var sut = service.RollMeal();

            //Assert
            Assert.IsNotNull(sut);
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