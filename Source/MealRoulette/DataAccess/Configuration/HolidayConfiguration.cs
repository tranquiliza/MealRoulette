using MealRoulette.Models;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class HolidayConfiguration : EntityTypeConfiguration<Holiday>
    {
        public HolidayConfiguration()
        {
            Property(x => x.Name).HasMaxLength(200);
        }
    }
}
