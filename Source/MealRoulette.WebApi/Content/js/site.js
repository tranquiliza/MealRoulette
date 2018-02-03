$(document).ready(function () {
    $('.collapsible').collapsible();

    $("#desktopMealNavDropdown").dropdown({
        hover: true,
        constrainWidth: false,
        coverTrigger: false
    });

    $("#mobileNavDropdown").dropdown();

    $('#sideNav').sidenav();

    let $languageSelector = $('#language-selector');
    let languageOptions = {
        dropdownOptions: {
            "1": "1",
            2: "2",
            3: "3",
            4: "4",
            5: "5"
        }
    }

    let languageSelectorInstance = M.Select.init($languageSelector, languageOptions);
    
    HideLoader();
});

function HideLoader() {
    $("#loader").attr("style", "display:none");
    $("#contentWrapper").attr("style", "");
}

function ShowLoader() {
    $("#loader").attr("style", "");
    $("#contentWrapper").attr("style", "display:none");
}

var MealRouletteSettings = {
    apiUrl: "http://localhost:24171/api/",
    ownUrl: "http://localhost:24171/",
}