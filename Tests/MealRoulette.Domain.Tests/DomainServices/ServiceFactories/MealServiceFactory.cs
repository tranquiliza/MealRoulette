using MealRoulette.Domain.Services;
using MealRoulette.Domain.Repositories.Abstractions;
using Moq;

namespace MealRoulette.Domain.Tests.DomainServices.ServiceFactories
{
    internal class MealServiceFactory
    {
        private IIngredientRepository _IngredientRepository;
        private IMealCategoryRepository _MealCategoryRepository;
        private IMealRepository _MealRepository;

        public MealServiceFactory Create()
        {
            _IngredientRepository = null;
            _MealCategoryRepository = null;
            _MealRepository = null;
            return this;
        }

        public MealServiceFactory WithIngredientRepo(IIngredientRepository ingredientRepository)
        {
            _IngredientRepository = ingredientRepository;
            return this;
        }

        public MealServiceFactory WithMealCategoryRepo(IMealCategoryRepository mealCategoryRepository)
        {
            _MealCategoryRepository = mealCategoryRepository;
            return this;
        }

        public MealServiceFactory WithMealRepo(IMealRepository mealRepository)
        {
            _MealRepository = mealRepository;
            return this;
        }

        public MealService Build()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(m => m.IngredientRepository).Returns(_IngredientRepository);
            mock.Setup(m => m.MealCategoryRepository).Returns(_MealCategoryRepository);
            mock.Setup(m => m.MealRepository).Returns(_MealRepository);
            var mealService = new MealService(mock.Object);
            return mealService;
        }
    }
}
