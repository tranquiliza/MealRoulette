using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories;
using MealRoulette.Domain.Tests.DomainServices.ServiceFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MealRoulette.Domain.Tests.DomainServices
{
    [TestFixture]
    public class MealServiceShould
    {
        [Test]
        public void CreateMeal()
        {
            //Arrange
            var mealRepo = CreateMealRepo();
            var mealCategoryRepo = CreateMealCategoryRepo();
            var ingredientRepo = CreateIngredientRepo();

            var mealServiceFactory = new MealServiceFactory().Create()
                .WithIngredientRepo(ingredientRepo)
                .WithMealCategoryRepo(mealCategoryRepo)
                .WithMealRepo(mealRepo);

            var mealService = mealServiceFactory.Build();

            var ingredients = new List<int>();

            //Act
            mealService.CreateMeal("SomeName", 1, ingredients);

            //Assert
            Assert.IsNotNull(mealRepo.Get("SomeName"));
        }

        private IIngredientRepository CreateIngredientRepo()
        {
            var mock = new Mock<IIngredientRepository>();
            return mock.Object;
        }

        private IMealCategoryRepository CreateMealCategoryRepo()
        {
            var mock = new Mock<IMealCategoryRepository>();
            mock.Setup(m => m.Get(1)).Returns(It.IsAny<MealCategory>);
            return mock.Object;
        }

        private IMealRepository CreateMealRepo()
        {
            var mock = new Mock<IMealRepository>();
            return mock.Object;
            //return new TestMealRepo();
        }
    }
}
