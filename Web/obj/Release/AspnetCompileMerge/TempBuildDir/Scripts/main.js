$(function() {
	var id = 1;
	$("#SlideShow").responsiveSlides({
		maxwidth: 1200,
		speed: 800,
		before: function() {
			$("#SliderSpinner").animate({
				"opacity": 0.8,
				"width": 0,
				"margin-left": $("#SliderSpinner").outerWidth() / 2
			}, 300, function() { });
			$("#SliderSpinner").animate({
				"margin-left": 0,
				"width": $("#SubMenu").outerWidth(),
				"opacity": 0
			}, 300, function() { });
		}
	});
	$("#Menu ul li").css({
		"width": $("#Menu").width() / $("#Menu ul").children().length
	});
	$("#SocialBar a img").css({
		"height": $("#BodyWrapper").width() / 20.11 + "px"
	})
	$("#SocialBar a img").hover(function() {
		$(this).css({
			"height": $("#BodyWrapper").width() / 18.1 + "px",
			"margin-top": -($("#BodyWrapper").width() / 18.1 - $("#SocialBar a img").height()) + "px"
		})
	}, function() {
		$(this).css({
			"height": $("#BodyWrapper").width() / 20.11 + "px",
			"margin-top": 0
		})
	});
	$("#SocialBar").css({
		"margin-top": -($("#SocialBar").height() / 2) + "px"
	})
});
$(window).load(function() {
	$("#LanguageBar a img").hover(
        function() {
        	$(this).animate({ opacity: 1 }, 50, function() { });
        },
        function() {
        	$(this).animate({ opacity: 0.8 }, 50, function() { });
        });
	$("#Menu ul li a").hover(
	    function() {
	    	$("#SubMenuSpinner").finish();
	    	$("#SubMenuSpinner").css({ "opacity": 0 });
	    	var ItemHoveredPosition = $(this).position().left - $("#Menu").offset().left;
	    	var ItemHoveredWidth = $(this).outerWidth();
	    	$("#SubMenuSpinner").animate({
	    		"opacity": 0,
	    		"width": 0,
	    		"margin-left": (ItemHoveredPosition + (ItemHoveredWidth / 2))
	    	}, 100);
	    	$("#SubMenuSpinner").animate({
	    		"margin-left": ItemHoveredPosition,
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
	     		"margin-left": $("#MenuItemActive").offset().left - $("#Menu").offset().left
	     	}, 400);
	     });
	$("#SubMenuSpinner").css({
		"width": $("#MenuItemActive").outerWidth(),
		"margin-left": $("#MenuItemActive").offset().left - $("#Menu").offset().left
	});
	$(window).resize(function() {
		$("#SubMenuSpinner").css({
			"width": $("#MenuItemActive").outerWidth(),
			"margin-left": $("#MenuItemActive").offset().left - $("#Menu").offset().left
		});
		$("#SocialBar a img").css({
			"height": $("#BodyWrapper").width() / 20.11 + "px"
		})
		$("#SocialBar a img").hover(function() {
			$(this).css({
				"height": $("#BodyWrapper").width() / 18.1 + "px",
				"margin-top": -($("#BodyWrapper").width() / 18.1 - $("#SocialBar a img").height()) + "px"
			})
		}, function() {
			$(this).css({
				"height": $("#BodyWrapper").width() / 20.11 + "px",
				"margin-top": 0
			})
		});
		$("#SocialBar").css({
			"margin-top": -($("#SocialBar").height() / 2) + "px"
		})
	});
});

