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
            if (tableId != null) {
                $("#" + tableId).DataTable(settings);
            }
        }
    });
};
function loadComponentView(loadDiv, viewComponentName, module, businessEntityId, model, viewName) {
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
            loadGallery(true, 'a.thumbnail');
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



/**
 *  Image Dialog
 * param setIDs        Sets IDs when DOM is loaded. If using a PHP counter, set to false.
 * param setClickAttr  Sets the attribute for the click handler.
 */
//This function disables buttons when needed
function disableButtons(counter_max, counter_current) {
    if (counter_max == 1) {
        $('#show-next-image').hide();
        $('#show-previous-image').hide();
        return;
    }
    $('#show-previous-image, #show-next-image').show();
    if (counter_max == counter_current) {
        $('#show-next-image').hide();
    } else if (counter_current == 1) {
        $('#show-previous-image').hide();
    }
} 
function loadGallery(setIDs, setClickAttr) { 
    var current_image,
        selector,
        counter = 0;

    $('#show-next-image, #show-previous-image').click(function () {
        if ($(this).attr('id') == 'show-previous-image') {
            current_image--;
        } else {
            current_image++;
        }

        selector = $('[data-image-id="' + current_image + '"]');
        updateGallery(selector);
    });

    function updateGallery(selector) {
        var $sel = selector;
        current_image = $sel.data('image-id');
        $('#image-gallery-caption').text($sel.data('caption'));
        $('#image-gallery-title').text($sel.data('title'));
        $('#image-gallery-image').attr('src', $sel.data('image'));
        disableButtons(counter, $sel.data('image-id'));
    }

    if (setIDs == true) {
        $('[data-image-id]').each(function () {
            counter++;
            $(this).attr('data-image-id', counter);
        });
    }
    $(setClickAttr).on('click', function () {
        updateGallery($(this));
    });
}
//Img Dialog END


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

    $('#image-gallery').find('.modal-body').css({
        width: 'auto', //probably not needed
        height: 'auto', //probably not needed 
        'max-height': '100%'
    });

})(jQuery);
