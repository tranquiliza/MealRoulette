using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using Moq;
using System;

namespace MealRoulette.Domain.Tests.Services.ServiceFactories
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
