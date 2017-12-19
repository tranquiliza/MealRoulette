using MealRoulette.Events;
using MealRoulette.Models;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MealRoulette.DataAccess
{
    public interface IMealRouletteContext
    {
        DbSet<Holiday> Holidays { get; set; }

        DbSet<Ingredient> Ingredients { get; set; }

        DbSet<Meal> Meals { get; set; }

        DbSet<MealCategory> MealCategories { get; set; }

        DbSet<EventData> DomainEvents { get; set; }
        
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
