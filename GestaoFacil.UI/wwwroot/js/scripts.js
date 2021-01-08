/*!
    * Start Bootstrap - SB Admin v6.0.1 (https://startbootstrap.com/templates/sb-admin)
    * Copyright 2013-2020 Start Bootstrap
    * Licensed under MIT (https://github.com/StartBootstrap/startbootstrap-sb-admin/blob/master/LICENSE)
    */
    (function($) {
    "use strict";

    // Add active state to sidbar nav links
        var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
        debugger;
        $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
            debugger;
            if (this.href === path) {
                $(this).addClass("active");
            }
        });

    // Toggle the side 
        debugger;
        $("#sidebarToggle").on("click", function (e) {
            debugger;
        e.preventDefault();
        $("body").toggleClass("sb-sidenav-toggled");
    });
})(jQuery);
