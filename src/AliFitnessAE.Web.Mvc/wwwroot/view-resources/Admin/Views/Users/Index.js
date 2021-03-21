﻿(function ($) {
    var _userService = abp.services.app.user,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#UserCreateModal'),
        _$form = _$modal.find('form').attr('autocomplete', 'off'),
        _$table = $('#UsersTable');

    var _$usersTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        ajax: function (data, callback, settings) {
            var filter = $('#UsersSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _userService.getAll(filter).done(function (result) {
                callback({
                    recordsTotal: result.totalCount,
                    recordsFiltered: result.totalCount,
                    data: result.items
                });
            }).always(function () {
                abp.ui.clearBusy(_$table);
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$usersTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                className: 'control',
                defaultContent: '',
            },
            {
                targets: 1,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    var result = '';
                    result += `<div class="btn-group">`
                    result += `<button class="btn btn-primary btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">`
                    result += `<span class="caret"></span>`
                    result += `</button>`
                    result += `<div class="dropdown-menu">`
                    result += ` <a class="dropdown-item edit-user" data-user-id="${row.id}" data-toggle="modal" data-target="#UserEditModal">Edit</a>`
                    result += ` <a class="dropdown-item delete-user" data-user-id="${row.id}" data-user-name="${row.name}">Delete</a>`
                    if (isAdminLoggedIn) {
                        result += ` <a class="dropdown-item goto-profile-user" data-user-id="${row.id}">GotProfile</a>`
                    }
                    result += `</div>`
                    result += `</div>`
                    return result;
                }
            },
            {
                targets: 2,
                data: 'userName',
                sortable: false
            },
            {
                targets: 3,
                data: 'fullName',
                sortable: false
            },
            {
                targets: 4,
                data: 'emailAddress',
                sortable: false
            },
            {
                targets: 5,
                data: 'isActive',
                sortable: false,
                render: data => `<input type="checkbox" disabled ${data ? 'checked' : ''}>`
            }
        ]
    });

    _$form.validate({
        rules: {
            Password: "required",
            ConfirmPassword: {
                equalTo: "#Password"
            }
        }
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var user = _$form.serializeFormToObject();
        user.roleNames = [];
        var _$roleCheckboxes = _$form[0].querySelectorAll("input[name='role']:checked");
        if (_$roleCheckboxes) {
            for (var roleIndex = 0; roleIndex < _$roleCheckboxes.length; roleIndex++) {
                var _$roleCheckbox = $(_$roleCheckboxes[roleIndex]);
                user.roleNames.push(_$roleCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _userService.create(user).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$usersTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-user', function () {
        var userId = $(this).attr("data-user-id");
        var userName = $(this).attr('data-user-name');

        deleteUser(userId, userName);
    });

    function deleteUser(userId, userName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                userName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _userService.delete({
                        id: userId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$usersTable.ajax.reload();
                    });
                }
            }
        );
    }

    $(document).on('click', '.edit-user', function (e) {
        var userId = $(this).attr("data-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Admin/Users/EditModal?userId=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#UserEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        });
    });
    $(document).on('click', '.goto-profile-user', function (e) {
        var userId = $(this).attr("data-user-id");

        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Admin/Users/GotoUserProfile?userId=' + userId,
            type: 'POST',
            dataType: 'html',
            success: function (data) { 
                var response = jQuery.parseJSON(data); 
                if (response.result != null && response.result.success) {
                    window.location.href = response.result.targetUrl;
                }
                else {
                    abp.message.error('URL is wrong,please contact with Admin', 'Error Occurred');
                }
            },
            error: function (e) { }
        });
    });
    $(document).on('click', 'a[data-target="#UserCreateModal"]', (e) => {
        $('.nav-tabs a[href="#user-details"]').tab('show')
    });

    abp.event.on('user.edited', (data) => {
        _$usersTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$usersTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$usersTable.ajax.reload();
            return false;
        }
    });
    $("#AddUserType").select2({
        placeholder: "Select",
        theme: "bootstrap4",
        allowClear: true,
        dropdownParent: $('#UserCreateModal .modal-content')
    });
    $("#AddGender").select2({
        placeholder: "Select",
        theme: "bootstrap4",
        allowClear: true,
        dropdownParent: $('#UserCreateModal .modal-content')
    });
    $('#AddUserDOB').datepicker({
        format: "mm/dd/yyyy",
        startView: 2,
        clearBtn: true,
        endDate: '+0d',
        //container: '#UserEditModal .modal-content'
    });
})(jQuery);
