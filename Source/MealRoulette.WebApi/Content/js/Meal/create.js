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

        let ingredientsFiltered = this.Ingredients.filter(function (ingredient) {
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
        let txtHardwareCategory = $("#txtHardwareCategory");
        let txtCountryOfOrigin = $("#txtCountryOfOrigin");
        let txtDescription = $("#txtMealDescription");
        let txtRecipe = tinyMCE.activeEditor.getContent();

        let mealHoliday = "";

        meal.Name = txtMealName.val();
        meal.MealCategory = await FetchCategoryFromId(selectMealCategory.val());
        meal.HardwareCategory = txtHardwareCategory.val();
        meal.CountryOfOrigin = txtCountryOfOrigin.val();
        meal.Description = txtDescription.val();
        meal.Recipe = txtRecipe;

        console.log(meal);

        //let result = await PostMealToApi(meal);
    }

    async function FetchCategoryFromId(id) {
        let response = await $.ajax({
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/mealcategory/" + "?Id=" + id
        }).fail(() => { window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRouletteController.Settings.mealRouletteUrl); });

        return response;
    }

    async function PostMealToApi(meal) {
        $.ajax({
            type: "POST",
            url: mealRouletteController.Settings.mealRouletteUrl + "/api/meal",
            data: JSON.stringify(meal),
            contentType: "application/json; charset=utf-8",
            dataType: "json"
        })
        //.done(window.location.replace("/Meal/"));
    }
}