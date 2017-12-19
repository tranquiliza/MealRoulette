using System;

namespace MealRoulette.Events
{
    public class EventData
    {
        public Guid Id { get; private set; }
        
        public string EventType { get; private set; }

        public string Data { get; private set; }

        private EventData() { }

        public EventData(string eventType, string data)
        {
            Id = Guid.NewGuid();
            EventType = eventType;
            Data = data;
        }
    }
}
