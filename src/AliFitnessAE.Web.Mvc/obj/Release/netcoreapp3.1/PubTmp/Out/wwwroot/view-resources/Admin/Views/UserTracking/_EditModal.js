(function ($) {
    var _userTrackingService = abp.services.app.userTracking,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#UserTrackingEditModal'),
        _$form = _$modal.find('form').attr('autocomplete', 'off');
     
    function save() {
        if (!_$form.valid()) {
            return;
        } 
        var userTracking = _$form.serializeFormToObject();  
        userTracking.userId = userTracking.editUserTrackingUserId;

        abp.ui.setBusy(_$form);
        _userTrackingService.update(userTracking).done(function () {
            // _$modal.modal('hide'); 
            activeTab('edit-tracking-photo');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('userTracking.edited', userTracking);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault(); 
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    }).on('hidden.bs.modal', () => {  
    }); 
})(jQuery);
