$(document).ready(function () {
    $.validator.unobtrusive.parse($("#rate-form"));
    $.validator.unobtrusive.parse($("#remember-form"));
});

$('.rate-button-sub').click(function(){
    if($('#rate-form').valid()){
        var form = $('#rate-form').serialize();
        $.ajax({
            url: "/Home/RateFormPost",
            type: "POST",
            data: form,
            success: function (response) {
                alert(response);
            }
        })

        }
    }   
});

$('.remember-button-sub').click(function(){
    if($('#remember-form').valid()){
        var form = $('#remember-form').serialize();
        console.log(form);
    }   
});