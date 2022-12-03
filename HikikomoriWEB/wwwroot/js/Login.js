$(document).ready(function () {
    $.validator.unobtrusive.parse($("#signin-form"));
});

$('.signin-button').click(function(){
    var form = $('#signin-form');
    var SerilizaeForm = form.serialize();
    $.ajax({
        url: "/Account/Login",
        type: "POST",
        data: SerilizaeForm,
        success: function(data){
            var SerilizaeData = JSON.parse(data);
            if(SerilizaeData.StatusCode == 200){
                alert(SerilizaeData.Description);
                window.location.replace("/Home/Index");
            }
            else{
                alert(SerilizaeData.Description);
            }
        }
    });
});

$(document).ready(function () {
    $.validator.unobtrusive.parse($("#reg-form"));
});

$('.reg-button').click(function(){
    var form = $('#reg-form');
    var SerilizaeForm = form.serialize();
    $.ajax({
        url: "/Account/Registration",
        type: "POST",
        data: SerilizaeForm,
        success: function(data){
            var SerilizaeData = JSON.parse(data);
            if(SerilizaeData.StatusCode == 200){
                alert(SerilizaeData.Description);
                window.location.replace("/Account/Login");
            }
            else{
                alert(SerilizaeData.Description);
            }
        }
    });
});