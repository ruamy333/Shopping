
$(function () {
    $("#view2").click(function () {
        $(".product-inside").addClass("test2", 1000);
        $(".product-inside").removeClass("test3", 1000);
        $(".product-inside").removeClass("test4", 1000);
    });
    $("#view3").click(function () {
        $(".product-inside").addClass("test3", 1000);
        $(".product-inside").removeClass("test2", 1000);
        $(".product-inside").removeClass("test4", 1000);
    });
    $("#view4").click(function () {
        $(".product-inside").addClass("test4", 1000);
        $(".product-inside").removeClass("test3", 1000);
        $(".product-inside").removeClass("test2", 1000);
    });
});