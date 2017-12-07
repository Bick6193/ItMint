var f = function () {
  OpenBox({
    wrap: '#nav',
    link: '.toogle-menu',
    box: '.menu-holder',
    openClass: 'open'
  });
  initHeader();
  initMap();
  initCounter();
  initSteps();
  initGallery();
  initGoTo();

  if (is_touch_device()) {
    $('body').addClass('touchDevice');
  }
  ;
  jQuery('form').customForm();
  $('div.file-btn').customFile();
  $('.simplebox').simplebox({
    fixed: true,
    overlay: {
      color: '#1e2833',
      opacity: 1
    },
    onOpen: function () {
      $('body').css({overflow: 'hidden'});
    },
    afterOpen: function () {
      $('#nav').trigger('close');
      $('body').css({overflow: 'hidden'});
    },
    onClose: function () {
      $('body').css({overflow: 'auto'});
    }
  });

};

$(f());

jQuery(window).load(function () {
  pageInit.init();
});
var myExtObj = jQuery(window).load(function () {
  pageInit.init();
});

function is_touch_device() {
  return (('ontouchstart' in window)
    || (navigator.MaxTouchPoints > 0)
    || (navigator.msMaxTouchPoints > 0));
}


function initGoTo() {
  var head = $('#header');
  var flag = false, h = head.outerHeight();
  $('.go-to').click(function () {
    flag = false;
    if (!head.hasClass('fixed-header')) flag = true;
    if (flag) head.addClass('fixed-header');
    h = head.outerHeight();
    if (flag) head.removeClass('fixed-header');
    $('html, body').animate({scrollTop: $($(this).attr('href')).offset().top - h}, 500);

    return false;
  });
}

function initGallery() {
  var link = $('#header .aside-nav > .link');
  $('.gallery-brands, .gallery-statistics, .gallery-clients, .gallery-projects').each(function () {
    var hold = $(this);
    var time;

    if (link.is(':hidden')) hold.gallery({
      oneSlide: true,
      disableBtn: 'disabled',
      autoHeight: hold.hasClass('gallery-projects'),
      switcher: "ul.switcher > li"
    });

    $(window).bind('resize', function () {
      if (time) clearTimeout(time);
      time = setTimeout(function () {
        if (link.is(':hidden')) {
          if (!hold.data('gallery')) hold.gallery({
            oneSlide: true,
            disableBtn: 'disabled',
            autoHeight: hold.hasClass('gallery-projects'),
            switcher: "ul.switcher > li"
          });
        }
        else {
          if (hold.data('gallery')) hold.gallery('destroy');
        }
      }, 300);
    });
  });
}

function initSteps() {
  $('.wrap-steps .item-step').each(function () {
    var hold = $(this);
    var link = hold.find('.title-step');
    var box = hold.find('.box-open');

    link.click(function () {
      if (!hold.hasClass('open')) {
        hold.addClass('open');
        box.css({display: 'none'}).slideDown(300);
      }
      else {
        box.slideUp(300, function () {
          hold.removeClass('open');
        });
      }
      return false;
    });
  });
}

function initCounter() {
  $('.gallery-statistics .number').each(function (i) {
    var hold = $(this);
    var k = hold.data('number');
    var count = 0;
    var time;
    var sec = 1; // time in seconds

    hold.parents('.gallery-statistics').eq(0).bind('visible', function () {
      setTimeout(function () {
        time = setInterval(function () {
          hold.text(Math.round(k / (50 * sec) * count));
          if (count == (50 * sec)) clearTimeout(time);
          else count++;
        }, 20);
      }, 500 * i);
    });
  });
}

function initMap() {
  $('.hold-map').each(function () {
    var hold = $(this);
    var link = hold.find('.point-middle');
    var points = hold.find('.point').not('.point-middle');

    time = setInterval(function () {
      link.addClass('active');
      setTimeout(function () {
        link.removeClass('active');
        setTimeout(function () {
          points.eq(Math.round((points.length - 1) * Math.random())).addClass('active');
          setTimeout(function () {
            points.removeClass('active');
          }, 1700);
        }, 500);
      }, 800);
    }, 3500);
  });
}

function initHeader() {
  $('#header').each(function () {
    var hold = $(this);
    var st = hold.find('.aside-nav > .link');

    var _scroll = function (e) {
      if ($(window).scrollTop() > (st.is(':visible') ? 40 : 0)) {
        hold.addClass('fixed-header');
      }
      else {
        hold.removeClass('fixed-header');
      }
    }

    _scroll();
    $(window).bind('scroll', _scroll);
  });
}

function OpenBox(obj) {
  $(obj.wrap).each(function () {
    var hold = $(this);
    var link = hold.find(obj.link);
    var box = hold.find(obj.box);
    var w = obj.w;
    var close = hold.find(obj.close);

    link.click(function () {
      $(obj.wrap).not(hold).removeClass(obj.openClass);
      if (!hold.hasClass(obj.openClass)) {
        if (obj.wrap == '#nav') $('body').css({overflow: 'hidden'});
        hold.addClass(obj.openClass);
      }
      else {
        if (obj.wrap == '#nav') $('body').removeAttr('style');
        hold.removeClass(obj.openClass);
      }
      return false;
    });

    hold.bind('close', function () {
      $('body').removeAttr('style');
      hold.removeClass(obj.openClass);
    });

    hold.hover(function () {
      $(this).addClass('hovering');
    }, function () {
      $(this).removeClass('hovering');
    });

    $("body").click(function () {
      if (!hold.hasClass('hovering')) {
        hold.removeClass(obj.openClass);
      }
    });
    close.click(function () {
      hold.removeClass(obj.openClass);
      return false;
    });
  });
}

var pageInit = {
    init: function () {
      this.animStart();
    },

    animStart: function () {
      var castom = 5;

      function all() {
        $('.start-anim').each(function () {
          if ($(this).offset().top <= $(window).scrollTop() + $(window).height() - ($(window).height() / castom)) {
            if (!$(this).hasClass('visible')) {
              $(this).addClass('visible');
              $(this).trigger('visible');
            }
          }
        });
      }

      $(window).bind('scroll resize', function () {
        all();
      });
      all();
    }
  }

  /**
   * jQuery gallery v2.3.0
   * Copyright (c) 2013 JetCoders
   * email: yuriy.shpak@jetcoders.com
   * www: JetCoders.com
   * Licensed under the MIT License:
   * http://www.opensource.org/licenses/mit-license.php
   **/

;(function ($) {
  var _installDirections = function (data) {
      data.holdWidth = data.list.parent().outerWidth();
      data.woh = data.elements.outerWidth(true);
      if (!data.direction) data.parentSize = data.holdWidth; else {
        data.woh = data.elements.outerHeight(true);
        data.parentSize = data.list.parent().height()
      }
      data.wrapHolderW = Math.ceil(data.parentSize / data.woh);
      if ((data.wrapHolderW - 1) * data.woh + data.woh / 2 > data.parentSize) data.wrapHolderW--;
      if (data.wrapHolderW == 0) data.wrapHolderW = 1
    }, _dirAnimate = function (data) {
      if (!data.direction) return {
        left: -(data.woh *
          data.active)
      }; else return {top: -(data.woh * data.active)}
    }, _initDisableBtn = function (data) {
      data.prevBtn.removeClass(data.disableBtn);
      data.nextBtn.removeClass(data.disableBtn);
      if (data.active == 0 || data.count + 1 == data.wrapHolderW - 1) data.prevBtn.addClass(data.disableBtn);
      if (data.active == 0 && data.count + 1 == 1 || data.count + 1 <= data.wrapHolderW - 1) data.nextBtn.addClass(data.disableBtn);
      if (data.active == data.rew) data.nextBtn.addClass(data.disableBtn)
    }, _initEvent = function (data, btn, side) {
      btn.bind(data.event + ".gallery",
        function () {
          if (data.flag) {
            if (data.infinite) data.flag = false;
            if (data._t) clearTimeout(data._t);
            _toPrepare(data, side);
            if (data.autoRotation) _runTimer(data);
            if (typeof data.onChange == "function") data.onChange({data: data})
          }
          if (data.event == "click") return false
        })
    }, _initEventSwitcher = function (data) {
      data.switcher.bind(data.event + ".gallery", function () {
        if (data.flag && !$(this).hasClass(data.activeClass)) {
          if (data.infinite) data.flag = false;
          data.active = data.switcher.index(jQuery(this)) * data.slideElement;
          if (data.infinite) data.active =
            data.switcher.index(jQuery(this)) + data.count;
          if (data._t) clearTimeout(data._t);
          if (data.disableBtn) _initDisableBtn(data);
          if (!data.effect) _scrollElement(data); else _fadeElement(data);
          if (data.autoRotation) _runTimer(data);
          if (typeof data.onChange == "function") data.onChange({data: data})
        }
        if (data.event == "click") return false
      })
    }, _toPrepare = function (data, side) {
      if (!data.infinite) {
        if (data.active == data.rew && data.circle && side) data.active = -data.slideElement;
        if (data.active == 0 && data.circle && !side) data.active = data.rew +
          data.slideElement;
        for (var i = 0; i < data.slideElement; i++) if (side) {
          if (data.active + 1 <= data.rew) data.active++
        } else if (data.active - 1 >= 0) data.active--
      } else {
        if (data.active >= data.count + data.count && side) data.active -= data.count;
        if (data.active <= data.count - 1 && !side) data.active += data.count;
        data.list.css(_dirAnimate(data));
        if (side) data.active += data.slideElement; else data.active -= data.slideElement
      }
      if (data.disableBtn) _initDisableBtn(data);
      if (!data.effect) _scrollElement(data); else _fadeElement(data)
    }, _fadeElement = function (data) {
      data.list.removeClass(data.activeClass).css({zIndex: 1});
      data.list.eq(data.last).stop().css({zIndex: 2, opacity: 1});
      if (data.effect == "transparent") data.list.eq(data.last).animate({opacity: 0}, {
        queue: false,
        duration: data.duration
      });
      data.list.eq(data.active).addClass(data.activeClass).css({
        opacity: 0,
        zIndex: 3
      }).animate({opacity: 1}, {
        queue: false, duration: data.duration, complete: function () {
          jQuery(this).css("opacity", "auto")
        }
      });
      if (data.autoHeight) data.list.parent().animate({height: data.list.eq(data.active).outerHeight()}, {
        queue: false,
        duration: data.duration
      });
      if (data.switcher) data.switcher.removeClass(data.activeClass).eq(data.active).addClass(data.activeClass);
      data.last = data.active
    }, _scrollElement = function (data) {
      data.elements.removeClass("active").eq(data.active).addClass(data.activeClass);
      if (!data.infinite) data.list.animate(_dirAnimate(data), {
        queue: false,
        easing: data.easing,
        duration: data.duration
      }); else {
        data.list.animate(_dirAnimate(data), data.duration, data.easing, function () {
          if (data.active >= data.count + data.count) data.active -= data.count;
          if (data.active <= data.count - 1) data.active += data.count;
          data.list.css(_dirAnimate(data));
          data.flag = true
        });
        data.elements.eq(data.active -
          data.count).addClass(data.activeClass);
        data.elements.eq(data.active + data.count).addClass(data.activeClass)
      }
      if (data.autoHeight) data.list.parent().animate({height: data.list.children().eq(data.active).outerHeight()}, {
        queue: false,
        duration: data.duration
      });
      if (data.switcher) if (!data.infinite) data.switcher.removeClass(data.activeClass).eq(Math.ceil(data.active / data.slideElement)).addClass(data.activeClass); else {
        data.switcher.removeClass(data.activeClass).eq(data.active - data.count).addClass(data.activeClass);
        data.switcher.removeClass(data.activeClass).eq(data.active - data.count - data.count).addClass(data.activeClass);
        data.switcher.eq(data.active).addClass(data.activeClass)
      }
    }, _runTimer = function (data) {
      if (data._t) clearTimeout(data._t);
      data._t = setInterval(function () {
        if (data.infinite) data.flag = false;
        _toPrepare(data, true);
        if (typeof data.onChange == "function") data.onChange({data: data})
      }, data.autoRotation)
    }, _rePosition = function (data) {
      if (data.flexible && !data.direction) {
        _installDirections(data);
        if (data.oneSlide) data.elements.css({width: data.holdWidth});
        else if (data.elements.length * data.minWidth > data.holdWidth) {
          data.elements.css({width: Math.floor(data.holdWidth / Math.floor(data.holdWidth / data.minWidth))});
          if (data.elements.outerWidth(true) > Math.floor(data.holdWidth / Math.floor(data.holdWidth / data.minWidth))) data.elements.css({width: Math.floor(data.holdWidth / Math.floor(data.holdWidth / data.minWidth)) - (data.elements.outerWidth(true) - Math.floor(data.holdWidth / Math.floor(data.holdWidth / data.minWidth)))})
        } else {
          data.active = 0;
          data.elements.css({
            width: Math.floor(data.holdWidth /
              data.elements.length)
          })
        }
      }
      _installDirections(data);
      if (!data.effect) {
        data.rew = data.count - data.wrapHolderW + 1;
        if (data.active > data.rew && !data.infinite) data.active = data.rew;
        if (data.active - data.count > data.rew && data.infinite) data.active = data.rew;
        data.list.css({position: "relative"}).css(_dirAnimate(data));
        if (data.autoHeight) data.list.parent().css({height: data.list.children().eq(data.active).outerHeight()})
      } else {
        data.rew = data.count;
        data.list.css({opacity: 0}).removeClass(data.activeClass).eq(data.active).addClass(data.activeClass).css({opacity: 1}).css("opacity",
          "auto");
        if (data.autoHeight) data.list.parent().css({height: data.list.eq(data.active).outerHeight()})
      }
      if (data.switcher) if (!data.infinite) data.switcher.removeClass(data.activeClass).eq(Math.ceil(data.active / data.slideElement)).addClass(data.activeClass); else {
        data.switcher.removeClass(data.activeClass).eq(data.active - data.count).addClass(data.activeClass);
        data.switcher.removeClass(data.activeClass).eq(data.active - data.count - data.count).addClass(data.activeClass);
        data.switcher.eq(data.active).addClass(data.activeClass)
      }
      if (data.disableBtn) _initDisableBtn(data)
    },
    _initTouchEvent = function (data) {
      var span = $("<span></span>");
      var touchOnGallery = false;
      var startTouchPos, listPosNow, side, start;
      span.css({
        position: "absolute",
        left: 0,
        top: 0,
        width: 9999,
        height: 9999,
        cursor: "pointer",
        zIndex: 9999,
        display: "none"
      });
      data.list.parent().css({position: "relative"}).append(span);
      data.list.bind("mousedown.gallery touchstart.gallery", function (e) {
        touchOnGallery = true;
        startTouchPos = e.originalEvent.touches ? e.originalEvent.touches[0].pageX : e.pageX;
        data.list.stop();
        start = 0;
        listPosNow = data.list.position().left;
        if (e.type == "mousedown") e.preventDefault()
      });
      $(document).bind("mousemove.gallery touchmove.gallery", function (e) {
        if (touchOnGallery && Math.abs(startTouchPos - (e.originalEvent.touches ? e.originalEvent.touches[0].pageX : e.pageX)) > 10) {
          span.css({display: "block"});
          start = (e.originalEvent.touches ? e.originalEvent.touches[0].pageX : e.pageX) - startTouchPos;
          if (!data.effect) data.list.css({left: listPosNow + start});
          return false
        }
      }).bind("mouseup.gallery touchend.gallery", function (e) {
        if (touchOnGallery && span.is(":visible")) {
          span.css({display: "none"});
          if (!data.infinite) if (!data.effect) if (data.list.position().left > 0) {
            data.active = 0;
            _scrollElement(data)
          } else if (data.list.position().left < -data.woh * data.rew) {
            data.active = data.rew;
            _scrollElement(data)
          } else {
            data.active = Math.floor(data.list.position().left / -data.woh);
            if (start < 0) data.active += 1;
            _scrollElement(data)
          } else {
            if (start < 0) _toPrepare(data, true);
            if (start > 0) _toPrepare(data, false)
          } else {
            if (data.list.position().left > -data.woh * data.count) data.list.css({left: data.list.position().left - data.woh * data.count});
            if (data.list.position().left < -data.woh * data.count * 2) data.list.css({left: data.list.position().left + data.woh * data.count});
            data.active = Math.floor(data.list.position().left / -data.woh);
            if (start < 0) data.active += 1;
            _scrollElement(data)
          }
          if (data.disableBtn) _initDisableBtn(data);
          if (typeof data.onChange == "function") data.onChange({data: data});
          if (data.autoRotation) _runTimer(data);
          touchOnGallery = false
        } else touchOnGallery = false
      })
    }, methods = {
      init: function (options) {
        return this.each(function () {
          var $this = $(this);
          $this.data("gallery",
            jQuery.extend({}, defaults, options));
          var data = $this.data("gallery");
          data.aR = data.autoRotation;
          data.context = $this;
          data.list = data.context.find(data.elements);
          data.elements = data.list;
          if (data.elements.css("position") == "absolute" && data.autoDetect && !data.effect) data.effect = true;
          data.count = data.list.index(data.list.filter(":last"));
          if (!data.effect) data.list = data.list.parent();
          data.switcher = data.context.find(data.switcher);
          if (data.switcher.length == 0) data.switcher = false;
          if (data.nextBtn) data.nextBtn = data.context.find(data.nextBtn);
          if (data.prevBtn) data.prevBtn = data.context.find(data.prevBtn);
          if (data.switcher) data.active = data.switcher.index(data.switcher.filter("." + data.activeClass + ":eq(0)")); else data.active = data.elements.index(data.elements.filter("." + data.activeClass + ":eq(0)"));
          if (data.active < 0) data.active = 0;
          data.last = data.active;
          if (data.oneSlide) data.flexible = true;
          if (data.flexible && !data.direction) data.minWidth = data.elements.outerWidth(true);
          _rePosition(data);
          if (data.flexible && !data.direction) $(window).bind("resize.gallery",
            function () {
              _rePosition(data)
            });
          data.flag = true;
          if (data.infinite) {
            data.count++;
            data.active += data.count;
            data.list.append(data.elements.clone());
            data.list.append(data.elements.clone());
            data.list.css(_dirAnimate(data));
            data.elements = data.list.children()
          }
          if (data.rew < 0 && !data.effect) {
            data.list.css({left: 0});
            return false
          }
          if (data.list.length <= 1 && data.effect) return $this;
          if (data.nextBtn) _initEvent(data, data.nextBtn, true);
          if (data.prevBtn) _initEvent(data, data.prevBtn, false);
          if (data.switcher) _initEventSwitcher(data);
          if (data.autoRotation) _runTimer(data);
          if (data.touch) _initTouchEvent(data);
          if (typeof data.onChange == "function") data.onChange({data: data})
        })
      }, option: function (name, set) {
        if (set) return this.each(function () {
          var data = $(this).data("gallery");
          if (data) data[name] = set
        }); else {
          var ar = [];
          this.each(function () {
            var data = $(this).data("gallery");
            if (data) ar.push(data[name])
          });
          if (ar.length > 1) return ar; else return ar[0]
        }
      }, destroy: function () {
        return this.each(function () {
          var $this = $(this), data = $this.data("gallery");
          if (data) {
            if (data._t) clearTimeout(data._t);
            data.context.find("*").unbind(".gallery");
            $(window).unbind(".gallery");
            $(document).unbind(".gallery");
            data.elements.removeAttr("style");
            data.list.parent().removeAttr("style");
            data.list.removeAttr("style");
            $this.removeData("gallery")
          }
        })
      }, rePosition: function () {
        return this.each(function () {
          var $this = $(this), data = $this.data("gallery");
          _rePosition(data)
        })
      }, stop: function () {
        return this.each(function () {
          var $this = $(this), data = $this.data("gallery");
          data.aR = data.autoRotation;
          data.autoRotation = false;
          if (data._t) clearTimeout(data._t)
        })
      }, play: function (time) {
        return this.each(function () {
          var $this =
            $(this), data = $this.data("gallery");
          if (data._t) clearTimeout(data._t);
          data.autoRotation = time ? time : data.aR;
          if (data.autoRotation) _runTimer(data)
        })
      }, next: function (element) {
        return this.each(function () {
          var $this = $(this), data = $this.data("gallery");
          if (element != "undefined" && element > -1) {
            data.active = element;
            if (data.disableBtn) _initDisableBtn(data);
            if (!data.effect) _scrollElement(data); else _fadeElement(data)
          } else if (data.flag) {
            if (data.infinite) data.flag = false;
            if (data._t) clearTimeout(data._t);
            _toPrepare(data, true);
            if (data.autoRotation) _runTimer(data);
            if (typeof data.onChange == "function") data.onChange({data: data})
          }
        })
      }, prev: function () {
        return this.each(function () {
          var $this = $(this), data = $this.data("gallery");
          if (data.flag) {
            if (data.infinite) data.flag = false;
            if (data._t) clearTimeout(data._t);
            _toPrepare(data, false);
            if (data.autoRotation) _runTimer(data);
            if (typeof data.onChange == "function") data.onChange({data: data})
          }
        })
      }
    }, defaults = {
      infinite: false,
      activeClass: "active",
      duration: 300,
      slideElement: 1,
      autoRotation: false,
      effect: false,
      elements: "ul:eq(0) > li",
      switcher: ".switcher > li",
      disableBtn: false,
      nextBtn: "a.link-next, a.btn-next, .next",
      prevBtn: "a.link-prev, a.btn-prev, .prev",
      circle: true,
      direction: false,
      event: "click",
      autoHeight: false,
      easing: "easeOutQuad",
      flexible: false,
      oneSlide: false,
      autoDetect: true,
      touch: true,
      onChange: null
    };
  $.fn.gallery = function (method) {
    if (methods[method]) return methods[method].apply(this, Array.prototype.slice.call(arguments, 1)); else if (typeof method === "object" || !method) return methods.init.apply(this, arguments);
    else $.error("Method " + method + " does not exist on jQuery.gallery")
  };
  jQuery.easing["jswing"] = jQuery.easing["swing"];
  jQuery.extend(jQuery.easing, {
    def: "easeOutQuad", swing: function (x, t, b, c, d) {
      return jQuery.easing[jQuery.easing.def](x, t, b, c, d)
    }, easeOutQuad: function (x, t, b, c, d) {
      return -c * (t /= d) * (t - 2) + b
    }, easeOutCirc: function (x, t, b, c, d) {
      return c * Math.sqrt(1 - (t = t / d - 1) * t) + b
    }
  })
})(jQuery);

/**
 * jQuery Custom Form min v1.3.0
 * Copyright (c) 2014 JetCoders
 * email: yuriy.shpak@jetcoders.com
 * www: JetCoders.com
 * Licensed under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 **/

jQuery.fn.customForm = jQuery.customForm = function (_options) {
  var _this = this;
  var methods = {
    destroy: function () {
      var elements;
      if (typeof this === "function") elements = $("select, input:radio, input:checkbox"); else elements = this.add(this.find("select, input:radio, input:checkbox"));
      elements.each(function () {
        var data = $(this).data("customForm");
        if (data) {
          $(this).removeClass("outtaHere");
          if (data["events"]) data["events"].unbind(".customForm");
          if (data["create"]) data["create"].remove();
          if (data["resizeElement"]) data.resizeElement =
            false;
          $(this).unbind(".customForm")
        }
      })
    }, refresh: function () {
      if (typeof this === "function") $("select, input:radio, input:checkbox").trigger("refresh"); else this.trigger("refresh")
    }
  };
  if (typeof _options === "object" || !_options) {
    if (typeof _this == "function") _this = $(document);
    var options = jQuery.extend(true, {
      select: {
        elements: "select.customSelect",
        structure: '<div class="selectArea"><a tabindex="-1" href="#" class="selectButton"><span></span><span class="right">&nbsp;</span></a><div class="disabled"></div></div>',
        text: "span:first",
        btn: ".selectButton",
        optStructure: '<div class="selectOptions"><ul></ul></div>',
        maxHeight: false,
        topClass: "position-top",
        optList: "ul",
        nativeDrop: false
      },
      radio: {
        elements: "input.customRadio",
        structure: "<div></div>",
        defaultArea: "radioArea",
        checked: "radioAreaChecked"
      },
      checkbox: {
        elements: "input.customCheckbox",
        structure: "<div></div>",
        defaultArea: "checkboxArea",
        checked: "checkboxAreaChecked"
      },
      mobile: /(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od|ad)|iris|kindle|lge |maemo|midp|mmp|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino/i.test(navigator.userAgent ||
        navigator.vendor || window.opera) || /1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-/i.test((navigator.userAgent ||
        navigator.vendor || window.opera).substr(0, 4)),
      disabled: "disabled",
      hoverClass: "hover"
    }, _options);
    return _this.each(function () {
      var hold = jQuery(this);
      var reset = jQuery();
      if (this !== document) reset = hold.find("input:reset, button[type=reset]");
      initSelect(hold.find(options.select.elements), hold, reset);
      initRadio(hold.find(options.radio.elements), hold, reset);
      initCheckbox(hold.find(options.checkbox.elements), hold, reset)
    })
  } else if (methods[_options]) methods[_options].apply(this);

  function initSelect(elements, form,
                      reset) {
    elements.not(".outtaHere").each(function () {
      var select = $(this);
      var replaced = jQuery(options.select.structure);
      var selectText = replaced.find(options.select.text);
      var selectBtn = replaced.find(options.select.btn);
      var selectDisabled = replaced.find("." + options.disabled).hide();
      var optHolder = jQuery(options.select.optStructure);
      var optList = optHolder.find(options.select.optList);
      var html = "";
      var optTimer;
      if (select.prop("disabled")) selectDisabled.show();
      if (options.mobile) select.addClass("mobile");

      function createStructure() {
        html =
          "";
        select.find("option").each(function () {
          var selOpt = jQuery(this);
          if (selOpt.prop("selected") && !select.data("placeholder")) selectText.html(selOpt.html()).addClass(selOpt.attr("class"));
          html += '<li data-value="' + selOpt.val() + '" class="' + (selOpt.attr("class") ? selOpt.attr("class") : "") + " " + (selOpt.prop("selected") ? "selected" : "") + '">' + (selOpt.prop("disabled") ? "<span>" : '<a href="#">') + selOpt.html() + (selOpt.prop("disabled") ? "</span>" : "</a>") + "</li>"
        });
        if (select.data("placeholder")) {
          selectText.html(select.data("placeholder"));
          replaced.addClass("placeholder");
          select.val("-")
        }
        optList.append(html).find("a").click(function () {
          replaced.removeClass("placeholder");
          select.val(jQuery(this).parent().data("value").toString());
          select.change();
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999});
          return false
        });
        if (select.data("customForm") !== undefined && select.data("customForm")["resizeElement"]) select.data("customForm").resizeElement()
      }

      createStructure();
      replaced.width(select.outerWidth());
      replaced.insertBefore(select);
      replaced.addClass(select.attr("class"));
      optHolder.css({width: select.outerWidth(), position: "absolute", left: -9999, top: -9999});
      optHolder.addClass(select.attr("class"));
      replaced.append(optHolder);
      select.bind("refresh", function () {
        optList.empty();
        createStructure()
      });
      replaced.hover(function () {
        if (optTimer) clearTimeout(optTimer)
      }, function () {
        optTimer = setTimeout(function () {
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999})
        }, 200)
      });
      optHolder.hover(function () {
          if (optTimer) clearTimeout(optTimer)
        },
        function () {
          optTimer = setTimeout(function () {
            replaced.removeClass(options.hoverClass);
            optHolder.css({left: -9999, top: -9999})
          }, 200)
        });
      if (options.select.maxHeight && optHolder.children().height() > options.select.maxHeight) optHolder.children().css({
        height: options.select.maxHeight,
        overflow: "auto"
      });
      if (options.mobile) $(document).bind("touchstart.customForm", function (e) {
        if (!($(e.target).parents().index(optHolder) != -1 || $(e.target).index(optHolder) != -1)) {
          replaced.removeClass(options.hoverClass);
          optHolder.css({
            left: -9999,
            top: -9999
          })
        }
      });
      selectBtn.click(function () {
        if (optHolder.offset().left > 0) {
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999})
        } else openDrop();
        return false
      });
      reset.click(function () {
        setTimeout(function () {
          select.find("option").each(function (i) {
            var selOpt = jQuery(this);
            if (selOpt.val() == select.val()) {
              selectText.html(selOpt.html());
              optList.find("li").removeClass("selected");
              optList.find("li").eq(i).addClass("selected")
            }
          })
        }, 10)
      });
      var openDrop = function () {
        replaced.addClass(options.hoverClass);
        select.attr("style", "height: 0 !important;").removeClass("outtaHere");
        optHolder.css({width: select.outerWidth(), top: -9999});
        select.addClass("outtaHere").removeAttr("style");
        if (options.select.maxHeight && optHolder.children().height() > options.select.maxHeight) optHolder.children().css({
          height: options.select.maxHeight,
          overflow: "auto"
        });
        if ($(window).height() + $(window).scrollTop() > optHolder.outerHeight(true) + replaced.offset().top + replaced.outerHeight()) {
          optHolder.removeClass(options.select.topClass).css({
            top: replaced.outerHeight(),
            left: 0
          });
          replaced.removeClass(options.select.topClass)
        } else {
          optHolder.addClass(options.select.topClass).css({top: replaced.outerHeight(), left: 0});
          replaced.addClass(options.select.topClass)
        }
        replaced.focus()
      };
      var changeSelect = function (e) {
        select.find("option").each(function (i) {
          var selOpt = jQuery(this);
          if (selOpt.val() == select.val()) {
            selectText.html(selOpt.html());
            selectText.removeClass().addClass(selOpt.attr("class") ? selOpt.attr("class") : "");
            optList.find("li").removeClass("selected");
            optList.find("li").eq(i).addClass("selected")
          }
        });
        if ((e.keyCode == 13 || e.keyCode == 27) && replaced.hasClass(options.hoverClass)) {
          replaced.removeClass(options.hoverClass);
          optHolder.css({left: -9999, top: -9999})
        } else if (e.keyCode == 13 && !replaced.hasClass(options.hoverClass)) openDrop()
      };
      select.bind("change.customForm", changeSelect);
      select.get(0).onkeyup = select.get(0).onkeydown = select.get(0).onkeypress = changeSelect;
      select.bind("focus.customForm", function () {
        replaced.addClass("focus");
        select.attr("size", 4)
      }).bind("blur.customForm", function () {
        replaced.removeClass("focus");
        select.removeAttr("size")
      });
      select.data("customForm", {
        "resizeElement": function () {
          select.removeClass("outtaHere");
          replaced.width(Math.floor(select.outerWidth()));
          select.addClass("outtaHere")
        }, "create": replaced.add(optHolder)
      });
      $(window).bind("resize.customForm", function () {
        if (select.data("customForm")["resizeElement"]) select.data("customForm").resizeElement()
      })
    }).addClass("outtaHere")
  }

  function initRadio(elements, form, reset) {
    elements.each(function () {
      var radio = $(this);
      if (!radio.hasClass("outtaHere") &&
        radio.is(":radio")) {
        radio.data("customRadio", {
          radio: radio,
          name: radio.attr("name"),
          label: $("label[for=" + radio.attr("id") + "]").length ? $("label[for=" + radio.attr("id") + "]") : radio.parents("label"),
          replaced: jQuery(options.radio.structure, {"class": radio.attr("class")})
        });
        radio.data("customRadio").replaced.addClass(radio.attr("class"));
        var data = radio.data("customRadio");
        if (radio.is(":disabled")) {
          data.replaced.addClass(options.disabled);
          if (radio.is(":checked")) data.replaced.addClass("disabledChecked")
        } else if (radio.is(":checked")) {
          data.replaced.addClass(options.radio.checked);
          data.label.addClass("checked")
        } else {
          data.replaced.addClass(options.radio.defaultArea);
          data.label.removeClass("checked")
        }
        data.replaced.click(function () {
          if (jQuery(this).hasClass(options.radio.defaultArea)) {
            radio.change();
            radio.prop("checked", true);
            changeRadio(data)
          }
        });
        reset.click(function () {
          setTimeout(function () {
            if (radio.is(":checked")) data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.checked); else data.replaced.removeClass(options.radio.defaultArea +
              " " + options.radio.checked).addClass(options.radio.defaultArea)
          }, 10)
        });
        radio.bind("refresh", function () {
          if (radio.is(":checked")) {
            data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.checked);
            data.label.addClass("checked")
          } else {
            data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.defaultArea);
            data.label.removeClass("checked")
          }
        });
        radio.bind("click.customForm", function () {
          changeRadio(data)
        });
        radio.bind("focus.customForm",
          function () {
            data.replaced.addClass("focus")
          }).bind("blur.customForm", function () {
          data.replaced.removeClass("focus")
        });
        data.replaced.insertBefore(radio);
        radio.addClass("outtaHere");
        radio.data("customForm", {"create": data.replaced})
      }
    })
  }

  function changeRadio(data) {
    jQuery('input:radio[name="' + data.name + '"]').not(data.radio).each(function () {
      var _data = $(this).data("customRadio");
      if (_data.replaced && !jQuery(this).is(":disabled")) {
        _data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.defaultArea);
        _data.label.removeClass("checked")
      }
    });
    data.replaced.removeClass(options.radio.defaultArea + " " + options.radio.checked).addClass(options.radio.checked);
    data.label.addClass("checked");
    data.radio.trigger("change")
  }

  function initCheckbox(elements, form, reset) {
    elements.each(function () {
      var checkbox = $(this);
      if (!checkbox.hasClass("outtaHere") && checkbox.is(":checkbox")) {
        checkbox.data("customCheckbox", {
          checkbox: checkbox,
          label: $("label[for=" + checkbox.attr("id") + "]").length ? $("label[for=" + checkbox.attr("id") + "]") :
            checkbox.parents("label"),
          replaced: jQuery(options.checkbox.structure, {"class": checkbox.attr("class")})
        });
        checkbox.data("customCheckbox").replaced.addClass(checkbox.attr("class"));
        var data = checkbox.data("customCheckbox");
        if (checkbox.is(":disabled")) {
          data.replaced.addClass(options.disabled);
          if (checkbox.is(":checked")) data.replaced.addClass("disabledChecked")
        } else if (checkbox.is(":checked")) {
          data.replaced.addClass(options.checkbox.checked);
          data.label.addClass("checked")
        } else {
          data.replaced.addClass(options.checkbox.defaultArea);
          data.label.removeClass("checked")
        }
        data.replaced.click(function () {
          if (!data.replaced.hasClass("disabled") && !data.replaced.parents("label").length) {
            if (checkbox.is(":checked")) checkbox.prop("checked", false); else checkbox.prop("checked", true);
            changeCheckbox(data)
          }
        });
        reset.click(function () {
          setTimeout(function () {
            changeCheckbox(data)
          }, 10)
        });
        checkbox.bind("refresh", function () {
          if (checkbox.is(":checked")) {
            data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.defaultArea).addClass(options.checkbox.checked);
            data.label.addClass("checked")
          } else {
            data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.checked).addClass(options.checkbox.defaultArea);
            data.label.removeClass("checked")
          }
        });
        checkbox.bind("click.customForm", function () {
          changeCheckbox(data)
        });
        checkbox.bind("focus.customForm", function () {
          data.replaced.addClass("focus")
        }).bind("blur.customForm", function () {
          data.replaced.removeClass("focus")
        });
        data.replaced.insertBefore(checkbox);
        checkbox.addClass("outtaHere");
        checkbox.data("customForm",
          {"create": data.replaced, "events": data.replaced.parents("label")})
      }
    })
  }

  function changeCheckbox(data) {
    if (data.checkbox.is(":checked")) {
      data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.defaultArea).addClass(options.checkbox.checked);
      data.label.addClass("checked")
    } else {
      data.replaced.removeClass(options.checkbox.defaultArea + " " + options.checkbox.checked).addClass(options.checkbox.defaultArea);
      data.label.removeClass("checked")
    }
    data.checkbox.trigger("change")
  }
};

/**
 * jQuery Custom File min v1.0.0
 * Copyright (c) 2012 JetCoders
 * email: yuriy.shpak@jetcoders.com
 * www: JetCoders.com
 * Licensed under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 **/

jQuery.fn.customFile = function (_options) {
  var _options = jQuery.extend({
    file: 'input.file-input-area',
    input: 'input.file-text',
    filledClass: 'filled',
    hoverClass: 'hover'
  }, _options);
  return this.each(function () {
    var hold = jQuery(this);
    var file = hold.find(_options.file);
    var input = hold.find(_options.input);

    input.prop('readonly', true);
    file.change(function () {
      input.val(this.value);
      hold.addClass(_options.filledClass);
    }).hover(function () {
      hold.addClass(_options.hoverClass);
    }, function () {
      hold.removeClass(_options.hoverClass);
    });
  });
}

/**
 * jQuery simplebox v1.1.1
 * Copyright (c) 2016 JetCoders
 * email: yuriy.shpak@jetcoders.com
 * www: JetCoders.com
 * Licensed under the MIT License:
 * http://www.opensource.org/licenses/mit-license.php
 **/

;(function ($) {
  var _condition = function (id, options) {
    if ($.simplebox.modal) {
      var data = $.simplebox.modal.data("simplebox");
      data.onClose($.simplebox.modal);
      $.simplebox.modal.fadeOut(data.duration, function () {
        $.simplebox.modal.css({left: "-9999px", top: "-9999px"}).show();
        data.afterClose($.simplebox.modal);
        $.simplebox.modal.removeData("simplebox");
        $.simplebox.modal = false;
        _toPrepare(id, options)
      })
    } else _toPrepare(id, options)
  }, _calcWinWidth = function () {
    return $(document).width() > $("body").width() ? $(document).width() :
      jQuery("body").width()
  }, _toPrepare = function (id, options) {
    $.simplebox.modal = $(id);
    $.simplebox.modal.data("simplebox", options);
    var data = $.simplebox.modal.data("simplebox");
    data.btnClose = $.simplebox.modal.find(data.linkClose);
    var popupTop = $(window).scrollTop() + $(window).height() / 2 - $.simplebox.modal.outerHeight(true) / 2;
    if ($(window).scrollTop() > popupTop) popupTop = $(window).scrollTop();
    if (popupTop + $.simplebox.modal.outerHeight(true) > $(document).height()) popupTop = $(document).height() - $.simplebox.modal.outerHeight(true);
    if (popupTop < 0) popupTop = 0;
    if (!data.positionFrom) $.simplebox.modal.css({
      zIndex: 1E3,
      top: data.fixed ? 0 : popupTop,
      left: data.fixed ? 0 : _calcWinWidth() / 2 - $.simplebox.modal.outerWidth(true) / 2
    }).hide(); else $.simplebox.modal.css({
      zIndex: 1E3,
      top: $(data.positionFrom).offset().top + $(data.positionFrom).outerHeight(true),
      left: $(data.positionFrom).offset().left
    }).hide();
    _initAnimate(data);
    _closeEvent(data, data.btnClose);
    if (data.overlay.closeClick) _closeEvent(data, $.simplebox.overlay)
  }, _initAnimate = function (data) {
    data.onOpen($.simplebox.modal);
    if (data.overlay) $.simplebox.overlay.html(data.overlay.content).css({
      background: data.overlay.color,
      opacity: data.overlay.opacity
    }).fadeIn(data.duration, function () {
      $.simplebox.modal.fadeIn(data.duration, function () {
        $.simplebox.busy = false;
        data.afterOpen($.simplebox.modal);
        if ($(window).scrollTop() > $.simplebox.modal.offset().top && !data.fixed) $("html, body").animate({scrollTop: $.simplebox.modal.offset().top}, 500)
      })
    }); else {
      $.simplebox.overlay.fadeOut(data.duration);
      $.simplebox.modal.fadeIn(data.duration, function () {
        $.simplebox.busy =
          false;
        data.afterOpen($.simplebox.modal);
        if ($(window).scrollTop() > $.simplebox.modal.offset().top) $("html, body").animate({scrollTop: $.simplebox.modal.offset().top}, 500)
      })
    }
  }, _closeEvent = function (data, element) {
    element.unbind("click.simplebox").bind("click.simplebox", function () {
      if (!$.simplebox.busy) {
        $.simplebox.busy = true;
        data.onClose($.simplebox.modal);
        $.simplebox.modal.fadeOut(data.duration, function () {
          $.simplebox.modal.css({left: "-9999px", top: "-9999px"}).show();
          $.simplebox.overlay.fadeOut(data.duration,
            function () {
              data.afterClose($.simplebox.modal);
              $.simplebox.modal.removeData("simplebox");
              $.simplebox.modal = false;
              $.simplebox.busy = false
            })
        })
      }
      return false
    })
  }, _error = function (text) {
    if (typeof console == "object") console.warn(text)
  }, methods = {
    init: function (options) {
      $(this).unbind("click.simplebox").bind("click.simplebox", function () {
        var data = $(this).data("simplebox");
        var id = $(this).attr("href") ? $(this).attr("href") : $(this).data("href");
        if ($(id).length == 0) {
          _error('ID "' + id + '" does not exist on document');
          return false
        }
        if (!$(this).hasClass(defaults.disableClass) &&
          !$.simplebox.busy) {
          $.simplebox.busy = true;
          _condition(id, jQuery.extend(true, {}, defaults, options))
        }
        return false
      });
      return this
    }, option: function (name, set) {
      if (set) return this.each(function () {
        var data = $(this).data("simplebox");
        if (data) data[name] = set
      }); else {
        var ar = [];
        this.each(function () {
          var data = $(this).data("simplebox");
          if (data) ar.push(data[name])
        });
        if (ar.length > 1) return ar; else return ar[0]
      }
    }
  }, defaults = {
    duration: 300, linkClose: ".close, .btn-close", disableClass: "disabled", overlay: {
      box: "simplebox-overlay",
      color: "black", closeClick: true, opacity: .3, content: ""
    }, positionFrom: false, fixed: false, onOpen: function () {
    }, afterOpen: function () {
    }, onClose: function () {
    }, afterClose: function () {
    }
  };
  $.fn.simplebox = function (method) {
    if (methods[method]) return methods[method].apply(this, Array.prototype.slice.call(arguments, 1)); else if (typeof method === "object" || !method) return methods.init.apply(this, arguments); else _error("Method " + method + " does not exist on jQuery.simplebox")
  };
  $.simplebox = function (id, options) {
    if (!$.simplebox.busy) {
      $.simplebox.busy =
        true;
      _condition(id, jQuery.extend(true, {}, defaults, options))
    }
  };
  $.simplebox.init = function () {
    if (!$.simplebox.overlay) {
      $.simplebox.overlay = jQuery('<div class="' + defaults.overlay.box + '"></div>');
      jQuery("body").append($.simplebox.overlay);
      $.simplebox.overlay.css({
        position: "fixed",
        zIndex: 999,
        left: 0,
        top: 0,
        width: "100%",
        height: "100%",
        background: defaults.overlay.color,
        opacity: defaults.overlay.opacity
      }).hide()
    }
    $(document).unbind("keypress.simplebox").bind("keypress.simplebox", function (e) {
      if ($.simplebox.modal &&
        $.simplebox.modal.is(":visible") && e.keyCode == 27) $.simplebox.close()
    });
    $(window).bind("resize.simplebox", function () {
      if ($.simplebox.modal && $.simplebox.modal.is(":visible")) {
        var data = $.simplebox.modal.data("simplebox");
        if (!data.positionFrom) $.simplebox.modal.animate({left: _calcWinWidth() / 2 - $.simplebox.modal.outerWidth(true) / 2}, {
          queue: false,
          duration: $.simplebox.modal.data("simplebox").duration
        }); else $.simplebox.modal.animate({
          top: $(data.positionFrom).offset().top + $(data.positionFrom).outerHeight(true),
          left: $(data.positionFrom).offset().left
        }, {queue: false, duration: $.simplebox.modal.data("simplebox").duration})
      }
    })
  };
  $.simplebox.close = function () {
    if ($.simplebox.modal && !$.simplebox.busy) {
      var data = $.simplebox.modal.data("simplebox");
      $.simplebox.busy = true;
      data.onClose($.simplebox.modal);
      $.simplebox.modal.fadeOut(data.duration, function () {
        $.simplebox.modal.css({left: "-9999px", top: "-9999px"}).show();
        if ($.simplebox.overlay) $.simplebox.overlay.fadeOut(data.duration, function () {
          data.afterClose($.simplebox.modal);
          $.simplebox.modal.removeData("simplebox");
          $.simplebox.modal = false;
          $.simplebox.busy = false
        }); else {
          data.afterClose($.simplebox.modal);
          $.simplebox.modal.removeData("simplebox");
          $.simplebox.modal = false;
          $.simplebox.busy = false
        }
      })
    }
  };
  $(document).ready(function () {
    $.simplebox.init()
  })
})(jQuery);
