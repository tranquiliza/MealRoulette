using MealRoulette.Models;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class IngredientConfiguration : EntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {
            Property(x => x.Name).HasMaxLength(200);
        }
    }
}
