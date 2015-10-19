$("document").ready(function () {

    $('#FileUpload1').bind('change', function () {
        var ext = $(this).val().split('.').pop().toLowerCase();
        if (this.files[0].size > 50000000) {
            alert("Παρακαλώ επιλέξτε αρχεία μικρότερα των 50MB.");
            $(this).val('');
            $("#dataDiv").attr("style", "display:none");
            return false;
        }
        else if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg', 'tiff']) == -1) {
            alert("Παρακαλώ επιλέξτε κάποιο αρχείο εικόνας με format 'gif', 'png', 'jpg', 'jpeg', 'tiff'.");
            $(this).val('');
            $("#dataDiv").attr("style", "display:none");
            return false;
        }
        else {
            if ($(this).val() != "") {
                $("#dataDiv").removeAttr("style");
                $("#NameTxt").val('');
                $("#DescriptionTxt").empty();
            }
            else
                $("#dataDiv").attr("style", "display:none");
        }


    });

});