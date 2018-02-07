$(document).ready(function () {
    $("#btnRoll").click(function () {
        Roll()
    });
    $("#btnReroll").click(function () {
        Roll()
    });
    $("#mealCarousel").carousel();
})

async function Roll() {

    function HideRollFunction() {
        let $RollButton = $("#rollButtonContainer");
        $RollButton.attr("style", "display:none");
    }
    HideRollFunction();

    function ShowRollFunction() {
        let $RollButton = $("#rollButtonContainer");
        $RollButton.attr("style", "");
    }

    function RequestDataFromAPI() {
        return $.ajax({
            url: mealRoulette.Settings.apiUrl + "mealroulette",
        }).done(function (result) {
            return result;
        }).fail(function () {
            window.alert(MealRouletteLabels.lblApiDidNotRespondError + mealRoulette.Settings.apiUrl);
            ShowRollFunction();
        });
    }
    let mealData = await RequestDataFromAPI();

    function ClearDomAndAppendHtml(mealData) {
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
        let cardImage = CreateCardImage("https://picsum.photos/205/300/?random", mealData.Name);

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
        let cardContent = CreateCardContent(mealData.Description, mealData.MealCategory.Name, mealData.CountryOfOrigin);

        function CreateCardActions(mealLink) {
            let cardActions = document.createElement("div");
            cardActions.className = "card-action";

            let cardLink = document.createElement("a");
            cardLink.href = mealLink;
            cardLink.innerHTML = MealRouletteLabels.lblMealRoulleteClickHereToSeeMore;
            cardActions.appendChild(cardLink);

            return cardActions;
        }
        let cardActions = CreateCardActions(mealRoulette.Settings.ownUrl + "Meal/Details/" + mealData.Id);

        function CreateCard(cardImage, cardContent, cardActions) {
            let card = document.createElement("div");
            card.className = "card large hoverable";

            card.appendChild(cardImage);
            card.appendChild(cardContent);
            card.appendChild(cardActions);

            return card;
        }
        let card = CreateCard(cardImage, cardContent, cardActions);

        function CreateRow(card) {
            let row = document.createElement("div");
            row.className = "row";

            let col = document.createElement("div");
            col.className = "col s8 offset-s2"
            col.appendChild(card);
            row.appendChild(col);

            return row;
        }
        let row = CreateRow(card);

        let $container = $("#mealRouletteResultContainer");
        $container.html(row);
    }
    ClearDomAndAppendHtml(mealData);

    function ShowRerollButton() {
        $("#rerollButtonContainer").attr("style", "");
    }
    ShowRerollButton();
}