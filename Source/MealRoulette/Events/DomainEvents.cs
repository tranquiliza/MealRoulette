using MealRoulette.Events.Abstractions;

namespace MealRoulette.Events
{
    public static class DomainEvents
    {
        public static IDomainHandlerContainer Container { get; set; }
        
        public static void Raise<T>(T args) where T : IDomainEvent
        {
            if (Container != null)
            {
                foreach (var eventHandler in Container.ResolveAll<T>())
                {
                    eventHandler.Handle(args);
                }
            }
        }
    }
}
