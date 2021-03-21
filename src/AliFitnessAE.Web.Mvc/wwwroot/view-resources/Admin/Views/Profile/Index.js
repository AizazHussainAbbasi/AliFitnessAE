$(document).ready(function () {
    l = abp.localization.getSource('AliFitnessAE');
    var _$table = $('#UserTrackingProfileTable');
    var _$userTrackingProfileSearchform = $('#UserTrackingProfileSearchForm');
    _$userTrackingProfileSearchform.attr('autocomplete', 'off'); 

    //-----------------------
    //- USER MEASUREMENT  
    //-----------------------    
    //Table 
    var settings = {
        "buttons": []
    }
    var _$userTrackingProfileTable = _$table.DataTable(settings);  
    //Right Nav Body Part click
    $('#profile-tracking-tabs a').off().on('click', function (e) { 
        e.preventDefault()
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
});

