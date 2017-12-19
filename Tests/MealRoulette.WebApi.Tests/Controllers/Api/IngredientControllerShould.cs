using MealRoulette.DataStructures;
using MealRoulette.Exceptions;
using MealRoulette.Models;
using MealRoulette.Services.Abstractions;
using MealRoulette.WebApi.Models.Ingredient;
using MealRoulette.WebApi.Tests.Controllers.ControllerFactories;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;

namespace MealRoulette.WebApi.Tests.Controllers
{
    [TestFixture]
    public class IngredientControllerShould
    {

        [Test]
        public void Return_Page_Of_Ingredients_On_Get_Request_With_Parameters()
        {
            //Arrange
            var service = CreateServiceWithIngredients();
            var controller = new IngredientControllerFactory()
                .WithIngredientService(service)
                .Build();

            //Act
            var sut = controller.Get(0, 3);

            //Assert
            Assert.AreEqual(0, sut.PageIndex);
            Assert.AreEqual(3, sut.PageSize);
            Assert.AreEqual(sut.PageSize, sut.Count);
            Assert.AreEqual(6, sut.TotalCount);
            Assert.AreEqual(2, sut.TotalPageCount);
            Assert.IsTrue(sut.HasNextPage);
        }

        [Test]
        public void Return_Ingredients_On_Get_Request()
        {
            //Arrange
            var service = CreateServiceWithIngredients();
            var controller = new IngredientControllerFactory()
                .WithIngredientService(service)
                .Build();

            //Act
            var sut = controller.Get();

            //Assert
            Assert.AreEqual(6, sut.Count());
        }

        private IIngredientService CreateServiceWithIngredients()
        {
            var ingredients = CreateIngredients();

            var pageIndex = 0;
            var pageSize = 3;
            var page = ingredients.OrderBy(x => x.Id).Skip(pageIndex * pageSize).Take(pageSize);
            var ingredientsPage = new Page<Ingredient>(ingredients.Take(3), 0, 3, ingredients.Count());

            var mock = new Mock<IIngredientService>();
            mock.Setup(x => x.Get()).Returns(ingredients);
            mock.Setup(x => x.Get(It.IsAny<int>(), It.IsAny<int>())).Returns(ingredientsPage);
            return mock.Object;
        }

        private IEnumerable<Ingredient> CreateIngredients()
        {
            var result = new List<Ingredient>
            {
                new Ingredient("Pepperoni"),
                new Ingredient("Butter"),
                new Ingredient("Milk"),
                new Ingredient("Water"),
                new Ingredient("Cheese"),
                new Ingredient("Cheddar")
            };
            return result;
        }

        [Test]
        public void Post_With_Null_Argument_Returns_Bad_Request()
        {
            //Arrange
            var service = CreateEmptyIngredientsService();
            var controller = new IngredientControllerFactory()
                .WithIngredientService(service)
                .Build();

            //Act
            var sut = controller.Post(null) as BadRequestResult;

            //Assert 
            Assert.IsNotNull(sut);
        }

        private IIngredientService CreateEmptyIngredientsService()
        {
            var mock = new Mock<IIngredientService>();
            return mock.Object;
        }

        [Test]
        public void Post_With_Valid_Argument_Return_Ok_Result()
        {
            //Arrange
            var service = CreateEmptyIngredientsService();
            var controller = new IngredientControllerFactory()
                .WithIngredientService(service)
                .Build();

            //Act
            var sut = controller.Post(new CreateIngredientApiRequest { Name = "Chicken" }) as OkResult;

            //Assert 
            Assert.IsNotNull(sut);
        }

        [Test]
        public void Return_BadRequestMessageResult_When_Posting_With_Ingredient_That_Already_Exists()
        {
            //Arrange
            var service = CreateServiceThatThrows();
            var controller = new IngredientControllerFactory()
                .WithIngredientService(service)
                .Build();

            //Act
            var sut = controller.Post(new CreateIngredientApiRequest { Name = "Chicken" }) as BadRequestErrorMessageResult;

            //Assert
            Assert.IsNotNull(sut);
            Assert.AreEqual("Ingredient with Chicken, already exists", sut.Message);
        }

        private IIngredientService CreateServiceThatThrows()
        {
            var mock = new Mock<IIngredientService>();
            mock.Setup(x => x.Create("Chicken")).Throws(new DomainException("Ingredient with Chicken, already exists"));
            return mock.Object;
        }
    }
}
