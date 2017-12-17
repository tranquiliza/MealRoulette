using MealRoulette.DataAccess;
using System.Data.Entity.Migrations;

namespace MealRoulette.Migrations
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
