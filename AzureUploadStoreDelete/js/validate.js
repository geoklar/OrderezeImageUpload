$("document").ready(function () {

    $("#Button1").click(function () {
        if ($("#NameTxt").val() == "") {
            $("label[for='NameTxt']").addClass("form-validation-error");
            return false;
        }
        else
            $("label[for='NameTxt']").removeClass("form-validation-error");
    });

    $("#NameTxt").blur(function () {
        if ($("#NameTxt").val() == "") {
            $("label[for='NameTxt']").addClass("form-validation-error");
            return false;
        }
        else
            $("label[for='NameTxt']").removeClass("form-validation-error");
    });

});