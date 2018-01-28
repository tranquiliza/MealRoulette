$(document).ready(function () {
    $('.collapsible').collapsible();

    $("#desktopMealNavDropdown").dropdown({
        hover: true,
        constrainWidth: false,
        coverTrigger: false
    });

    $("#mobileNavDropdown").dropdown();

    $('#sideNav').sidenav();

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