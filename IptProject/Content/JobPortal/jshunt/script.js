$(document).on('ready',function(){
    "use strict";

    
    /* =============== Ajax Contact Form ===================== */
    $('#contactform').submit(function(){
        var action = $(this).attr('action');
        $("#message").slideUp(750,function() {
        $('#message').hide();
            $('#submit')
            .after('<img src="images/ajax-loader.gif" class="loader" />')
            .attr('disabled','disabled');
        $.post(action, {
            name: $('#name').val(),
            email: $('#email').val(),
            comments: $('#comments').val(),
            verify: $('#verify').val()
        },
            function(data){
                document.getElementById('message').innerHTML = data;
                $('#message').slideDown('slow');
                $('#contactform img.loader').fadeOut('slow',function(){$(this).remove()});
                $('#submit').removeAttr('disabled');
                if(data.match('success') != null) $('#contactform').slideUp('slow');

            }
        );
        });
        return false;
    });


    /* index3.html slide mousemove */
    $(window).mousemove(function(e) {
        var change;
        var xpos=e.clientX;var ypos=e.clientY;var left= change*20;
        var  xpos=xpos*2;ypos=ypos*2;
        $('.new-slide-3 img').css('top',((100+(ypos/50))+"px"));
        $('.new-slide-3 img').css('right',((0+(xpos/80))+"px"));
                   
    });  

    /*** FIXED Menu APPEARS ON SCROLL DOWN ***/ 
    $(window).on('scroll', function(){    
        var scroll = $(window).scrollTop();
        if (scroll >= 50) {
        $(".forsticky").addClass("sticky");
        }
        else{
        $(".forsticky").removeClass("sticky");
        $(".forsticky").addClass("");
        }
    });  

    /* Skip Loading */
    $('.page-loading > span').on('click', function(){
        $(this).parent().fadeOut();
    });

    /* Signin Popup */
    $('.signin-popup').on('click', function(){
        $('.signin-popup-box').fadeIn('fast');
        $('html').addClass('no-scroll');
    });
    $('.close-popup').on('click', function(){
        $('.signin-popup-box').fadeOut('fast');
        $('html').removeClass('no-scroll');
    });

    /* Signup Popup */
    $('.signup-popup').on('click', function(){
        $('.signup-popup-box').fadeIn('fast');
        $('html').addClass('no-scroll');
    });
    $('.close-popup').on('click', function(){
        $('.signup-popup-box').fadeOut('fast');
        $('html').removeClass('no-scroll');
    });

    /*** QUICK POST SHARE ***/
    $('.select-user > span').on('click', function (){
        $('.select-user > span').removeClass('active');
        $(this).addClass('active');
    });

    /* Tabs Sec */
    $('.tab-sec li a').on("click", function(){
        var tab_id = $(this).attr('data-tab');
        $('.tab-sec li a').removeClass('current');
        $('.tab-content').removeClass('current');
        $(this).addClass('current');
        $("#"+tab_id).addClass('current');
    });


    $('#toggle-widget .content').hide();
    $('#toggle-widget h2:first').addClass('active').next().slideDown('fast');
    $('#toggle-widget h2').on("click", function(){
    if($(this).next().is(':hidden')) {
        $('#toggle-widget h2').removeClass('active').next().slideUp('fast');
        $(this).toggleClass('active').next().slideDown('fast');
    }
    });

    $('.sb-title.open').next().slideDown();
    $('.sb-title.closed').next().slideUp();
    $('.sb-title').on('click', function(){
        $(this).next().slideToggle();
        $(this).toggleClass('active');
        $(this).toggleClass('closed');
    });

    $('.tree_widget-sec > ul > li.inner-child:first > ul').slideDown();
    $('.tree_widget-sec > ul > li.inner-child:first').addClass('active');
    $('.tree_widget-sec > ul > li.inner-child > a').on('click', function(){
        $('.tree_widget-sec > ul > li.inner-child').removeClass('active');
        $('.tree_widget-sec > ul > li > ul').slideUp();
        $(this).parent().addClass('active');
        $(this).next('ul').slideDown();
        return false;
    });

    $('.btns-profiles-sec > span').on('click', function(){
        $('.btns-profiles-sec > ul').fadeToggle();
    });
    $('body').on('click', function(){
        $('.btns-profiles-sec > ul').fadeOut();
    });
    $(".btns-profiles-sec").on("click",function(e){
        e.stopPropagation();
    });

    $('.action-center > span').on('click', function(){
        $('.action-center ul').fadeOut()
        $('.emply-resume-list').removeClass('active')
        $(this).next('ul').fadeToggle();
        $(this).parent().parent().parent().addClass('active');
    });
    $('body').on('click', function(){
        $('.action-center ul').fadeOut();
    });
    $(".action-center").on("click",function(e){
        e.stopPropagation();
    });

    $('.open-letter').on('click', function(){
        $('.coverletter-popup').fadeIn();
        $('html').addClass('no-scroll');
    });
    $('.close-letter').on('click', function(){
        $('.coverletter-popup').fadeOut();
        $('html').removeClass('no-scroll');
    });

    $('.open-contact').on('click', function(){
        $('.contactus-popup').fadeIn();
        $('html').addClass('no-scroll');
    });
    $('.close-contact').on('click', function(){
        $('.contactus-popup').fadeOut();
        $('html').removeClass('no-scroll');
    });

    $('.my-profiles-sec > span').on('click', function(){
        $('.profile-sidebar').addClass('active');
    });
    $('.close-profile').on('click', function(){
        $('.profile-sidebar').removeClass('active');
    });

    $('.wishlist-dropsec > span').on('click', function(){
        $('.wishlist-dropdown').fadeToggle();
    });
    $('body').on('click', function(){
        $('.wishlist-dropdown').fadeOut();
    });
    $(".wishlist-dropsec").on("click",function(e){
        e.stopPropagation();
    });

    $('.view-resume-list').on('click', function(){
        $('.view-resumesec').fadeIn();
        $('html').addClass('no-scroll');
        return false;
    });
    $('.close-resume-popup').on('click', function(){
        $('.view-resumesec').fadeOut();
        $('html').removeClass('no-scroll');
    });

    $('.follow-companies-popup').on('click', function(){
        $('.follow-companiesec').fadeIn();
        $('html').addClass('no-scroll');
        return false;
    });
    $('.close-follow-company').on('click', function(){
        $('.follow-companiesec').fadeOut();
        $('html').removeClass('no-scroll');
    });

    $('.faq-box > h2').on('click', function(){
        $(this).toggleClass('active');
        $(this).next().slideToggle();
    });

    $('.scroll-to a, .scrollup, .back-top, .tree_widget-sec > ul > li > ul > li a, .cand-extralink a').on('click', function(e) {
        e.preventDefault();
        $('html, body').animate({ scrollTop: $($(this).attr('href')).offset().top}, 500, 'linear');
    });
    
    $('.fav-job').on('click', function(){
        $(this).toggleClass('active');
    });

    $('.emlthis').on('click', function(){
        $(this).toggleClass('active');
    });

    $('.tags-bar > span i').on('click', function(){
        $(this).parent().fadeOut();
    });

    $('.upload-img-bar > span i').on('click', function(){
        $(this).parent().parent().fadeOut();
    });

    $('.del-resume').on('click', function(){
        $(this).parent().fadeOut();
        return false;
    });

    $('.cand-extralink li').on('click', function(){
    	$('.cand-extralink li').removeClass('active');
    	$(this).addClass('active');
    });
    /*** FIXED Menu APPEARS ON SCROLL DOWN ***/	
	$(window).on('scroll', function(){    
		var scroll = $(window).scrollTop();
		if (scroll >= 600) {
		$(".cand-extralink").addClass("stick");
		}
		else{
		$(".cand-extralink").removeClass("stick");
		$(".cand-extralink").addClass("");
		}
	});	

	$(".responsivemenu .menu-item-has-children > a").on("click",function(){
	    $(this).parent().siblings().children("ul").slideUp();
	    $(this).parent().siblings().removeClass("active");
	    $(this).parent().children("ul").slideToggle();
	    $(this).parent().toggleClass("active");
	    return false;
	});

	$('.res-openmenu').on('click', function(){
		$('.responsive-header').addClass('active');
		$('.responsive-opensec').slideDown();
		$('.res-closemenu').removeClass('active')
		$(this).addClass('active');
	});
	$('.res-closemenu').on('click', function(){
		$('.responsive-header').removeClass('active');
		$('.responsive-opensec').slideUp();
		$('.res-openmenu').removeClass('active')
		$(this).addClass('active');
	});

    /* Table Scroll */
    $('.manage-jobs-sec > table').parent().addClass('addscroll')

});



$(window).on('load',function(){
    "use strict";

    $('.page-loading').fadeOut();

});