using MealRoulette.Events.Abstractions;
using System.Threading.Tasks;

namespace MealRoulette.Events
{
    public static class DomainEvents
    {
        public static IDomainHandlerContainer Container { get; set; }

        public async static Task Raise<T>(T args) where T : IDomainEvent
        {
            await Task.Run(() =>
            {
                if (Container != null)
                {
                    foreach (var eventHandler in Container.ResolveAll<T>())
                    {
                        eventHandler.Handle(args);
                    }
                }
            });
        }
    }
}
