using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace MealRoulette.WebApi.Tests.Controllers.Api
{
    [TestFixture]
    internal class MealCategoryControllerShould
    {
        [Test]
        public void Return_MealCategories()
        {
            //Arrange
            var service = CreateServiceWithAMealCategory();
            var controller = new MealCategoryControllerFactory()
                .WithMealCategoryService(service)
                .Build();

            //Act
            var sut = controller.Get();

            //Assert
            Assert.AreEqual(4, sut.Count());
        }

        private IMealCategoryService CreateServiceWithAMealCategory()
        {
            var mock = new Mock<IMealCategoryService>();
            mock.Setup(x => x.Get()).Returns(CreateMealCategories());
            return mock.Object;
        }

        private IEnumerable<MealCategory> CreateMealCategories()
        {
            var mealCategories = new List<MealCategory>()
            {
                new MealCategory("Dinner"),
                new MealCategory("Lunch"),
                new MealCategory("Breakfast"),
                new MealCategory("Snack")
            };
            return mealCategories;
        }
    }
}
