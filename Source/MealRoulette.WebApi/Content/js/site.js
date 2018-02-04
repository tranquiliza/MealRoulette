var MealRouletteSettings = {
    apiUrl: "http://localhost:24171/api/",
    ownUrl: "http://localhost:24171/",
    selectedLanguage: null,
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
                option.text = readableText;
                return option;
            }

            let elements = [
                CreateLanguageOptionElementForLanguage("dev", "Development"),
                CreateLanguageOptionElementForLanguage("da-DK", "Danish"),
                //CreateLanguageOptionElementForLanguage("en-GB", "English"),
            ];

            return elements;
        }

        let options = CreateAndSetLanguageSelectElements();
        $languageSelector.html(options);
        $languageSelector.select();
        $languageSelector.change(() => RequestAndReplaceLabelsFor($languageSelector.val()));

        if (MealRouletteSettings.selectedLanguage === null) {
            RequestAndReplaceLabelsFor("dev");
        }
    }
    InitLanguageSelector();
    HideLoader();
});

async function RequestAndReplaceLabelsFor(isoLanguageCode) {
    Labels = await RequestLabelsForLanguageCode(isoLanguageCode);

    for (var i = 0; i < 20000; i++) {
        Labels[i] = i;
    }

    function FindAndReplaceLabels() {
        let regex = /{{(\w+)}}/g;

        function FetchLabel(matchedElement, labelKey) {
            return Labels[labelKey];
        }

        let count = 0;
        $("body *").each(function () {
            let $this = $(this);
            if (!$this.children().length) {
                count++;
                $this.text($this.text().replace(regex, FetchLabel));
            }
        })
        console.log(count);
    }

    FindAndReplaceLabels();
}

function RequestLabelsForLanguageCode(isoCode) {
    return $.ajax({
        url: "/content/languages/" + isoCode + ".json",
    }).done(function (result) {
        return result;
    }).fail(function () {
        window.alert("Unable to retrieve labels from server");
    });
}

function HideLoader() {
    $("#loader").attr("style", "display:none");
    $("#contentWrapper").attr("style", "");
}

function ShowLoader() {
    $("#loader").attr("style", "");
    $("#contentWrapper").attr("style", "display:none");
}