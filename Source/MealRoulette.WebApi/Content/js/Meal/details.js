var detailsController = new MealDetailsController();

$(document).ready(() => {
    $('#navigationTabs').tabs();
    detailsController.Initialize();
})

MealRoulette.prototype.FetchMealDetailsFromApi = function (mealId) {
    let url = mealRouletteController.Settings.mealRouletteUrl + "/api/meal/" + mealId;

    return $.ajax({
        url: url,
    })
        .done(function (result) { return result; })
        .fail(() => {
            window.alert(MealRouletteLabels.lblApiDidNotRespondError + url)
        })
}

function MealDetailsController() {
    this.Initialize = function () {
        let id = GetMealIdFromUrl();
        LoadDetailsForMeal(id);
    }

    function GetMealIdFromUrl() {
        let id = location.pathname.split('/')[3];
        return id;
    }

    async function LoadDetailsForMeal(mealId) {
        let response = await mealRouletteController.FetchMealDetailsFromApi(mealId);

        AppendMealDetailsToPage(response);

        AppendMealIngredientsToPage(response.MealIngredients);
        CalculateIngredientsForPeople(response.MealIngredients, 10);

        AppendRecipeToPage(response.Recipe);
    }

    function AppendRecipeToPage(recipe) {
        $("#mealRecipeContainer").html(recipe);
    }

    function AppendMealIngredientsToPage(MealIngredients) {
        let container = $("#mealIngredientsContainer");
        MealIngredients.forEach((mealIngredient) => {
            let listItem = document.createElement("li");
            listItem.className = "collection-item";
            listItem.innerHTML = mealIngredient.Ingredient.Name + " : " + mealIngredient.Amount + " " + mealIngredient.UnitOfMeasurement.Name;

            container.append(listItem);
        })
    }

    function CalculateIngredientsForPeople(MealIngredients, AmountOfPeople) {
        let container = $("#mealIngredientsContainerForMultiplePeople");
        MealIngredients.forEach((mealIngredient) => {
            let listItem = document.createElement("li");
            listItem.className = "collection-item";
            listItem.innerHTML = mealIngredient.Ingredient.Name + " : " + mealIngredient.Amount * AmountOfPeople + " " + mealIngredient.UnitOfMeasurement.Name;

            container.append(listItem);
        })
    }

    function AppendMealDetailsToPage(response) {
        $("#mealName").html(response.Name);
        $("#mealDescription").html(response.Description);
        $("#mealCountryOfOrigin").html(response.CountryOfOrigin);
        $("#mealHardwareCategory").html(response.HardwareCategory);
        $("#mealCategory").html(response.MealCategory.Name);

        $("#checkboxMealIsFastFood").attr("checked", response.IsFastFood ? "checked" : undefined);
        $("#checkboxMealIsVegetarionFriendly").attr("checked", response.IsVegetarianFriendly ? "checked" : undefined);
    }
}