using System;

namespace MealRoulette.Domain.Exceptions
{
    public class DomainException : Exception
    {
        private DomainException() : base()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
