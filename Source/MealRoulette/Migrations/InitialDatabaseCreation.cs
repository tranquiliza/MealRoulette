using MealRoulette.DataAccess;
using MealRoulette.Factories;
using MealRoulette.Models;
using System.Collections.Generic;
using System.Linq;

namespace MealRoulette.Migrations
{
    internal static class InitialDatabaseCreation
    {
        internal static void CreateTestData(MealRouletteContext context)
        {
            CreateUnitsOfMeasurement(context);

            CreateHolidays(context);

            CreateIngredients(context);

            CreateMealCategories(context);

            CreateMeals(context);
        }

        private static void CreateMeals(MealRouletteContext context)
        {
            if (DatabaseContainsMeals(context)) return;

            var mealCategories = context.MealCategories.ToList();
            var ingredients = context.Ingredients.ToList();
            var unitsOfMeasurement = context.UnitsOfMeasurement.ToList();

            var danielsPizza = CreatePizza(mealCategories, ingredients, unitsOfMeasurement);
            danielsPizza.SetCountryOfOrigin("Italy");

            var danielsPasta = CreatePasta(mealCategories, ingredients, unitsOfMeasurement);
            danielsPasta.SetCountryOfOrigin("Italy");

            var meals = new List<Meal>()
            {
                danielsPizza,
                danielsPasta
            };

            context.Meals.AddRange(meals);
            context.SaveChanges();
        }

        private static Meal CreatePasta(List<MealCategory> mealCategories, List<Ingredient> ingredients, List<UnitOfMeasurement> unitsOfMeasurement)
        {
            var gram = unitsOfMeasurement.First(x => x.Name == "Gram");
            var mililitre = unitsOfMeasurement.First(x => x.Name == "Millilitre");

            var dinnerCategory = mealCategories.First(x => x.Name == "Dinner");

            var pastaIngredients = new List<MealIngredient>();

            var pasta = ingredients.First(x => x.Name == "Pasta");
            pastaIngredients.Add(new MealIngredient(pasta, 400, gram));

            var water = ingredients.First(x => x.Name == "Water");
            pastaIngredients.Add(new MealIngredient(water, 400, mililitre));

            var oregano = ingredients.First(x => x.Name == "Oregano");
            pastaIngredients.Add(new MealIngredient(oregano, 10, gram));

            return MealFactory.Create("Daniel's Pasta", dinnerCategory, pastaIngredients);
        }

        private static Meal CreatePizza(ICollection<MealCategory> mealCategories, ICollection<Ingredient> ingredients, ICollection<UnitOfMeasurement> unitsOfMeasurement)
        {
            var gram = unitsOfMeasurement.First(x => x.Name == "Gram");
            var dinnerCategory = mealCategories.First(x => x.Name == "Dinner");

            var pizzaIngredients = new List<MealIngredient>();

            var pepperoni = ingredients.First(x => x.Name == "Pepperoni");
            pizzaIngredients.Add(new MealIngredient(pepperoni, 250, gram));

            var mozzarella = ingredients.First(x => x.Name == "Mozzarella");
            pizzaIngredients.Add(new MealIngredient(mozzarella, 250, gram));

            var beef = ingredients.First(x => x.Name == "Beef");
            pizzaIngredients.Add(new MealIngredient(beef, 250, gram));

            var oregano = ingredients.First(x => x.Name == "Oregano");
            pizzaIngredients.Add(new MealIngredient(oregano, 10, gram));


            return MealFactory.Create("Daniel's Pizza", dinnerCategory, pizzaIngredients);
        }

        private static bool DatabaseContainsMeals(MealRouletteContext context)
        {
            return context.Meals.Any();
        }

        private static void CreateMealCategories(MealRouletteContext context)
        {
            if (DatabaseContainsMealCategories(context)) return;

            var mealCategories = new List<MealCategory>()
            {
                new MealCategory("Breakfast"),
                new MealCategory("Lunch"),
                new MealCategory("Dinner"),
                new MealCategory("Snack"),
                new MealCategory("Dessert")
            };

            context.MealCategories.AddRange(mealCategories);
            context.SaveChanges();
        }

        private static bool DatabaseContainsMealCategories(MealRouletteContext context)
        {
            return context.MealCategories.Any();
        }

        private static void CreateIngredients(MealRouletteContext context)
        {
            if (DatabaseContainsIngredients(context)) return;

            var ingredients = new List<Ingredient>()
            {
                new Ingredient("Chicken"),
                new Ingredient("Beef"),
                new Ingredient("Pork"),
                new Ingredient("Potato"),
                new Ingredient("Carrot"),
                new Ingredient("Flour"),
                new Ingredient("Oregano"),
                new Ingredient("Water"),
                new Ingredient("Pepper"),
                new Ingredient("Salt"),
                new Ingredient("Sugar"),
                new Ingredient("Milk"),
                new Ingredient("Mozzarella"),
                new Ingredient("Pasta"),
                new Ingredient("Pepperoni")
            };
            context.Ingredients.AddRange(ingredients);
            context.SaveChanges();
        }

        private static bool DatabaseContainsIngredients(MealRouletteContext context)
        {
            return context.Ingredients.Any();
        }

        private static void CreateHolidays(MealRouletteContext context)
        {
            if (DatabaseContainsHolidays(context)) return;

            var holidays = new List<Holiday>()
            {
                new Holiday("Christmas"),
                new Holiday("Halloween"),
                new Holiday("New Years"),
                new Holiday("Easter")
            };

            context.Holidays.AddRange(holidays);
            context.SaveChanges();
        }

        private static bool DatabaseContainsHolidays(MealRouletteContext context)
        {
            return context.Holidays.Any();
        }

        private static void CreateUnitsOfMeasurement(MealRouletteContext context)
        {
            if (DatabaseContainsUnitsOfMeasurement(context)) return;

            var unitsOfMeasurement = new List<UnitOfMeasurement>()
            {
                new UnitOfMeasurement("Gram"),
                new UnitOfMeasurement("Millilitre")
            };

            context.UnitsOfMeasurement.AddRange(unitsOfMeasurement);
            context.SaveChanges();
        }

        private static bool DatabaseContainsUnitsOfMeasurement(MealRouletteContext context)
        {
            return context.UnitsOfMeasurement.Any();
        }
    }
}
