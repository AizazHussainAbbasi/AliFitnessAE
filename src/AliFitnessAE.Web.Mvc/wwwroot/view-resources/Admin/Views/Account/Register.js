(function () {
    var _$form = $('#RegisterForm').attr('autocomplete', 'off');

    $.validator.addMethod("customUsername", function (value, element) {
        if (value === _$form.find('input[name="EmailAddress"]').val()) {
            return true;
        }

        //Username can not be an email address (except the email address entered)
        return !$.validator.methods.email.apply(this, arguments);
    }, abp.localization.localize("RegisterFormUserNameInvalidMessage", "AliFitnessAE"));
    $.validator.addMethod("customMobileNumber", function (value, element) {
        debugger;
        var regEx = /^(?:\+971|00971|0)?(?:50|51|52|55|56|2|3|4|6|7|9)\d{7}$/; 
        var val = _$form.find('input[name="MobileNumber"]').val();
        if (!val.match(regEx)) { 
            return false;
        }
        return  true;
    }, abp.localization.localize("InValidMobileNumber", "AliFitnessAE"));
    _$form.validate({
        rules: {
            UserName: {
                required: true,
                customUsername: true
            },
            MobileNumber: {
                required: true,
                customMobileNumber: true 
            }
        }
    });
    //$("#AddGender").select2({
    //    placeholder: "Select",
    //    theme: "bootstrap4",
    //    allowClear: true,
    //    //dropdownParent: $('#UserCreateModal .modal-content')
    //});
    //$('#AddUserDOB').datepicker({
    //    format: "mm/dd/yyyy",
    //    startView: 2,
    //    clearBtn: true,
    //    endDate: '+0d', 
    //    //container: '#UserEditModal .modal-content'
    //}).val(""); 
})();
