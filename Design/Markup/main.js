
$(document).ready(function() {
	var MenuItemsTotalWidth = 0;
	$("#Menu ul li a").each(function() {
		MenuItemsTotalWidth = MenuItemsTotalWidth + $(this).width();
	});
	var AllowedMarginForMenuItem = ($("#Menu").width() - MenuItemsTotalWidth) / ($("#Menu ul li").children().length * 2);
	$("#Menu ul li").css({
		"padding-left": AllowedMarginForMenuItem + "px",
		"padding-right": AllowedMarginForMenuItem + "px"
	});
	$("#LanguageBar a img").hover(
        function() {
        	$(this).animate({ opacity: 1 }, 50, function() { });
        },
        function() {
        	$(this).animate({ opacity: 0.8 }, 50, function() { });
        });
	$("#Menu ul li").click(function() {
		window.location = $(this).children().attr("href");
	});
	$("#Menu ul li").hover(
        function() {
        	$("#SubMenuSpinner").finish();
        	$("#SubMenuSpinner").css({ "opacity": 0 });
        	var ItemHoveredPosition = $(this).position().left;
        	var ItemHoveredWidth = $(this).outerWidth();
        	$("#SubMenuSpinner").animate({
        		"opacity": 0,
        		"width": 0,
        		"margin-left": (ItemHoveredPosition + (ItemHoveredWidth / 2)) - 15
        	}, 100);
        	$("#SubMenuSpinner").animate({
        		"margin-left": ItemHoveredPosition - 15,
        		"width": ItemHoveredWidth,
        		"opacity": 1
        	}, 200);
        },
        function() { });
	$("#Menu").hover(
         function() { },
         function() {
         	$("#SubMenuSpinner").animate({
         		"width": $("#MenuItemActive").outerWidth(),
         		"margin-left": $("#MenuItemActive").position().left - 15
         	}, 400);
         });
	$("#SubMenuSpinner").css({
		"width": $("#MenuItemActive").outerWidth(),
		"margin-left": $("#MenuItemActive").position().left - 15
	});
	$("#SliderPanel ul li").css({
		"width": $("#SliderPanel").outerWidth() / $("#SliderPanel ul").children().length
	});
	$("#SliderSpinner").css({
		"width": $("#SliderPanel").outerWidth() / $("#SliderPanel ul").children().length
	});
});