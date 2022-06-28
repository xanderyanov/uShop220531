var townSelected;

var locations = {
    engels: {
        name: "Энгельс",
        phone: "8-917-988-88-33"
    },
    saratov: {
        name: "Саратов",
        phone: "8-917-988-88-55"
    },
    penza: {
        name: "Пенза",
        phone: "8-917-988-88-77"
    }
};

$(function () {

    if (localStorage.getItem("townSelected")) {
        townSelected = localStorage.getItem("townSelected");
        $(".locationName").text(locations[townSelected].name);
        $(".topLine__phone_location a").text(locations[townSelected].phone);
        $(".topLine__phone_location a").attr('href', 'tel:' + locations[townSelected].phone);
    } else {
        townSelected = "saratov";
        $(".locationName").text(locations[townSelected].name);
    }




    $(".location__town").on("click", function () {
        $this = $(this);
        townSelected = $this.data("town");
        console.log(townSelected);
        // let loc = locations[townSelected];
        localStorage.setItem("townSelected", townSelected);
        $(".locationName").text(locations[townSelected].name);
        $(".topLine__phone_location a").text(locations[townSelected].phone);
        $(".topLine__phone_location a").attr('href', 'tel:' + locations[townSelected].phone);
        closeFlyBox();

    });
});


$(function () {
    var mainSliderOptions = {};
    if ($(".mainSlider .swiper-slide").length) {
        mainSliderOptions = {
            slidesPerView: 1,
            loop: true,
            spaceBetween: 0,
            // centeredSlides: true,
            speed: 600,
            autoplay: {
                delay: 15000,
                disableOnInteraction: true,
            },
            navigation: {
                nextEl: ".mainSlider__next",
                prevEl: ".mainSlider__prev",
            },
            keyboard: true,
            watchOverflow: true,
            pagination: {
                el: ".mainSlider__pag",
                type: "bullets",
                dynamicBullets: true,
                clickable: true,
            }
        };
    }
    var swiper = new Swiper(".mainSlider", mainSliderOptions);
})
function closeFlyBox() {
    $("body").removeClass("stop");
    $(".overlay").fadeOut(200);
}

$(function () {

    /********************FlyBox*********************/
    $(".openFlyBoxBtn").on("click", function (e) {
        e.preventDefault();
        var $this = $(this);
        var id = $this.data("id");
        var content = $('.overlay[data-overlay="' + id + '"]');
        content.fadeIn(200);
        $("body").addClass("stop");
    });
    $(".flyBox").on("click", function (e) {
        e.stopPropagation();
    });
    $(".flyBox__close").on("click", function (e) {
        e.preventDefault();
        closeFlyBox();
    });
    $(".overlay").on("click", function (e) {
        e.stopPropagation();
        e.preventDefault();
        closeFlyBox();
    });


});

$window = $(window);

function newFunc() {
	console.log("Hello!");
}

function siteResizeFunction() {
	windowWidth = $window.width();
	topLine3 = $(".topLine3__area").height();
	header3 = $(".header3__area");
	header3Height = $(".header3__area").height();
	prevWindowWidth = windowWidth;


	newFunc();

	if (prevWindowWidth <= 1080 && windowWidth > 1080) {
		newFunc();
	}

	if (prevWindowWidth > 1080 && windowWidth <= 1080) {
		newFunc();
	}
}

$(function () {
	// siteResizeFunction();
	$window.on("resize", siteResizeFunction);
});

//# sourceMappingURL=main.js.map
