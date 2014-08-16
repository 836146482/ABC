Date.prototype.format = function (format) {
    var o = {
        "M+": this.getMonth() + 1, //month 
        "d+": this.getDate(), //day 
        "h+": this.getHours(), //hour 
        "m+": this.getMinutes(), //minute 
        "s+": this.getSeconds(), //second 
        "q+": Math.floor((this.getMonth() + 3) / 3), //quarter 
        "S": this.getMilliseconds() //millisecond 
    };

    if (/(y+)/.test(format)) {
        format = format.replace(RegExp.$1, (this.getFullYear() + "").substr(4 - RegExp.$1.length));
    }

    for (var k in o) {
        if (new RegExp("(" + k + ")").test(format)) {
            format = format.replace(RegExp.$1, RegExp.$1.length == 1 ? o[k] : ("00" + o[k]).substr(("" + o[k]).length));
        }
    }
    return format;
};
$(function () {
    $("#time").text(new Date().format("yyyy-MM-dd hh:mm:ss"));
    setInterval('$("#time").text(new Date().format("yyyy-MM-dd hh:mm:ss"));', 1000);
    setTitle();
    window.onresize = setTitle;
});
function setTitle() {
    if ($(window).width() < 1150 || $(window).width() > 767) {
        $("#adminTitle").css({ 'font-size': $(window).width() / 29 });
    }
};

function checkAll() {
    $(":checkbox").each(function() {
        $(this).attr("checked","checked");
    });
}