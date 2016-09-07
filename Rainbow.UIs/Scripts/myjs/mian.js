;
(function ($) {
    var main = {
        init: function () {
            this.resizeW();
            $(window).resize(this.resizeW);
        },
        resizeW: function () {
            var winh = $(window).height();
            $("#page-wrapper").height(winh - 35);
        }
    };
    $(function() {
        main.init();
    });
})(jQuery);