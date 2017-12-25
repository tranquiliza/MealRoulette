using MealRoulette.Events;
using System.Data.Entity.ModelConfiguration;

namespace MealRoulette.DataAccess.Configuration
{
    internal class EventDataConfiguration : EntityTypeConfiguration<EventData>
    {
        public EventDataConfiguration()
        {
            Property(x => x.EventType).HasMaxLength(300);
        }
    }
}
