using System.Threading.Tasks;
using MealRoulette.DataAccess;
using MealRoulette.Events.Abstractions;
using Newtonsoft.Json;

namespace MealRoulette.Events
{
    public class EventHandler : IHandle<RandomMealWasChosenEvent>
    {
        IMealRouletteContext context;

        public EventHandler()
        {
            var factory = new MealRouletteContextFactory();
            context = factory.Create();
        }

        public async Task Handle(RandomMealWasChosenEvent domainEvent)
        {
            var data = SerializeEvent(domainEvent);
            context.DomainEvents.Add(new EventData(nameof(RandomMealWasChosenEvent), data));
            await context.SaveChangesAsync().ConfigureAwait(false);
        }

        private string SerializeEvent(RandomMealWasChosenEvent domainEvent)
        {
            return JsonConvert.SerializeObject(domainEvent);
        }
    }
}
