using MealRoulette.DataAccess;
using MealRoulette.Factories;
using MealRoulette.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MealRoulette.Migrations
{
    internal static class InitialDatabaseCreation
    {
        internal static void CreateTestData(MealRouletteContext context)
        {
            CreateUnitsOfMeasurement(context);

            CreateHardwareCategories(context);

            CreateCountries(context);

            CreateHolidays(context);

            CreateIngredients(context);

            CreateMealCategories(context);

            CreateMeals(context);
        }

        private static void CreateCountries(MealRouletteContext context)
        {
            if (DatabaseContainsCountries(context)) return;

            var countriesInTheWorldString = "Afghanistan,Albania,Algeria,Andorra,Angola,Antigua and Barbuda,Argentina,Armenia,Australia,Austria,Azerbaijan,Bahamas,Bahrain,Bangladesh,Barbados,Belarus,Belgium,Belize,Benin,Bhutan,Bolivia,Bosnia and Herzegovina,Botswana,Brazil,Brunei,Bulgaria,Burkina Faso,Burundi,Cabo Verde,Cambodia,Cameroon,Canada,Central African Republic(CAR),Chad,Chile,China,Colombia,Comoros,Democratic Republic of the Congo,Republic of the Congo,Costa Rica,Cote d'Ivoire,Croatia,Cuba,Cyprus,Czech Republic,Denmark,Djibouti,Dominica,Dominican Republic,Ecuador,Egypt,El Salvador,Equatorial Guinea,Eritrea,Estonia,Ethiopia,Fiji,Finland,France,Gabon,Gambia,Georgia,Germany,Ghana,Greece,Grenada,Guatemala,Guinea,Guinea - Bissau,Guyana,Haiti,Honduras,Hungary,Iceland,India,Indonesia,Iran,Iraq,Ireland,Israel,Italy,Jamaica,Japan,Jordan,Kazakhstan,Kenya,Kiribati,Kosovo,Kuwait,Kyrgyzstan,Laos,Latvia,Lebanon,Lesotho,Liberia,Libya,Liechtenstein,Lithuania,Luxembourg,Macedonia(FYROM),Madagascar,Malawi,Malaysia,Maldives,Mali,Malta,Marshall Islands,Mauritania,Mauritius,Mexico,Micronesia,Moldova,Monaco,Mongolia,Montenegro,Morocco,Mozambique,Myanmar,Namibia,Nauru,Nepal,Netherlands,New Zealand,Nicaragua,Niger,Nigeria,North Korea,Norway,Oman,Pakistan,Palau,Palestine,Panama,Papua New Guinea,Paraguay,Peru,Philippines,Poland,Portugal,Qatar,Romania,Russia,Rwanda,Saint Kitts and Nevis,Saint Lucia,Saint Vincent and the Grenadines,Samoa,San Marino,Sao Tome and Principe,Saudi Arabia,Senegal,Serbia,Seychelles,Sierra Leone,Singapore,Slovakia,Slovenia,Solomon Islands,Somalia,South Africa,South Korea,South Sudan,Spain,Sri Lanka,Sudan,Suriname,Swaziland,Sweden,Switzerland,Syria,Taiwan,Tajikistan,Tanzania,Thailand,Timor - Leste,Togo,Tonga,Trinidad and Tobago,Tunisia,Turkey,Turkmenistan,Tuvalu,Uganda,Ukraine,United Arab Emirates,United Kingdom,United States of America,Uruguay,Uzbekistan,Vanuatu,Vatican City,Venezuela,Vietnam,Yemen,Zambia,Zimbabwe";

            var countries = countriesInTheWorldString.Split(',');

            var countriesToAdd = new List<Country>();
            for (int i = 0; i < countries.Length; i++)
            {
                var country = new Country(countries[i]);
                countriesToAdd.Add(country);
            }

            context.Countries.AddRange(countriesToAdd);
            context.SaveChanges();
        }

        private static bool DatabaseContainsCountries(MealRouletteContext context)
        {
            return context.Countries.Any();
        }

        private static void CreateHardwareCategories(MealRouletteContext context)
        {
            if (DatabaseContainsHardwareCatagories(context)) return;

            const string DefaultHardwareCategoryName = "None";
            var hardwareCategory = new HardwareCategory(DefaultHardwareCategoryName);
            context.HardwareCategories.Add(hardwareCategory);
            context.SaveChanges();
        }

        private static bool DatabaseContainsHardwareCatagories(MealRouletteContext context)
        {
            return context.HardwareCategories.Any();
        }

        private static void CreateMeals(MealRouletteContext context)
        {
            if (DatabaseContainsMeals(context)) return;

            var mealCategories = context.MealCategories.ToList();
            var ingredients = context.Ingredients.ToList();
            var unitsOfMeasurement = context.UnitsOfMeasurement.ToList();
            var defaultHardwareCategory = context.HardwareCategories.FirstOrDefault(x => x.Name == "None");

            var italy = context.Countries.FirstOrDefault(x => x.Name == "Italy");

            var danielsPizza = CreatePizza(mealCategories, defaultHardwareCategory, ingredients, unitsOfMeasurement);
            danielsPizza.SetCountryOfOrigin(italy);

            var danielsPasta = CreatePasta(mealCategories, ingredients, defaultHardwareCategory, unitsOfMeasurement);
            danielsPasta.SetCountryOfOrigin(italy);

            var meals = new List<Meal>()
            {
                danielsPizza,
                danielsPasta
            };

            context.Meals.AddRange(meals);
            context.SaveChanges();
        }

        private static Meal CreatePasta(List<MealCategory> mealCategories, List<Ingredient> ingredients, HardwareCategory hardwareCategory, List<UnitOfMeasurement> unitsOfMeasurement)
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

            return MealFactory.Create("Daniel's Pasta", dinnerCategory, hardwareCategory, pastaIngredients);
        }

        private static Meal CreatePizza(ICollection<MealCategory> mealCategories, HardwareCategory hardwareCategory, ICollection<Ingredient> ingredients, ICollection<UnitOfMeasurement> unitsOfMeasurement)
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


            return MealFactory.Create("Daniel's Pizza", dinnerCategory, hardwareCategory, pizzaIngredients);
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
