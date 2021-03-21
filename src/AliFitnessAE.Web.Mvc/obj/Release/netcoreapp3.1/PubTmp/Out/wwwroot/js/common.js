function activeTab(tab) {
    $('.nav-tabs a[href="#' + tab + '"]').tab('show');
}; 
function loadComponentView(loadDiv, viewComponentName, module, businessEntityId) {
    var componentData = {}; 
    componentData.Module = module;
    componentData.BusinessEntityId = businessEntityId;
    componentData.ViewComponentName = viewComponentName; 
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

(function ($) {
})(jQuery);
