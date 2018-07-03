angular.module("wescolaApp").factory("NotyService", function () {
    var service = {}

    service.Type = {
        Success: "success",
        Info: "info",
        Danger: "danger",
        Warning: "warning"
    };
    var method = 3000;
    var position = "top";
    var style = "topbar";

    service.Noty = function generate(title, message, type, confirm, callback) {
        var content = "<div class=\"alert alert-" + type + " media fade in\"><h4 class=\"alert-title\">" + title + "</h4><p><strong>Mensagem: </strong>" + message + "</p></div>";
        var container = "";

        if ($(".preview.active").data("content")) {
            content = $(this).data("content");
        }

        style = "panel";

        if (style === "topbar") {
            container = ".page-content";
            position = "top";
        } else if (style === "panel") {
            container = ".panel-notif";
            position = "top";
        } else if (style === "box") {
            container = "";
            position = "topRight";
        };

        if (style === "topbar" && position === "bottom") container = "";
        if (style === "topbar" && position === "top") {
            container = ".page-content";
        }
        if (style === "panel") {
            container = ".modal-content";
        }

        var openAnimation = "animated bounceIn";
        var closeAnimation = "animated bounceOut";

        if (position === "bottom") {
            openAnimation = "animated fadeInUp";
            closeAnimation = "animated fadeOutDown";
        } else if (position === "top") {
            openAnimation = "animated fadeIn";
            closeAnimation = "animated fadeOut";
        }

        if (container == '') {
            var n = noty({
                text: content,
                //type: type,
                dismissQueue: true,
                layout: position,
                closeWith: ['click'],
                theme: 'made',
                maxVisible: 10,
                animation: {
                    open: openAnimation,
                    close: closeAnimation,
                    easing: 'swing',
                    speed: 100
                },
                timeout: method,
                buttons: confirm ? [
                    {
                        addClass: 'btn btn-primary', text: 'Ok', onClick: function ($noty) {
                            callback(true);
                            var idnoty = $(".noty_bar").attr("id");
                            $("#" + idnoty).removeClass().addClass("bounceOut animated");

                            setTimeout(function () {
                                $("#" + idnoty).remove();
                            }, 500);
                        }
                    },
                    {
                        addClass: 'btn btn-danger', text: 'Cancel', onClick: function ($noty) {
                            callback(false);
                            var idnoty = $(".noty_bar").attr("id");
                            $("#" + idnoty).removeClass().addClass("bounceOut animated");

                            setTimeout(function () {
                                $("#" + idnoty).remove();
                            }, 500);
                        }
                    }
                ] : '',
                callback: {
                    onShow: function () {
                        leftNotfication = $('.sidebar').width();
                        if ($('body').hasClass('rtl')) {
                            if (position == 'top' || position == 'bottom') {
                                $('#noty_top_layout_container').css('margin-right', leftNotfication).css('left', 0);
                                $('#noty_bottom_layout_containe').css('margin-right', leftNotfication).css('left', 0);
                            }
                            if (position == 'topRight' || position == 'centerRight' || position == 'bottomRight') {
                                $('#noty_centerRight_layout_container').css('right', leftNotfication + 20);
                                $('#noty_topRight_layout_container').css('right', leftNotfication + 20);
                                $('#noty_bottomRight_layout_container').css('right', leftNotfication + 20);
                            }
                        }
                        else {
                            if (position == 'top' || position == 'bottom') {
                                $('#noty_top_layout_container').css('margin-left', leftNotfication).css('right', 0);
                                $('#noty_bottom_layout_container').css('margin-left', leftNotfication).css('right', 0);
                            }
                            if (position == 'topLeft' || position == 'centerLeft' || position == 'bottomLeft') {
                                $('#noty_centerLeft_layout_container').css('left', leftNotfication + 20);
                                $('#noty_topLeft_layout_container').css('left', leftNotfication + 20);
                                $('#noty_bottomLeft_layout_container').css('left', leftNotfication + 20);
                            }
                        }
                    }
                }
            });
        }
        else {
            var n = $(container).noty({
                text: content,
                dismissQueue: true,
                layout: position,
                closeWith: ['click'],
                theme: 'made',
                maxVisible: 10,
                buttons: confirm ? [
                    {
                        addClass: 'btn btn-primary', text: 'Ok', onClick: function ($noty) {
                            callback(true);
                            var idnoty = $(".noty_bar").attr("id");
                            $("#" + idnoty).removeClass().addClass("bounceOut animated");

                            setTimeout(function () {
                                $("#" + idnoty).remove();
                            }, 500);
                        }
                    },
                    {
                        addClass: 'btn btn-danger', text: 'Cancel', onClick: function ($noty) {
                            callback(false);
                            var idnoty = $(".noty_bar").attr("id");
                            $("#" + idnoty).removeClass().addClass("bounceOut animated");

                            setTimeout(function () {
                                $("#" + idnoty).remove();
                            }, 500);
                        }
                    }
                ] : '',
                animation: {
                    open: openAnimation,
                    close: closeAnimation
                },
                timeout: method,
                callback: {
                    onShow: function () {
                        var sidebarWidth = $('.sidebar').width();
                        var topbarHeight = $('.topbar').height();
                        if (position == 'top' && style == 'topbar') {
                            $('.noty_inline_layout_container').css('top', 0);
                            if ($('body').hasClass('rtl')) {
                                $('.noty_inline_layout_container').css('right', 0);
                            }
                            else {
                                $('.noty_inline_layout_container').css('left', 0);
                            }
                        }
                    }
                }
            });
        }
    }
    return service;
});