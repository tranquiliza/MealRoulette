using MealRoulette.Events.Abstractions;
using SimpleInjector;
using System.Collections.Generic;

namespace MealRoulette.WebApi.App_Start
{
    public class DomainHandlerContainer : IDomainHandlerContainer
    {
        private Container container;

        public DomainHandlerContainer(Container container)
        {
            this.container = container;
        }

        public IEnumerable<IHandle<T>> ResolveAll<T>() where T : IDomainEvent
        {
            return container.GetAllInstances<IHandle<T>>();
        }
    }
}