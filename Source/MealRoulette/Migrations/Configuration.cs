using System.Data.Entity.Migrations;

namespace MealRoulette.DataAccess.Migrations
{
    public class Configuration : DbMigrationsConfiguration<MealRouletteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;    
        }

        protected override void Seed(MealRouletteContext context)
        {
            base.Seed(context);
        }
    }
}
