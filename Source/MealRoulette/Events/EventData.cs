using System;

namespace MealRoulette.Events
{
    public class EventData
    {
        public int Id { get; set; }

        public Guid EventIdentifier { get; private set; }

        public string EventType { get; private set; }

        public string Data { get; private set; }

        private EventData() { }

        public EventData(string eventType, string data)
        {
            EventIdentifier = Guid.NewGuid();
            EventType = eventType;
            Data = data;
        }
    }
}
