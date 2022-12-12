$('.delete-button').click(function() {
    var Id = $('.active-row').find("td").eq(0).html();
    var tableClass = $('.active-row').closest('table').attr('class');
    $.ajax({
        url: "/Content/RemoveAction",
        type: "POST",
        data: { Id: Id, tableClass: tableClass },
        success: function(data) {
            var SerilizaeData = JSON.parse(data);
            if(SerilizaeData.StatusCode == 500){
                window.location.replace("/Home/Error");
            }
            else{
                $('.active-row').css('visibility', 'collapse');
            }
        },
    });
});