function ComponentChanged(rowvalue) {
    var targetCtrl = $(ComponentChanged.caller.arguments[0].target);
    var targetid = targetCtrl.attr('id');
    var cStat = targetCtrl.is(":checked");
    var mtidSpan = $('#Txt' + targetid);
    var rowpriceCtrl = $('#RowPrice_' + rowvalue);
    rowpriceCtrl.html('₹'+CalculateComponentPrice('mPrice' + rowvalue)+'/-');
    if (cStat == 'true') { mtidSpan.html('Yes'); } else { mtidSpan.html('No'); }
    var compPrice = CalculateComponentPrice('mPrice');
    $('#TableTotal').html('Total: ₹' + compPrice + '/-');
    $('#myModalSubTotal').html('₹' + compPrice);
    $('#TotlPrice').html('₹' + ($('#AlbumAmount2').html() * 1 + compPrice) + '/-');
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
    $('#TotlPrice').html('₹' + (albumtot + totamount) + '/-');
    $('#myModalGrandTotal').html('₹' + (albumtot + totamount) );
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
        that.html('₹'+CalculateComponentPrice('mPrice' + rowvalue)+'/-');
    });
    var totPrice = CalculateComponentPrice('mPrice');
    var grandtotal = $('#AlbumAmount2').html() * 1 + totPrice;
    $('#myModalSubTotal').html('₹' + totPrice);
    $('#TableTotal').html('Total: ₹' + totPrice + '/-');
    $('#TotlPrice').html('₹' + grandtotal + '/-');
    $('#myModalGrandTotal').html('₹' + grandtotal);
});