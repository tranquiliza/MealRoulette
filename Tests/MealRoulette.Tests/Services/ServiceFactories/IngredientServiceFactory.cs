using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;
using System;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class IngredientServiceFactory
    {
        private IIngredientRepository ingredientRepository;

        internal IngredientServiceFactory()
        {
            ingredientRepository = null;
        }

        internal IngredientServiceFactory WithIngredientRepository(IIngredientRepository ingredientRepository)
        {
            this.ingredientRepository = ingredientRepository ?? throw new ArgumentNullException(nameof(ingredientRepository));

            return this;
        }

        internal IIngredientService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.IngredientRepository).Returns(ingredientRepository);

            var service = new IngredientService(unitOfWork.Object);

            return service;
        }
    }
}
