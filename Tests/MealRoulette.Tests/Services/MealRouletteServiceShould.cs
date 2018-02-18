using MealRoulette.Events;
using MealRoulette.Events.Abstractions;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MealRoulette.Tests.Services
{
    [TestFixture]
    public class MealRouletteServiceShould
    {
        [Test]
        public async Task Raise_RandomMealWasChosenEvent()
        {
            //Arrange
            var repository = CreateAsyncMealRepositoryWithMeals();
            var service = new MealRouletteServiceFactory()
                .WithMealRepository(repository)
                .Build();

            var eventHappened = false;
            var handler = CreateHandler(() => eventHappened = true);
            DomainEvents.Container = CreateContainer(handler);

            //Act
            var sut = await service.RollMealAsync();

            //Assert
            Assert.IsTrue(eventHappened);
        }

        private IMealRepository CreateAsyncMealRepositoryWithMeals()
        {
            var meals = CreateMealsAsync();
            var mock = new Mock<IMealRepository>();
            mock.Setup(x => x.GetAsync()).Returns(meals);
            return mock.Object;
        }

        private async Task<IEnumerable<Meal>> CreateMealsAsync()
        {
            var dinnerCategory = new MealCategory("Dinner");
            var dessertCategory = new MealCategory("Dessert");
            var defaultHardwareCategory = new HardwareCategory("None");


            var meals = new List<Meal>()
            {
                new Meal("Pizza", dinnerCategory,defaultHardwareCategory),
                new Meal("IceCream", dessertCategory,defaultHardwareCategory),
                new Meal("Pasta", dinnerCategory,defaultHardwareCategory),
                new Meal("Apple Pie", dessertCategory,defaultHardwareCategory)
            };

            return await Task.FromResult<IEnumerable<Meal>>(meals);
        }
        private IHandle<RandomMealWasChosenEvent> CreateHandler(Action action)
        {
            var mock = new Mock<IHandle<RandomMealWasChosenEvent>>();
            mock.Setup(x => x.Handle(It.IsAny<RandomMealWasChosenEvent>())).Callback(action);
            return mock.Object;
        }

        private IDomainHandlerContainer CreateContainer(IHandle<RandomMealWasChosenEvent> handler)
        {
            var handlers = new List<IHandle<RandomMealWasChosenEvent>>()
            {
                handler
            };
            var mock = new Mock<IDomainHandlerContainer>();
            mock.Setup(x => x.ResolveAll<RandomMealWasChosenEvent>()).Returns(handlers);
            return mock.Object;
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
            var sut = service.RollMealAsync();
            var sut2 = service2.RollMealAsync();

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
            var dessertCategory = new MealCategory("Dessert");
            var defaultHardwareCategory = new HardwareCategory("None");

            var meals = new List<Meal>()
            {
                new Meal("Pizza", dinnerCategory,defaultHardwareCategory),
                new Meal("IceCream", dessertCategory,defaultHardwareCategory),
                new Meal("Pasta", dinnerCategory,defaultHardwareCategory),
                new Meal("Apple Pie", dessertCategory,defaultHardwareCategory)
            };

            return meals;
        }
    }
}