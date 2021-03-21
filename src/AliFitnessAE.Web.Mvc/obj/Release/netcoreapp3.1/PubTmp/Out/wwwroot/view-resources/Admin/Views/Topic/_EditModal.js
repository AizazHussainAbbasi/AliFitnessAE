(function ($) {
    var _TopicService = abp.services.app.topic,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#TopicEditModal'),
        _$form = _$modal.find('form').attr('autocomplete', 'off');

    function save() {
        if (!_$form.valid()) {
            return;
        }
        debugger;
        var Topic = _$form.serializeFormToObject(); 
        Topic.Published = _$form.find($("input[name=Published]")).is(":checked");
        Topic.IncluedInTopMenu = _$form.find($("input[name=IncluedInTopMenu]")).is(":checked");
        Topic.IncluedInFooterColumn1 = _$form.find($("input[name=IncluedInFooterColumn1]")).is(":checked");
        Topic.IncluedInFooterColumn2 = _$form.find($("input[name=IncluedInFooterColumn2]")).is(":checked");
        Topic.IncluedInFooterColumn3 = _$form.find($("input[name=IncluedInFooterColumn3]")).is(":checked"); 
        

        abp.ui.setBusy(_$form);
        _TopicService.update(Topic).done(function () {
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('Topic.edited', Topic);
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
    });
    debugger;
    $('.editRichTextControl').richText();
})(jQuery);
