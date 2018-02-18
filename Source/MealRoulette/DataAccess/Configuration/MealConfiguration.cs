using MealRoulette.Models;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class MealConfiguration : EntityTypeConfiguration<Meal>
    {
        public MealConfiguration()
        {
            Property(x => x.Name).HasMaxLength(200);
            Property(x => x.Recipe).HasMaxLength(3000);
        }
    }
}
