function activeTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
};
function loadViewComponentUserTracking(model, tableId, settings) {
    $.ajax({
        url: window.location.origin + "/Admin/Home/LoadViewComponentUserTracking",
        type: "post",
        dataType: "json",
        data: model,
        complete: function (result) {
            $("#" + model.loadDiv).html(result.responseText);
            debugger;
            if (tableId != null) { 
                $("#" +tableId).DataTable(settings);
            } 
        }
    });
};
function loadComponentView(loadDiv, viewComponentName, module, businessEntityId, model, viewName) {
    debugger;
    var componentData = {};
    componentData.Module = module;
    componentData.BusinessEntityId = businessEntityId;
    componentData.ViewComponentName = viewComponentName; 
    componentData.ViewName = viewName;
    componentData.SearchModel = model;
    $.ajax({
        url: window.location.origin + "/Admin/Home/LoadViewComponent",
        type: "post",
        dataType: "json",
        data: componentData,
        complete: function (result) {
            $("#" + loadDiv).html(result.responseText);
        }
    });
};
function loadChartComponentView(loadInDiv, filter) {
    var loadInDiv = '#' + loadInDiv;
    abp.ui.setBusy(loadInDiv);

    $.ajax({
        url: window.location.origin + "/Admin/Home/LoadChartViewComponent",
        type: "post",
        dataType: "json",
        data: filter,
        complete: function (result) {
            $(loadInDiv).html(result.responseText);
            abp.ui.clearBusy(loadInDiv);
        }
    });
};
function errorHandler(jqXHR) {
    debugger;
    var json = $.parseJSON(jqXHR.responseText);
    if (json && json.__abp) {
        abp.ajax.handleResponse(json, userOptions, $dfd, jqXHR);
    } else {
        abp.ajax.handleNonAbpErrorResponse(jqXHR, userOptions, $dfd);
    }
};
function getParameterByName(name, url = window.location.href) {
    name = name.replace(/[\[\]]/g, '\\$&');
    var regex = new RegExp('[?&]' + name + '(=([^&#]*)|&|#|$)'),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
}

(function ($) {
    $(document).on('click', '[data-toggle="lightbox"]', function (event) {
        event.preventDefault();
        $(this).ekkoLightbox({
            alwaysShowClose: true
        });
    });
    $('.form-horizontal').attr('autocomplete', 'off');

    //User Tracking Profile - Search FORM
    $("#userTrackingProfileSearchFormUserList").select2({}); //#AddGender
    $('#userTrackingProfileSearchFromDate,#userTrackingProfileSearchToDate,#EditUserDOB,#AddUserDOB').datepicker({
        format: "mm/dd/yyyy",
        clearBtn: true,
        endDate: '+0d'
    });
    $('#AddUserDOB').val('');
})(jQuery);
