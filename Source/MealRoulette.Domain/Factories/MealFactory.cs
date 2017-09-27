using MealRoulette.Domain.Models;

namespace MealRoulette.Domain.Factories
{
    public class MealFactory
    {
        private Meal _Meal;
        //Implement this sort of like how the ServiceFactory in the Test project works?
        private MealFactory(string nameOfMeal, MealCategory mealCategory)
        {
            _Meal = new Meal(nameOfMeal, mealCategory);
        }

        public static MealFactory Create(string nameOfMeal, MealCategory mealCategory)
        {
            return new MealFactory(nameOfMeal, mealCategory);
        }

        public void AddIngredient(string name, string nameOfUnit, int amountInGrams)
        {
            var ingredient = new Ingredient(name, nameOfUnit, amountInGrams);
            _Meal.AddIngredient(ingredient);
        }

        public Meal CreateMeal()
        {
            return _Meal;
        }
    }
}
