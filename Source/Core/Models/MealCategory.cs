using System.Collections.Generic;

namespace Core.Models
{
    public class MealCategory
    {
        string Name { get; set; }

        IEnumerable<Meal> Meals { get; set; }

        public MealCategory(string name)
        {
            Name = name;
        }
    }
}
