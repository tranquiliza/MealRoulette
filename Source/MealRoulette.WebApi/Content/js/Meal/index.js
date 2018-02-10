var MealViewSettings = {
    pageSize: 5,
    currentPageIndex: 0
};

$(document).ready(() => {
    mealRoulette.LoadSettingsFromLocalStorage();

    let pageIndex = MealViewSettings.currentPageIndex;
    let pageSize = MealViewSettings.pageSize;

    mealRoulette.FetchAndRenderMeals(pageIndex, pageSize);
    mealRoulette.SetupPageSizeInput(pageIndex, pageSize);
})

MealRoulette.prototype.LoadSettingsFromLocalStorage = function () {
    let savedPageSize = localStorage.getItem("MealViewSettings.pageSize");
    if (savedPageSize !== null) {
        MealViewSettings.pageSize = savedPageSize;
    }
    let savedPageIndex = localStorage.getItem("MealViewSettings.currentPageIndex");
    if (savedPageIndex !== null) {
        MealViewSettings.currentPageIndex = savedPageIndex;
    }
}

MealRoulette.prototype.FetchMealPageFromApi = function (pageIndex, pageSize) {
    let queryString = "?pageIndex=" + pageIndex + "&pageSize=" + pageSize;
    let UrlWithQuery = mealRoulette.Settings.mealRouletteApiUrl + "/api/meal" + queryString;

    return $.ajax({
        url: UrlWithQuery,
    }).done(function (result) { return result; })
        .fail(() => {
            window.alert(Labels.lblApiDidNotRespondError + UrlWithQuery)
        })
}

MealRoulette.prototype.SetupPageSizeInput = function (pageIndex, pageSize) {
    SetPageSize = function (pageSize) {
        mealRoulette.SavePageSizeSetting(pageSize);
        FetchAndRenderMeals(MealViewSettings.currentPageIndex, pageSize);
    }

    let $input = $("#inputPageSize");
    $input.val(MealViewSettings.pageSize);
    $input.change(() => {
        SetPageSize($input.val());
    })
    M.updateTextFields();
}

MealRoulette.prototype.SavePageSizeSetting = function (pageSize) {
    localStorage.setItem("MealViewSettings.pageSize", pageSize);
    MealViewSettings.pageSize = pageSize;
}

MealRoulette.prototype.SavePageIndexSettings = function (pageIndex) {
    localStorage.setItem("MealViewSettings.currentPageIndex", pageIndex);
    MealViewSettings.currentPageIndex = pageIndex;
}

MealRoulette.prototype.FetchAndRenderMeals = async function (pageIndex, pageSize) {
    let response = await mealRoulette.FetchMealPageFromApi(pageIndex, pageSize);

    if (response.Meals.length === 0) {
        FetchAndRenderMeals(MealViewSettings.currentPageIndex - 1, MealViewSettings.pageSize);
    }

    mealRoulette.SavePageIndexSettings(response.PageIndex);

    let htmlBuilder = new HtmlBuilder();
    let mealsHTML = htmlBuilder.MealHtmlBuilder(response.Meals);

    let $CollectionsElement = $("#MealsCollection");
    $CollectionsElement.html(mealsHTML);

    let pagination = htmlBuilder.CreatePaginationElement(response, mealRoulette);
    let $paginationContainer = $("#pagination");
    $paginationContainer.html(pagination);
}

function HtmlBuilder() {

    this.MealHtmlBuilder = function (meals) {
        let result = [];
        meals.forEach(function (meal) {
            result.push(BuildHtmlFor(meal));
        })

        return result;
    }

    BuildHtmlFor = function (meal) {
        let Image = BuildImageElement(meal);
        let Title = BuildTitleSpan(meal);
        let Description = BuildDescription(meal);
        let SecondaryContent = BuildIconForRow(meal);

        let listElement = document.createElement("li");
        listElement.className = "collection-item avatar hoverable";
        listElement.appendChild(Image);
        listElement.appendChild(Title);
        listElement.appendChild(Description);
        listElement.appendChild(SecondaryContent);
        return listElement;
    }

    BuildImageElement = function (meal) {
        let image = document.createElement("img");
        image.src = "http://via.placeholder.com/350x350";
        image.className = "circle";
        image.alt = "TEMPORARY IMAGE";
        return image;
    }

    BuildTitleSpan = function (meal) {
        let TitleSpan = document.createElement("span");
        TitleSpan.className = "title";
        TitleSpan.innerHTML = meal.Name;
        return TitleSpan;
    }

    BuildDescription = function (meal) {
        let DescriptionParagraph = document.createElement("p");

        let descriptionInnerHtml = meal.CountryOfOrigin + "<br>";
        if (meal.Description !== null) {
            descriptionInnerHtml += meal.Description;
        }
        DescriptionParagraph.innerHTML = descriptionInnerHtml;
        return DescriptionParagraph;
    }

    BuildIconForRow = function (meal) {
        let icon = document.createElement("i");
        icon.className = "material-icons";
        icon.innerHTML = "more";

        let anchor = document.createElement("a");
        anchor.href = mealRoulette.Settings.mealRouletteApiUrl + "Meal/Details/" + meal.Id;
        anchor.className = "secondary-content";
        anchor.appendChild(icon);
        return anchor;
    }

    this.CreatePaginationElement = function (response, mealRoulette) {
        let ul = document.createElement("ul");
        ul.className = "pagination";

        let prevChevron = CreatePreviousChevron(response.HasPreviousPage, response.PageIndex, () => mealRoulette.FetchAndRenderMeals(response.PageIndex - 1, MealViewSettings.pageSize));
        ul.appendChild(prevChevron);

        for (var buttonIndex = 0; buttonIndex < response.TotalPageCount; buttonIndex++) {
            let button = CreatePaginationButtonFor(buttonIndex, response.PageIndex, mealRoulette);
            ul.appendChild(button);
        }

        let nextChevron = CreateNextChevron(response.HasNextPage, response.PageIndex, () => mealRoulette.FetchAndRenderMeals(response.PageIndex + 1, MealViewSettings.pageSize));
        ul.appendChild(nextChevron);

        return ul;
    }

    CreatePreviousChevron = function (hasPreviousPage, pageIndex, buttonFunction) {
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

    CreatePaginationButtonFor = function (buttonIndex, currentPageIndex, mealRoulette) {
        let isCurrentPageIndex = buttonIndex === currentPageIndex;

        let li = document.createElement("li");
        li.className = isCurrentPageIndex ? "active" : "waves-effect";

        let a = document.createElement("a");
        a.innerHTML = buttonIndex + 1;
        a.onclick = isCurrentPageIndex ? null : () => mealRoulette.FetchAndRenderMeals(buttonIndex, MealViewSettings.pageSize);

        li.appendChild(a);
        return li;
    }

    CreateNextChevron = function (hasNextPage, pageIndex, buttonFunction) {
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
}