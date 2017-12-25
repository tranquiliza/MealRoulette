using MealRoulette.Models;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class MealCategoryConfiguration : EntityTypeConfiguration<MealCategory>
    {
        public MealCategoryConfiguration()
        {
            Property(x => x.Name).HasMaxLength(200);
        }
    }
}
