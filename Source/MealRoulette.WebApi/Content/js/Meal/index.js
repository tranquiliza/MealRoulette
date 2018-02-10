var MealViewSettings = {
    pageSize: 5,
    currentPageIndex: 0,
}

$(document).ready(() => {
    function LoadSettingsFromLocalStorage() {
        let savedPageSize = localStorage.getItem("MealViewSettings.pageSize");
        if (savedPageSize !== null) {
            MealViewSettings.pageSize = savedPageSize;
        }
        let savedPageIndex = localStorage.getItem("MealViewSettings.currentPageIndex");
        if (savedPageIndex !== null) {
            MealViewSettings.currentPageIndex = savedPageIndex;
        }
    }
    LoadSettingsFromLocalStorage();
    FetchAndRenderMeals(MealViewSettings.currentPageIndex, MealViewSettings.pageSize);
    SetupPageSizeInput();
})

function SetupPageSizeInput() {

    function SetPageSize(size) {
        localStorage.setItem("MealViewSettings.pageSize", size);
        MealViewSettings.pageSize = size;
        FetchAndRenderMeals(MealViewSettings.currentPageIndex, MealViewSettings.pageSize);
    }

    function SetupPageSizeInputField() {
        let $input = $("#inputPageSize");
        $input.val(MealViewSettings.pageSize);
        $input.change(() => {
            SetPageSize($input.val());
        })
        M.updateTextFields();
    }

    SetupPageSizeInputField();
}

async function FetchAndRenderMeals(pageIndex, pageSize) {

    function FetchMealPageFromApi(pageIndex, pageSize) {
        let queryString = "?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
        let UrlWithQuery = mealRoulette.Settings.mealRouletteApiUrl + "/api/meal" + queryString;
        return $.ajax({
            url: UrlWithQuery,
        }).done(function (result) { return result; })
            .fail(() => {
                window.alert(Labels.lblApiDidNotRespondError + UrlWithQuery)
            })
    }

    //Meal Page is 0 Indexed.
    let response = await FetchMealPageFromApi(pageIndex, pageSize);
    if (response.Meals.length === 0) {
        //User has recieved a page with nothing on it, go backwards until we hit a page with meals on it?
        FetchAndRenderMeals(MealViewSettings.currentPageIndex - 1, MealViewSettings.pageSize);
    }

    function SetAndSavePageIndex(pageIndex) {
        localStorage.setItem("MealViewSettings.currentPageIndex", pageIndex);
        MealViewSettings.currentPageIndex = pageIndex;
    }
    SetAndSavePageIndex(response.PageIndex);

    function AppendResponseToPage(response) {
        let mealsHTML = [];

        response.Meals.forEach(function (meal) {
            let mealHTML = BuildHTMLFor(meal);
            mealsHTML.push(mealHTML);
        })

        let $CollectionsElement = $("#MealsCollection");
        $CollectionsElement.html(mealsHTML);

        let pagination = CreatePaginationElement(response);
        let $container = $("#pagination");
        $container.html(pagination);
    }
    AppendResponseToPage(response);
}

function CreatePaginationElement(response) {
    let ul = document.createElement("ul");
    ul.className = "pagination";

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
    let prevChevron = CreatePreviousChevron(response.HasPreviousPage, response.PageIndex, () => FetchAndRenderMeals(response.PageIndex - 1, MealViewSettings.pageSize));
    ul.appendChild(prevChevron);

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
    for (var buttonIndex = 0; buttonIndex < response.TotalPageCount; buttonIndex++) {
        let button = CreatePaginationButtonFor(buttonIndex, response.PageIndex);
        ul.appendChild(button);
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
    let nextChevron = CreateNextChevron(response.HasNextPage, response.PageIndex, () => FetchAndRenderMeals(response.PageIndex + 1, MealViewSettings.pageSize));
    ul.appendChild(nextChevron);

    return ul;
}

function BuildHTMLFor(meal) {
    function BuildImageElement(meal) {
        let image = document.createElement("img");
        image.src = "http://via.placeholder.com/350x350";
        image.className = "circle";
        image.alt = "TEMPORARY IMAGE";
        return image;
    }
    let Image = BuildImageElement(meal);

    function BuildTitleSpan(meal) {
        let TitleSpan = document.createElement("span");
        TitleSpan.className = "title";
        TitleSpan.innerHTML = meal.Name;
        return TitleSpan;
    }
    let Title = BuildTitleSpan(meal);

    function BuildDescription(meal) {
        let DescriptionParagraph = document.createElement("p");

        let descriptionInnerHtml = meal.CountryOfOrigin + "<br>";
        if (meal.Description !== null) {
            descriptionInnerHtml += meal.Description;
        }
        DescriptionParagraph.innerHTML = descriptionInnerHtml;
        return DescriptionParagraph;
    }
    let Description = BuildDescription(meal);

    function BuildIconForRow(meal) {
        let icon = document.createElement("i");
        icon.className = "material-icons";
        icon.innerHTML = "more";

        let anchor = document.createElement("a");
        anchor.href = mealRoulette.Settings.mealRouletteApiUrl + "Meal/Details/" + meal.Id;
        anchor.className = "secondary-content";
        anchor.appendChild(icon);
        return anchor;
    }
    let SecondaryContent = BuildIconForRow(meal);

    let listElement = document.createElement("li");
    listElement.className = "collection-item avatar hoverable";
    listElement.appendChild(Image);
    listElement.appendChild(Title);
    listElement.appendChild(Description);
    listElement.appendChild(SecondaryContent);
    return listElement;
}