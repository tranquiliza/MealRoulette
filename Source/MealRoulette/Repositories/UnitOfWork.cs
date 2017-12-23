using MealRoulette.DataAccess;
using MealRoulette.Repositories.Abstractions;

namespace MealRoulette.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMealRouletteContext mealRouletteContext;

        public UnitOfWork(IMealRouletteContext mealRouletteContext)
        {
            this.mealRouletteContext = mealRouletteContext;
        }

        IIngredientRepository IUnitOfWork.IngredientRepository => new IngredientRepository(mealRouletteContext);

        IMealRepository IUnitOfWork.MealRepository => new MealRepository(mealRouletteContext);

        IMealCategoryRepository IUnitOfWork.MealCategoryRepository => new MealCategoryRepository(mealRouletteContext);

        IHolidayRepository IUnitOfWork.HolidayRepository => new HolidayRepository(mealRouletteContext);

        IUnitOfMeasurementRepository IUnitOfWork.UnitOfMeasurementRepository => new UnitOfMeasurementRepository(mealRouletteContext);

        void IUnitOfWork.SaveChanges()
        {
            mealRouletteContext.SaveChanges();
        }
    }
}
