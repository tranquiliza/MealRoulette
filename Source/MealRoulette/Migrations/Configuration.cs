using MealRoulette.DataAccess;
using MealRoulette.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;

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
            if (true)
            {
                InitialDatabaseCreation.CreateTestData(context);
            }

          
            base.Seed(context);
        }

       
    }
}
