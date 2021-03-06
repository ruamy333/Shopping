﻿$(window).load(function () {
    var $win = $(window),
		$ad = $('#buycar').css('opacity', 0).show(),
		_width = $ad.width(),
		_height = $ad.height(),
		_diffY = 20, _diffX = 20,
		_moveSpeed = 800;

    $ad.css({
        top: $(document).height(),
        //left:_diffX,
        left: $win.width() - _width - _diffX - 20,
        opacity: 1
    });

    $win.bind('scroll resize', function () {
        var $this = $(this);

        $ad.stop().animate({
            top: $this.scrollTop() + $this.height() - _height - _diffY,
            //left:60 + _diffX
            left: $this.scrollLeft() + $this.width() -20 - _width - _diffX
        }, _moveSpeed);
    }).scroll();
});
$(document).ready(function () {
    var productID = "";
    $(".image").draggable({
        drag: function (event, ui) {
            productID = $(this).attr("id");
        },
        revert: true,
        containment: "#containment-wrapper",
        scroll: false
    });
            
    $("#buycar").droppable({
        drop: function (event, ui) {
            var txtID = "txt" + productID;
            var number = document.getElementById(txtID).value;
            document.location.href = "Product.aspx?ID=" + productID + "&num=" + number;
        }
    });
});
