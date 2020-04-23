// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function compareHosts() {
    $("#Host2008").val($("#hostnameSource").val());
    $("#Host2016").val($("#hostnameTarget").val());
    $("#compareForm").submit();
}

function fetchHostDetails() {
    $("#extractForm").submit();

    //initiateExtract();

    //Force delay of 5 seconds.
    setTimeout(refreshAllExtractTabs, 5000);
}

function refreshAllExtractTabs() {
    getPolicyTabHTML();
    getPackageTabHTML();
    getPermissionTabHTML();
}

function refreshCompareResults() {
    $.ajax({
        type: "GET",
        url: "/Home/PartialFetchCompareResults",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#divCompareResult").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}
function initiateExtract() {
    
    var hostnamecsv = $("#hostnamecsv").val();
    var folderPath = $("#hostPath").val();
    var formData = jQuery('#extractForm').serialize();
    $.ajax({
        type: "POST",
        //data: '{HostCSV: "' + hostnamecsv + '",FolderPath: "' + folderPath + '" }',
        data: {
            formdata: formData
        },
        url: "/Home/RunExtract",
        contentType: "application/json; charset=utf-8",
        success: function (response) {
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}

function getPolicyTabHTML() {
    $.ajax({
        type: "GET",
        url: "/Home/ExtractPolicyDetails",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#nav-policies").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}
function getPackageTabHTML() {
    $.ajax({
        type: "GET",
        url: "/Home/ExtractPackageDetails",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#nav-packages").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}

function getPermissionTabHTML() {
    $.ajax({
        type: "GET",
        url: "/Home/ExtractPermissionDetails",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#nav-permission").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}