using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.DomainServices.Interfaces
{
    public interface IIngredientService
    {
        void CreateIngredient(string name, string unitOfMeasurement, int amount);

        void SetUnitOfMeasurement(string unitOfMeasurement, Ingredient ingredient);

        void SetAmount(int amount, Ingredient ingredient);
    }
}
