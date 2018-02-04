var MealRouletteSettings = {
    apiUrl: "http://localhost:24171/api/",
    ownUrl: "http://localhost:24171/"
}

var Labels = {}

$(document).ready(function () {
    $('.collapsible').collapsible();

    function InitNavigation() {
        $("#desktopMealNavDropdown").dropdown({
            hover: true,
            constrainWidth: false,
            coverTrigger: false
        });
        $("#mobileNavDropdown").dropdown();
        $('#sideNav').sidenav();
        $('#settingsNav').sidenav({
            edge: "right"
        });
    }
    InitNavigation();

    function InitLanguageSelector() {
        let $languageSelector = $("#language-selector");

        function CreateAndSetLanguageSelectElements() {

            function CreateLanguageOptionElementForLanguage(isoCode, readableText) {
                let option = document.createElement("option");
                option.setAttribute("value", isoCode);
                if (isoCode === GetPrefferedLanguage()) {
                    option.setAttribute("selected", "selected");
                }
                option.text = readableText;
                return option;
            }

            let elements = [
                CreateLanguageOptionElementForLanguage("dev", "Development"),
                CreateLanguageOptionElementForLanguage("da-DK", "{{lblLanguageDanish}}"),
                CreateLanguageOptionElementForLanguage("en-GB", "{{lblLanguageEnglish}}"),
            ];

            return elements;
        }

        function SetLanguageSettingAndReload(isoLanguageCode) {
            SetPrefferedLanguage(isoLanguageCode);
            location.reload();
        }

        let options = CreateAndSetLanguageSelectElements();
        $languageSelector.html(options);
        $languageSelector.select();
        $languageSelector.change(() => SetLanguageSettingAndReload($languageSelector.val()));

        if (GetPrefferedLanguage() === null) {
            RequestAndReplaceLabelsFor("dev");
        }
        else {
            RequestAndReplaceLabelsFor(GetPrefferedLanguage());
        }
    }
    InitLanguageSelector();
    HideLoader();
});

function SetPrefferedLanguage(isoCode) {
    localStorage.setItem("mealRoulleteLanguage", isoCode);
}

function GetPrefferedLanguage() {
    let language = window.navigator.userLanguage || window.navigator.language;
    //console.log(language);
    return localStorage.getItem("mealRoulleteLanguage");
}

async function RequestAndReplaceLabelsFor(isoLanguageCode) {
    //console.log("Change language request for code: " + isoLanguageCode);
    function RequestLabelsForLanguageCode(isoCode) {
        return $.ajax({
            url: "/content/languages/" + isoCode + ".json",
        }).done(function (result) {
            return result;
        }).fail(function () {
            window.alert("Unable to retrieve labels from server");
        });
    }
    Labels = await RequestLabelsForLanguageCode(isoLanguageCode);

    function FindAndReplaceLabels() {
        let regex = /{{(\w+)}}/g;

        function FetchLabel(matchedElement, labelKey) {
            if (Labels[labelKey] !== undefined) {
                return Labels[labelKey];
            }

            return matchedElement;
        }

        $("body *").each(function () {
            let $this = $(this);
            if (!$this.children().length) {
                $this.text($this.text().replace(regex, FetchLabel));
            }
        })
    }
    FindAndReplaceLabels();
}

function HideLoader() {
    $("#loader").attr("style", "display:none");
    $("#contentWrapper").attr("style", "");
}

function ShowLoader() {
    $("#loader").attr("style", "");
    $("#contentWrapper").attr("style", "display:none");
}