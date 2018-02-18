var mealCreateController = new MealCreateController();

$(document).ready(() => {
    mealCreateController.Initialize();
});

function MealCreateController() {
    "use strict";
    //MealApiModel
    function Meal() {
        this.Name = null;
        this.CountryOfOrigin = null;
        this.HardwareCategory = null;
        this.Holiday = null;
        this.Recipe = null;
        this.Description = null;
        this.MealCategory = null;
        this.MealIngredients = null;
    }

    //HolidayApiModel
    function HolidayApiModel(id, name) {
        this.Id = id;
        this.Name = name;
    }

    //MealCategoryApiModel 
    function MealCategoryApiModel(id, name) {
        this.Id = id;
        this.Name = name;
    }

    //MealIngredientApiModel
    function MealIngredientApiModel(ingredient, amount, unit) {
        this.Ingredient = ingredient;
        this.Amount = amount;
        this.UnitOfMeasurement = unit;
    }
    function UnitOfMeasurementApiModel(id, name) {
        this.Id = id;
        this.Name = name;
    }
    function IngredientApiModel(id, name) {
        this.Id = id;
        this.Name = name;
    }

    let meal = new Meal();

    let Ingredients;

    this.Initialize = function () {
        InitializeCharacterCounterFields();
        InitializeMealsCategoryInputField();
        InitializeIngredientUnitOfMeasurementInputField();
        InitializeIngredientsSearchField();
        InitializeRecipeField();
        InitializeHardwareCategoryInputField();
        InitializeCountryInputField();
        InitializeHolidayInputField();

        $("#btnSubmitMeal").click(() => SubmitMeal());
        $("#btnMealIngredientAddToMeal").click(() => AddIngredientToMeal());
    }

    function GetUnitOfMeasurementBy(id) {
        let response = $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/unitofmeasurement?id=" + id
        })
            .done((data) => { response = data; })
            .fail(() => { throw "api not repsond"; });

        return response;
    }

    async function AddIngredientToMeal() {
        if (meal.MealIngredients === undefined || meal.MealIngredients === null) {
            meal.MealIngredients = [];
        }

        let $selectedIngredient = $("#txtIngredientsSearchBar");
        let $selectedAmount = $("#txtMealIngredientAmount");
        let $selectedUnit = $("#mealIngredientUnitOfMeasurementSelect");

        let ingredientsFiltered = Ingredients.filter(function (ingredient) {
            return ingredient.Name === $selectedIngredient.val();
        })

        let amount = $selectedAmount.val() !== "" ? parseInt($selectedAmount.val()) : ShowError("Please specify amount", "amount was not selected");
        let unitOfMeasurementId = $selectedUnit.val() ? $selectedUnit.val() : ShowError("Please select a Unit of Measurement", "unit was not selected");
        let ingredientToAdd = ingredientsFiltered.length !== 0 ? ingredientsFiltered[0] : ShowError("Please select an ingredient", "ingredient was not selected");

        let unit = await GetUnitOfMeasurementBy(unitOfMeasurementId);

        let mealIngredient = new MealIngredientApiModel(ingredientToAdd, amount, unit)


        let notAdded = true;

        meal.MealIngredients.forEach((ingredientApiModel) => {
            if (ingredientApiModel.Ingredient.Id === ingredientToAdd.Id) {

                if (ingredientApiModel.UnitOfMeasurement.Id !== unit.Id) {
                    throw "User tried to do something stupid?";
                }

                let currentAmount = parseInt(ingredientApiModel.Amount);
                ingredientApiModel.Amount = currentAmount + amount;
                notAdded = false;
                return;
            }
        });

        if (notAdded) {
            meal.MealIngredients.push(mealIngredient);
        }

        $selectedIngredient.val(null);

        M.updateTextFields();

        RenderChosenMealIngredients();
    }

    function ShowError(message, fromElement) {
        window.alert(message);
        throw "error occoured: " + fromElement;
    }

    function RenderChosenMealIngredients() {
        let $container = $("#mealIngredientsCollection");

        let ul = document.createElement("ul");
        ul.className = "collection";

        meal.MealIngredients.forEach((ingredientApiModel) => {
            let icon = document.createElement("i");
            icon.className = "material-icons red-text";
            icon.innerHTML = "delete";

            let action = document.createElement("a");
            action.className = "secondary-content";
            action.href = "#";
            $(action).click(() => { RemoveMealIngredient(ingredientApiModel.Ingredient.Id); })
            action.appendChild(icon);

            let content = document.createElement("div");
            content.innerText = ingredientApiModel.Ingredient.Name + " x " + ingredientApiModel.Amount + " " + ingredientApiModel.UnitOfMeasurement.Name;
            content.appendChild(action);

            let li = document.createElement("li");
            li.className = "collection-item";
            li.appendChild(content);

            ul.append(li);
        })

        $container.html(ul);
    }

    function RemoveMealIngredient(id) {
        for (var i = 0; i < meal.MealIngredients.length; i++) {

            if (meal.MealIngredients[i].Ingredient.Id === id) {
                meal.MealIngredients.splice(i, 1);
            }
        }
        RenderChosenMealIngredients();
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

    async function InitializeHardwareCategoryInputField() {

        let hardwareCategories = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/hardwarecategory/"
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        let first = true;
        let dropdown = document.querySelector("#hardwareCategorySelect");
        hardwareCategories.forEach((hardwareCategory) => {
            let option = document.createElement("option");
            option.value = hardwareCategory.Id;
            option.innerText = hardwareCategory.Name;
            if (first) {
                option.selected = true;
                first = false;
            }

            dropdown.append(option);
        })

        M.Select.init(dropdown);
    }

    async function InitializeCountryInputField() {

        let countries = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/country/"
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        let first = true;
        let dropdown = document.querySelector("#countryOfOriginSelect");
        countries.forEach((country) => {
            let option = document.createElement("option");
            option.value = country.Id;
            option.innerText = country.Name;

            //Add logic to select user's preffered language here. (Need Iso Standards added to the Country Table, See Github https://github.com/tranquiliza/MealRoulette/issues/40);

            dropdown.append(option);
        })

        M.Select.init(dropdown);
    }

    async function InitializeHolidayInputField() {

        let holidays = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/holiday/"
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        let first = true;
        let dropdown = document.querySelector("#holidaySelect");
        holidays.forEach((holiday) => {
            let option = document.createElement("option");
            option.value = holiday.Id;
            option.innerText = holiday.Name;

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

        Ingredients = response;

        response.forEach((ingredient) => {
            myData[ingredient.Name] = null;
        });

        $("#txtIngredientsSearchBar").autocomplete({
            data: myData
        });
    }

    function InitializeRecipeField() {
        tinymce.init({
            selector: "#mealRecipeInput",
            height: 500,
            menubar: false,
            plugins: [
                'advlist autolink lists link image charmap print preview anchor textcolor',
                'searchreplace visualblocks code fullscreen',
                'insertdatetime media table contextmenu paste code help wordcount'
            ],
            toolbar: 'insert | undo redo |  formatselect | bold italic backcolor  | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | removeformat | help'
        });
    }

    async function SubmitMeal() {
        mealRouletteController.ShowLoader();

        //All the inputs.
        let txtMealName = $("#txtMealName");
        let selectMealCategory = $("#mealCategorySelect");
        let selectHardwareCategory = $("#hardwareCategorySelect");
        let selectCountryOfOrigin = $("#countryOfOriginSelect");
        let txtDescription = $("#txtMealDescription");
        let txtRecipe = tinyMCE.activeEditor.getContent();
        let selectHoliday = $("#holidaySelect");

        let isValid = ValidateInputs(txtMealName.val(), selectMealCategory.val());

        if (isValid === false) {
            mealRouletteController.HideLoader();
            return;
        }

        let mealCategoryId = selectMealCategory.val();
        let hardwareCategoryId = selectHardwareCategory.val();
        let countryId = selectCountryOfOrigin.val();
        let holidayId = selectHoliday.val();

        meal.Name = txtMealName.val();
        meal.MealCategory = await FetchCategoryFromId(mealCategoryId);
        meal.HardwareCategory = await FetchHardwareCategoryFromId(hardwareCategoryId);
        meal.CountryOfOrigin = countryId ? await FetchCountryFromId(countryId) : null; //If null, set null otherweise fetch actual object.
        meal.Holiday = holidayId ? await FetchHolidayFromId(holidayId) : null; //If null, set null otherweise fetch actual object.
        meal.Description = txtDescription.val();
        meal.Recipe = txtRecipe;

        PostMealToApi(meal);
    }

    function NavigateToMealOverview() {
        window.location.replace("http://localhost:24171/Meal");
    }

    function ValidateInputs(txtMealName, selectMealCategory) {
        if (txtMealName.length === 0) {
            return false;
        }
        if (selectMealCategory === null) {
            return false;
        }

        return true;
    }

    async function FetchCategoryFromId(id) {
        let response = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/mealcategory/" + "?Id=" + id
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        return response;
    }

    async function FetchHardwareCategoryFromId(id) {
        let response = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/hardwarecategory/" + "?Id=" + id
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        return response;
    }

    async function FetchCountryFromId(id) {
        let response = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/country/" + "?Id=" + id
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        return response;
    }

    async function FetchHolidayFromId(id) {
        let response = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/holiday/" + "?Id=" + id
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        return response;
    }

    function PostMealToApi(meal) {
        $.ajax({
            type: "POST",
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/meal",
            data: JSON.stringify(meal),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () { NavigateToMealOverview() },
            error: function (error) {
                console.log("Api Dead: ");
                console.log(error);
                window.alert(error.statusText);
            }
        });
    }
}