using System.Collections.Generic;

namespace MealRoulette.Events.Abstractions
{
    public interface IDomainHandlerContainer
    {
        IEnumerable<IHandle<T>> ResolveAll<T>() where T : IDomainEvent;
    }
}
