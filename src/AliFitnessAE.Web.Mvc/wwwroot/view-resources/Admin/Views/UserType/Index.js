(function ($) {
    debugger;
    var _UserTypeService = abp.services.app.userType,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#UserTypeCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#UserTypeTable');
      
    var _$UserTypeTable = _$table.DataTable({
        scrollY: "300px",
        scrollX: true,
        scrollCollapse: true,
        processing: true,
        responsive: false,
        paging: true,
        serverSide: true,
        ordering: false, 
        ajax: function (data, callback, settings) {
            var filter = $('#UserTypeSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _UserTypeService.getAll(filter).done(function (result) {
                debugger;
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
                action: () => _$UserTypeTable.draw(false)
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
                    result += `<a class="dropdown-item edit-UserType" data-UserType-id="${row.id}" data-toggle="modal" data-target="#UserTypeEditModal"> ${l('Edit')}</a>`
                    result += `<a class="dropdown-item delete-UserType" data-UserType-id="${row.id}" data-UserType-name="${row.UserTypeConst}"> ${l('Delete')}</a>`
                    result += `</div>`
                    result += `</div>`
                    return result;
                }
            },
            {
                targets: 1,
                data: 'userTypeConst'  
            },
            {
                targets: 2,
                data: 'userTypeName' 
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var UserType = _$form.serializeFormToObject(); 

        abp.ui.setBusy(_$modal);
        _UserTypeService
            .create(UserType)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$UserTypeTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-UserType', function () {
        var UserTypeId = $(this).attr("data-UserType-id");
        var UserTypeName = $(this).attr('data-UserType-name');

        deleteUserType(UserTypeId, UserTypeName);
    });

    $(document).on('click', '.edit-UserType', function (e) {
        var UserTypeId = $(this).attr("data-UserType-id");
        debugger;
        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Admin/UserType/EditModal?UserTypeId=' + UserTypeId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#UserTypeEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('UserType.edited', (data) => {
        _$UserTypeTable.ajax.reload();
    });

    function deleteUserType(UserTypeId, UserTypeName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                UserTypeName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _UserTypeService.delete({
                        id: UserTypeId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$UserTypeTable.ajax.reload();
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
        _$UserTypeTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$UserTypeTable.ajax.reload();
            return false;
        }
    }); 
})(jQuery);
