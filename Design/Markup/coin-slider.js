(function($) {
	var params = [],
		order = [],
		images = [],
		links = [],
		linksTarget = [],
		titles = [],
		interval = [],
		imagePos = [],
		appInterval = [],
		squarePos = [],
		reverse = [];
	$.fn.coinslider = $.fn.CoinSlider = function(options) {
		// squares positions
		var setFields = function(el) {
			var tWidth = parseInt(params[el.id].width / params[el.id].spw),
				sWidth = tWidth,
				tHeight = parseInt(params[el.id].height / params[el.id].sph),
				sHeight = tHeight,
				counter = 0,
				sLeft = 0,
				sTop = 0,
				i,
				j,
				tgapx = params[el.id].width - params[el.id].spw * sWidth,
				gapx = tgapx,
				tgapy = params[el.id].height - params[el.id].sph * sHeight,
                trans = 0,
				gapy = tgapy;
			for(i = 1; i <= params[el.id].sph; i++) {
				gapx = tgapx;
				if(gapy > 0) {
					gapy--;
					sHeight = tHeight + 1;
				} else {
					sHeight = tHeight;
				}
				for(j = 1; j <= params[el.id].spw; j++) {
					if(gapx > 0) {
						gapx--;
						sWidth = tWidth + 1;
					} else {
						sWidth = tWidth;
					}
					order[el.id][counter] = i + "" + j;
					counter++;
					$('#' + el.id).append("<div class='cs-" + el.id + "' id='cs-" + el.id + i + j + "' style='width:" + sWidth + "px; height:" + sHeight + "px; float: left; position: absolute;'></div>");
					// positioning squares
					$("#cs-" + el.id + i + j).css({
						'background-position': -sLeft + 'px ' + (-sTop + 'px'),
						'left': sLeft,
						'top': sTop
					});
					sLeft += sWidth;
				}
				sTop += sHeight;
				sLeft = 0;
			}
			if(params[el.id].hoverPause) {
				$("#SliderPanel ul").mouseover(function() {
					params[el.id].pause = true;
				});

				$("#SliderPanel ul").mouseout(function() {
					params[el.id].pause = false;
				});
			}
		};
		var transitionCall = function(el) {
			clearInterval(interval[el.id]);
			var delay = params[el.id].delay + params[el.id].spw * params[el.id].sph * params[el.id].sDelay;
			interval[el.id] = setInterval(function() { transition(el); }, delay);
		};
		// transitions
		var transition = function(el, direction, trans) {
			if(params[el.id].pause === true) {
				return;
			}
			effect(el);
			squarePos[el.id] = 0;
			appInterval[el.id] = setInterval(function() { appereance(el, order[el.id][squarePos[el.id]]); }, params[el.id].sDelay);
			$(el).css({ 'background-image': 'url(' + images[el.id][imagePos[el.id]] + ')' });
			if(typeof (direction) == "undefined") {
				imagePos[el.id]++;
			} else {
				if(direction == 'prev') {
					imagePos[el.id]--;
				} else {
					imagePos[el.id] = direction;
				}
			}
			if(imagePos[el.id] == images[el.id].length) {
				imagePos[el.id] = 0;
			}
			if(imagePos[el.id] == -1) {
				imagePos[el.id] = images[el.id].length - 1;
			}
			$('.SliderButton' + el.id).removeClass('ButtonActive');
			$('#SliderButton' + el.id + "-" + (imagePos[el.id] + 1)).addClass('ButtonActive');
			if(trans == null) {
				$("#SliderSpinner").animate({
					"opacity": 0,
					"width": 0,
					"margin-left": ($('#SliderButton' + el.id + "-" + (imagePos[el.id] + 1)).position().left + ($('#SliderButton' + el.id + "-" + (imagePos[el.id] + 1)).outerWidth() / 2))
				}, 500, function() { });
				$("#SliderSpinner").animate({
					"margin-left": $('#SliderButton' + el.id + "-" + (imagePos[el.id] + 1)).position().left,
					"width": $('#SliderButton' + el.id + "-" + (imagePos[el.id] + 1)).outerWidth(),
					"opacity": 1
				}, 500, function() { });
			}
		};
		var appereance = function(el, sid) {
			$('.cs-' + el.id).attr('href', links[el.id][imagePos[el.id]]).attr('target', linksTarget[el.id][imagePos[el.id]]);
			if(squarePos[el.id] == params[el.id].spw * params[el.id].sph) {
				clearInterval(appInterval[el.id]);
				return;
			}
			$('#cs-' + el.id + sid).css({ opacity: 0, 'background-image': 'url(' + images[el.id][imagePos[el.id]] + ')' });
			$('#cs-' + el.id + sid).animate({ opacity: 1 }, 300);
			squarePos[el.id]++;
		};
		// navigation
		var setNavigation = function(el) {
			// image buttons
			if(true) {
				var k;
				for(k = 1; k < images[el.id].length + 1; k++) {
					$('#SliderPanel ul').append("<li class='SliderButton" + el.id + "' id='SliderButton" + el.id + "-" + k + "'><span></span></li>");
				}
				$.each($('.SliderButton' + el.id), function(i, item) {
					$(item).click(function(e) {
						$('.SliderButton-' + el.id).removeClass('ButtonActive');
						$(this).addClass('ButtonActive');
						e.preventDefault();
						transition(el, i);
						transitionCall(el);
					});
				});
				$('#SliderPanel ul').mouseout(function() {
					params[el.id].pause = false;
				});
			}
		};
		// effects
		var effect = function(el) {
			straight(el);
		};
		// straight effect
		var straight = function(el) {
			var counter = 0,
				i,
				j;
			for(i = 1; i <= params[el.id].sph; i++) {
				for(j = 1; j <= params[el.id].spw; j++) {
					order[el.id][counter] = i + '' + j;
					counter++;
				}
			}
		};
		var init = function(el, trans) {
			order[el.id] = [];	// order of square appereance
			images[el.id] = [];
			links[el.id] = [];
			linksTarget[el.id] = [];
			titles[el.id] = [];
			imagePos[el.id] = 0;
			squarePos[el.id] = 0;
			reverse[el.id] = 1;

			params[el.id] = $.extend({}, $.fn.coinslider.defaults, options);

			// create images, links and titles arrays
			$.each($('#' + el.id + ' img'), function(i, item) {
				images[el.id][i] = $(item).attr('src');
				$(item).hide();
				$(item).next().hide();
			});

			// set panel
			$(el).css({
				'background-image': 'url(' + images[el.id][0] + ')',
				'width': params[el.id].width,
				'height': params[el.id].height,
				'position': 'relative',
				'background-position': 'top left'
			}).wrap("<div class='coin-slider' id='coin-slider-" + el.id + "' />");
			setFields(el);
			if(params[el.id].navigation) {
				setNavigation(el);
			}
			var trans = 0;
			transition(el, 0, trans);
			transitionCall(el);
			trans++;
		};
		this.each(
			function() {
				init(this);
			}
		);
	};
	$.fn.coinslider.defaults = {
		width: 853, // width of slider panel
		height: 390, // height of slider panel
		spw: 7, // squares per width
		sph: 5, // squares per height
		delay: 3000, // delay between images in ms
		sDelay: 30, // delay beetwen squares in ms
		opacity: 0.7, // opacity of title and navigation
		titleSpeed: 500, // speed of title appereance in ms
		effect: 'straight', // random, swirl, rain, straight
		links: false, // show images as links
		hoverPause: true, // pause on hover
		prevText: 'prev',
		nextText: 'next',
		navigation: true, // show/hide prev, next and buttons
		showNavigationPrevNext: false,
		showNavigationButtons: true,
		navigationPrevNextAlwaysShown: false
	};
})(jQuery);