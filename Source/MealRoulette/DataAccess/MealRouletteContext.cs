using MealRoulette.DataAccess.Abstractions;
using MealRoulette.DataAccess.Configuration;
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

        public DbSet<HardwareCategory> HardwareCategories { get; set; }

        public DbSet<Country> Countries { get; set; }

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
            modelBuilder.Configurations.Add(new EventDataConfiguration());
            modelBuilder.Configurations.Add(new HolidayConfiguration());
            modelBuilder.Configurations.Add(new IngredientConfiguration());
            modelBuilder.Configurations.Add(new MealCategoryConfiguration());
            modelBuilder.Configurations.Add(new MealConfiguration());
            modelBuilder.Configurations.Add(new MealIngredientConfiguration());
            modelBuilder.Configurations.Add(new UnitOfMeasurementConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
