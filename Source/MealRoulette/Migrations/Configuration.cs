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
            if (DatabaseContainsNoUnitsOfMeasurement(context))
            {
                CreateUnitsOfMeasurement(context);
            }

            base.Seed(context);
        }

        private static bool DatabaseContainsNoUnitsOfMeasurement(MealRouletteContext context)
        {
            return context.UnitsOfMeasurement.ToList().Any() == false;
        }

        private void CreateUnitsOfMeasurement(MealRouletteContext context)
        {
            var unitsOfMeasurement = new List<UnitOfMeasurement>()
            {
                new UnitOfMeasurement("Gram"),
                new UnitOfMeasurement("Millilitre")
            };

            context.UnitsOfMeasurement.AddRange(unitsOfMeasurement);
            context.SaveChanges();
        }
    }
}
