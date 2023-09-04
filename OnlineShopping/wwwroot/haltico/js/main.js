/*********************************************************************************

	Template Name: Haltico - Mega Store eCommerce Bootstrap 5 Template
	Description: A perfect template to build beautiful and unique mega store eCommerce websites. It comes with nice and clean design.
	Version: 3.0

	Note: This is main js.

**********************************************************************************/

/**************************************************************
	
	SCRIPT INDEXING
	|
	|
	|___ Mobile Menu
	|___ Custom Selectbox
	|___ Herobanner Slider
	|___ Deal Of The Day Slider
	|___ Deal Of The Day Slider 2
	|___ Trending Product Slider
	|___ Trending Product Slider 2
	|___ Our Product Slider
	|___ Our Proudct Slider 2
	|___ Our Proudcts Slider 3
	|___ New Best Featured Slider
	|___ Category Slider
	|___ Category Slider 2
	|___ Recommended Product Slider
	|___ Featured Product Slider
	|___ Brand Logos Slider
	|___ Latest Blog Slider
	|___ Product Details Slider Image
	|___ Product Details Image Slider
	|___ Countdown Activation
	|___ Accountbox
	|___ Current Currency
	|___ Current Language
	|___ Select Sortby
	|___ Header Cart
	|___ Category Menu
	|___ Recommended Product Exerpt
	|___ Product Quantity
	|___ Product Detals Color & Size
	|___ Rating Hover Action
	|___ Quickview Modal
	|___ Product Details Zoom
	|___ Range Slider Active
	|___ Product Viewmode
	|___ Checkout Login Coupon
	|___ Different Address Form
	|___ Progress Bar Effect
	|___ Ajax Chimp
	|___ Scroll Up Active
	|
	|
	|___ END SCRIPT INDEXING

***************************************************************/


(function ($) {
	'use strict';


	/* Mobile Menu */
	$('nav.ho-navigation').meanmenu({
		meanMenuOpen: '<i class="flaticon-menu"></i>',
		meanMenuClose: '<i class="flaticon-cancel"></i>',
		meanMenuCloseSize: '18px',
		meanScreenWidth: '991',
		meanExpandableChildren: true,
		meanMenuContainer: '.mobile-menu',
		onePage: true
	});


	/* Custom Selectbox */
	$('select').niceSelect();


	/* Herobanner Slider */
	$('.herobanner').slick({
		slidesToShow: 1,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: true,
		easing: 'ease-in-out',
		dots: true,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
	});


	/* Deal Of The Day Slider */
	$('.deal-of-the-day-slider').slick({
		slidesToShow: 3,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Deal Of The Day Slider 2 */
	$('.deal-of-the-day-slider-2').slick({
		slidesToShow: 4,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 1200,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Trending Product Slider */
	$('.trending-products-slider').slick({
		slidesToShow: 2,
		autoplay: false,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
			breakpoint: 992,
			settings: {
				slidesToShow: 1,
				slidesToScroll: 1
			}
		}]
	});


	/* Trending Product Slider 2 */
	$('.trending-products-slider-2').slick({
		slidesToShow: 3,
		autoplay: false,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 1200,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Our Product Slider */
	$('.our-products-slider').slick({
		slidesToShow: 3,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Our Proudct Slider 2 */
	$('.ourproduct-2-slider').slick({
		slidesToShow: 4,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 1200,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Our Proudcts Slider 3 */
	$('.our-products-slider-3').slick({
		slidesToShow: 4,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 1200,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* New Best Featured Slider */
	$('.new-best-featured-slider').slick({
		slidesToShow: 5,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 1200,
				settings: {
					slidesToShow: 4,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Category Slider */
	$('.categories-slider').slick({
		slidesToShow: 1,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Category Slider 2 */
	$('.categories-slider-2').slick({
		slidesToShow: 4,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 992,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Recommended Product Slider */
	$('.recommended-products-slider').slick({
		slidesToShow: 1,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});

	/* Recommended Product Slider */
	$('.recommended-products-slider-2').slick({
		slidesToShow: 1,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Featured Product Slider */
	$('.featured-product-slider').slick({
		slidesToShow: 2,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
			breakpoint: 576,
			settings: {
				slidesToShow: 1,
				slidesToScroll: 1
			}
		}]
	});


	/* Brand Logos Slider */
	$('.brand-logo-slider').slick({
		slidesToShow: 5,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 1200,
				settings: {
					slidesToShow: 4,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 992,
				settings: {
					slidesToShow: 3,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 768,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Latest Blog Slider */
	$('.blogitem-slider').slick({
		slidesToShow: 3,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});

	/* Product Details Slider Image */
	$('.pdetails-sliderimages').slick({
		slidesToShow: 3,
		autoplay: true,
		autoplaySpeed: 8000,
		speed: 1000,
		adaptiveHeight: true,
		fade: false,
		easing: 'ease-in-out',
		dots: false,
		arrows: true,
		prevArrow: '<span class="slider-navigation-arrow slider-navigation-prev"><i class="ion ion-ios-arrow-back"></i></span>',
		nextArrow: '<span class="slider-navigation-arrow slider-navigation-next"><i class="ion ion-ios-arrow-forward"></i></span>',
		responsive: [{
				breakpoint: 992,
				settings: {
					slidesToShow: 2,
					slidesToScroll: 1
				}
			},
			{
				breakpoint: 576,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
		]
	});


	/* Product Details Image Slider */
	$('.pdetails-largeimages').slick({
		slidesToShow: 1,
		slidesToScroll: 1,
		arrows: false,
		dots: false,
		fade: true,
		asNavFor: '.pdetails-thumbs'
	});

	$('.pdetails-thumbs:not(.pdetails-thumbs-vertical)').slick({
		slidesToShow: 4,
		slidesToScroll: 1,
		asNavFor: '.pdetails-largeimages',
		arrows: false,
		dots: false,
		focusOnSelect: true,
		vertical: false
	});

	$('.pdetails-thumbs-vertical').slick({
		slidesToShow: 4,
		slidesToScroll: 1,
		asNavFor: '.pdetails-largeimages',
		arrows: false,
		dots: false,
		focusOnSelect: true,
		centerMode: true,
		vertical: true,
		responsive: [{
			breakpoint: 576,
			settings: {
				vertical: false,
			}
		}]

	});


	/* Countdown Activation */
	$('.countdown').each(function () {
		var $this = $(this),
			finalDate = $(this).data('countdown');
		$this.countdown(finalDate, function (event) {
			$this.html(event.strftime(
				'<div class="countdown-pack countdown-day"><h3 class="countdown-count">%-D</h3><h6>Days</h6></div>:<div class="countdown-pack countdown-hour"><h3 class="countdown-count">%-H</h3><h6>Hour</h6></div>:<div class="countdown-pack countdown-minutes"><h3 class="countdown-count">%M</h3><h6>Min</h6></div>:<div class="countdown-pack countdown-seconds"><h3 class="countdown-count">%S</h3><h6>Sec</h6></div>'));
		});
	});


	/* Accountbox */
	$('.header-accountbox-trigger').on('click', function () {
		$('.header-accountbox').slideToggle();
	});


	/* Current Currency */
	$('.select-currency-current').on('click', function () {
		$('.select-currency-list').slideToggle();
	});


	/* Current Language */
	$('.select-language-current').on('click', function () {
		$('.select-language-list').slideToggle();
	});


	/* Select Sortby */
	$('.select-sortby-current').on('click', function () {
		$('.select-sortby-list').slideToggle();
	});


	/* Header Cart */
	$('.header-carticon').on('click', function (e) {
		e.preventDefault();
		$(this).toggleClass('is-active');
		$('.header-minicart').slideToggle();
	});


	/* Category Menu */
	function categoryMenu() {
		var winWidth = $(window).width();

		// Toggle Category Menu
		$('.catmenu-trigger').on('click', function (e) {
			e.preventDefault();
			$(this).toggleClass('is-active');
			$(this).siblings('.catmenu-body').slideToggle();
		});
		$('.catmenu-trigger.is-active').siblings('.catmenu-body').slideDown();

		// Category Menu More
		$('.catmenu-moretrigger a').on('click', function (e) {
			e.preventDefault();
			$(this).parents('.catmenu').find('.catmenu-hidden').slideToggle();
		});

		// Mobile Attitude
		if (winWidth < 992) {

			$('.catmenu-body').find('.megamenu').removeClass('megamenu');
			$('.catmenu-body').find('.catmenu-megamenu').removeClass('catmenu-megamenu');
			$('.catmenu-body').find('.catmenu-dropdown').removeClass('catmenu-dropdown');

			$('.catmenu-body').find('li').each(function () {
				if ($(this).children('ul').length) {
					$(this).addClass('has-children');
					$(this).children('a').on('click', function (e) {
						e.preventDefault();
						$(this).parent('li').toggleClass('is-active');
						$(this).siblings('ul').slideToggle();
					});
				}
			});

			$('.catmenu-2').find('.catmenu-trigger').removeClass('is-active');
			$('.catmenu-2').find('.catmenu-body').css('display', 'none');
		}
	}
	categoryMenu();


	/* Recommended Product Exerpt */
	function recommendedExerpt() {
		var max = 75;
		var tot, str;
		$('.recommended-products-slider .hoproduct-4 .hoproduct-title').each(function () {
			str = String($(this).html());
			tot = str.length;
			str = (tot <= max) ? str : str.substring(0, (max + 1)) + "...";
			$(this).html(str);
		});
	}
	recommendedExerpt();


	/* Product Quantity */
	function productQuantity() {
		$('.quantity-select').append('<div class="dec qtybutton">-</i></div><div class="inc qtybutton">+</div>');
		$('.qtybutton').on('click', function () {
			var $button = $(this);
			var oldValue = $button.parent().find('input').val();
			var newVal;
			if ($button.text() == "+") {
				newVal = parseFloat(oldValue) + 1;
			} else {
				if (oldValue > 1) {
					newVal = parseFloat(oldValue) - 1;
				} else {
					newVal = 1;
				}
			}
			$button.parent().find('input').val(newVal);
		});
	}
	productQuantity();


	/* Product Detals Color & Size */
	$('.pdetails-color ul li, .pdetails-size ul li').on('click', function () {
		$(this).addClass('checked').siblings().removeClass('checked');
	});

	/* Rating Hover Action */
	$('.rattingbox.hover-action span').on('mouseenter', function () {
		$('.rattingbox.hover-action span').addClass('active');
		$(this).nextAll('span').removeClass('active');
	});


	/* Quickview Modal */
	$('.quickview-trigger').on('click', function (e) {
		e.preventDefault();
		$('.quickmodal').toggleClass('is-visible');
	});
	$('.quickmodal').find('.body-overlay').on('click', function () {
		$(this).parents('.quickmodal').removeClass('is-visible');
	});
	$('.quickmodal-close').on('click', function () {
		$(this).parent('.quickmodal').removeClass('is-visible');
	});



	/* Product Details Zoom */
	$('.pdetails-imagezoom').lightGallery({
		selector: '.pdetails-singleimage'
	});


	/* Range Slider Active */
	$('.range-slider').nstSlider({
		'left_grip_selector': '.range-slider-leftgrip',
		'right_grip_selector': '.range-slider-rightgrip',
		'value_bar_selector': '.bar',
		'value_changed_callback': function (cause, leftValue, rightValue) {
			$(this).parent().find('.range-slider-leftlabel').text(leftValue);
			$(this).parent().find('.range-slider-rightlabel').text(rightValue);
		}
	});



	/* Product Viewmode */
	$('.shop-filters-viewmode').on('click', 'button', function () {
		$(this).addClass('is-active').siblings().removeClass('is-active');

		var dataView = $(this).data('view');

		if (dataView == 'list') {
			$('.shop-page-products').addClass('list-view-active');
		} else {
			$('.shop-page-products').removeClass('list-view-active');
		}
	});



	/* Checkout Login Coupon */
	$('.checkout-info-collapsebox').css('display', 'none');
	$('.checkout-info-login-trigger, .checkout-info-coupon-trigger').on('click', function (e) {
		e.preventDefault();
		$(this).parent('.checkout-info').next('.checkout-info-collapsebox').slideToggle();
	});



	/* Different Address Form */
	$('.different-address-form-trigger .ho-checkbox').on('change', function () {
		if ($(this).is(':checked')) {
			$('.different-address-form').slideDown();
		} else {
			$('.different-address-form').slideUp();
		}
	});



	/* Progress Bar Effect */
	$(window).on('scroll', function () {

		function winScrollPosition() {
			var scrollPos = $(window).scrollTop(),
				winHeight = $(window).height();
			var scrollPosition = Math.round(scrollPos + (winHeight / 1.2));
			return scrollPosition;
		}


		var trigger = $('.progress-bar');
		if (trigger.length) {
			var triggerPos = Math.round(trigger.offset().top);
			if (triggerPos < winScrollPosition()) {
				trigger.each(function () {
					$(this).addClass('fill');
				});
			}
		}

	});


	/* Ajax Chimp */
	$('#mc-form').ajaxChimp({
		language: 'en',
		callback: mailChimpResponse,
		// ADD YOUR MAILCHIMP URL BELOW HERE!
		url: 'http://devitems.us11.list-manage.com/subscribe/post?u=6bbb9b6f5827bd842d9640c82&amp;id=05d85f18ef'
	
	});
	function mailChimpResponse(resp) {
		
		if (resp.result === 'success') {
			$('.mailchimp-success').html('' + resp.msg).fadeIn(900);
			$('.mailchimp-error').fadeOut(400);
			
		} else if(resp.result === 'error') {
			$('.mailchimp-error').html('' + resp.msg).fadeIn(900);
		}  
	}
	

	/* Scroll Up Active */
	$.scrollUp({
		scrollText: '<i class="ion ion-ios-arrow-up"></i>',
		easingType: 'linear',
		scrollSpeed: 900,
		animation: 'slide'
	});




})(jQuery);