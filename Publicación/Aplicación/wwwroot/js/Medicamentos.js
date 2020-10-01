$(document).ready(function () {
    $("#btnGenerate").click(function () {
        ReportManager.GenerateReport();
    });
});

var ReportManager = {
    GenerateReport: function () {
        var jsonParam = "";
        var serviceUrl = "../Medicamento/GetMedicamentoReport";
        ReportManager.GetReport(serviceUrl, jsonParam, onFailed);
        function onFailed(error) {
            alert(error);
        }
    },

    GetReport: function (serviceUrl, JsonParams, errorCallback) {
        jQuery.ajax({
            url: serviceUrl,
            async: false,
            type: "POST",
            data: "{" + JsonParams + "}",
            contentType: "application/json; charset=utf-8",
            success: function () {
                window.open('../Reports/ReportViewer.aspx', '_newtab');
            },
            error: errorCallback
        });
    }
};
var ReportHelper = {


};