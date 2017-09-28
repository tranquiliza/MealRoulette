using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
