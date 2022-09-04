$('.delete-button').click(function() {
    var id = $('.active').find("td").eq(0).html();
    var tableClass = $('.active').closest('table').attr('class');
    $.ajax({
        url: "/Content/ListBooks",
        type: "POST",
        data: { contentId: id, tableClass: tableClass },
        success: function() {
            $('.active').css('visibility', 'collapse');
        },
        error: function() {
            alert("Ошибка удаления");
        }
    });
});