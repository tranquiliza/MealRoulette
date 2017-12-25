using MealRoulette.Models;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class MealIngredientConfiguration : EntityTypeConfiguration<MealIngredient>
    {
        public MealIngredientConfiguration()
        {
        }
    }
}
