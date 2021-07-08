(function () {
    $('#ReturnUrlHash').val(location.hash);

    var _$form = $('#LoginForm').attr('autocomplete', 'off'); 
    _$form.submit(function (e) { 
        debugger;
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        abp.ui.setBusy(
            $('body'),

            abp.ajax({
                contentType: 'application/x-www-form-urlencoded',
                url: _$form.attr('action'),
                data: _$form.serialize()
            })
        );
    }); 


    var _$forgotPasswordform = $('#ForgotPasswordForm').attr('autocomplete', 'off'); 
    _$forgotPasswordform.submit(function (e) {
        debugger;
        if (_$forgotPasswordform.valid())
            abp.ui.setBusy(_$forgotPasswordform);
        else
            abp.ui.clearBusy(_$forgotPasswordform);
    });
    //_$forgotPasswordform.submit(function (e) {
    //    debugger;
    //    e.preventDefault();

    //    if (!_$forgotPasswordform.valid()) {
    //        return;
    //    }

    //    abp.ui.setBusy(
    //        $('body'),

    //        abp.ajax({
    //            contentType: 'application/x-www-form-urlencoded',
    //            url: _$forgotPasswordform.attr('action'),
    //            data: _$forgotPasswordform.serialize()
    //        })
    //    );
    //}); 
})();
