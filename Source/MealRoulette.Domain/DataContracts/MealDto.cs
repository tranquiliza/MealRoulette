using System.Collections.Generic;

namespace MealRoulette.Domain.DataContracts
{
    public class MealDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public bool IsFastFood { get; set; }

        public bool IsVegetarianFriendly { get; set; }

        public string HardwareCategory { get; set; }

        public SeasonDto Season { get; set; } 

        public HolidayDto Holiday { get; set; }

        public string Recipe { get; set; }

        public MealCategoryDto MealCategory { get; set; }

        public List<IngredientDto> Ingredients { get; set; }
    }
}
