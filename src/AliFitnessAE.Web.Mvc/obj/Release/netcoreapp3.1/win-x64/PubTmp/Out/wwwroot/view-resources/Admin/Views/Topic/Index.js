(function ($) {
    var _topicService = abp.services.app.topic,
        l = abp.localization.getSource('AliFitnessAE'),
        _$modal = $('#TopicCreateModal'),
        _$form = _$modal.find('form').attr('autocomplete', 'off'),
        _$table = $('#TopicTable');
      
    var _$TopicTable = _$table.DataTable({
        scrollY: "300px",
        scrollX: true,
        scrollCollapse: true,
        processing: true,
        responsive: false,
        paging: true,
        serverSide: true,
        ordering: false, 
        ajax: function (data, callback, settings) {
            var filter = $('#TopicSearchForm').serializeFormToObject(true);
            filter.maxResultCount = data.length;
            filter.skipCount = data.start;

            abp.ui.setBusy(_$table);
            _topicService.getAll(filter).done(function (result) {
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
                action: () => _$TopicTable.draw(false)
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
                    result += `<a class="dropdown-item edit-Topic" data-Topic-id="${row.id}" data-toggle="modal" data-target="#TopicEditModal"> ${l('Edit')}</a>`
                    result += `<a class="dropdown-item delete-Topic" data-Topic-id="${row.id}" data-Topic-name="${row.topicConst}"> ${l('Delete')}</a>`
                    result += `</div>`
                    result += `</div>`
                    return result;
                }
            },
            {
                targets: 1,
                data: 'topicConst',
                sortable: false
            },
            {
                targets: 2,
                data: 'title',
                sortable: false
            },
            {
                targets: 3,
                data: 'published',
                sortable: false
            },
            {
                targets: 4,
                data: 'incluedInTopMenu',
                sortable: false
            }
        ]
    });

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var Topic = _$form.serializeFormToObject();
        Topic.Published = _$form.find($("input[name=Published]")).is(":checked");
        Topic.IncluedInTopMenu = _$form.find($("input[name=IncluedInTopMenu]")).is(":checked");
        Topic.IncluedInFooterColumn1 = _$form.find($("input[name=IncluedInFooterColumn1]")).is(":checked");
        Topic.IncluedInFooterColumn2 = _$form.find($("input[name=IncluedInFooterColumn2]")).is(":checked");
        Topic.IncluedInFooterColumn3 = _$form.find($("input[name=IncluedInFooterColumn3]")).is(":checked");

        abp.ui.setBusy(_$modal);
        _topicService
            .create(Topic)
            .done(function () {
                _$modal.modal('hide');
                _$form[0].reset();
                abp.notify.info(l('SavedSuccessfully'));
                _$TopicTable.ajax.reload();
            })
            .always(function () {
                abp.ui.clearBusy(_$modal);
            });
    });

    $(document).on('click', '.delete-Topic', function () {
        var TopicId = $(this).attr("data-Topic-id");
        var TopicName = $(this).attr('data-Topic-name');

        deleteTopic(TopicId, TopicName);
    });

    $(document).on('click', '.edit-Topic', function (e) {
        var TopicId = $(this).attr("data-Topic-id");
        debugger;
        e.preventDefault();
        abp.ajax({
            url: abp.appPath + 'Admin/Topic/EditModal?TopicId=' + TopicId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#TopicEditModal div.modal-content').html(content);
            },
            error: function (e) { }
        })
    });

    abp.event.on('Topic.edited', (data) => {
        _$TopicTable.ajax.reload();
    });

    function deleteTopic(TopicId, TopicName) {
        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                TopicName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _topicService.delete({
                        id: TopicId
                    }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$TopicTable.ajax.reload();
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
        _$TopicTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which == 13) {
            _$TopicTable.ajax.reload();
            return false;
        }
    });
    debugger;
    $('.addRichTextControl').richText();
})(jQuery);



//{
//    targets: 5,
//        data: null,
//            sortable: false,
//                autoWidth: false,
//                    defaultContent: '',
//                        render: (data, type, row, meta) => {
//                            var result = [];
//                            if (abp.auth.isGranted('Pages.Topic.UpdateTopic') == true) {
//                                result[0] = `<button type="button" class="btn btn-sm bg-secondary edit-Topic" data-Topic-id="${row.id}" data-toggle="modal" data-target="#TopicEditModal">  <i class="fas fa-pencil-alt"></i> ${l('Edit')} </button>`
//                            }
//                            if (abp.auth.isGranted('Pages.Topic.DeleteTopic') == true) {
//                                result[1] = ` <button type="button" class="btn btn-sm bg-danger delete-Topic" data-Topic-id="${row.id}" data-Topic-name="${row.topicConst}">  <i class="fas fa-trash"></i> ${l('Delete')}</button>`
//                            }
//                            return result.join('');
//                        }
//    //render: (data, type, row, meta) => {
//    //    return [ 
//    //        `   <button type="button" class="btn btn-sm bg-secondary edit-Topic" data-Topic-id="${row.id}" data-toggle="modal" data-target="#TopicEditModal">`,
//    //        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
//    //        '   </button>',
//    //        `   <button type="button" class="btn btn-sm bg-danger delete-Topic" data-Topic-id="${row.id}" data-Topic-name="${row.topicConst}">`,
//    //        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
//    //        '   </button>',
//    //    ].join('');
//    //},
//}