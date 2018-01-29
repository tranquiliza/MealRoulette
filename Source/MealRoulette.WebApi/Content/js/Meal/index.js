var MealViewSettings = {
    pageSize: 10,
    currentPageIndex: 0,
}

$(document).ready(() => {
    //Add logic to load something from cookies or localstorage?
    //To provide a better user experience we could save the preferences the user puts.
    FetchAndRenderMeals(MealViewSettings.currentPageIndex, MealViewSettings.pageSize);
})

function SetPageSize(size) {
    MealViewSettings.pageSize = size;
    FetchAndRenderMeals(MealViewSettings.currentPageIndex, MealViewSettings.pageSize);
}

async function FetchAndRenderMeals(pageIndex, pageSize) {
    //Meal Page is 0Indexed.
    let response = await FetchMealPageFromApi(pageIndex, pageSize);
    MealViewSettings.currentPageIndex = response.PageIndex;
    AppendResponseToPage(response);
}

function FetchMealPageFromApi(pageIndex, pageSize) {
    let queryString = "?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    let UrlWithQuery = MealRouletteSettings.apiUrl + "meal" + queryString;
    return $.ajax({
        url: UrlWithQuery,
    }).done(function (result) { return result; })
        .fail(() => {
            window.alert("API Error " + UrlWithQuery)
        })
}

function AppendResponseToPage(response) {
    let mealsHTML = [];

    response.Meals.forEach(function (meal) {
        meal.Description = "TEMP DESC";
        let mealHTML = BuildHTMLFor(meal);
        mealsHTML.push(mealHTML);
    })

    let pagination = CreatePaginationElement(response);

    ReplaceMealCollectionHTML(mealsHTML);
    ReplacePaginationHTML(pagination);
}

function ReplacePaginationHTML(paginationElement) {
    let $container = $("#pagination");
    $container.html(paginationElement);
}

function CreatePaginationElement(response) {
    let ul = document.createElement("ul");
    ul.className = "pagination";

    let prevChevron = CreatePreviousChevron(response.HasPreviousPage, response.PageIndex, () => FetchAndRenderMeals(response.PageIndex - 1, MealViewSettings.pageSize));
    ul.appendChild(prevChevron);

    for (var buttonIndex = 0; buttonIndex < response.TotalPageCount; buttonIndex++) {
        let button = CreatePaginationButtonFor(buttonIndex, response.PageIndex);
        ul.appendChild(button);
    }

    let nextChevron = CreateNextChevron(response.HasNextPage, response.PageIndex, () => FetchAndRenderMeals(response.PageIndex + 1, MealViewSettings.pageSize));
    ul.appendChild(nextChevron);

    return ul;
}

function CreatePreviousChevron(hasPreviousPage, pageIndex, buttonFunction) {
    let prevChevron = document.createElement("li");
    prevChevron.className = hasPreviousPage ? "waves-effect" : "disabled";
    prevChevron.onclick = hasPreviousPage ? buttonFunction : null;

    let chevronIcon = document.createElement("i");
    chevronIcon.className = "material-icons";
    chevronIcon.innerHTML = "chevron_left";

    let anchor = document.createElement("a");
    anchor.appendChild(chevronIcon);
    prevChevron.appendChild(anchor);
    return prevChevron;
}

function CreatePaginationButtonFor(buttonIndex, currentPageIndex) {
    let isCurrentPageIndex = buttonIndex === currentPageIndex;
    
    let li = document.createElement("li");
    li.className = isCurrentPageIndex ? "active" : "waves-effect";

    let a = document.createElement("a");
    a.innerHTML = buttonIndex + 1;
    a.onclick = isCurrentPageIndex ? null : () => FetchAndRenderMeals(buttonIndex, MealViewSettings.pageSize);

    li.appendChild(a);
    return li;
}

function CreateNextChevron(hasNextPage, pageIndex, buttonFunction) {
    let prevChevron = document.createElement("li");
    prevChevron.className = hasNextPage ? "waves-effect" : "disabled";
    prevChevron.onclick = hasNextPage ? buttonFunction : null;

    let a = document.createElement("a");

    let chevronIcon = document.createElement("i");
    chevronIcon.className = "material-icons";
    chevronIcon.innerHTML = "chevron_right";

    a.appendChild(chevronIcon);
    prevChevron.appendChild(a);
    return prevChevron;
}

function BuildHTMLFor(meal) {
    let Image = BuildImageElement(meal);
    let Title = BuildTitleSpan(meal);
    let Description = BuildDescription(meal);
    let SecondaryContent = BuildIconForRow(meal);

    return CreateListElement(Image, Title, Description, SecondaryContent);
}

function CreateListElement(image, title, description, secondaryContent) {
    let li = document.createElement("li");
    li.className = "collection-item avatar dismissable";
    li.appendChild(image);
    li.appendChild(title);
    li.appendChild(description);
    li.appendChild(secondaryContent);
    return li;
}

function BuildImageElement(meal) {
    let image = document.createElement("img");
    image.src = "http://via.placeholder.com/350x350";
    image.className = "circle";
    image.alt = "TEMPORARY IMAGE";
    return image;
}

function BuildTitleSpan(meal) {
    let TitleSpan = document.createElement("span");
    TitleSpan.className = "title";
    TitleSpan.innerHTML = meal.Name;
    return TitleSpan;
}

function BuildDescription(meal) {
    let DescriptionParagraph = document.createElement("p");

    DescriptionParagraph.innerHTML = meal.Description + "<br>"
        + meal.CountryOfOrigin;

    return DescriptionParagraph;
}

function BuildIconForRow(meal) {
    let icon = document.createElement("i");
    icon.className = "material-icons";
    icon.innerHTML = "more";

    let anchor = document.createElement("a");
    anchor.href = MealRouletteSettings.ownUrl + "Meal/Details/" + meal.Id;
    anchor.className = "secondary-content";
    anchor.appendChild(icon);
    return anchor;
}

function ReplaceMealCollectionHTML(mealsHTML) {
    let $CollectionsElement = $("#MealsCollection");
    $CollectionsElement.html(mealsHTML);
}