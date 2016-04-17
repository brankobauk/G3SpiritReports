
function ShowInputs(id) {
    $(".Text_" + id).hide();
    $(".Input_" + id).show();
}
function HideInputs(id) {
    $(".Text_" + id).show();
    $(".Input_" + id).hide();
}
function ReloadPage() {
    var date = $("#Date").val();
    var year = $("#Year option:selected").val();
    var countryId = $("#CountryId option:selected").val();

    window.location = "/MonthlyBrandReport?CountryId=" + countryId + "&Date="+date;
}
function FixDate(date)
{
    dateparts = date.split(".");

    return dateparts[2] + '-' + dateparts[1] + '-' + dateparts[0];
}
$(document).ready(function () {
    $(".main-content a").click(function () {
        var id = $(this).attr("href").split("BrandId=")[1];
        ShowInputs(id);
        return false;
    });
    $(".save").click(function () {
        var id = $(this).attr("id").split("Save_")[1];
        var date = $("#Date").val();
        var countryId = $("#CountryId option:selected").val();
        var soldPieces = $("#SoldPieces_" + id).val().trim();
        if (soldPieces == "") {
            soldPieces = 0;
        }
        var data = { CountryId: countryId, Date: FixDate(date), BrandId: id, SoldPieces: soldPieces }
        $.ajax({
            method: "GET",
            cache: false,
            url: "/MonthlyBrandReport/CreateOrEdit",
            data: data,
            success: function (response) {
                location.reload();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(thrownError);
            }
        })

    });
    $(".cancel").click(function () {
        var id = $(this).attr("id").split("Cancel_")[1];
        HideInputs(id);
    });
    $("#Date").change(function () {
        ReloadPage();
    });
    $("#CountryId").change(function () {
        ReloadPage();
    });
    $(".input-number").numeric()


    $('#Date').prop('readOnly', true);
    $("#Date").datepicker({
        dateFormat: 'dd.mm.yy',
        minDate: '1.1.2010',
    });
    jQuery.validator.addMethod(
            'date',
            function (value, element, params) {
                if (this.optional(element)) {
                    return true;
                };
                var result = false;
                try {
                    $.datepicker.parseDate('dd.mm.yy', value);
                    result = true;
                } catch (err) {
                    result = false;
                }
                return result;
            },
            ''
        );
});