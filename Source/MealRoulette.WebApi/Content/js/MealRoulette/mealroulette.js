$(document).ready(function () {
    let roulette = new Roulette();
    $("#btnRoll").click(function () {
        roulette.Roll()
    });
    $("#btnReroll").click(function () {
        roulette.Roll()
    });
    $("#mealCarousel").carousel();
})

function Roulette() {
    this.Roll = async function () {
        HideRollFunction();
        let mealData = await RequestDataFromAPI();
        ClearDomAndAppendHtml(mealData);
        ShowRerollButton();
    }

    function HideRollFunction() {
        let $RollButton = $("#rollButtonContainer");
        $RollButton.attr("style", "display:none");
    }

    function ShowRollFunction() {
        let $RollButton = $("#rollButtonContainer");
        $RollButton.attr("style", "");
    }

    function ShowRerollButton() {
        $("#rerollButtonContainer").attr("style", "");
    }

    function RequestDataFromAPI() {
        return $.ajax({
            url: mealRoulette.Settings.mealRouletteUrl + "/api/mealroulette",
        }).done(function (result) {
            return result;
        }).fail(function () {
            window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRoulette.Settings.mealRouletteUrl);
            ShowRollFunction();
        });
    }

    function ClearDomAndAppendHtml(mealData) {
        let cardImage = CreateCardImage("https://picsum.photos/205/300/?random", mealData.Name);

        let cardContent = CreateCardContent(mealData.Description, mealData.MealCategory.Name, mealData.CountryOfOrigin);

        let cardActions = CreateCardActions(mealRoulette.Settings.mealRouletteUrl + "Meal/Details/" + mealData.Id);

        let card = CreateCard(cardImage, cardContent, cardActions);

        let row = CreateRow(card);

        let $container = $("#mealRouletteResultContainer");
        $container.html(row);
    }

    function CreateCardImage(imageSource, mealName) {
        let cardImage = document.createElement("div");
        cardImage.className = "card-image";

        let image = document.createElement("img");
        image.src = imageSource;
        cardImage.appendChild(image);

        let cardTitle = document.createElement("span");
        cardTitle.className = "card-title";
        cardTitle.innerHTML = mealName;
        cardImage.appendChild(cardTitle);

        return cardImage;
    }

    function CreateCardContent(mealDescription, mealCategory, mealCountryOfOrigin) {
        let cardContent = document.createElement("div");
        cardContent.className = "card-content";

        let cardDescription = document.createElement("p");
        cardDescription.className = "flow-text";
        cardDescription.innerHTML = mealDescription;
        cardContent.appendChild(cardDescription);

        if (mealCategory !== undefined) {
            let somethingAdditional = document.createElement("p");
            somethingAdditional.innerHTML = "<b>" + MealRouletteLabels.lblMealRouletteMealCategory + ":</b> " + mealCategory;
            cardContent.appendChild(somethingAdditional);
        }

        if (mealCountryOfOrigin !== undefined) {
            let somethingAdditional = document.createElement("p");
            somethingAdditional.innerHTML = "<b>" + MealRouletteLabels.lblMealRoulleteCountryOfOrigin + ":</b> " + mealCountryOfOrigin;
            cardContent.appendChild(somethingAdditional);
        }

        return cardContent;
    }

    function CreateCardActions(mealLink) {
        let cardActions = document.createElement("div");
        cardActions.className = "card-action";

        let cardLink = document.createElement("a");
        cardLink.href = mealLink;
        cardLink.innerHTML = MealRouletteLabels.lblMealRoulleteClickHereToSeeMore;
        cardActions.appendChild(cardLink);

        return cardActions;
    }

    function CreateCard(cardImage, cardContent, cardActions) {
        let card = document.createElement("div");
        card.className = "card large hoverable";

        card.appendChild(cardImage);
        card.appendChild(cardContent);
        card.appendChild(cardActions);

        return card;
    }

    function CreateRow(card) {
        let row = document.createElement("div");
        row.className = "row";

        let col = document.createElement("div");
        col.className = "col s8 offset-s2"
        col.appendChild(card);
        row.appendChild(col);

        return row;
    }
}