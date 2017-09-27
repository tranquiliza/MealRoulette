namespace MealRoulette.Domain.Models
{
    public class Ingredient : BaseEntity
    {
        public string Name { get; private set; }
        public string NameOfUnit { get; private set; }
        public int AmountInGrams { get; private set; }

        public Ingredient(string name, string nameOfUnit, int amount)
        {
            Name = name;
            NameOfUnit = nameOfUnit;
            AmountInGrams = amount;
        }
    }
}
