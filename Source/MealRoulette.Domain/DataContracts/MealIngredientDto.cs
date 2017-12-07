using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealRoulette.Domain.DataContracts
{
    public class MealIngredientDto
    {
        public int Amount { get; set; }

        public string UnitOfMeasurement { get; set; }

        public int IngredientId { get; set; }
    }
}
