const settings = {
    "async": true,
    "crossDomain": true,
    "url": "https://movies-quotes.p.rapidapi.com/quote",
    "method": "GET",
    "headers": {
        "X-RapidAPI-Key": "dd794a4204mshf290cb22156b9a4p17e39cjsn95e339e2f71d",
        "X-RapidAPI-Host": "movies-quotes.p.rapidapi.com"
    }
};

$(document).ready(function() {
    $.ajax(settings).done(function(response) {
        var sidebar = $('.sidebar');
        sidebar.find('h3').append(response['show']);
        sidebar.find('p').append(response['quote']);
        sidebar.find('span').append("(" + response['character'] + ")");
    })
})