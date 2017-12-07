using MealRoulette.Domain.DataContracts;
using MealRoulette.Domain.Models;
using MealRoulette.Domain.Repositories.Abstractions;
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
        public void Create_With_Ingredients()
        {
            //Arrange
            var mealRepo = CreateMealRepo();
            var mealCategoryRepo = CreateMealCategoryRepo();
            var ingredientRepo = CreateIngredientRepo();

            var mealServiceFactory = new MealServiceFactory()
                .WithIngredientRepo(ingredientRepo)
                .WithMealCategoryRepo(mealCategoryRepo)
                .WithMealRepo(mealRepo);

            var mealService = mealServiceFactory.Build();

            var mealName = "Pepperoni Pizza";
            var mealCategory = new MealCategoryDto()
            {
                Id = 1,
                Name = "Lunch"
            };
            var ingredients = CreateIngredientsList();

            //Act
            mealService.CreateMeal(mealName, mealCategory, ingredients);

            //Assert
            Assert.IsNotNull(mealRepo.Get(mealName));
        }
        
        private List<MealIngredientDto> CreateIngredientsList()
        {
            var ingredients = CreateListOfIngredients();
            var mealIngredients = new List<MealIngredientDto>();
            foreach (var ingredient in ingredients)
            {
                mealIngredients.Add(new MealIngredientDto()
                {
                    IngredientId = ingredient.Id,
                    Amount = 10,
                    UnitOfMeasurement = "Grams"
                });
            }

            return mealIngredients;
        }

        private List<Ingredient> CreateListOfIngredients()
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

            return ingredients;
        }

        private IIngredientRepository CreateIngredientRepo()
        {
            var ingredients = CreateListOfIngredients();
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

            var mealServiceFactory = new MealServiceFactory()
                .WithMealCategoryRepo(mealCategoryRepo)
                .WithMealRepo(mealRepo);

            var mealService = mealServiceFactory.Build();

            var mealName = "Pepperoni Pizza";
            var mealCategory = new MealCategoryDto()
            {
                Id = 1,
                Name = "Dinner"
            };

            //Act
            mealService.CreateMeal(mealName, mealCategory);

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
