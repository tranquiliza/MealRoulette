namespace MealRoulette.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IIngredientRepository IngredientRepository { get; }
        IMealRepository MealRepository { get; }
        IMealCategoryRepository MealCategoryRepository { get; }
        void SaveChanges();
    }
}
