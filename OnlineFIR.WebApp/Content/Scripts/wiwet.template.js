/*

WIWET.com - ASP.NET Templates

Wildomar Template

*/

$(document).ready(function(){
  $("[data-toggle=popover]").popover();
  $("#menu-toggle,.menuBtn").click(function(e) {
          e.preventDefault();
          $("#wrapper").toggleClass("toggled");
  });
  var screenWidth = $(document).width();
  var screenHeight = $(document).height();
  var screenHeightW = $(window).height();
  if (screenWidth > 992) {
    $(".wiwet-dashboard > div:last-child").height($(".wiwet-dashboard > div:first-child").innerHeight() - 300);
    $(".engagement > div").height($(".statistics").height() - 80);
    $(".page-wrap").css("min-height",screenHeight - 109 + "px");
    $(".invoice.page-wrap").css("min-height",screenHeight - 220 + "px");
  }else{
    $(".engagement > div").height($(".statistics").height() - 80);
    $(".page-wrap").css("min-height",screenHeight - 170 + "px");
    $(".wiwet-dashboard > div:last-child").css("height","auto");
    $(".sidebar-nav,#sidebar-wrapper").css("min-height", screenHeight + "px");
  }
    
  $(".under-search > div:first-child").height($(".under-search").height());

  var pageContentWrapper = $("#page-content-wrapper").height();
    if (pageContentWrapper < screenHeight) {
      pageContentWrapper = $("#page-content-wrapper").height(screenHeight);
    }
});

//Select the navigation menu base on URL.
$(function () {
    var path = window.location.pathname;
    path = path.replace(/\/$/, "");
    path = decodeURIComponent(path);
    if (path == '') {
        path = "/";
    }
    $(".wiwet-navigation li a").each(function () {
        if ($(this).attr('href') == path) {
            $(this).parent().addClass("active");
        }
    });
    $(".wiwet-navigation li.ui-components ul li a").each(function () {
        if ($(this).attr("href") == path || $(this).attr("href") == '') {
            $(".ui-components").addClass("active-ui-components");
            $(".ui-components .collapse").addClass("collapse in");
        }

    });
});