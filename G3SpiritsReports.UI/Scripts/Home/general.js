﻿$(document).ready(function () {
    $("#tabs").tabs();//.tabs('rotate', 10000);;
    $("#tabs li a").click(function () {
        var countryId = $(this).attr("id");
        var url;
        var date = getParameterByName("date");
        if (date == null)
        {
            date = Date.now();
        }
        if (countryId > 0) {
            url = '/Home/CountryReport?CountryId=' + countryId + '&Date=' + date;
        } else {
            url = '/Home/Report?CountryId=' + countryId;
        }
        var targetDiv = $(this).attr("href");
        $.get(url, null, function (result) {
            $(targetDiv).html(result);
        });
    });
    $("#tabs").find('> ul a:first').trigger("click");
    $('#tabs').tabs('select', 0);
});

function getParameterByName(name) {
    name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}