namespace MealRoulette.Repositories.Abstractions
{
    public interface IUnitOfWork
    {
        IIngredientRepository IngredientRepository { get; }

        IMealRepository MealRepository { get; }
        
        IMealCategoryRepository MealCategoryRepository { get; }

        IHolidayRepository HolidayRepository { get; }

        ISeasonRepository SeasonRepository { get; }

        void SaveChanges();
    }
}
