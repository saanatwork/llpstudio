function ValidateControl() {
    var myCtrl = $(ValidateControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val());
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function validatectrl(targetid, value) {
    var isvalid = false;
    switch (targetid) {
        case "cAlbumType":
            if (value.length < 50) {
                isvalid = IsAlphaNumericWithSpace(value);
            }
            break;
        case "cDescription":
            isvalid = IsAlphaNumericWithSpace(value);
            break;
        case "cIsActive":
            if (value != '') { isvalid = true; }
            break;
        case "cUnitPrice":
            isvalid = IsValidInteger(value);
            break;
    }
    return isvalid;
};
function SaveBtnStatus() {
    if ($('.is-invalid').length > 0) {
        $('#btnSave').makeDisable();
    } else { $('#btnSave').makeEnabled(); }
};
function FnViewNote(ctrl) {
    var myCtrl = $(ctrl);
    var eventid = myCtrl.attr('id');
    $.ajax({
        url: '/Admin/GetAlbumInfo?AlbumTypeID=' + eventid,
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            $(data).each(function (index, item) {
                $('#cAlbumTypeId').val(item.AlbumTypeId);
                $('#cAlbumType').val(item.AlbumType).isValid();
                if (item.Description != null && item.Description != '') {
                    $('#cDescription').val(item.Description).isValid();
                }
                else {
                    $('#cDescription').val(item.Description).isInvalid();
                }
                $('#cIsActive').val(item.IsActive ? 'true' : 'false').isValid();
                $('#cUnitPrice').val(item.UnitPrice).isValid();
                $('#modalHdr').html('Update Album Type');
                $('#btnSave').makeEnabled();
            });
        }
    });

};
function FnDeleteNote(ctrl) {
    var myCtrl = $(ctrl);
    var eventid = myCtrl.attr('id').split('_')[1];
    alert('Delete - ' + eventid);
};
function AddEventClicked() {
    $('#cAlbumTypeId').val('');
    $('#cAlbumType').val('').isInvalid();
    $('#cDescription').val('').isInvalid();
    $('#cIsActive').val('').isInvalid();
    $('#cUnitPrice').val('').isInvalid();
    $('#modalHdr').html('Add New Album Type');
    $('#btnSave').makeDisable();
};
$(document).ready(function () {
    var dtinstance = $('#tblDataList').DataTable({
        columns: [
            { 'data': 'AlbumTypeId' },
            { 'data': 'AlbumType' },
            { 'data': 'Description' },
            { 'data': 'IsActiveStr' },
            { 'data': 'UnitPrice' },
            {
                'data': 'AlbumTypeId', render: function (data, type, row, meta) {
                    var viewBtn = '<button data-toggle="modal" data-target="#EventModal" type="button" id="' + row.AlbumTypeId + '" onclick="FnViewNote(this)" class="btn btn-sm bg-success-light mr-2"><i class="far fa-edit mr-1"></i> Edit</button>';
                    var deleteBtn = '<button  type="button" id="D_' + row.AlbumTypeId + '" onclick="FnDeleteNote(this)" class="btn btn-sm bg-danger-light mr-2"><i class="fas fa-trash-alt mr-1"></i></button>';
                    var mbtns = '<span class="actionBtn d-block">';
                    mbtns = mbtns + viewBtn;
                    if (!row.IsApplied) { mbtns = mbtns + deleteBtn; }
                    mbtns = mbtns + '</span>';
                    return type === 'display' ? mbtns : data;
                }
            },
        ],
        bServerSide: true,
        sAjaxSource: '/Admin/GetAlbumList',
    });
    $('#btnSave').click(function () {
        var schrecords = GetRecordsFromTable('tblDataListModal');
        var x = '{"DataList":' + schrecords + '}';
        $.ajax({
            method: 'POST',
            url: '/Admin/SetAlbumType',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: x,
            success: function (data) {
                $(data).each(function (index, item) {
                    if (item.bResponseBool == true) {
                        $('#cAlbumTypeId').val('');
                        $('#cAlbumType').val('').isInvalid();
                        $('#cDescription').val('').isInvalid();
                        $('#cIsActive').val('').isInvalid();
                        $('#cUnitPrice').val('').isInvalid();
                        $('#modalHdr').html('Add New Album Type');
                        $('#btnSave').makeDisable();
                        Swal.fire({
                            title: 'Success',
                            text: 'Album Type Saved Successfully.',
                            icon: 'success',
                            customClass: 'swal-wide',
                            buttons: {
                                confirm: 'Ok'
                            },
                            confirmButtonColor: '#2527a2',
                        });

                        dtinstance.ajax.reload();
                    }
                    else {
                        Swal.fire({
                            title: 'Error!',
                            text: 'Failed To Save Album Type.',
                            icon: 'error',
                            customClass: 'swal-wide',
                            buttons: {
                                confirm: 'Ok'
                            },
                            confirmButtonColor: '#2527a2',
                        });
                    }
                });
            },
        });
    });

});