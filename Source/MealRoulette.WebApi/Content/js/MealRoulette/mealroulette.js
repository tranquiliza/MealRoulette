$(document).ready(function () {
    $("#btnRoll").click(function () {
        Roll()
    });
    $("#btnReroll").click(function () {
        Roll()
    });
    HideRerollButton();
    $("#mealCarousel").carousel();
})

async function Roll() {
    HideRollFunction();
    let mealData = await RequestDataFromAPI();
    ClearDomAndAppendHtml(mealData);
    ShowRerollButton();
}

function RequestDataFromAPI() {
    return $.ajax({
        url: MealRouletteSettings.apiUrl + "mealroulette",
    }).done(function (result) {
        return result;
    }).fail(function () {
        window.alert("The API did not respond " + MealRouletteSettings.apiUrl);
        ShowRollFunction();
    });
}

function ClearDomAndAppendHtml(mealData) {
    let cardImage = CreateCardImage("https://picsum.photos/205/300/?random", mealData.Name);
    let cardContent = CreateCardContent(mealData.CountryOfOrigin, mealData.MealCategory.Name);
    let cardActions = CreateCardActions(MealRouletteSettings.ownUrl + "Meal/Details/" + mealData.Id);

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

function CreateCardContent(mealDescription, mealCategory) {
    let cardContent = document.createElement("div");
    cardContent.className = "card-content";

    let cardDescription = document.createElement("p");
    cardDescription.className = "flow-text";
    cardDescription.innerHTML = mealDescription;
    cardContent.appendChild(cardDescription);

    if (mealCategory !== undefined) {
        let somethingAdditional = document.createElement("p");
        somethingAdditional.className = ""
        //somethingAdditional.className = "flow-text";
        somethingAdditional.innerHTML = "Category: " + mealCategory;
        cardContent.appendChild(somethingAdditional);
    }

    return cardContent;
}

function CreateCardActions(mealLink) {
    let cardActions = document.createElement("div");
    cardActions.className = "card-action";

    let cardLink = document.createElement("a");
    cardLink.href = mealLink;
    cardLink.innerHTML = "Click here to see how to cook this meal!";
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

function HideRerollButton() {
    $("#rerollButtonContainer").attr("style", "display:none");
}