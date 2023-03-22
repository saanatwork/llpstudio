function ComponentChanged(rowvalue) {
    var targetCtrl = $(ComponentChanged.caller.arguments[0].target);
    var targetid = targetCtrl.attr('id');
    var cStat = targetCtrl.is(":checked");
    var mtidSpan = $('#Txt' + targetid);
    var rowpriceCtrl = $('#RowPrice_' + rowvalue);
    rowpriceCtrl.html(CalculateComponentPrice('mPrice' + rowvalue));
    if (cStat == 'true') { mtidSpan.html('Yes'); } else { mtidSpan.html('No'); }
    var compPrice = CalculateComponentPrice('mPrice');
    $('#TableTotal').html('Total: ' + compPrice);
    $('#TotlPrice').html($('#AlbumAmount').html() * 1 + compPrice);
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
    $('#AlbumAmount').html(albumtot);
    $('#TotlPrice').html(albumtot + CalculateComponentPrice('mPrice'));
};
function RemoveBtnClicked() {
    var targetCtrl = $(RemoveBtnClicked.caller.arguments[0].target);
    var rowvalue = targetCtrl.attr('id').split('_')[1];
    Swal.fire({
        title: 'Removing Event Date',
        text: "Are you sure want to delete this?",
        icon: 'success',        
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
    $('#TableTotal').html('Total: ' + CalculateComponentPrice('mPrice'));
    $('#TotlPrice').html($('#AlbumAmount').html() * 1 + CalculateComponentPrice('mPrice'));
});