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
            if(data == 200){
                window.location.replace("/Home/Index");
            }
            else if(data == 403){
                alert("Неверный логин или пароль");
            }
            else{
                alert("Не удалось обработать запрос (ServerError)")
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
            if(SerilizaeData.Status == 200){
                alert(SerilizaeData.Message);
                window.location.replace("/Account/Login");
            }
            else{
                alert(SerilizaeData.Message);
            }
        }
    });
});