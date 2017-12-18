using MealRoulette.Events.Abstractions;
using MealRoulette.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.Events
{
    public class EventHandler : IHandle<RandomMealWasChosenEvent>
    {
        public void Handle(RandomMealWasChosenEvent args)
        {

        }
    }

    public class WillAlsoHandleEvent : IHandle<RandomMealWasChosenEvent>
    {
        public void Handle(RandomMealWasChosenEvent args)
        {

        }
    }
}
