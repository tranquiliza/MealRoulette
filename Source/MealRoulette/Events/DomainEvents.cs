using MealRoulette.Events.Abstractions;
using System;
using System.Collections.Generic;

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
