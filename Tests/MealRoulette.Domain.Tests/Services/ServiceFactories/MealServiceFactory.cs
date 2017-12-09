using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using Moq;

namespace MealRoulette.Domain.Tests.Services.ServiceFactories
{
    internal class MealServiceFactory
    {
        private IIngredientRepository _IngredientRepository;
        private IMealCategoryRepository _MealCategoryRepository;
        private IMealRepository _MealRepository;

        internal MealServiceFactory()
        {
            _IngredientRepository = null;
            _MealCategoryRepository = null;
            _MealRepository = null;
        }

        internal MealServiceFactory WithIngredientRepository(IIngredientRepository ingredientRepository)
        {
            _IngredientRepository = ingredientRepository;
            return this;
        }

        internal MealServiceFactory WithMealCategoryRepository(IMealCategoryRepository mealCategoryRepository)
        {
            _MealCategoryRepository = mealCategoryRepository;
            return this;
        }

        internal MealServiceFactory WithMealRepository(IMealRepository mealRepository)
        {
            _MealRepository = mealRepository;
            return this;
        }

        internal IMealService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(m => m.IngredientRepository).Returns(_IngredientRepository);
            unitOfWork.Setup(m => m.MealCategoryRepository).Returns(_MealCategoryRepository);
            unitOfWork.Setup(m => m.MealRepository).Returns(_MealRepository);
            return new MealService(unitOfWork.Object);
        }
    }
}
