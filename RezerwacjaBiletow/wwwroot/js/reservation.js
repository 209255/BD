var settings = {
    rows: 5,
    cols: 15,
    rowCssPrefix: 'row-',
    colCssPrefix: 'col-',
    seatWidth: 35,
    seatHeight: 35,
    seatCss: 'seat',
    selectedSeatCss: 'selectedSeat',
    selectingSeatCss: 'selectingSeat'
};


$(function () {
    $('#inlineDatepicker').datepick({
        minDate: '09/01/2017', maxDate: '01/15/2018', showTrigger: '#calImg'
    });
    //$('#popupDatepicker').datepick();
    var dates = $('#popupDatepicker').datepick('getDate');
});

$(document).ready(function () {
    var bookedSeats = [5, 10, 25];
    init(bookedSeats);

    $('.' + settings.seatCss).click(function () {
        if ($(this).hasClass(settings.selectedSeatCss)) {
            alert('This seat is already reserved');
        }
        else {
            $(this).toggleClass(settings.selectingSeatCss);
        }
    });
});


var init = function (reservedSeat) {
    var str = [], seatNo, className;
    for (i = 0; i < settings.rows; i++) {
        for (j = 0; j < settings.cols; j++) {
            seatNo = (i + j * settings.rows + 1);
            className = settings.seatCss + ' ' + settings.rowCssPrefix + i.toString() + ' ' + settings.colCssPrefix + j.toString();
            if ($.isArray(reservedSeat) && $.inArray(seatNo, reservedSeat) != -1) {
                className += ' ' + settings.selectedSeatCss;
            }
            str.push('<li class="' + className + '"' +
                'style="top:' + (i * settings.seatHeight).toString() + 'px;left:' + (j * settings.seatWidth).toString() + 'px">' +
                '<a title="' + seatNo + '">' + seatNo + '</a>' +
                '</li>');
        }
    }
    $('#place').html(str.join(''));
};