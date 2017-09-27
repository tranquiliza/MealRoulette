using System.Collections.Generic;

namespace Core.Models
{
    public class Meat
    {
        public string Name { get; private set; }

        IEnumerable<Meal> Meals { get; set; }

        public Meat(string name)
        {
            Name = name;
        }
    }
}
