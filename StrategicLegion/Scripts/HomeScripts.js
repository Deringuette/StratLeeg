$("#SLNavbar").addClass("js");
$("#SLNavbar").addClass("js").before('<div id="menu">☰</div>');
$("#menu").click(function () {
    $("#SLNavbar").toggle();
});
$(window).resize(function () {
    if (window.innerWidth > 768) {
        $("#SLNavbar").removeAttr("style");
    }
});