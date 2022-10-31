$('.delete-button').click(function() {
    var Id = $('.active-row').find("td").eq(0).html();
    var tableClass = $('.active-row').closest('table').attr('class');
    $.ajax({
        url: "/Content/RemoveAction",
        type: "POST",
        data: { Id: Id, tableClass: tableClass },
        success: function() {
            $('.active-row').css('visibility', 'collapse');
        },
        error: function() {
            alert("Ошибка удаления");
        }
    });
});