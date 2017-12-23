using MealRoulette.Events;
using MealRoulette.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;

namespace MealRoulette.DataAccess
{
    public class MealRouletteContext : DbContext, IMealRouletteContext
    {
        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealCategory> MealCategories { get; set; }

        public DbSet<EventData> DomainEvents { get; set; }

        public DbSet<UnitOfMeasurement> UnitsOfMeasurement { get; set; }

        public MealRouletteContext(string connectionString) : base(connectionString)
        {
        }

        void IMealRouletteContext.SaveChanges()
        {
            base.SaveChanges();
        }

        async Task IMealRouletteContext.SaveChangesAsync()
        {
            await base.SaveChangesAsync();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }


    }
}
