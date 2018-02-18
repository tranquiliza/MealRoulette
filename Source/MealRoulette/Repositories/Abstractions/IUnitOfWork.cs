namespace MealRoulette.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        IIngredientRepository IngredientRepository { get; }

        IMealRepository MealRepository { get; }

        IMealCategoryRepository MealCategoryRepository { get; }

        IHolidayRepository HolidayRepository { get; }

        IUnitOfMeasurementRepository UnitOfMeasurementRepository { get; }

        IHardwareCategoryRepository HardwareRepository { get; }

        ICountryRepository CountryRepository { get; }

        void SaveChanges();
    }
}
