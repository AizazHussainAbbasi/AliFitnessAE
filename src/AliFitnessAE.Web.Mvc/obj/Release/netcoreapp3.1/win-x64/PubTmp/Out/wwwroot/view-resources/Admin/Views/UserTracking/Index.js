(function ($) {
    var _userTrackingService = abp.services.app.userTracking,
        _lookUpService = abp.services.app.lookup,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#UserTrackingCreateModal'),
        _$form = _$modal.find('form').attr('autocomplete', 'off'),
        _$table = $('#UserTrackingTable'),
        _$searchForm = $('#UserTrackingSearchForm'),
        measurementScale = {};

    var _$userTrackingTable = _$table.removeAttr('width').DataTable({
        scrollY: "300px",
        scrollX: true,
        scrollCollapse: true,
        paging: true,
        serverSide: false,
        processing: true,
        responsive: false,
        order: [[2, 'desc']],//Default sort icon and sorted
        ajax: function (data, callback, settings) {
            var filter = _$searchForm.serializeFormToObject(true);
            _lookUpService.getMeasurementScaleComboboxItems().done(function (result) {
                measurementScale = result.items;

                //Load Table Data
                filter.maxResultCount = data.length;
                filter.skipCount = data.start;
                filter.userId = filter.searchFormUserList; 
                filter.isApproved = getParameterByName('isApproved');  

                abp.ui.setBusy(_$table);
                _userTrackingService.getAllUserTrackingPagedResult(filter).done(function (result) {
                    callback({
                        recordsTotal: result.totalCount,
                        recordsFiltered: result.totalCount,
                        data: result.items
                    });
                }).always(function () {
                    abp.ui.clearBusy(_$table);
                });
            });
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$userTrackingTable.draw(false)
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
                    if (row.status.statusConst == "Approved") {
                        if (isAdminLoggedIn) {
                            result += `<a class="dropdown-item edit-userTracking" data-userTracking-id="${row.id}" class="dropdown-item">${l('Edit')}</a>`
                            result += `<a class="dropdown-item delete-userTracking" data-userTracking-id="${row.id}" data-userTracking-name="${moment(row.creationTime).format("MMMM Do YYYY")}">${l('Delete')}</a>`
                            result += `<a class="dropdown-item update-userTracking-status" data-userTracking-id="${row.id}" data-userTracking-status="false" data-toggle="tooltip" data-placement="right"  title="${l("UnApproveStatusToolTip")}">${l('UnApprove')}</a>`
                        }
                        else
                            result += `<a class="dropdown-item edit-userTracking" data-userTracking-id="${row.id}" class="dropdown-item">${l('Detail')}</a>`
                    } else {
                        result += `<a class="dropdown-item edit-userTracking" data-userTracking-id="${row.id}" class="dropdown-item">${l('Edit')}</a>`
                        result += `<a class="dropdown-item delete-userTracking" data-userTracking-id="${row.id}" data-userTracking-name="${moment(row.creationTime).format("MMMM Do YYYY")}">${l('Delete')}</a>`
                        if (isAdminLoggedIn) {
                            result += `<a class="dropdown-item update-userTracking-status" data-userTracking-id="${row.id}" data-userTracking-status="true" data-toggle="tooltip" data-placement="right"  title="${l("ApproveStatusToolTip")}">${l('Approve')}</a>`
                        }
                    }
                    result += `</div>`
                    result += `</div>`
                    return result;
                }
            },
            {
                targets: 1,
                data: 'user',
                render: (data, type, row, meta) => {
                    return row.user.fullName;
                }
            },
            {
                targets: 2,
                data: 'date',
                render: (data, type, row, meta) => {
                    return moment(row.creationTime).format("MMMM Do YYYY");
                }
            },
            {
                targets: 3,
                data: 'date',
                render: (data, type, row, meta) => {
                    var spanClass = 'p-1 ';
                    if (row.status.statusConst == "Approved") {
                        spanClass = spanClass + 'label bg-green';
                    } else {
                        spanClass = spanClass + 'label bg-warning';
                    }
                    return [
                        `   <span class="${spanClass}">`,
                        `    ${l(row.status.statusConst)}`,
                        '   </span>'
                    ].join('');
                }
            },
            {
                targets: 4,
                data: 'height',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.heightLkdId)
                    return row.height + ' ' + measurement.displayText;
                }
            },
            {
                targets: 5,
                data: 'weight',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.weightLkdId)
                    return row.weight + ' ' + measurement.displayText;
                }
            },
            {
                targets: 6,
                data: 'hip',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.hipLkdId)
                    return row.hip + ' ' + measurement.displayText;
                }
            },
            {
                targets: 7,
                data: 'bellyButtonWaist',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.bellyButtonWaistLkdId)
                    return row.bellyButtonWaist + ' ' + measurement.displayText;
                }
            },
            {
                targets: 8,
                data: 'hipBoneWaist',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.hipBoneWaistLkdId)
                    return row.hipBoneWaist + ' ' + measurement.displayText;
                }
            },
            {
                targets: 9,
                data: 'chest',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.chestLkdId)
                    return row.chest + ' ' + measurement.displayText;
                }
            },
            {
                targets: 10,
                data: 'rightArm',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.rightArmLkdId)
                    return row.rightArm + ' ' + measurement.displayText;
                }
            },
            {
                targets: 11,
                data: 'leftArm',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.leftArmLkdId)
                    return row.leftArm + ' ' + measurement.displayText;
                }
            },
            {
                targets: 12,
                data: 'rightThigh',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.rightThighLkdId)
                    return row.rightThigh + ' ' + measurement.displayText;
                }
            },
            {
                targets: 13,
                data: 'leftThigh',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.leftThighLkdId)
                    return row.leftThigh + ' ' + measurement.displayText;
                }
            },
            {
                targets: 14,
                data: 'rightCalve',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.rightCalveLkdId)
                    return row.rightCalve + ' ' + measurement.displayText;
                }
            },
            {
                targets: 15,
                data: 'leftCalve',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.leftCalveLkdId)
                    return row.leftCalve + ' ' + measurement.displayText;
                }
            },
            {
                targets: 16,
                data: 'rightForeArm',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.rightForeArmLkdId)
                    return row.rightForeArm + ' ' + measurement.displayText;
                }
            },
            {
                targets: 17,
                data: 'leftForeArm',
                render: (data, type, row, meta) => {
                    var measurement = measurementScale.find(x => x.value == row.leftForeArmLkdId)
                    return row.leftForeArm + ' ' + measurement.displayText;
                }
            },
            {
                targets: 18,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    var result = [];
                    var editIcon = '';
                    if (row.status.statusConst == "Approved") {
                        if (isAdminLoggedIn)
                            editIcon = 'fas fa-pencil-alt';
                        else
                            editIcon = 'fas fa-eye';
                        result[0] = `<span type='button' class="edit-userTracking" data-userTracking-id="${row.id}"><i class="${editIcon}"></i></span>' `
                        if (isAdminLoggedIn) {
                            result[2] = `  &nbsp | &nbsp `
                            result[3] = ` <span type='button' class="delete-userTracking" data-userTracking-id="${row.id}" data-userTracking-name="${moment(row.creationTime).format("MMMM Do YYYY")}"><i class="fas fa-trash"></i></span>`
                            result[4] = `  &nbsp | &nbsp `
                            result[5] = ` <span type='button' class="update-userTracking-status" data-userTracking-id="${row.id}" data-userTracking-status="false" data-toggle="tooltip" data-placement="right"  title="${l("UnApproveStatusToolTip")}"><i class="fas fa-times"></i></span>`
                        }
                    }
                    else {
                        editIcon = 'fas fa-pencil-alt';
                        result[0] = `  <span type='button' class="edit-userTracking" data-userTracking-id="${row.id}"> <i class="${editIcon}"></i></span>' `
                        result[1] = `  &nbsp | &nbsp `
                        result[2] = `  <span type='button' class="delete-userTracking" data-userTracking-id="${row.id}" data-userTracking-name="${moment(row.creationTime).format("MMMM Do YYYY")}"><i class="fas fa-trash"></i></span>`
                        if (isAdminLoggedIn) {
                            result[3] = `  &nbsp | &nbsp `
                            result[4] = ` <span type='button' class="update-userTracking-status" data-userTracking-id="${row.id}" data-userTracking-status="true" data-toggle="tooltip" data-placement="right"  title="${l("ApproveStatusToolTip")}"><i class="fas fa-thumbs-up"></i></i></span>`
                        }
                    }

                    return result.join('');
                } 
            }  
        ]
    });
    $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
        $($.fn.dataTable.tables(true)).DataTable()
            .columns.adjust();
    });
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }
        var userTracking = _$form.serializeFormToObject();
        userTracking.userId = userTracking.addUserTrackingUserId;

        if ($('#addedUserTrackingId').val() > 0) {
            update();
        }
        else {
            abp.ui.setBusy(_$modal);
            _userTrackingService
                .createUserTracking(userTracking)
                .done(function (data) {
                    debugger;
                    $('#addedUserTrackingId').val(data.id);
                    _$modal.modal('hide');
                    abp.notify.info(l('SavedSuccessfully'));
                    _$userTrackingTable.ajax.reload();
                    //_$form[0].reset(); 
                    //activeTab('create-tracking-photo');
                    //loadComponentView("create-tracking-photo", "DocumentUploader", "UserTracking", data.id);
                })
                .always(function () {
                    debugger;
                    abp.ui.clearBusy(_$modal);
                });
        }
    });

    function update() {
        if (!_$form.valid()) {
            return;
        }
        var userTracking = _$form.serializeFormToObject();
        userTracking.id = userTracking.addedUserTrackingId;
        userTracking.userId = userTracking.addUserTrackingUserId;

        abp.ui.setBusy(_$form);
        _userTrackingService.update(userTracking).done(function () {
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('userTracking.added', userTracking);
            //_$userTrackingTable.ajax.reload();
            //activeTab('create-tracking-photo');
            //loadComponentView("create-tracking-photo", "DocumentUploader", "UserTracking", userTracking.id);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }
    $(document).on('click', '.delete-userTracking', function () {
        var userTrackingId = $(this).attr("data-userTracking-id");
        var userTrackingName = $(this).attr('data-userTracking-name');
        deleteUserTracking(userTrackingId, userTrackingName);
    });
    $(document).on('click', '.update-userTracking-status', function () {
        var userTrackingId = $(this).attr("data-userTracking-id");
        var userTrackingApproveStatus = $(this).attr('data-userTracking-status');
        updateUserTrackingStatus(userTrackingId, userTrackingApproveStatus);
    });
    $(document).on('click', '.edit-userTracking', function (e) {
        var userTrackingId = $(this).attr("data-userTracking-id");
        e.preventDefault();
        abp.ui.setBusy(_$table);
        abp.ajax({
            url: abp.appPath + 'Admin/userTracking/EditModal?userTrackingId=' + userTrackingId,
            type: 'POST',
            dataType: 'html',
        }).done(function (data) {
            $('#devEditModal').html(data);
            $('#UserTrackingEditModal').modal('show').find('label').addClass('active');
        }).fail(function (jqXHR) {
            errorHandler(jqXHR);
        }).always(function () {
            abp.ui.clearBusy(_$table);
        });
    });

    abp.event.on('userTracking.edited', (data) => {
        _$userTrackingTable.ajax.reload();
    });
    abp.event.on('userTracking.added', (data) => {
        _$userTrackingTable.ajax.reload();
    });
    function deleteUserTracking(userTrackingId, userTrackingName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                userTrackingName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _userTrackingService.delete({
                        id: userTrackingId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$userTrackingTable.ajax.reload();
                    });
                }
            }
        );
    }
    function updateUserTrackingStatus(userTrackingId, userTrackingApproveStatus) {
        var displayMessage = '';
        var userTrackingStatus = {};
        userTrackingStatus.id = userTrackingId;
        userTrackingStatus.isApprove = userTrackingApproveStatus;
        if (userTrackingStatus.isApprove)
            displayMessage = l('SuccessfullyApproved');
        else
            displayMessage = l('SuccessfullyUnApprove');

        _userTrackingService.updateUserTrackingStatus(userTrackingStatus).done(() => {
            abp.notify.info(displayMessage);
            _$userTrackingTable.ajax.reload();
        });
    }
    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
        _$form.find('label').removeClass('active');
        $('#addedUserTrackingId').val('');
        $('#create-tracking-photo').html('');
    });

    $('.btn-search').on('click', (e) => {
        _$userTrackingTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$userTrackingTable.ajax.reload();
            return false;
        }
    });

    $("#SearchFormUserList").select2({
    });
    $('#SearchFromDate,#SearchToDate').datepicker({
        format: "mm/dd/yyyy",
        clearBtn: true,
        endDate: '+0d'
    }); 
})(jQuery);




    //function getMeasurementScaleComboboxItems() {
    //    _lookUpService.getMeasurementScaleComboboxItems().done(function (result) {
    //        measurementScale = result.items;
    //    });
    //}

 //{
            //    targets: 0,
            //    className: 'control',
            //    defaultContent: ''
            //}, 

//result += `<div class="btn-group">`
//result += `<button class="btn btn-primary btn-sm dropdown-toggle" type="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">`
//result += `<span class="caret"></span>`
//result += `</button>`
//result += `<div class="dropdown-menu">`
//render: (data, type, row, meta) => {
                //    return [
                //        `   <span type='button' class="edit-userTracking" data-userTracking-id="${row.id}">`,
                //        `       <i class="fas fa-pencil-alt"></i>`,
                //        '   </span>',
                //        `&nbsp | &nbsp  <span type='button' class="delete-userTracking" data-userTracking-id="${row.id}" data-userTracking-name="${moment(row.creationTime).format("MMMM Do YYYY")}">`,
                //        `       <i class="fas fa-trash"></i>`,
                //        '   </span>',
                //    ].join('');
                //},
