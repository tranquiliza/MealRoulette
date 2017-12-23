using System;

namespace MealRoulette.Events.Abstractions
{
    public interface IDomainEvent
    {
        DateTimeOffset OccouredOn { get; }
    }
}
