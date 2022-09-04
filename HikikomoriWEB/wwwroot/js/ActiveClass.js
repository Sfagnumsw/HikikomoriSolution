$('.table-list-rate tr, .table-list-remember tr').click(function() {
    $('.table-list-rate tr, .table-list-remember tr').removeClass("active");
    $(this).addClass("active");
});