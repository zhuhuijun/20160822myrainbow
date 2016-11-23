if (window != top)
    top.location.href = location.href;
toastr.options = {
    "closeButton": true,
    "debug": false,
    "progressBar": true,
    "positionClass": "toast-top-center",
    "onclick": null,
    "showDuration": "400",
    "hideDuration": "1000",
    "timeOut": "7000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
};
$(function () {
    var myFrom = $(this).find("form");
    //myFrom.bValidator();
    document.oncontextmenu = function () {//屏蔽浏览器右键事件
        return false;
    };
    document.onkeydown = function (e) {
        var ev = document.all ? window.event : e;
        if (ev.keyCode === 13) {
            myFrom.submit(); //处理事件 
        }
    };
    $("#btnlogin").click(function () {
        var username = $("#UserName").val();
        var userpwd = $("#Password").val();
        if (username === "" || userpwd === "") {
            toastr.error("用户名或者密码不能为空!", "错误提示");
        } else {
            myFrom.submit(); //处理事件 
        }

    });
});
function errorTip(msg) {

    if (msg != null && msg !== "") {
        toastr.error(msg, "错误提示");
    }
}
