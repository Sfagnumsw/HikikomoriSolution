$('.delete-button').click(function() {
    var Id = $('.active').find("td").eq(0).html();
    var tableClass = $('.active').closest('table').attr('class');
    $.ajax({
        url: "/Content/RemoveAction",
        type: "POST",
        data: { Id: Id, tableClass: tableClass },
        success: function() {
            $('.active').css('visibility', 'collapse');
        },
        error: function() {
            alert("Ошибка удаления");
        }
    });
});