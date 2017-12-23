namespace MealRoulette.DataContracts
{
    public class MealIngredientDto
    {
        public int Amount { get; set; }

        public UnitOfMeasurementDto UnitOfMeasurement { get; set; }

        public int IngredientId { get; set; }
    }
}
