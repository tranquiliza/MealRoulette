﻿using MealRoulette.Domain.Models;
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
        public void CreateWithIngredients()
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

        private List<Ingredient> CreateIngredientsList()
        {
            var ingredients = new List<Ingredient>()
            {
                new Ingredient("Pepperoni", "gram", 100),
                new Ingredient("Mozzarella Cheese", "gram", 200),
                new Ingredient("Tomato Sauce","decilitres",2)
            };

            return ingredients;
        }

        private IIngredientRepository CreateIngredientRepo()
        {
            var mock = new Mock<IIngredientRepository>();
            return mock.Object;
        }

        [Test]
        public void Create()
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
