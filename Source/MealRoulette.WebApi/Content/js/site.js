var mealRouletteController = new MealRoulette();

$(document).ready(function () {
    $('.collapsible').collapsible();

    mealRouletteController.ShowCookiesDisclaimer();

    mealRouletteController.HideLoader();
});

function MealRoulette() {
    this.Settings = {
        mealRouletteUrl: "http://localhost:24171"
    }

    this.SupportedLanguageIsoCodes = [
        "dev",
        "da-DK",
        "en-GB"
    ]

    this.ShowCookiesDisclaimer = function () {
        if (UserAcceptsCookies() === false) {
            let cookieModal = document.querySelector("#CookiePopup");
            let cookieModalInstance = M.Modal.init(cookieModal, { dismissible: false });

            $("#btnAcceptCookies").click(() => {
                SaveUserAcceptCookies();
                cookieModalInstance.close();
            })

            cookieModalInstance.open();
        }
    }

    function SaveUserAcceptCookies() {
        localStorage.setItem("UserAcceptCookies", true);
    }

    function UserAcceptsCookies() {
        let savedValue = localStorage.getItem("UserAcceptCookies");
        if (savedValue === null) {
            return false;
        }

        return savedValue;
    }

    async function Construct() {
        let prefferedLanguage = GetPreferedOrDefaultLanguage();

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

    function ClearLocalStorage() {
        localStorage.clear();
    }

    function SetPreferedLanguage(isoCode) {
        localStorage.setItem("mealRoulletteLanguage", isoCode);
    }

    function GetPreferedOrDefaultLanguage() {
        let preferedLanguage = localStorage.getItem("mealRoulletteLanguage");
        if (preferedLanguage !== null) {
            return preferedLanguage;
        }

        let language = window.navigator.userLanguage || window.navigator.language;
        if (IsSupportedLanguage(language)) {
            return language;
        }

        // For now we just return Dev code. In future this will probably be english.
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
            SetPreferedLanguage(isoLanguageCode);
            location.reload();
        }
        $languageSelector.change(() => SetLanguageSettingAndReload($languageSelector.val()));
    }

    function ReplaceLabelKeysWithValues(labels) {

        function FetchLabel(matchedElement, labelKey) {
            if (labels[labelKey] !== undefined) {
                return labels[labelKey];
            }

            return matchedElement;
        }

        let regex = /{{(\w+)}}/g;
        $("body *").each(function () {
            let $this = $(this);
            if (!$this.children().length) {
                $this.text($this.text().replace(regex, FetchLabel));
            }
        })
    }

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