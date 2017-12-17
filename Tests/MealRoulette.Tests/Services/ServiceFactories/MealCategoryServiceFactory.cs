using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;

namespace MealRoulette.Tests.Services.Helpers
{
    internal class MealCategoryServiceFactory
    {
        private IMealCategoryRepository _mealCategoryRepository;

        public MealCategoryServiceFactory()
        {
            _mealCategoryRepository = null;
        }

        internal MealCategoryServiceFactory WithMealCategoryRepository(IMealCategoryRepository mealCategoryRepository)
        {
            _mealCategoryRepository = mealCategoryRepository;
            return this;
        }

        internal IMealCategoryService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(x => x.MealCategoryRepository).Returns(_mealCategoryRepository);

            return new MealCategoryService(unitOfWork.Object);
        }
    }
}
