using MealRoulette.Repositories.Abstractions;
using MealRoulette.Services;
using MealRoulette.Services.Abstractions;
using Moq;

namespace MealRoulette.Tests.Services.ServiceFactories
{
    internal class MealServiceFactory
    {
        private IIngredientRepository _IngredientRepository;
        private IMealCategoryRepository _MealCategoryRepository;
        private IMealRepository _MealRepository;
        private IUnitOfMeasurementRepository _UnitOfMeasurementRepository;
        private IHardwareCategoryRepository _HardwareCategoryRepository;

        internal MealServiceFactory()
        {
            _IngredientRepository = null;
            _MealCategoryRepository = null;
            _MealRepository = null;
            _UnitOfMeasurementRepository = null;
            _HardwareCategoryRepository = null;
        }

        internal MealServiceFactory WithIngredientRepository(IIngredientRepository ingredientRepository)
        {
            _IngredientRepository = ingredientRepository;
            return this;
        }

        internal MealServiceFactory WithHardwareCategoryRepository(IHardwareCategoryRepository hardwareCategoryRepository)
        {
            _HardwareCategoryRepository = hardwareCategoryRepository;
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

        internal MealServiceFactory WithUnitOfMeasurementRepository(IUnitOfMeasurementRepository unitOfMeasurementRepository)
        {
            _UnitOfMeasurementRepository = unitOfMeasurementRepository;
            return this;
        }

        internal IMealService Build()
        {
            var unitOfWork = new Mock<IUnitOfWork>();
            unitOfWork.Setup(m => m.IngredientRepository).Returns(_IngredientRepository);
            unitOfWork.Setup(m => m.MealCategoryRepository).Returns(_MealCategoryRepository);
            unitOfWork.Setup(m => m.MealRepository).Returns(_MealRepository);
            unitOfWork.Setup(m => m.UnitOfMeasurementRepository).Returns(_UnitOfMeasurementRepository);
            unitOfWork.Setup(m => m.HardwareRepository).Returns(_HardwareCategoryRepository);
            return new MealService(unitOfWork.Object);
        }
    }
}
