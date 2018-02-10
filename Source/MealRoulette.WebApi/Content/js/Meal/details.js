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
            window.alert(Labels.lblApiDidNotRespondError + url)
        })
}

function MealDetailsController() {
    this.Initialize = function () {
        let id = GetMealIdFromUrl();
        GetDetailsFor(id);
    }

    function GetMealIdFromUrl() {
        let id = location.pathname.split('/')[3];
        return id;
    }

    async function GetDetailsFor(mealId) {
        let response = await mealRouletteController.FetchMealDetailsFromApi(mealId);
    }

    function BuildHtmlFor(meal) {

    }

    function ReplaceHtmlOnPage() {

    }
}