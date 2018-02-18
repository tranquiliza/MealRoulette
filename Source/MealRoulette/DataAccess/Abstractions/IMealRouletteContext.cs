using MealRoulette.Events;
using MealRoulette.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MealRoulette.DataAccess.Abstractions
{
    public interface IMealRouletteContext
    {
        DbSet<Holiday> Holidays { get; set; }

        DbSet<Ingredient> Ingredients { get; set; }

        DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }

        DbSet<HardwareCategory> HardwareCategories { get; set; }

        DbSet<Meal> Meals { get; set; }

        DbSet<MealCategory> MealCategories { get; set; }

        DbSet<EventData> DomainEvents { get; set; }

        DbSet<Country> Countries { get; set; }

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
