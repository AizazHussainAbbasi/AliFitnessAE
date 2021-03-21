(function () {
    var _$form = $('#RegisterForm').attr('autocomplete', 'off');

    $.validator.addMethod("customUsername", function (value, element) {
        if (value === _$form.find('input[name="EmailAddress"]').val()) {
            return true;
        }

        //Username can not be an email address (except the email address entered)
        return !$.validator.methods.email.apply(this, arguments);
    }, abp.localization.localize("RegisterFormUserNameInvalidMessage", "AliFitnessAE"));

    _$form.validate({
        rules: {
            UserName: {
                required: true,
                customUsername: true
            }
        }
    });
    //$("#AddGender").select2({
    //    placeholder: "Select",
    //    theme: "bootstrap4",
    //    allowClear: true,
    //    //dropdownParent: $('#UserCreateModal .modal-content')
    //});
    $('#AddUserDOB').datepicker({
        format: "mm/dd/yyyy",
        startView: 2,
        clearBtn: true,
        endDate: '+0d', 
        //container: '#UserEditModal .modal-content'
    }).val(""); 
})();
