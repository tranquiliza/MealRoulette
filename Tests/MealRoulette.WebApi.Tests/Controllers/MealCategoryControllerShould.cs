using MealRoulette.Domain.Models;
using MealRoulette.Domain.Services.Abstractions;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MealRoulette.WebApi.Tests.Controllers
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
            Assert.IsInstanceOf<IEnumerable<MealCategory>>(sut);
            Assert.IsNotNull(sut);
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
                new MealCategory("1"),
                new MealCategory("2"),
                new MealCategory("3"),
                new MealCategory("4")
            };
            return mealCategories;
        }
    }
}
