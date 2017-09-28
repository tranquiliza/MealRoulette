using MealRoulette.Domain.DomainServices.DataContracts;
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
        public void CreateMealWithIngredients()
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

            var mealName = "Pepperoni Pizza";
            var ingredients = CreateIngredientsList();

            //Act
            mealService.CreateMeal(mealName, 1, ingredients);

            //Assert
            Assert.IsNotNull(mealRepo.Get(mealName));
        }

        private List<IngredientType> CreateIngredientsList()
        {
            var ingredients = new List<IngredientType>()
            {
                new IngredientType()
                {
                    Name = "Pepperoni",
                    NameOfUnit = "gram",
                    Amount = 100
                },
                new IngredientType()
                {
                    Name = "Mozzarella Cheese",
                    NameOfUnit = "gram",
                    Amount = 200
                },
                new IngredientType()
                {
                    Name = "Tomato Sauce",
                    NameOfUnit = "decilitres",
                    Amount = 2
                }
            };

            return ingredients;
        }

        [Test]
        public void CreateMeal()
        {
            //Arrange
            var mealRepo = CreateMealRepo();
            var mealCategoryRepo = CreateMealCategoryRepo();

            var mealServiceFactory = new MealServiceFactory().Create()
                .WithMealCategoryRepo(mealCategoryRepo)
                .WithMealRepo(mealRepo);

            var mealService = mealServiceFactory.Build();

            var mealName = "Pepperoni Pizza";

            //Act
            mealService.CreateMeal(mealName, 1);

            //Assert
            Assert.IsNotNull(mealRepo.Get(mealName));
        }

        private IIngredientRepository CreateIngredientRepo()
        {
            var mock = new Mock<IIngredientRepository>();
            return mock.Object;
        }

        private IMealCategoryRepository CreateMealCategoryRepo()
        {
            var mock = new Mock<IMealCategoryRepository>();
            var dinnerCategory = new MealCategory("Dinner");
            mock.Setup(m => m.Get(1)).Returns(dinnerCategory);
            return mock.Object;
        }

        private IMealRepository CreateMealRepo()
        {
            //var mock = new Mock<IMealRepository>();
            //return mock.Object;
            return new TestMealRepo();
        }
    }
}
