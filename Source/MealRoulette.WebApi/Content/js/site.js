var mealRoulette = new MealRoulette();

$(document).ready(function () {
    $('.collapsible').collapsible();

    mealRoulette.HideLoader();
});

function MealRoulette() {
    async function Construct() {
        let prefferedLanguage = GetPrefferedOrDefaultLanguage();

        let labels = await FetchLabelsFor(prefferedLanguage);

        this.MealRouletteLabels = Object.assign({}, labels);

        InitLanguageSelector(prefferedLanguage);

        InitNavigation();

        ReplaceLabelKeysWithValues(labels);
    }

    async function FetchLabelsFor(isoCode) {
        const promise = $.ajax({
            url: "/content/languages/" + isoCode + ".json"
        }).done((result) => { return result; });

        return promise;
    }

    this.Settings = {
        apiUrl: "http://localhost:24171/api/",
        ownUrl: "http://localhost:24171/"
    }

    function ClearLocalStorage() {
        localStorage.clear();
    }

    function SetPrefferedLanguage(isoCode) {
        localStorage.setItem("mealRoulletteLanguage", isoCode);
    }

    function GetPrefferedOrDefaultLanguage() {
        let preferedLanguage = localStorage.getItem("mealRoulletteLanguage");
        if (preferedLanguage !== null) {
            return preferedLanguage;
        }

        let language = window.navigator.userLanguage || window.navigator.language;
        if (IsSupportedLanguage(language)) {
            return language;
        }

        // For now we just return Dev code.
        return "dev";
    }

    function IsSupportedLanguage(isoCode) {
        for (var i = 0; i < this.SupportedLanguageIsoCodes; i++) {
            if (this.SupportedLanguageIsoCodes[i] === isoCode) {
                return true;
            }
        }
        return false;
    }

    this.SupportedLanguageIsoCodes = [
        "dev",
        "da-DK",
        "en-GB"
    ]

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

    function InitLanguageSelector(prefferedLanguage) {
        let $languageSelector = $("#language-selector");

        function CreateLanguageOptionElementForLanguage(isoCode, readableText) {
            let option = document.createElement("option");
            option.setAttribute("value", isoCode);
            if (isoCode === prefferedLanguage) {
                option.setAttribute("selected", "selected");
            }
            option.text = readableText;
            return option;
        }

        let options = [
            CreateLanguageOptionElementForLanguage("dev", "Development"),
            CreateLanguageOptionElementForLanguage("da-DK", "{{lblLanguageDanish}}"),
            CreateLanguageOptionElementForLanguage("en-GB", "{{lblLanguageEnglish}}"),
        ];

        $languageSelector.html(options);
        $languageSelector.select();

        function SetLanguageSettingAndReload(isoLanguageCode) {
            SetPrefferedLanguage(isoLanguageCode);
            location.reload();
        }
        $languageSelector.change(() => SetLanguageSettingAndReload($languageSelector.val()));
    }

    function ReplaceLabelKeysWithValues(labels) {

        let regex = /{{(\w+)}}/g;
        function FetchLabel(matchedElement, labelKey) {
            if (labels[labelKey] !== undefined) {
                return labels[labelKey];
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

    //Call our own constructer cause cool kids do strange things.
    Construct();
}

MealRoulette.prototype.HideLoader = function () {
    $("#loader").attr("style", "display:none");
    $("#contentWrapper").attr("style", "");
}

MealRoulette.prototype.ShowLoader = function () {
    $("#loader").attr("style", "");
    $("#contentWrapper").attr("style", "display:none");
}
