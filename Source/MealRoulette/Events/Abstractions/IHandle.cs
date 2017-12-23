using System.Threading.Tasks;

namespace MealRoulette.Events.Abstractions
{
    public interface IHandle<T> where T : IDomainEvent
    {
        Task Handle(T args);
    }
}
