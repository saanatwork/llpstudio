function ValidateControl() {
    var myCtrl = $(ValidateControl.caller.arguments[0].target);
    var isvalid = validatectrl(myCtrl.attr('id'), myCtrl.val());
    if (isvalid) { myCtrl.isValid(); } else { myCtrl.isInvalid(); }
    SaveBtnStatus();
};
function validatectrl(targetid, value) {
    var isvalid = false;
    switch (targetid) {
        case "cEventName":
            if (value.length < 50) {
                isvalid = IsAlphaNumericWithSpace(value);
            }
            break;
        case "cParentEventID":
        case "cIsActive":
            if (value != '') { isvalid = true; }
            break;
    }
    return isvalid;
};
function SaveBtnStatus() {
    if ($('.is-invalid').length > 0) {
        $('#btnSave').makeDisable();
    } else { $('#btnSave').makeEnabled(); }
};
function UploadImage(ImageforText, existingImageFile, ImageCtrl) {
    var uploadimgfinename = '';
    Swal.fire({
        title: 'Want To Change The Following Image For : ' + ImageforText+' ?',
        text: '',
        /*icon: 'success',*/
        html: `<div style="text-align:center;">
                            <div class="form-group">
                                <img src="/assets/img/custom/` + existingImageFile + `" style="width:150px;height:150px;">
                                <label class="swal-label">Attach File(Only Png,Jpeg OR Jpg Files)</label>
                                <input type="file" id="uploadCtrl" name="uploadCtrl" class="form-control" placeholder="">
                            </div>
                        </div>`,
        cancelButtonClass: 'btn-cancel',
        cancelButtonText: 'Cancel',
        confirmButtonText: 'Submit',
        confirmButtonColor: '#2527a2',
        showCancelButton: true,
    }).then(callback);
    function callback(result) {
        if (result.value) {
            var data = new FormData();
            var files = $("#uploadCtrl").get(0).files;
            if (files.length > 0) {
                data.append("MyImages", files[0]);
                $.ajax({
                    url: "/Common/UploadFile",
                    type: "POST",
                    processData: false,
                    contentType: false,
                    data: data,
                    success: function (response) {
                        $(response).each(function (index, item) {
                            if (item.ResponseStat == 1) {
                                $.ajax({
                                    url: '/Admin/SetEventImage?ImageFile=' + item.FileName + '&EventID=' + $(ImageCtrl).attr('data-id'),
                                    method: 'GET',
                                    dataType: 'json',
                                    success: function (data) {
                                        var imgpath = '/assets/img/custom/' + item.FileName;
                                        $(ImageCtrl).attr('src', imgpath);
                                    }
                                });
                                //uploadimgfinename = item.FileName;
                                
                            }
                            else {
                                Swal.fire({
                                    title: 'Failed To Upload File.',
                                    text: item.ResponseMsg,
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
                    error: function (er) {
                        //alert(er);
                    }
                });
            }
            else {
                Swal.fire({
                    title: 'No Files Selected.',
                    text: 'Select Only Png,Jpeg or Jpg Files.',
                    icon: 'error',
                    customClass: 'swal-wide',
                    buttons: {
                        confirm: 'Ok'
                    },
                    confirmButtonColor: '#2527a2',
                });
            }
        }
    }
    return uploadimgfinename;
}
function FnImageClicked(ctrl) {
    var myCtrl = $(ctrl);    
    var uploadimgfinename = UploadImage(myCtrl.attr('data-name'), myCtrl.attr('data-img'), ctrl);
    
};
function FnViewNote(ctrl) {
    var myCtrl = $(ctrl);
    var eventid = myCtrl.attr('id');
    $.ajax({
        url: '/Admin/GetEventInfo?EventID=' + eventid,
        method: 'GET',
        dataType: 'json',
        success: function (data) {
            $(data).each(function (index, item) {
                $('#cEventId').val(item.EventId);
                $('#cEventName').val(item.EventName).isValid();
                $('#cIsActive').val(item.IsActive ? 'true' : 'false').isValid();
                $('#cParentEventID').val(item.ParentEventID).isValid();
                $('#cImageFile').val(item.ImageFile);
                $('#modalHdr').html('Update Event');
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
    $('#cEventId').val('');
    $('#cImageFile').val('');
    $('#cEventName').val('').isInvalid();
    $('#cIsActive').val('').isInvalid();
    $('#cParentEventID').val('').isInvalid();
    $('#modalHdr').html('New Event');
    $('#btnSave').makeDisable();
};

$(document).ready(function () {
    var dtinstance = $('#tblDataList').DataTable({
        columns: [
            { 'data': 'EventId' },
            { 'data': 'EventName' },
            { 'data': 'EventNameUrl' },
            { 'data': 'ParrentEventName' },
            {
                'data': 'ImageFile', render: function (data, type, row, meta) {
                    var viewImg = '<img src="/assets/img/custom/' + row.ImageFile + '" onclick="FnImageClicked(this)" data-id="' + row.EventId + '" data-name="' + row.EventName + '" data-img="' + row.ImageFile+'" style="width:80px;height:80px;">';
                    return type === 'display' ? viewImg : data;
                }
            },
            /*{ 'data': 'EventLongText' },*/
            { 'data': 'IsActiveStr' },
            {
                'data': 'EventId', render: function (data, type, row, meta) {
                    var viewBtn = '<button data-toggle="modal" data-target="#EventModal" type="button" id="' + row.EventId + '" onclick="FnViewNote(this)" class="btn btn-sm bg-success-light mr-2"><i class="far fa-edit mr-1"></i> Details</button>';
                    var deleteBtn = '<button  type="button" id="D_' + row.EventId + '" onclick="FnDeleteNote(this)" class="btn btn-sm bg-danger-light mr-2"><i class="fas fa-trash-alt mr-1"></i></button>';
                    var mbtns = '<span class="actionBtn d-block">';
                    mbtns = mbtns + viewBtn;
                    if (!row.IsApplied) { mbtns = mbtns + deleteBtn; }
                    mbtns = mbtns + '</span>';
                    return type === 'display' ? mbtns : data;
                }
            },
        ],
        bServerSide: true,
        sAjaxSource: '/Admin/GetEventList',
    });
    $('#btnSave').click(function () {
        var schrecords = GetRecordsFromTable('tblDataListModal');
        var x = '{"DataList":' + schrecords + '}';
        $.ajax({
            method: 'POST',
            url: '/Admin/SetEvent',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: x,
            success: function (data) {
                $(data).each(function (index, item) {
                    if (item.bResponseBool == true) {
                        $('#cEventId').val('');
                        $('#cImageFile').val('');
                        $('#cEventName').val('').isInvalid();
                        $('#cIsActive').val('').isInvalid();
                        $('#cParentEventID').val('').isInvalid();
                        $('#modalHdr').html('New Event');
                        $('#btnSave').makeDisable();
                        Swal.fire({
                            title: 'Success',
                            text: 'Event Information Saved Successfully.',
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
                            text: 'Failed To Save Event Information.',
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