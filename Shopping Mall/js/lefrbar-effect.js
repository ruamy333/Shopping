
$(document).ready(function () {
    $('.leftbar-type').click(function () {
        var $ul = $(this).next('.leftbar ul');
        if (!$ul.is(':visible')) {
            $('.leftbar ul:visible').slideUp();
        }
        $ul.slideToggle();
    }).siblings('ul').hide();

    $('.center-column').click(function () {
        var $ul = $(this).next('.content-center ul');
        if (!$ul.is(':visible')) {
            $('.content-center ul:visible').slideUp();
        }
        $ul.slideToggle();
    }).siblings('ul').hide();
});