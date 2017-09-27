namespace MealRoulette.Domain.Models
{
    public class Season : BaseEntity
    {
        public string Name { get; private set; }

        public Season(string name)
        {
            Name = name;
        }
    }
}