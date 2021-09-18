(function ($) {
    _photoTrackingService = abp.services.app.photoTracking,
        l = abp.localization.getSource('AliFitnessAE'),
        _$searchForm = $('#UserTrackingSearchForm'),
        _$divPhotoTrackingList = $('#divPhotoTrackingList');

    $('.btn-search').on('click', (e) => {
        var filter = _$searchForm.serializeFormToObject(true);
        filter.userId = filter.searchFormUserList; 
        filter.isApproved = getParameterByName('isApproved');  
        loadComponentView("divPhotoTrackingList", "PhotoTracking", "PhotoTracking", null, filter, "_Default");
    });

    $("#SearchFormUserList").select2({
    });
    $('#SearchFromDate,#SearchToDate').datepicker({
        format: "mm/dd/yyyy",
        clearBtn: true,
        endDate: '+0d'
    });

    //Photo Tracking
    $(document).on('click', '#hrefPhotoTrackingCreate', function (e) {
        LoadPhotoTrackingModel(null);
    });
    $(document).on('click', '.hrefPhotoTrackingEdit', function (e) { 
        var id = $(this).attr('data-id');
        LoadPhotoTrackingModel(id);
    });
    function LoadPhotoTrackingModel(id) {
        abp.ui.setBusy(_$divPhotoTrackingList);
        abp.ajax({
            url: abp.appPath + 'Admin/userTracking/CreatePhotoTrackingModal',
            type: 'GET',
            dataType: 'html',
        }).done(function (data) { 
            $('#divCreatePhotoTrackingModal').html(data); 
            $('#PhotoTrackingCreateModal').modal('show');
            $('#photoTrackingId').val(id);
        }).fail(function (jqXHR) {
            errorHandler(jqXHR);
        }).always(function () {
            abp.ui.clearBusy(_$divPhotoTrackingList);
        });
    } 
    $(document).on('shown.bs.modal', '#PhotoTrackingCreateModal', function () { 
        var photoTracking = {};
        photoTracking.userId = abp.session.userId;
        var photoTrackingId = $('#photoTrackingId').val();
        if (photoTrackingId == "" || photoTrackingId == null || photoTrackingId == undefined) {
            //Create PhotoTracking record
            _photoTrackingService
                .createPhotoTracking(photoTracking)
                .done(function (data) {
                    $('#photoTrackingId').val(data.id);
                    loadComponentView("create-tracking-photo", "DocumentUploader", "PhotoTracking", data.id);// moment.utc().format('YYYY-MM-DD HH:mm:ss')
                });
        }
        else {
            loadComponentView("create-tracking-photo", "DocumentUploader", "PhotoTracking", photoTrackingId);// moment.utc().format('YYYY-MM-DD HH:mm:ss')
        }
    }).on('hidden.bs.modal', '#PhotoTrackingCreateModal', () => {
        //Delete PhotoTracking record if now document found
        var photoTrackingId = $('#photoTrackingId').val();
        abp.ajax({
            url: abp.appPath + 'Admin/userTracking/DeletePhotoTracking?id=' + photoTrackingId,
            type: 'POST',
            dataType: 'html',
        }).done(function (data) { 
            $(".btn-search").trigger('click');
        }).fail(function (jqXHR) {
            errorHandler(jqXHR);
        }); 
    });
    //Status
    $(document).on('click', '.updatePhotoTrackingStatus', function () { 
        var photoTrackingId = $(this).attr("data-id");
        var photoTrackingApproveStatus = $(this).attr('data-userTracking-status');
        var status = false;
        if (photoTrackingApproveStatus == 'UnApproved')
            status = true;
        else if (photoTrackingApproveStatus == 'Approved')
            status = false;
        updateUserTrackingStatus(photoTrackingId, status);
    });
    function updateUserTrackingStatus(userTrackingId, trackingApproveStatus) { 
        var displayMessage = '';
        var photoTrackingStatus = {};
        photoTrackingStatus.id = userTrackingId;
        photoTrackingStatus.isApprove = trackingApproveStatus;
        if (photoTrackingStatus.isApprove)
            displayMessage = l('SuccessfullyApproved');
        else
            displayMessage = l('SuccessfullyUnApprove');

        _photoTrackingService.updatePhotoTrackingStatus(photoTrackingStatus).done(() => {
            abp.notify.info(displayMessage);
            $(".btn-search").trigger('click');
        });
    }

    //Init Image Dailog
    loadGallery(true, 'a.thumbnail');

})(jQuery);
