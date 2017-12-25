using MealRoulette.Models;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class UnitOfMeasurementConfiguration : EntityTypeConfiguration<UnitOfMeasurement>
    {
        public UnitOfMeasurementConfiguration()
        {
            Property(x => x.Name).HasMaxLength(200);
        }
    }
}
