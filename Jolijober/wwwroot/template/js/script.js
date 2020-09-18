$(window).on("load", function () {
    "use strict";



    //  ============= POST PROJECT POPUP FUNCTION =========

    $(document).on("click", ".post_project", function () {
        $(".post-popup.pst-pj").addClass("active");
        $(".wrapper").addClass("overlay");
        return false;
    });
    $(document).on("click", ".post-project > a", function () {
        $(".post-popup.pst-pj").removeClass("active");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= POST JOB POPUP FUNCTION =========

    $(document).on("click", ".post-jb", function () {
        $(".post-popup.job_post").addClass("active");
        $(".wrapper").addClass("overlay");
        return false;
    });
     $(document).on("click", ".post-project > a", function () {
        $(".post-popup.job_post").removeClass("active");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= SIGNIN CONTROL FUNCTION =========

    $(document).on("click", '.sign-control li', function () {
        var tab_id = $(this).attr('data-tab');
        $('.sign-control li').removeClass('current');
        $('.sign_in_sec').removeClass('current');
        $(this).addClass('current animated fadeIn');
        $("#" + tab_id).addClass('current animated fadeIn');
        return false;
    });

    //  ============= SIGNIN TAB FUNCTIONALITY =========

    $(document).on("click", '.signup-tab ul li', function () {
        var tab_id = $(this).attr('data-tab');
        $('.signup-tab ul li').removeClass('current');
        $('.dff-tab').removeClass('current');
        $(this).addClass('current animated fadeIn');
        $("#" + tab_id).addClass('current animated fadeIn');
        return false;
    });

    //  ============= SIGNIN SWITCH TAB FUNCTIONALITY =========

    $(document).on("click", '.tab-feed ul li', function () {
        var tab_id = $(this).attr('data-tab');
        $('.tab-feed ul li').removeClass('active');
        $('.product-feed-tab').removeClass('current');
        $(this).addClass('active animated fadeIn');
        $("#" + tab_id).addClass('current animated fadeIn');
        return false;
    });

    
    //  ============= OVERVIEW EDIT FUNCTION =========

    $(document).on("click", ".overview-open", function () {
        $("#overview-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
   $(document).on("click", ".close-box", function () {
        $("#overview-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= EXPERIENCE EDIT FUNCTION =========

    $(document).on("click", ".exp-bx-open", function () {
        $("#experience-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
   $(document).on("click", ".close-box", function () {
        $("#experience-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= EDUCATION EDIT FUNCTION =========

   $(document).on("click", ".ed-box-open", function () {
        $("#education-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
   $(document).on("click", ".close-box", function () {
        $("#education-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= LOCATION EDIT FUNCTION =========

    $(document).on("click", ".lct-box-open", function () {
        $("#location-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
    $(document).on("click", ".close-box", function () {
        $("#location-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= SKILLS EDIT FUNCTION =========

    $(document).on("click", ".skills-open", function () {
        $("#skills-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
     $(document).on("click", ".close-box", function () {
        $("#skills-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= ESTABLISH EDIT FUNCTION =========

  $(document).on("click", ".esp-bx-open", function () {
        $("#establish-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
    $(document).on("click", ".close-box", function () {
        $("#establish-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= CREATE PORTFOLIO FUNCTION =========

   $(document).on("click", ".gallery_pt > a", function () {
        $("#create-portfolio").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
     $(document).on("click", ".close-box", function () {
        $("#create-portfolio").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  ============= EMPLOYEE EDIT FUNCTION =========

     $(document).on("click", ".emp-open", function () {
        $("#total-employes").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });
    $(document).on("click", ".close-box", function () {
        $("#total-employes").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });

    //  =============== Ask a Question Popup ============


    $(document).on("click", ".ask-question", function () {
        $("#question-box").addClass("open");
        $(".wrapper").addClass("overlay");
        return false;
    });

    $(document).on("click", ".close-box", function () {
        $("#question-box").removeClass("open");
        $(".wrapper").removeClass("overlay");
        return false;
    });


    //  ============== ChatBox ============== 


    $(document).on("click", ".chat-mg", function () {
        $(this).next(".conversation-box").toggleClass("active");
        return false;
    });
    $(document).on("click", ".close-chat", function () {
        $(".conversation-box").removeClass("active");
        return false;
    });

    //  ================== Edit Options Function =================


     $(document).on("click", ".ed-opts-open", function () {
        $(this).next(".ed-options").toggleClass("active");
        return false;
    });


    // ============== Menu Script =============

    $(document).on("click", ".menu-btn > a", function () {
        $("nav").toggleClass("active");
        return false;
    });


    //  ============ Notifications Open =============

     $(document).on("click", ".not-box-open", function () {
        $(this).next(".notification-box").toggleClass("active");
    });

    // ============= User Account Setting Open ===========

   $(document).on("click", ".user-info", function () {
        $(this).next(".user-account-settingss").toggleClass("active");
    });

    //  ============= FORUM LINKS MOBILE MENU FUNCTION =========

    $(document).on("click", ".forum-links-btn > a", function () {
        $(".forum-links").toggleClass("active");
        return false;
    });
     $(document).on("click", "html", function () {
        $(".forum-links").removeClass("active");
    });
     $(document).on("click", ".forum-links-btn > a, .forum-links", function (e) {
        e.stopPropagation();
    });


    this.window.initscript = () => {
        //  ============= COVER GAP FUNCTION =========

        var gap = $(".container").offset().left;
        $(".cover-sec > a, .chatbox-list").css({
            "right": gap
        });

    //  ============= PORTFOLIO SLIDER FUNCTION =========

        $('.profiles-slider').slick({
            slidesToShow: 3,
            slick: true,
            slidesToScroll: 1,
            prevArrow: '<span class="slick-previous"></span>',
            nextArrow: '<span class="slick-nexti"></span>',
            autoplay: true,
            dots: false,
            autoplaySpeed: 2000,
            responsive: [
                {
                    breakpoint: 1200,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 1,
                        infinite: true,
                        dots: false
                    }
                },
                {
                    breakpoint: 991,
                    settings: {
                        slidesToShow: 2,
                        slidesToScroll: 2
                    }
                },
                {
                    breakpoint: 768,
                    settings: {
                        slidesToShow: 1,
                        slidesToScroll: 1
                    }
                }
                // You can unslick at a given breakpoint now by adding:
                // settings: "unslick"
                // instead of a settings object
            ]


        });
    }

    // used in RedirectToLogin
    this.window.getUrlReferrer = () => {
        return document.referrer;
    }


    this.window.setSelectedLang=(lang)=>
    {
        //    direction: rtl;
       // text - align: right;
        localStorage.setItem("lang", lang);
    }

    this.window.getSelectedLang = (lang) => {
        localStorage.getItem("lang");
    }


  

 

   

    window.blazorExtensions = {

        WriteCookie: function (name, value, days) {

            var expires;
            if (days) {
                var date = new Date();
                date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
                expires = "; expires=" + date.toGMTString();
            }
            else {
                expires = "";
            }
            document.cookie = name + "=" + value + expires + "; path=/";

            // swap file to translate
           // fixLang(value);

          // let value = getCookie("Translate");

            if (value == "en") {
                removejscssfile("template/css/StyleAr.css", "css");
               // createjscssfile("template/css/StyleAr.css", "css");
            } else // ar
            {
                $('head').append(createjscssfile("template/css/StyleAr.css", "css"));
             //   createjscssfile("template/css/StyleAr.css", "css");
            }
           
        }

    }

    //this.window.loadImage = (input) => {

    //    input.

    //}


});



$(document).ready(() => {

   let value = getCookie("Translate");

   if (value == "en") {
       removejscssfile("template/css/StyleAr.css", "css");
   } else // ar
   {
       $('head').append(createjscssfile("template/css/StyleAr.css", "css"));
   }
});



function replacejscssfile(oldfilename, newfilename, filetype) {
    var targetelement = (filetype == "js") ? "script" : (filetype == "css") ? "link" : "none" //determine element type to create nodelist using
    var targetattr = (filetype == "js") ? "src" : (filetype == "css") ? "href" : "none" //determine corresponding attribute to test for
    var allsuspects = document.getElementsByTagName(targetelement)
    for (var i = allsuspects.length; i >= 0; i--) { //search backwards within nodelist for matching elements to remove
        if (allsuspects[i] && allsuspects[i].getAttribute(targetattr) != null && allsuspects[i].getAttribute(targetattr).indexOf(oldfilename) != -1) {
            var newelement = createjscssfile(newfilename, filetype)
            allsuspects[i].parentNode.replaceChild(newelement, allsuspects[i])
        }
    }
}


function createjscssfile(filename, filetype) {
    if (filetype == "js") { //if filename is a external JavaScript file
        var fileref = document.createElement('script')
        fileref.setAttribute("type", "text/javascript")
        fileref.setAttribute("src", filename)
    }
    else if (filetype == "css") { //if filename is an external CSS file
        var fileref = document.createElement("link")
        fileref.setAttribute("rel", "stylesheet")
        fileref.setAttribute("type", "text/css")
        fileref.setAttribute("href", filename)
    }
    return fileref
}

function removejscssfile(filename, filetype) {
    var targetelement = (filetype == "js") ? "script" : (filetype == "css") ? "link" : "none" //determine element type to create nodelist from
    var targetattr = (filetype == "js") ? "src" : (filetype == "css") ? "href" : "none" //determine corresponding attribute to test for
    var allsuspects = document.getElementsByTagName(targetelement)
    for (var i = allsuspects.length; i >= 0; i--) { //search backwards within nodelist for matching elements to remove
        if (allsuspects[i] && allsuspects[i].getAttribute(targetattr) != null && allsuspects[i].getAttribute(targetattr).indexOf(filename) != -1)
            allsuspects[i].parentNode.removeChild(allsuspects[i]) //remove element by calling parentNode.removeChild()
    }
}

function getCookie(name) {
    const value = `; ${document.cookie}`;
    const parts = value.split(`; ${name}=`);
    if (parts.length === 2) return parts.pop().split(';').shift();
}


//$(document).ready(() => {

//    $(document).on("click",".ask-question", function () {
//        $("#question-box").addClass("open");
//        $(".wrapper").addClass("overlay");
//        return false;
//    });

//})
