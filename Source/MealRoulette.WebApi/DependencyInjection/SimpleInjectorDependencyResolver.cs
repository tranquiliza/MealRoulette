using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;

namespace MealRoulette.WebApi.DependencyInjection
{
    public class SimpleInjectorDependencyResolver : IDependencyResolver
    {
        private readonly Container container;

        public SimpleInjectorDependencyResolver(Container container)
        {
            this.container = container ?? throw new ArgumentNullException(nameof(container));
        }
        
        public IDependencyScope BeginScope()
        {
            return this;
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            IServiceProvider provider = this.container;
            return provider.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            IServiceProvider provider = this.container;
            Type collectionType = typeof(IEnumerable<>).MakeGenericType(serviceType);
            var services = (IEnumerable<object>)provider.GetService(collectionType);
            return services ?? Enumerable.Empty<object>();
        }
        
        
    }
}