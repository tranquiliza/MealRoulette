using MealRoulette.Models;
using System.Data.Entity;

namespace MealRoulette.DataAccess
{
    public interface IMealRouletteContext
    {
        DbSet<Holiday> Holidays { get; }

        DbSet<Ingredient> Ingredients { get; }

        DbSet<Meal> Meals { get; }

        DbSet<MealCategory> MealCategories { get; }

        DbSet<Season> Seasons { get; }
    }
}
