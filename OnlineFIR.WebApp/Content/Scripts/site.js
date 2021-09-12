/* Add your custom JavaScript in this file */

/* Show Progress
========================================================*/
function ShowProgress() {
    console.log('ShowProgress');
    setTimeout(function () {
        var modal = $('<div />');
        modal.addClass("modal");
        //$('.container').append(modal);
        var loading = $(".loading");
        loading.show();
        var top = Math.max($(window).height() / 2 - loading[0].offsetHeight / 2, 0);
        var left = Math.max($(window).width() / 2 - loading[0].offsetWidth / 2, 0);
        loading.css({ top: top, left: left });
    }, 200);
    $(".container").css('opacity', '0.5');
    //$(".saveSuccess").css('visibility','visible');
}