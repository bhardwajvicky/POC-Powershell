// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function compareHosts() {
    runFlag = true;
    if ($("#hostnameSource").val() === null || $("#hostnameSource").val() === '') {
        alert('Please provide 2008 server details.');
        runFlag = false;
        $("#hostnameSource").focus();
	}
    if (runFlag === true) {
        if ($("#hostnameTarget").val() === null || $("#hostnameTarget").val() === '') {
            alert('Please provide 2016 server details.');
            runFlag = false;
            $("#hostnameTarget").focus();
        }
    }
    if (runFlag === true) {
        if ($("#cmphostPath").val() === null || $("#cmphostPath").val() === '') {
            alert('Please provide folder path details.');
            runFlag = false;
            $("#cmphostPath").focus();
        }
    }

    if (runFlag === true) {
        $("#Host2008").val($("#hostnameSource").val());
        $("#Host2016").val($("#hostnameTarget").val());
        $("#CompareHostPath").val($("#cmphostPath").val());
        $("#compareForm").submit();
	}
}

function fetchHostDetails() {
    if ($("#extractForm").valid() === true) {
        trimHostTextArea();
        $("#extractForm").submit();


        //Force delay of 5 seconds.
        //setTimeout(refreshAllExtractTabs, 5000);
    }
    else {
        //alert("Please provide values for both hostname & path.")
	}
}

function trimHostTextArea() {
    var lines = $("textarea[name=HostCSV]").val().split(/\n/);
    var texts = [];
    for (var i = 0; i < lines.length; i++) {
        if (/\S/.test(lines[i])) {
            texts.push($.trim(lines[i]));
        }
    }
    var n = texts.toString().split(",").join("\n");
    $("textarea[name=HostCSV]").val(n);
}

function refreshAllExtractTabs() {
    getPolicyTabHTML();
    getPackageTabHTML();
    getPermissionTabHTML();
    getCoreRamTabHTML();
    getDiskTabHTML();
    getSericeAccountTabHTML();
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

function getCoreRamTabHTML() {
    $.ajax({
        type: "GET",
        url: "/Home/ExtractCoreAndRAMDetails",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#nav-coreram").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}

function getDiskTabHTML() {
    $.ajax({
        type: "GET",
        url: "/Home/ExtractDiskDetails",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#nav-disk").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}

function getSericeAccountTabHTML() {
    $.ajax({
        type: "GET",
        url: "/Home/ExtractServiceAccountDetails",
        contentType: "application/json",
        dataType: "html",
        success: function (response) {
            $("#nav-serviceaccount").html(response);
            //populate the form elements with the returned data
        },
        failure: function (response) {
            //handle the error
        }
    });
}