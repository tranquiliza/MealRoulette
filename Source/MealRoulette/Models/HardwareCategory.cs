using MealRoulette.Exceptions;

namespace MealRoulette.Models
{
    public class HardwareCategory : BaseEntity
    {
        public string Name { get; private set; }

        public HardwareCategory(string name)
        {
            Name = name;
        }

        public void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new DomainException("Hardware Category must have a name");

            Name = name;
        }
    }
}
