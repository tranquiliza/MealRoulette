using MealRoulette.Models;
using System.Data.Entity;

namespace MealRoulette.DataAccess
{
    public interface IMealRouletteContext
    {
        DbSet<Holiday> Holidays { get; set; }

        DbSet<Ingredient> Ingredients { get; set; }

        DbSet<Meal> Meals { get; set; }

        DbSet<MealCategory> MealCategories { get; set; }
        
        void SaveChanges();
    }
}
