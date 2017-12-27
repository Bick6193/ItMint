$(document).ready(function () {

    // initialise plugin
    $("#phone").intlTelInput({
        utilsScript: "/src/assets/js/utils.js",
        allowDropdown: false,
        nationalMode: false,
        autoHideDialCode: false,
        initialCountry: "auto",
        geoIpLookup: function (callback) {
            $.get('https://ipinfo.io', function () { }, "jsonp").always(function (resp) {
                var countryCode = (resp && resp.country) ? resp.country : "";
                if (countryCode == "Unknown") { countryCode = "US"; }
                callback(countryCode);
            });
        },
        preferredCountries: ["ca", "us"]
    });

    //var reset = function () {
    //    telInput.removeClass("error");
    //    errorMsg.addClass("hide");
    //    validMsg.addClass("hide");
    //};


    //function valid() {
    //    reset();
    //    if ($.trim(telInput.val())) {
    //        if (telInput.intlTelInput("isValidNumber")) {
    //            validMsg.removeClass("hide");
    //        } else {
    //            telInput.addClass("error");
    //            errorMsg.removeClass("hide");
    //        }
    //    }
    //};

    //function valitAtPageLoad() {
    //    var val = telInput.val();
    //    var  plusIndex = val.indexOf("+");
    //    if (val.length > 4 || (plusIndex !== 0 && val.length > 0)) valid();
    //}

    //valitAtPageLoad();

    //// on blur: validate
    //telInput.blur(function () {
    //    valid();
    //});

    //// on keyup / change flag: reset
    //telInput.on("keyup change", reset);
});
