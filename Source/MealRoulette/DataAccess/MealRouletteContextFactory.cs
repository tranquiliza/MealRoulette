using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MealRoulette.DataAccess
{
    public class MealRouletteContextFactory : IDbContextFactory<MealRouletteContext>
    {
        private readonly string connectionStringName;

        public MealRouletteContextFactory()
        {
            connectionStringName = "DefaultConnection";
        }

        public MealRouletteContextFactory(string connectionStringName)
        {
            this.connectionStringName = connectionStringName;
        }

        public MealRouletteContext Create()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MealRouletteContext, Migrations.Configuration>());
            var context = new MealRouletteContext(connectionStringName);
            context.Database.Initialize(false);

            return context;
        }
    }
}
