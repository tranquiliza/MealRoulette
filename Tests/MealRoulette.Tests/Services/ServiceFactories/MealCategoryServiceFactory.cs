using MealRoulette.Domain.Repositories.Abstractions;
using MealRoulette.Domain.Services;
using MealRoulette.Domain.Services.Abstractions;
using Moq;

namespace MealRoulette.Domain.Tests.Services.Helpers
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
