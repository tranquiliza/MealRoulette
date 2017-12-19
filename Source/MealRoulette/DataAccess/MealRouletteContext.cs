﻿using MealRoulette.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MealRoulette.DataAccess
{
    public class MealRouletteContext : DbContext, IMealRouletteContext
    {
        public DbSet<Holiday> Holidays { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealCategory> MealCategories { get; set; }
        
        public MealRouletteContext(string connectionString) : base(connectionString)
        {
        }
             
        void IMealRouletteContext.SaveChanges()
        {
            base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
