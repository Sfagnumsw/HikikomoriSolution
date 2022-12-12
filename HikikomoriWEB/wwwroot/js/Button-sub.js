$(document).ready(function () {
    $.validator.unobtrusive.parse($("#rate-form"));
    $.validator.unobtrusive.parse($("#remember-form"));
});

$('.rate-button-sub').click(function(){
    if($('#rate-form').valid()){
        var form = $('#rate-form');
        var SerilizaeForm = form.serialize();
        $.ajax({
            url: "/Home/RateFormPost",
            type: "POST",
            data: SerilizaeForm,
            success: function (data) {
                var SerilizaeData = JSON.parse(data);
                if(SerilizaeData.StatusCode == 500){
                    window.location.replace("/Home/Error");
                }
                else{
                    alert(SerilizaeData.Description);
                    CleanForm(form);
                }
            },
        });
    }
});

$('.remember-button-sub').click(function(){
    if($('#remember-form').valid()){
        var form = $('#remember-form');
        var SerilizaeForm = form.serialize();
        $.ajax({
            url: "/Home/RememberFormPost",
            type: "POST",
            data: SerilizaeForm,
            success: function (data) {
                var SerilizaeData = JSON.parse(data);
                if(SerilizaeData.StatusCode == 500){
                    window.location.replace("/Home/Error");
                }
                else{
                    alert(SerilizaeData.Description);
                    CleanForm(form);
                }
            },
        });
    }   
});

function CleanForm(f){
    f.each(function(){
        this.reset();
    });
}