var baseUrl = 'http://localhost:8090/';
//highlights selected page in menu
(function ($) {
    "use strict";

    // Add active state to sidbar nav links
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
        if (this.href === path) {
            $(this).addClass("active");
        }
    });

    // Toggle the side navigation
    $("#sidebarToggle").on("click", function (e) {
        e.preventDefault();
        $("body").toggleClass("sb-sidenav-toggled");
    });
})(jQuery);

$(document).ready(function () {
    $('#dataTable').DataTable();
});

function generateColor() {
    var colorArray = [];
    for (var i = 0; i < 7; i++) {
        var colorGen = getRandomColor();
        colorArray.push(colorGen);
    }
    return colorArray;
}
function getRandomColor(num) {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

async function makeGetRequest(url) {
    var headers = new Headers();
    headers.append('Content-Type', 'application/json');
    headers.append('Accept', 'application/json');
    headers.append('Access-Control-Allow-Origin', '*');

    var requestOptions = {
        method: 'GET',
        headers: headers,
        redirect: 'follow'
    };

    return await fetch(url, requestOptions)
        .then(response => response.json())
        .then(result => {
            return result;
        })
        .catch(error => console.error(`ERROR on GetRequest \nURL: ${url} \nMessage: ${error}`));
}




