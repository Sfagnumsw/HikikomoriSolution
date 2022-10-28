$('.table-list-rate tr, .table-list-remember tr').click(function() {
    $('.table-list-rate tr, .table-list-remember tr').removeClass("active-row");
    $(this).addClass("active-row");
});

$('.rate-link, .remember-link').click(function(){
    $('.rate-link, .remember-link').removeClass("active-tab");
    $(this).addClass("active-tab");
})