(function ($) {
    var _roleService = abp.services.app.role,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#RoleCreateModal'),
        _$form = _$modal.find('form').attr('autocomplete', 'off'),
        _$table = $('#RolesTable');

    var _$rolesTable = _$table.DataTable({
        scrollY: "300px",
        scrollX: true,
        scrollCollapse: true,
        processing: true,
        responsive: false,
        paging: true,
        serverSide: true,
        ordering: false,
        ajax: function (data, callback, settings) {
            var filter = $('#RolesSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _roleService.getAll(filter).done(function (result) {
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
                action: () => _$rolesTable.draw(false)
            }
        ],
        //responsive: {
        //    details: {
        //        type: 'column'
        //    }
        //},
        columnDefs: [
            {
                targets: 0,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    var result = '';
                    result += `<div class="btn-group">`
                    result += `<button class="btn-primary dropdown-toggle" type="button" data-toggle="dropdown"  aria-haspopup="true" aria-expanded="false">`
                    result += l("Actions")
                    result += `<span class="caret"></span>`
                    result += `</button>`
                    result += `<div class="dropdown-menu">`
                    result += `<a class="dropdown-item edit-role" data-role-id="${row.id}" data-toggle="modal" data-target="#RoleEditModal"> ${l('Edit')}</a>`
                    result += `<a class="dropdown-item delete-role" data-role-id="${row.id}" data-role-name="${row.name}"> ${l('Delete')}</a>`
                    result += `</div>`
                    result += `</div>`
                    return result;
                }
            },
            {
                targets: 1,
                data: 'name'
            },
            {
                targets: 2,
                data: 'displayName'
            },
            //{
            //    targets: 3,
            //    data: null,
            //    sortable: false,
            //    autoWidth: false,
            //    defaultContent: '',
            //    render: (data, type, row, meta) => {
            //        return [
            //            `   <button type="button" class="btn btn-sm bg-secondary edit-role" data-role-id="${row.id}" data-toggle="modal" data-target="#RoleEditModal">`,
            //            `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
            //            '   </button>',
            //            `   <button type="button" class="btn btn-sm bg-danger delete-role" data-role-id="${row.id}" data-role-name="${row.name}">`,
            //            `       <i class="fas fa-trash"></i> ${l('Delete')}`,
            //            '   </button>',
            //        ].join('');
            //    }
            //}
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var role = _$form.serializeFormToObject();
        role.grantedPermissions = [];
        var _$permissionCheckboxes = _$form[0].querySelectorAll("input[name='permission']:checked");
        if (_$permissionCheckboxes) {
            for (var permissionIndex = 0; permissionIndex < _$permissionCheckboxes.length; permissionIndex++) {
                var _$permissionCheckbox = $(_$permissionCheckboxes[permissionIndex]);
                role.grantedPermissions.push(_$permissionCheckbox.val());
            }
        }

        abp.ui.setBusy(_$modal);
        _roleService
            .create(role)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$rolesTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-role', function () {
        var roleId = $(this).attr("data-role-id");
        var roleName = $(this).attr('data-role-name');

        deleteRole(roleId, roleName);
    });

    $(document).on('click', '.edit-role', function (e) {
        var roleId = $(this).attr("data-role-id");
        debugger;
        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Admin/Roles/EditModal?roleId=' + roleId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#RoleEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('role.edited', (data) => {
        _$rolesTable.ajax.reload();
    });

    function deleteRole(roleId, roleName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                roleName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _roleService.delete({
                        id: roleId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$rolesTable.ajax.reload();
                    });
                }
            }
        );
    }

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', (e) => {
        _$rolesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$rolesTable.ajax.reload();
            return false;
        }
    });
})(jQuery);
