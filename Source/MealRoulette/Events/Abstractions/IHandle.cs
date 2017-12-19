namespace MealRoulette.Events.Abstractions
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}
