﻿using MealRoulette.DataContracts;
using MealRoulette.Models;
using MealRoulette.Repositories.Abstractions;
using MealRoulette.Tests.Services.ServiceFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MealRoulette.Tests.Services
{
    [TestFixture]
    public class MealServiceShould
    {
        [Test]
        public void Create_With_Ingredients()
        {
            //Arrange
            var mealRepo = CreateMealRepo();
            var mealCategoryRepo = CreateMealCategoryRepo();
            var ingredientRepo = CreateIngredientRepo();
            var unitOfMeasurementRepo = CreateUnitOfMeasurementRepository();
            var hardwareCategoryRepository = CreateHardwareCategoryRepositoryWithDefaultCategory();

            var mealService = new MealServiceFactory()
                .WithIngredientRepository(ingredientRepo)
                .WithMealCategoryRepository(mealCategoryRepo)
                .WithMealRepository(mealRepo)
                .WithUnitOfMeasurementRepository(unitOfMeasurementRepo)
                .WithHardwareCategoryRepository(hardwareCategoryRepository)
                .Build();

            var mealName = "Pepperoni Pizza";
            var mealCategory = new MealCategoryDto()
            {
                Id = 1,
                Name = "Lunch"
            };
            var ingredientDtos = CreateMealIngredientDtos();

            //Act
            var sut = new TestDelegate(() => mealService.Create(mealName, mealCategory, ingredientDtos));

            //Assert
            Assert.DoesNotThrow(sut);
        }

        private IEnumerable<MealIngredientDto> CreateMealIngredientDtos()
        {
            var unitOfMeasurement = new UnitOfMeasurementDto()
            {
                Id = 1,
                Name = "Gram"
            };
            var ingredients = new List<MealIngredientDto>()
            {
                new MealIngredientDto()
                {
                    IngredientId = 1,
                    Amount = 100,
                    UnitOfMeasurement = unitOfMeasurement
                },
                new MealIngredientDto()
                {
                    IngredientId = 2,
                    Amount = 500,
                    UnitOfMeasurement = unitOfMeasurement
                },
                new MealIngredientDto()
                {
                    IngredientId = 3,
                    Amount = 500,
                    UnitOfMeasurement = unitOfMeasurement
                }
            };

            return ingredients;
        }

        private IUnitOfMeasurementRepository CreateUnitOfMeasurementRepository()
        {
            var unitOfMeasurement = new UnitOfMeasurement("Gram");
            var mock = new Mock<IUnitOfMeasurementRepository>();
            mock.Setup(x => x.Get(It.IsAny<int>())).Returns(unitOfMeasurement);
            return mock.Object;
        }

        private IIngredientRepository CreateIngredientRepo()
        {
            var ingredients = new List<Ingredient>()
            {
                new Ingredient("Pepperoni"),
                new Ingredient("Mozzarella Cheese"),
                new Ingredient("Tomato Sauce")
            };

            var idCounter = 1;
            foreach (var ingredient in ingredients)
            {
                typeof(BaseEntity).GetProperty("Id").SetValue(ingredient, idCounter);
                idCounter++;
            }

            var mock = new Mock<IIngredientRepository>();
            mock.Setup(x => x.Get(1)).Returns(ingredients.Find(x => x.Id == 1));
            mock.Setup(x => x.Get(2)).Returns(ingredients.Find(x => x.Id == 2));
            mock.Setup(x => x.Get(3)).Returns(ingredients.Find(x => x.Id == 3));
            return mock.Object;
        }

        [Test]
        public void Create_Without_Ingredients()
        {
            //Arrange
            var mealRepo = CreateMealRepo();
            var mealCategoryRepo = CreateMealCategoryRepo();
            var hardwareCategoryRepository = CreateHardwareCategoryRepositoryWithDefaultCategory();

            var mealServiceFactory = new MealServiceFactory()
                .WithMealCategoryRepository(mealCategoryRepo)
                .WithHardwareCategoryRepository(hardwareCategoryRepository)
                .WithMealRepository(mealRepo);

            var mealService = mealServiceFactory.Build();

            var mealName = "Pepperoni Pizza";
            var mealCategory = new MealCategoryDto()
            {
                Id = 1,
                Name = "Dinner"
            };

            //Act
            var sut = new TestDelegate(() => mealService.Create(mealName, mealCategory));

            //Assert
            Assert.DoesNotThrow(sut);
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
            var mock = new Mock<IMealRepository>();
            return mock.Object;
        }

        private IHardwareCategoryRepository CreateHardwareCategoryRepositoryWithDefaultCategory()
        {
            var mock = new Mock<IHardwareCategoryRepository>();
            var defaultCategory = new HardwareCategory("None");
            mock.Setup(m => m.Get("None")).Returns(defaultCategory);
            return mock.Object;
        }
    }
}
