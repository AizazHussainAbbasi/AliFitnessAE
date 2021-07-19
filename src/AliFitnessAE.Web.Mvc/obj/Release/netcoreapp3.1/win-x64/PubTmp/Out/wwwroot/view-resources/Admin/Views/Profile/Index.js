$(document).ready(function () {
    var _userService = abp.services.app.user,
        l = abp.localization.getSource('AliFitnessAE'),
        _$table = $('#UserTrackingProfileTable'),
        _$userTrackingProfileSearchform = $('#UserTrackingProfileSearchForm'),
        _$formPersonalDetail = $('#formPersonalDetailProfile');

    _$userTrackingProfileSearchform.attr('autocomplete', 'off');
    _$formPersonalDetail.attr('autocomplete', 'off');

    //Personal Detail
    function save() {
        if (!_$formPersonalDetail.valid()) {
            return;
        }
        var user = _$formPersonalDetail.serializeFormToObject();
        abp.ui.setBusy(_$formPersonalDetail);
        _userService.updatePersonalDetail(user).done(function () {
            abp.notify.info(l('SavedSuccessfully'));
        }).always(function () {
            abp.ui.clearBusy(_$formPersonalDetail);
        });
    }
    _$formPersonalDetail.find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });
    //Profile Photo
    var readURL = function (input) {
        if (input.files && input.files[0]) {
            var reader = new FileReader();
            reader.onload = function (e) {
                $('.profile-user-img').attr('src', e.target.result);
            }
            reader.readAsDataURL(input.files[0]);
            uploadProfilePhoto(input.files);
        }
    }
    $(".file-upload").on('change', function () {
        readURL(this);
    });

    $(".upload-button").on('click', function () {
        $(".file-upload").click();
    });
    function uploadProfilePhoto(photoFiles) { 
        if (photoFiles.length >= 1) {
            $.each(photoFiles, function (i, img) {
                try { 
                    var formData = new FormData();
                    var profilePhotoControl = $('#profilePhotoControl');
                    formData.append("image", img);
                    formData.append("IsDeleteOld", true);
                    formData.append("businessEntityId", profilePhotoControl.attr("data-businessEntityId"));
                    formData.append("businessDocumentId", profilePhotoControl.attr("data-businessDocumentId"));
                    formData.append("documentTypeId", profilePhotoControl.attr("data-documentTypeId"));

                    $.ajax(
                        {
                            url: "/admin/document/upload",
                            data: formData,
                            processData: false,
                            contentType: false,
                            type: "POST",
                            success: function (data) { 
                                if (data.success) {
                                    abp.notify.info(l('SavedSuccessfully'));
                                }
                                else
                                    abp.notify.info(l('Error'));
                            },
                            error: function (e) {
                                abp.notify.info(l('Error'));
                            }
                        }
                    );

                } catch (e) {
                    console.log(e.message);
                }
            });
        }
    }
    //-----------------------
    //- USER MEASUREMENT  
    //-----------------------    
    //Table 
    var settings = {
        "buttons": [],
        responsive: false
    }
    var _$userTrackingProfileTable = _$table.DataTable(settings);
    //Right Nav Body Part click
    $('#profile-tracking-tabs a').off().on('click', function (e) {
        e.preventDefault()
        debugger;
        var tabID = "vert-tabs-profile-body";
        $("#" + tabID).html('');
        var filter = $('#userTrackingProfileSearchForm').serializeFormToObject(true);
        filter.chartType = filter.userTrackingProfileChartType;
        filter.bodyPart = $(this).attr("data-bodyPart");
        filter.measurementScaleLKDId = $('.ddl_ProfileTrackingScale').find(':selected').val();
        filter.loadDiv = tabID;
        _$userTrackingProfileTable = loadViewComponentUserTracking(filter, 'UserTrackingProfileTable', settings);
        $(this).tab('show');
    });

    //Search Button Click
    $(document).on("click", ".btn-search-userTracking-profile", (e) => {
        e.preventDefault();
        //Refresh Table and Chart
        var tabID = "vert-tabs-profile-body";
        $("#profile-tracking-tabs a").each(function () {
            $(this).removeClass('active');
        });
        $("#" + tabID).html('');
        var filter = $('#userTrackingProfileSearchForm').serializeFormToObject(true);
        var firstPhotoTab = $("#profile-tracking-tabs").find("a:first");
        firstPhotoTab.addClass('active');
        filter.chartType = filter.userTrackingProfileChartType;
        filter.bodyPart = firstPhotoTab.attr("data-bodyPart");
        filter.measurementScaleLKDId = firstPhotoTab.attr("data-measurementScale");
        filter.loadDiv = tabID;
        _$userTrackingProfileTable = loadViewComponentUserTracking(filter, 'UserTrackingProfileTable', settings);

        //Refresh Photos
        var photoTabContentID = "tab-profile-picture-trackingContent"; //$(this).attr("href").substr(1);
        $("profile-picture-trackingContent .tab-pane").each(function () {
            $(this).empty();
        });
        $("#profile-picture-tracking-tabs a").each(function () {
            $(this).removeClass('active');
        });
        $("#" + photoTabContentID).html('');
        var firstPhotoTab = $("#profile-picture-tracking-tabs").find("a:first");
        firstPhotoTab.addClass('active');
        filter.documentType = firstPhotoTab.attr("data-doc-type");
        var businessEntityId = firstPhotoTab.attr("data-BusinessEntityId");
        loadComponentView(photoTabContentID, "PhotoTracking", "PhotoTracking", businessEntityId, filter, "_ProfilePhotoTracking");
    });

    //Scale DDL change
    $(document).on("change", ".ddl_ProfileTrackingScale", function () {
        var ele = $('#profile-tracking-tabs a.active');
        var tabID = "vert-tabs-profile-body";
        var filter = $('#userTrackingProfileSearchForm').serializeFormToObject(true);
        filter.chartType = filter.userTrackingProfileChartType;
        filter.bodyPart = ele.attr("data-bodyPart");
        filter.measurementScaleLKDId = $('.ddl_ProfileTrackingScale').find(':selected').val();
        filter.loadDiv = tabID;
        _$userTrackingProfileTable = loadViewComponentUserTracking(filter, 'UserTrackingProfileTable', settings);
        ele.tab('show');
    });

    //-----------------------
    //- PHOTO TRACKING
    //----------------------- 
    $('#profile-picture-tracking-tabs a').click(function (e) { 
        e.preventDefault();
        var tabID = "tab-profile-picture-trackingContent"; //$(this).attr("href").substr(1);
        $("profile-picture-trackingContent .tab-pane").each(function () {
            console.log("clearing " + $(this).attr("id") + " tab");
            $(this).empty();
        });
        var filter = $('#userTrackingProfileSearchForm').serializeFormToObject(true);
        $("#" + tabID).html('');
        var docType = $(this).attr("data-doc-type");
        filter.documentType = docType;

        var businessEntityId = $(this).attr("data-BusinessEntityId");
        loadComponentView(tabID, "PhotoTracking", "PhotoTracking", businessEntityId, filter, "_ProfilePhotoTracking");
        $(this).tab('show')
    }); 
    //Init Image Dailog
    loadGallery(true, 'a.thumbnail');
});

