function Splash() {
    return window.pleaseWait({
        logo: "/assets/img/govao.jpg",
        //backgroundColor: '#3c8dff',
        backgroundColor: '#ffffff',
        loadingHtml: "<h1 style='font-size: 50px; color:rgb(123,9,67)' class='loading-message'>Ministerio da Saude - MINGEST</h1>" +
        '<div class="sk-circle"><div class="sk-circle1 sk-child"></div><div class="sk-circle2 sk-child"></div><div class="sk-circle3 sk-child"></div><div class="sk-circle4 sk-child"></div><div class="sk-circle5 sk-child"></div><div class="sk-circle6 sk-child"></div><div class="sk-circle7 sk-child"></div><div class="sk-circle8 sk-child"></div><div class="sk-circle9 sk-child"></div><div class="sk-circle10 sk-child"></div><div class="sk-circle11 sk-child"></div><div class="sk-circle12 sk-child"></div></div>'
    });
}
waiter = Splash();

document.addEventListener('DOMContentLoaded', function() { waiter.finish(); }, false);
