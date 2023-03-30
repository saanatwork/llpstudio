function EnableCheckOut() {
    var isvalid = true;
    //$('#ComponentTable tbody tr').each(function () {
    //    var that = $(this);
    //    if (that.find('.rowPrice').html() * 1 > 0) {
    //        if (that.find('.is-invalid').length > 0) { isvalid = false;}
    //    }
    //});
    return isvalid;
};
function PlaceChanged() {
    var targetCtrl = $(PlaceChanged.caller.arguments[0].target);
    if (targetCtrl.val().length>3) {
        targetCtrl.addClass('is-valid').removeClass('is-invalid');
    } else {
        targetCtrl.addClass('is-invalid').removeClass('is-valid');
    }
};
function EventTypeChanged() {
    var targetCtrl = $(EventTypeChanged.caller.arguments[0].target);
    if (targetCtrl.val() != '') {
        targetCtrl.addClass('is-valid').removeClass('is-invalid');
    } else {
        targetCtrl.addClass('is-invalid').removeClass('is-valid');
    }
};
function EventDateChanged() {
    var targetCtrl = $(EventDateChanged.caller.arguments[0].target);
    if (targetCtrl.val() != '') {
        targetCtrl.addClass('is-valid').removeClass('is-invalid');
    } else {
        targetCtrl.addClass('is-invalid').removeClass('is-valid');
    }
};
function GetAlbumDetails() {
    var mrecord = '';
    var isAlbum = $('#trigger').prop('checked');
    var atid = 0;
    var qty = 0; var rate = 0; var amount = 0;
    if (isAlbum) {
        atid = $('#AlbumDD').val().split('_')[0]*1;
        qty = $('#AlbumQtyDD').val()*1;
        rate = $('#AlbumDD').val().split('_')[1] * 1;
        amount = qty * rate;
    };
        mrecord = mrecord + '"AlbumTypeID":"' + atid + '",';
        mrecord = mrecord + '"NoOfAlbums":"' + qty + '",';
        mrecord = mrecord + '"UnitPrice":"' + rate + '",';
        mrecord = mrecord + '"TotalPrice":"' + amount + '",';
        mrecord = mrecord.replace(/,\s*$/, "");
        mrecord =  '[{' + mrecord + '}]';
    
    return mrecord;
};
function GetRecordsFromCompTable(tableID) {
    var schrecords = '';
    var mrecord = '';
    $('#' + tableID + ' tbody tr').each(function () {
        mRow = $(this);
        rowid = mRow.attr('id').split('_')[1];
        var childEvent = $('#CEvent_' + rowid).val();
        var eventDT = $('#EventDt_' + rowid).val();
        var eventLoc = $('#EventLocation_' + rowid).val();
        mRow.find(".mPrice:checked").each(function () {
            mComp = $(this);
            mrecord = mrecord + '"EventID":"' + childEvent + '",';
            mrecord = mrecord + '"PhotographerTypeCompomentLinkId":"' + mComp.attr('data-id') + '",';
            mrecord = mrecord + '"EventLocation":"' + eventLoc + '",';
            mrecord = mrecord + '"EventDate":"' + eventDT + '",';
            mrecord = mrecord + '"ComponentPrice":"' + mComp.attr('data-val') + '",';
            mrecord = mrecord.replace(/,\s*$/, "");
            schrecords = schrecords + '{' + mrecord + '},';
            mrecord = '';
        });
    });    
    schrecords = schrecords.replace(/,\s*$/, "");
    schrecords = '[' + schrecords + ']';
    return schrecords;
};
function CheckOutClicked() {
    var isvalid = EnableCheckOut();
    if (isvalid) {
        if ($('#TableTotal').html() * 1 > 0) {
            var BookingID = 0;
            var CustomerID = 0;
            var EventID = $('#MasterEventID').val();
            var UserRemarks = '';
            var bdList = GetRecordsFromCompTable('ComponentTable');
            var alList = GetAlbumDetails();
            var x = '{"BookingID":"' + BookingID
                + '","CustomerID":"' + CustomerID
                + '","EventID":"' + EventID
                + '","UserRemarks":"' + UserRemarks
                + '","BookingDtlList":' + bdList + ',"AlbumList":' + alList + '}';

            $.ajax({
                method: 'POST',
                url: '/BookEvent/SaveEventDetails',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: x,
                success: function (data) {
                    $(data).each(function (index, item) {
                        if (item.bResponseBool == true) {
                            window.location.href = '/BookEvent/CheckOut';
                        }                        
                    });
                },
            });
        }
        else {
            Swal.fire({
                title: 'Wrong Input!',
                text: "Cannot Proceed Without Selecting Any Component.",
                icon: 'error',
                cancelButtonClass: 'btn-cancel',
                //cancelButtonText: 'No',
                confirmButtonText: 'OK',
                confirmButtonColor: '#2527a2',
                showCancelButton: false,
            });
        }
    }
    else {
        Swal.fire({
            title: 'Wrong Input!',
            text: "Cannot Procceed Without Filling The Mandatory Fields.",
            icon: 'error',
            cancelButtonClass: 'btn-cancel',
            //cancelButtonText: 'No',
            confirmButtonText: 'OK',
            confirmButtonColor: '#2527a2',
            showCancelButton: false,
        });
    }
};
function ComponentChanged(rowvalue) {
    var targetCtrl = $(ComponentChanged.caller.arguments[0].target);
    var targetid = targetCtrl.attr('id');
    var cStat = targetCtrl.is(":checked");
    var mtidSpan = $('#Txt' + targetid);
    var rowpriceCtrl = $('#RowPrice_' + rowvalue);
    rowpriceCtrl.html(CalculateComponentPrice('mPrice' + rowvalue));
    if (cStat == 'true') { mtidSpan.html('Yes'); } else { mtidSpan.html('No'); }
    var compPrice = CalculateComponentPrice('mPrice');
    $('#TableTotal').html(compPrice);
    $('#myModalSubTotal').html('₹' + compPrice);
    $('#TotlPrice').html(($('#AlbumAmount2').html() * 1 + compPrice));
    $('#myModalGrandTotal').html('₹' + ($('#AlbumAmount2').html() * 1 + compPrice));
};
function CalculateComponentPrice(classname) {
    var price = 0;
    $("." + classname+":checked").each(function () {
        price = price + $(this).attr('data-val') * 1;
    });
    return price;
};
function CalculateAlbumAmount() {
    var albumid = $('#AlbumDD').val();
    var albumqty = $('#AlbumQtyDD').val()*1;
    var albumprice = albumid.split('_')[1] * 1;
    var albumtot = albumprice * albumqty;
    var totamount = CalculateComponentPrice('mPrice');
    $('#AlbumAmount').html('₹' + albumtot + '/-');
    $('#AlbumAmount2').html(albumtot);
    $('#myModalAlbum').html('₹' + albumtot);
    $('#TotlPrice').html((albumtot + totamount));
    $('#myModalGrandTotal').html(albumtot + totamount );
};
function RemoveBtnClicked() {
    var targetCtrl = $(RemoveBtnClicked.caller.arguments[0].target);
    var rowvalue = targetCtrl.attr('id').split('_')[1];
    Swal.fire({
        title: 'Confirmation',
        text: "Are you sure want to delete this?",
        icon: 'question',        
        cancelButtonClass: 'btn-cancel',
        cancelButtonText: 'No',
        confirmButtonText: 'Yes',
        confirmButtonColor: '#2527a2',
        showCancelButton: true,
    }).then(callback);
    function callback(result) {
        if (result.value) {
            $('.mPrice' + rowvalue).each(function () {
                var that = $(this);
                that.removeAttr('checked');
                $('#Txt' + that.attr('id')).html('No');
            });
            var rowpriceCtrl = $('#RowPrice_' + rowvalue);
            rowpriceCtrl.html(CalculateComponentPrice('mPrice' + rowvalue));
            var compPrice = CalculateComponentPrice('mPrice');
            $('#TableTotal').html('Total: ' + compPrice );
            $('#TotlPrice').html($('#AlbumAmount').html() * 1 + compPrice);
        }
    }


};
$(document).ready(function () {
    $('.rowPrice').each(function () {
        var that = $(this);
        var rowvalue = that.attr('id').split('_')[1];
        that.html(CalculateComponentPrice('mPrice' + rowvalue));
    });
    var totPrice = CalculateComponentPrice('mPrice');
    var grandtotal = $('#AlbumAmount2').html() * 1 + totPrice;
    $('#myModalSubTotal').html('₹' + totPrice);
    $('#TableTotal').html(totPrice);
    $('#TotlPrice').html( grandtotal);
    $('#myModalGrandTotal').html('₹' + grandtotal);
});
$(document).ready(function () {
    
});