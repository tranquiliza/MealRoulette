var mealCreateController = new MealCreateController();

$(document).ready(() => {
    mealCreateController.Initialize();
});

function MealCreateController() {

    this.Initialize = function () {
        InitializeCharacterCounterFields();
        InitializeMealsCategoryInputField();
        InitializeIngredientUnitOfMeasurementInputField();
        InitializeIngredientsSearchField();
        InitializeRecipeField();
    }

    function InitializeCharacterCounterFields() {
        $("#txtMealDescription").characterCounter();
    }

    async function InitializeMealsCategoryInputField() {

        let mealCategories = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/mealcategory/"
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        let dropdown = document.querySelector("#mealCategorySelect");
        mealCategories.forEach((mealCategory) => {
            let option = document.createElement("option");
            option.value = mealCategory.Id;
            option.innerText = mealCategory.Name;
            dropdown.append(option);
        })

        M.Select.init(dropdown);
    }

    async function InitializeIngredientUnitOfMeasurementInputField() {

        let units = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/unitofmeasurement"
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        let dropdown = document.querySelector("#mealIngredientUnitOfMeasurementSelect");

        units.forEach((unitOfMeasurement) => {
            let option = document.createElement("option");
            option.value = unitOfMeasurement.Id;
            option.innerText = unitOfMeasurement.Name;
            dropdown.append(option);
        })

        M.Select.init(dropdown);
    }

    async function InitializeIngredientsSearchField() {
        let response = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/Ingredient/"
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        let myData = [];

        response.forEach((ingredient) => {
            myData[ingredient.Name] = null;
        });

        $("#ingredientsSearchBar").autocomplete({
            data: myData
        });
    }

    function InitializeRecipeField() {
        tinymce.init({
            selector: "#mealRecipeInput"
        });
    }
}