using MealRoulette.Events.Abstractions;

namespace MealRoulette.Events
{
    public class EventHandler : IHandle<RandomMealWasChosenEvent>
    {
        public void Handle(RandomMealWasChosenEvent args)
        {

        }
    }
}
